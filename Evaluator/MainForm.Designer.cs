using Eval;

namespace Evaluator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.splitContainerTop = new System.Windows.Forms.SplitContainer();
            this.tabExpr = new System.Windows.Forms.TabControl();
            this.tabExprPage = new System.Windows.Forms.TabPage();
            this.txtExpression = new Evaluator.SciTextBoxControl();
            this.tabSourcePage = new System.Windows.Forms.TabPage();
            this.txtSourceCode = new Evaluator.SciTextBoxControl();
            this.lblExpressionLabel = new System.Windows.Forms.Label();
            this.lblInputsLabel = new System.Windows.Forms.Label();
            this.gridVars = new System.Windows.Forms.DataGridView();
            this.Variable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerBottom = new System.Windows.Forms.SplitContainer();
            this.lstMessages = new System.Windows.Forms.ListBox();
            this.lblMessagesLabel = new System.Windows.Forms.Label();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lblOutputsLabel = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.btnEval = new System.Windows.Forms.Button();
            this.toolStripTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).BeginInit();
            this.splitContainerTop.Panel1.SuspendLayout();
            this.splitContainerTop.Panel2.SuspendLayout();
            this.splitContainerTop.SuspendLayout();
            this.tabExpr.SuspendLayout();
            this.tabExprPage.SuspendLayout();
            this.tabSourcePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVars)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).BeginInit();
            this.splitContainerBottom.Panel1.SuspendLayout();
            this.splitContainerBottom.Panel2.SuspendLayout();
            this.splitContainerBottom.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripTop
            // 
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(1083, 25);
            this.toolStripTop.TabIndex = 0;
            this.toolStripTop.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerMain.Location = new System.Drawing.Point(0, 28);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.splitContainerTop);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerBottom);
            this.splitContainerMain.Size = new System.Drawing.Size(1083, 703);
            this.splitContainerMain.SplitterDistance = 429;
            this.splitContainerMain.TabIndex = 2;
            // 
            // splitContainerTop
            // 
            this.splitContainerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop.Name = "splitContainerTop";
            // 
            // splitContainerTop.Panel1
            // 
            this.splitContainerTop.Panel1.Controls.Add(this.tabExpr);
            this.splitContainerTop.Panel1.Controls.Add(this.lblExpressionLabel);
            // 
            // splitContainerTop.Panel2
            // 
            this.splitContainerTop.Panel2.Controls.Add(this.lblInputsLabel);
            this.splitContainerTop.Panel2.Controls.Add(this.gridVars);
            this.splitContainerTop.Size = new System.Drawing.Size(1083, 429);
            this.splitContainerTop.SplitterDistance = 771;
            this.splitContainerTop.TabIndex = 1;
            // 
            // tabExpr
            // 
            this.tabExpr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabExpr.Controls.Add(this.tabExprPage);
            this.tabExpr.Controls.Add(this.tabSourcePage);
            this.tabExpr.Location = new System.Drawing.Point(0, 20);
            this.tabExpr.Margin = new System.Windows.Forms.Padding(0);
            this.tabExpr.Name = "tabExpr";
            this.tabExpr.SelectedIndex = 0;
            this.tabExpr.Size = new System.Drawing.Size(772, 410);
            this.tabExpr.TabIndex = 5;
            // 
            // tabExprPage
            // 
            this.tabExprPage.Controls.Add(this.txtExpression);
            this.tabExprPage.Location = new System.Drawing.Point(4, 22);
            this.tabExprPage.Margin = new System.Windows.Forms.Padding(0);
            this.tabExprPage.Name = "tabExprPage";
            this.tabExprPage.Size = new System.Drawing.Size(764, 384);
            this.tabExprPage.TabIndex = 0;
            this.tabExprPage.Text = "Expression";
            this.tabExprPage.UseVisualStyleBackColor = true;
            // 
            // txtExpression
            // 
            this.txtExpression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpression.Location = new System.Drawing.Point(0, 0);
            this.txtExpression.Margin = new System.Windows.Forms.Padding(0);
            this.txtExpression.Name = "txtExpression";
            this.txtExpression.Size = new System.Drawing.Size(764, 384);
            this.txtExpression.TabIndex = 0;
            this.txtExpression.TextChanged += new System.EventHandler(this.txtSrcCode_TextChanged);
            // 
            // tabSourcePage
            // 
            this.tabSourcePage.Controls.Add(this.txtSourceCode);
            this.tabSourcePage.Location = new System.Drawing.Point(4, 22);
            this.tabSourcePage.Margin = new System.Windows.Forms.Padding(0);
            this.tabSourcePage.Name = "tabSourcePage";
            this.tabSourcePage.Size = new System.Drawing.Size(764, 384);
            this.tabSourcePage.TabIndex = 1;
            this.tabSourcePage.Text = "Source";
            this.tabSourcePage.UseVisualStyleBackColor = true;
            // 
            // txtSourceCode
            // 
            this.txtSourceCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSourceCode.Location = new System.Drawing.Point(0, 0);
            this.txtSourceCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSourceCode.Name = "txtSourceCode";
            this.txtSourceCode.Size = new System.Drawing.Size(764, 384);
            this.txtSourceCode.TabIndex = 0;
            // 
            // lblExpressionLabel
            // 
            this.lblExpressionLabel.AutoSize = true;
            this.lblExpressionLabel.Location = new System.Drawing.Point(3, 4);
            this.lblExpressionLabel.Name = "lblExpressionLabel";
            this.lblExpressionLabel.Size = new System.Drawing.Size(277, 13);
            this.lblExpressionLabel.TabIndex = 4;
            this.lblExpressionLabel.Text = "Use prefix i. for input variables and o. for output variables.";
            // 
            // lblInputsLabel
            // 
            this.lblInputsLabel.AutoSize = true;
            this.lblInputsLabel.Location = new System.Drawing.Point(3, 24);
            this.lblInputsLabel.Name = "lblInputsLabel";
            this.lblInputsLabel.Size = new System.Drawing.Size(39, 13);
            this.lblInputsLabel.TabIndex = 5;
            this.lblInputsLabel.Text = "Inputs:";
            // 
            // gridVars
            // 
            this.gridVars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridVars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridVars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Variable,
            this.Value});
            this.gridVars.Location = new System.Drawing.Point(0, 41);
            this.gridVars.Name = "gridVars";
            this.gridVars.Size = new System.Drawing.Size(308, 387);
            this.gridVars.TabIndex = 0;
            // 
            // Variable
            // 
            this.Variable.HeaderText = "Variable";
            this.Variable.Name = "Variable";
            this.Variable.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // splitContainerBottom
            // 
            this.splitContainerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerBottom.Location = new System.Drawing.Point(0, 0);
            this.splitContainerBottom.Name = "splitContainerBottom";
            this.splitContainerBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerBottom.Panel1
            // 
            this.splitContainerBottom.Panel1.Controls.Add(this.lstMessages);
            this.splitContainerBottom.Panel1.Controls.Add(this.lblMessagesLabel);
            // 
            // splitContainerBottom.Panel2
            // 
            this.splitContainerBottom.Panel2.Controls.Add(this.txtResults);
            this.splitContainerBottom.Panel2.Controls.Add(this.lblOutputsLabel);
            this.splitContainerBottom.Size = new System.Drawing.Size(1083, 270);
            this.splitContainerBottom.SplitterDistance = 120;
            this.splitContainerBottom.TabIndex = 1;
            // 
            // lstMessages
            // 
            this.lstMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMessages.FormattingEnabled = true;
            this.lstMessages.Location = new System.Drawing.Point(0, 21);
            this.lstMessages.Name = "lstMessages";
            this.lstMessages.Size = new System.Drawing.Size(1083, 95);
            this.lstMessages.TabIndex = 2;
            this.lstMessages.SelectedIndexChanged += new System.EventHandler(this.lstMessages_SelectedIndexChanged);
            // 
            // lblMessagesLabel
            // 
            this.lblMessagesLabel.AutoSize = true;
            this.lblMessagesLabel.Location = new System.Drawing.Point(3, 4);
            this.lblMessagesLabel.Name = "lblMessagesLabel";
            this.lblMessagesLabel.Size = new System.Drawing.Size(58, 13);
            this.lblMessagesLabel.TabIndex = 1;
            this.lblMessagesLabel.Text = "Messages:";
            // 
            // txtResults
            // 
            this.txtResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResults.Location = new System.Drawing.Point(0, 18);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(1083, 128);
            this.txtResults.TabIndex = 0;
            // 
            // lblOutputsLabel
            // 
            this.lblOutputsLabel.AutoSize = true;
            this.lblOutputsLabel.Location = new System.Drawing.Point(3, 2);
            this.lblOutputsLabel.Name = "lblOutputsLabel";
            this.lblOutputsLabel.Size = new System.Drawing.Size(47, 13);
            this.lblOutputsLabel.TabIndex = 1;
            this.lblOutputsLabel.Text = "Outputs:";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 734);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1083, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // btnEval
            // 
            this.btnEval.Location = new System.Drawing.Point(7, 2);
            this.btnEval.Name = "btnEval";
            this.btnEval.Size = new System.Drawing.Size(102, 23);
            this.btnEval.TabIndex = 4;
            this.btnEval.Text = "Eval";
            this.btnEval.UseVisualStyleBackColor = true;
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnEval;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 756);
            this.Controls.Add(this.btnEval);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.toolStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Evaluator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.splitContainerTop.Panel1.ResumeLayout(false);
            this.splitContainerTop.Panel1.PerformLayout();
            this.splitContainerTop.Panel2.ResumeLayout(false);
            this.splitContainerTop.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop)).EndInit();
            this.splitContainerTop.ResumeLayout(false);
            this.tabExpr.ResumeLayout(false);
            this.tabExprPage.ResumeLayout(false);
            this.tabSourcePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVars)).EndInit();
            this.splitContainerBottom.Panel1.ResumeLayout(false);
            this.splitContainerBottom.Panel1.PerformLayout();
            this.splitContainerBottom.Panel2.ResumeLayout(false);
            this.splitContainerBottom.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerBottom)).EndInit();
            this.splitContainerBottom.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripTop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.SplitContainer splitContainerTop;
        private SciTextBoxControl txtExpression;
        private System.Windows.Forms.Label lblExpressionLabel;
        private System.Windows.Forms.Label lblInputsLabel;
        private System.Windows.Forms.DataGridView gridVars;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.SplitContainer splitContainerBottom;
        private System.Windows.Forms.Label lblOutputsLabel;
        private System.Windows.Forms.Label lblMessagesLabel;
        private System.Windows.Forms.TabControl tabExpr;
        private System.Windows.Forms.TabPage tabExprPage;
        private System.Windows.Forms.TabPage tabSourcePage;
        private SciTextBoxControl txtSourceCode;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.ListBox lstMessages;
    }
}

