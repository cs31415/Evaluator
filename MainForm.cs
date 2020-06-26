using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
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
        public string MethodCode => txtSrcCode.Text;

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

            txtSrcCode.SetupStyle(new CSharpStyle());

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
            txtMessages.Text = string.Empty;
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
        #endregion

        #region Private methods
        private void OnLoadSettings(EvalSettings settings)
        {
            txtSrcCode.Text = settings.Expression;
            foreach (string variable in settings.Variables.Keys)
            {
                var val = settings.Variables[variable];
                gridVars.Rows.Add(variable, val);
            }
        }

        private EvalSettings OnSaveSettings()
        {
            var settings = new EvalSettings();
            settings.Expression = txtSrcCode.Text;
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
                var hash = Hasher.GetHashString(txtSrcCode.Text);

                // If we have a compiled instance for this expression, use it
                if (!_compiledInstances.ContainsKey(hash))
                {
                    // If not, compile expression
                    var result = CompileHelper.Compile(txtSrcCode.Text);

                    var sbErrors = new StringBuilder();
                    if (result.Errors.Count > 0)
                    {
                        sbErrors.AppendLine("*** Compilation Errors: ***");
                        foreach (CompilerError error in result.Errors)
                        {
                            sbErrors.AppendLine(
                                $"[{error.Line},{error.Column}] {error.ErrorNumber}: {error.ErrorText}");
                        }

                        txtMessages.Text = sbErrors.ToString();
                        return;
                    }

                    var assembly = result.CompiledAssembly;

                    _compiledInstances.Clear();
                    _compiledInstances.Add(hash, assembly.CreateInstance("Evaluator.Evaluator"));
                }

                dynamic inst = _compiledInstances[hash];

                txtMessages.Text = "Compile succeeded";

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
                    sbOutputs.AppendLine($"{key} = {outputs[key]}");
                }

                txtResults.Text = sbOutputs.ToString();
            }, null);
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
