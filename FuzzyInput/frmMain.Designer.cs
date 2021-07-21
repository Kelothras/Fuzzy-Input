
namespace FuzzyInput
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCFuzzy = new System.Windows.Forms.TabControl();
            this.tabPInput = new System.Windows.Forms.TabPage();
            this.btnSaveInput = new System.Windows.Forms.Button();
            this.txtEinheit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBez = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lstInputs = new System.Windows.Forms.ListBox();
            this.btnNewInput = new System.Windows.Forms.Button();
            this.tabPOutput = new System.Windows.Forms.TabPage();
            this.tabPRule = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFuzzyName = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabCFuzzy.SuspendLayout();
            this.tabPInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCFuzzy
            // 
            this.tabCFuzzy.Controls.Add(this.tabPInput);
            this.tabCFuzzy.Controls.Add(this.tabPOutput);
            this.tabCFuzzy.Controls.Add(this.tabPRule);
            this.tabCFuzzy.Controls.Add(this.tabPage4);
            this.tabCFuzzy.Location = new System.Drawing.Point(9, 99);
            this.tabCFuzzy.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCFuzzy.Name = "tabCFuzzy";
            this.tabCFuzzy.SelectedIndex = 0;
            this.tabCFuzzy.Size = new System.Drawing.Size(643, 432);
            this.tabCFuzzy.TabIndex = 0;
            // 
            // tabPInput
            // 
            this.tabPInput.Controls.Add(this.btnSaveInput);
            this.tabPInput.Controls.Add(this.txtEinheit);
            this.tabPInput.Controls.Add(this.label3);
            this.tabPInput.Controls.Add(this.txtBez);
            this.tabPInput.Controls.Add(this.label2);
            this.tabPInput.Controls.Add(this.lstInputs);
            this.tabPInput.Controls.Add(this.btnNewInput);
            this.tabPInput.Location = new System.Drawing.Point(4, 22);
            this.tabPInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPInput.Name = "tabPInput";
            this.tabPInput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPInput.Size = new System.Drawing.Size(635, 406);
            this.tabPInput.TabIndex = 0;
            this.tabPInput.Text = "Eingangsmengen";
            this.tabPInput.UseVisualStyleBackColor = true;
            // 
            // btnSaveInput
            // 
            this.btnSaveInput.Location = new System.Drawing.Point(150, 370);
            this.btnSaveInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSaveInput.Name = "btnSaveInput";
            this.btnSaveInput.Size = new System.Drawing.Size(68, 19);
            this.btnSaveInput.TabIndex = 6;
            this.btnSaveInput.Text = "Speichern";
            this.btnSaveInput.UseVisualStyleBackColor = true;
            this.btnSaveInput.Click += new System.EventHandler(this.btnSaveInput_Click);
            // 
            // txtEinheit
            // 
            this.txtEinheit.Location = new System.Drawing.Point(8, 345);
            this.txtEinheit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEinheit.Name = "txtEinheit";
            this.txtEinheit.Size = new System.Drawing.Size(211, 20);
            this.txtEinheit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 325);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Einheit";
            // 
            // txtBez
            // 
            this.txtBez.Location = new System.Drawing.Point(8, 299);
            this.txtBez.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBez.Name = "txtBez";
            this.txtBez.Size = new System.Drawing.Size(211, 20);
            this.txtBez.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 279);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bezeichnung";
            // 
            // lstInputs
            // 
            this.lstInputs.FormattingEnabled = true;
            this.lstInputs.Location = new System.Drawing.Point(7, 6);
            this.lstInputs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstInputs.Name = "lstInputs";
            this.lstInputs.Size = new System.Drawing.Size(214, 238);
            this.lstInputs.TabIndex = 1;
            // 
            // btnNewInput
            // 
            this.btnNewInput.Location = new System.Drawing.Point(6, 248);
            this.btnNewInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNewInput.Name = "btnNewInput";
            this.btnNewInput.Size = new System.Drawing.Size(74, 19);
            this.btnNewInput.TabIndex = 0;
            this.btnNewInput.Text = "Hinzufügen";
            this.btnNewInput.UseVisualStyleBackColor = true;
            this.btnNewInput.Click += new System.EventHandler(this.btnNewInput_Click);
            // 
            // tabPOutput
            // 
            this.tabPOutput.Location = new System.Drawing.Point(4, 22);
            this.tabPOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPOutput.Name = "tabPOutput";
            this.tabPOutput.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPOutput.Size = new System.Drawing.Size(635, 406);
            this.tabPOutput.TabIndex = 1;
            this.tabPOutput.Text = "Ausgangsmengen";
            this.tabPOutput.UseVisualStyleBackColor = true;
            // 
            // tabPRule
            // 
            this.tabPRule.Location = new System.Drawing.Point(4, 22);
            this.tabPRule.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPRule.Name = "tabPRule";
            this.tabPRule.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPRule.Size = new System.Drawing.Size(635, 406);
            this.tabPRule.TabIndex = 2;
            this.tabPRule.Text = "Regeln";
            this.tabPRule.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage4.Size = new System.Drawing.Size(635, 406);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(480, 17);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Öffnen";
            this.btnOpen.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(401, 17);
            this.btnNew.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Neu";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFuzzyName);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(639, 53);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuzzy-System";
            // 
            // txtFuzzyName
            // 
            this.txtFuzzyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFuzzyName.Location = new System.Drawing.Point(91, 19);
            this.txtFuzzyName.Name = "txtFuzzyName";
            this.txtFuzzyName.ReadOnly = true;
            this.txtFuzzyName.Size = new System.Drawing.Size(274, 20);
            this.txtFuzzyName.TabIndex = 5;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(559, 17);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bezeichnung";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabCFuzzy);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmMain";
            this.Text = "Fuzzy-Mieten";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabCFuzzy.ResumeLayout(false);
            this.tabPInput.ResumeLayout(false);
            this.tabPInput.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCFuzzy;
        private System.Windows.Forms.TabPage tabPInput;
        private System.Windows.Forms.TabPage tabPOutput;
        private System.Windows.Forms.TabPage tabPRule;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFuzzyName;
        private System.Windows.Forms.ListBox lstInputs;
        private System.Windows.Forms.Button btnNewInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSaveInput;
        private System.Windows.Forms.TextBox txtEinheit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBez;
    }
}

