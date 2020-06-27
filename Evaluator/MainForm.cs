using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Evaluator
{
    /// <summary>
    /// Main application window
    /// </summary>
    public partial class MainForm : Form
    {
        delegate void DelegateMethod(params object[] args);

        private bool _loading;
        private SettingsManager<EvalSettings> _settingsManager;
        private Dictionary<string, dynamic> _compiledInstances;

        #region Properties
        public string MethodCode => txtExpression.Text;

        public HashSet<string> Vars
        {
            get
            {
                var matches = Regex.Matches(MethodCode, $@"{CompileHelper.InputVariableIdentifier}\.(?<var>\w+)");
                var vars = new HashSet<string>();
                foreach (Match match in matches)
                {
                    var group = match.Groups["var"];
                    if (group != null && group.Success)
                    {
                        vars.Add(group.Value);
                    }
                }
                return vars;
            }
        }

        public Dictionary<string, object> Inputs {
            get
            {
                var vals = new Dictionary<string,object>();
                foreach (DataGridViewRow row in gridVars.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        var variable = row.Cells[0].Value.ToString();
                        if (!vals.ContainsKey(variable))
                        {
                            vals.Add(variable, row.Cells[1].EditedFormattedValue);
                        }
                    }
                }

                return vals;
            }
        }

        #endregion

        public MainForm()
        {
            _loading = true;
            InitializeComponent();
            _settingsManager = new SettingsManager<EvalSettings>(OnLoadSettings, OnSaveSettings);
            _compiledInstances = new Dictionary<string, dynamic>();

            txtExpression.TextBox.SetupStyle(new CSharpStyle());
            txtSourceCode.TextBox.SetupStyle(new CSharpStyle());

            bgWorker.DoWork += BgWorkerOnDoWork;   
            bgWorker.RunWorkerCompleted += BgWorkerOnRunWorkerCompleted;
        }
        
        #region Event handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            _settingsManager.LoadSettings();
            _loading = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _settingsManager.SaveSettings();
        }

        private void btnEval_Click(object sender, EventArgs e)
        {
            btnEval.Enabled = false;
            lstMessages.Items.Clear();
            txtSourceCode.TextBox.ReadOnly = false;
            lstMessages.ForeColor = Control.DefaultForeColor;
            txtResults.Text = string.Empty;
            lblStatus.Text = "Working...";
            bgWorker.RunWorkerAsync();
        }

        private void txtSrcCode_TextChanged(object sender, EventArgs e)
        {
            if (!_loading)
            {
                ParseVariables();
            }
        }

        private void lstMessages_SelectedIndexChanged(object sender, EventArgs e)
        {
            // parse out the line and column
            var compileError = lstMessages.SelectedItem as CompilerErrorEx;
            if (compileError != null)
            {
                var lineNum = compileError.Error.Line;
                var col = compileError.Error.Column;
                var line = txtSourceCode.TextBox.Lines[lineNum-1];

                // clear highlighted lines if any
                txtSourceCode.TextBox.UnHighlightSelection(0, txtSourceCode.Text.Length, HighlightLayer.LineLayer);
                
                // highlight error line
                txtSourceCode.TextBox.HighlightSelection(line.Position, line.Position + line.Length, Color.Yellow,
                    HighlightLayer.LineLayer);

                // clear highlighted chars if any
                txtSourceCode.TextBox.UnHighlightSelection(0, txtSourceCode.Text.Length, HighlightLayer.HighlightWordLayer);

                // highlight error char
                txtSourceCode.TextBox.HighlightSelection(line.Position + col - 1, line.Position + col, Color.Orange,
                    HighlightLayer.HighlightWordLayer);

                // Bring the source tab to the front
                tabExpr.SelectTab(tabSourcePage);
                txtSourceCode.TextBox.Select();

                // Set the cursor to the error line and column
                txtSourceCode.TextBox.GotoPosition(line.Position + col - 1);
            }
        }
        #endregion

        #region Private methods
        private void OnLoadSettings(EvalSettings settings)
        {
            txtExpression.Text = settings.Expression;
            foreach (string variable in settings.Variables.Keys)
            {
                var val = settings.Variables[variable];
                gridVars.Rows.Add(variable, val);
            }
        }

        private EvalSettings OnSaveSettings()
        {
            var settings = new EvalSettings();
            settings.Expression = txtExpression.Text;
            var vals = new Dictionary<string, string>();
            foreach (DataGridViewRow row in gridVars.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    var variable = row.Cells[0].Value.ToString();
                    var val = row.Cells[1].EditedFormattedValue?.ToString();
                    if (!vals.ContainsKey(variable))
                    {
                        vals.Add(variable, val);
                    }
                }
            }
            settings.Variables = vals;

            return settings;
        }

        private void ParseVariables()
        {
            var vals = Inputs;

            gridVars.Rows.Clear();
            foreach (string variable in Vars)
            {
                gridVars.Rows.Add(variable, vals.ContainsKey(variable) ? vals[variable] : null);
            }
        }

        private void BgWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            InvokeIfRequired(x =>
            {
                lblStatus.Text = "Ready";
                btnEval.Enabled = true;
            }, null);
        }

        private void BgWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            InvokeIfRequired(x =>
            {
                Thread.Sleep(500);
                var hash = Hasher.GetHashString(txtExpression.Text);

                // If we have a compiled instance for this expression, use it
                if (!_compiledInstances.ContainsKey(hash))
                {
                    // If not, compile expression
                    var sourceCode = CompileHelper.GetExpressionSourceCode(txtExpression.Text);
                    txtSourceCode.Text = sourceCode;
                    txtSourceCode.TextBox.ReadOnly = true;
                    tabSourcePage.Visible = true;

                    var result = CompileHelper.Compile(sourceCode);

                    if (result.Errors.Count > 0)
                    {
                        lstMessages.ForeColor = Color.Red;
                        foreach (CompilerError error in result.Errors)
                        {
                            lstMessages.Items.Add(new CompilerErrorEx(error));
                        }

                        return;
                    }

                    var assembly = result.CompiledAssembly;

                    _compiledInstances.Clear();
                    _compiledInstances.Add(hash, assembly.CreateInstance("Evaluator.Evaluator"));
                }

                dynamic inst = _compiledInstances[hash];

                lstMessages.Items.Add("Compile succeeded");

                // Cast input variables to appropriate type
                var vals = new Dictionary<string, dynamic>();
                foreach (DataGridViewRow row in gridVars.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        var val = row.Cells[1].EditedFormattedValue;
                        dynamic typedVal;
                        if (int.TryParse(val.ToString(), out int intVal))
                        {
                            typedVal = intVal;
                        }
                        else if (double.TryParse(val.ToString(), out double dblVal))
                        {
                            typedVal = dblVal;
                        }
                        else if (bool.TryParse(val.ToString(), out bool bVal))
                        {
                            typedVal = bVal;
                        }
                        else
                        {
                            typedVal = val.ToString();
                        }
                        vals.Add(row.Cells[0].Value.ToString(), typedVal);
                    }
                }

                // Evaluate compiled expression using supplied input variables
                var outputs = new Dictionary<string, object>();
                inst.Eval(vals, outputs);

                // Print output variables
                var sbOutputs = new StringBuilder();
                foreach (var key in outputs.Keys)
                {
                    if (!(outputs[key] is string) && IsEnumerable(outputs[key]))
                    {
                        if (outputs[key] is IEnumerable enumerable)
                        {
                            int i = 0;
                            foreach (var element in enumerable)
                            {
                                sbOutputs.AppendLine($"{key}[{i++}] = {element}");
                            }
                        }
                    }
                    else
                    {
                        sbOutputs.AppendLine($"{key} = {outputs[key]}");
                    }
                }

                txtResults.Text = sbOutputs.ToString();
            }, null);
        }

        private bool IsEnumerable(object obj)
        {
            return (obj as IEnumerable != null);
        }

        private void InvokeIfRequired(DelegateMethod method, params object[] args)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(method, new object[] { args });
            }
            else
            {
                method(args);
            }
        }

        #endregion
    }
}
