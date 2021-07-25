
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
            this.btnEingangFertig = new System.Windows.Forms.Button();
            this.splitContainerInput = new System.Windows.Forms.SplitContainer();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEingangMax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEingangMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstEingang = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBezEingang = new System.Windows.Forms.TextBox();
            this.btnSpeichernEingangTeilmenge = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBezEingangTeilmenge = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lstIEingangTeilmengen = new System.Windows.Forms.ListBox();
            this.tabPOutput = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPRule = new System.Windows.Forms.TabPage();
            this.tabShowOutput = new System.Windows.Forms.TabPage();
            this.chartAusgabe = new Accord.Controls.Chart();
            this.btnOffnenDatei = new System.Windows.Forms.Button();
            this.btnNeuesSystem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtFuzzyName = new System.Windows.Forms.TextBox();
            this.btnSpeichernDatei = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpeichernEingang = new System.Windows.Forms.Button();
            this.btnNeuEingang = new System.Windows.Forms.Button();
            this.btnLoeEingangTeilmenge = new System.Windows.Forms.Button();
            this.btnNeueEingangTeilmenge = new System.Windows.Forms.Button();
            this.tabCFuzzy.SuspendLayout();
            this.tabPInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInput)).BeginInit();
            this.splitContainerInput.Panel1.SuspendLayout();
            this.splitContainerInput.Panel2.SuspendLayout();
            this.splitContainerInput.SuspendLayout();
            this.tabPOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabShowOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCFuzzy
            // 
            this.tabCFuzzy.Controls.Add(this.tabPInput);
            this.tabCFuzzy.Controls.Add(this.tabPOutput);
            this.tabCFuzzy.Controls.Add(this.tabPRule);
            this.tabCFuzzy.Controls.Add(this.tabShowOutput);
            this.tabCFuzzy.Location = new System.Drawing.Point(9, 99);
            this.tabCFuzzy.Margin = new System.Windows.Forms.Padding(2);
            this.tabCFuzzy.Name = "tabCFuzzy";
            this.tabCFuzzy.SelectedIndex = 0;
            this.tabCFuzzy.Size = new System.Drawing.Size(679, 467);
            this.tabCFuzzy.TabIndex = 0;
            // 
            // tabPInput
            // 
            this.tabPInput.BackColor = System.Drawing.SystemColors.Control;
            this.tabPInput.Controls.Add(this.btnEingangFertig);
            this.tabPInput.Controls.Add(this.splitContainerInput);
            this.tabPInput.Location = new System.Drawing.Point(4, 22);
            this.tabPInput.Margin = new System.Windows.Forms.Padding(2);
            this.tabPInput.Name = "tabPInput";
            this.tabPInput.Padding = new System.Windows.Forms.Padding(2);
            this.tabPInput.Size = new System.Drawing.Size(671, 441);
            this.tabPInput.TabIndex = 0;
            this.tabPInput.Text = "Eingangsmengen";
            // 
            // btnEingangFertig
            // 
            this.btnEingangFertig.Location = new System.Drawing.Point(491, 413);
            this.btnEingangFertig.Name = "btnEingangFertig";
            this.btnEingangFertig.Size = new System.Drawing.Size(175, 23);
            this.btnEingangFertig.TabIndex = 8;
            this.btnEingangFertig.Text = "Eingang vollständig";
            this.btnEingangFertig.UseVisualStyleBackColor = true;
            this.btnEingangFertig.Click += new System.EventHandler(this.btnEingangFertig_Click);
            // 
            // splitContainerInput
            // 
            this.splitContainerInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerInput.Location = new System.Drawing.Point(5, 3);
            this.splitContainerInput.Name = "splitContainerInput";
            // 
            // splitContainerInput.Panel1
            // 
            this.splitContainerInput.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerInput.Panel1.Controls.Add(this.label10);
            this.splitContainerInput.Panel1.Controls.Add(this.txtEingangMax);
            this.splitContainerInput.Panel1.Controls.Add(this.label3);
            this.splitContainerInput.Panel1.Controls.Add(this.txtEingangMin);
            this.splitContainerInput.Panel1.Controls.Add(this.label6);
            this.splitContainerInput.Panel1.Controls.Add(this.btnSpeichernEingang);
            this.splitContainerInput.Panel1.Controls.Add(this.lstEingang);
            this.splitContainerInput.Panel1.Controls.Add(this.btnNeuEingang);
            this.splitContainerInput.Panel1.Controls.Add(this.label2);
            this.splitContainerInput.Panel1.Controls.Add(this.txtBezEingang);
            this.splitContainerInput.Panel1MinSize = 30;
            // 
            // splitContainerInput.Panel2
            // 
            this.splitContainerInput.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerInput.Panel2.Controls.Add(this.btnLoeEingangTeilmenge);
            this.splitContainerInput.Panel2.Controls.Add(this.btnSpeichernEingangTeilmenge);
            this.splitContainerInput.Panel2.Controls.Add(this.label5);
            this.splitContainerInput.Panel2.Controls.Add(this.txtBezEingangTeilmenge);
            this.splitContainerInput.Panel2.Controls.Add(this.btnNeueEingangTeilmenge);
            this.splitContainerInput.Panel2.Controls.Add(this.label4);
            this.splitContainerInput.Panel2.Controls.Add(this.lstIEingangTeilmengen);
            this.splitContainerInput.Size = new System.Drawing.Size(661, 389);
            this.splitContainerInput.SplitterDistance = 310;
            this.splitContainerInput.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 328);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Maximum";
            // 
            // txtEingangMax
            // 
            this.txtEingangMax.Location = new System.Drawing.Point(9, 342);
            this.txtEingangMax.Margin = new System.Windows.Forms.Padding(2);
            this.txtEingangMax.Name = "txtEingangMax";
            this.txtEingangMax.Size = new System.Drawing.Size(89, 20);
            this.txtEingangMax.TabIndex = 13;
            this.txtEingangMax.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 292);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Minimum";
            // 
            // txtEingangMin
            // 
            this.txtEingangMin.Location = new System.Drawing.Point(9, 306);
            this.txtEingangMin.Margin = new System.Windows.Forms.Padding(2);
            this.txtEingangMin.Name = "txtEingangMin";
            this.txtEingangMin.Size = new System.Drawing.Size(89, 20);
            this.txtEingangMin.TabIndex = 11;
            this.txtEingangMin.Text = "0";
            this.txtEingangMin.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Eingangsmengen";
            // 
            // lstEingang
            // 
            this.lstEingang.FormattingEnabled = true;
            this.lstEingang.Location = new System.Drawing.Point(10, 28);
            this.lstEingang.Margin = new System.Windows.Forms.Padding(2);
            this.lstEingang.Name = "lstEingang";
            this.lstEingang.Size = new System.Drawing.Size(199, 212);
            this.lstEingang.TabIndex = 1;
            this.lstEingang.SelectedIndexChanged += new System.EventHandler(this.lstEingang_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 250);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bezeichnung";
            // 
            // txtBezEingang
            // 
            this.txtBezEingang.Location = new System.Drawing.Point(10, 265);
            this.txtBezEingang.Margin = new System.Windows.Forms.Padding(2);
            this.txtBezEingang.Name = "txtBezEingang";
            this.txtBezEingang.Size = new System.Drawing.Size(199, 20);
            this.txtBezEingang.TabIndex = 3;
            // 
            // btnSpeichernEingangTeilmenge
            // 
            this.btnSpeichernEingangTeilmenge.AutoSize = true;
            this.btnSpeichernEingangTeilmenge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSpeichernEingangTeilmenge.Image = global::FuzzyInput.Properties.Resources.icons8_save_20;
            this.btnSpeichernEingangTeilmenge.Location = new System.Drawing.Point(171, 265);
            this.btnSpeichernEingangTeilmenge.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeichernEingangTeilmenge.Name = "btnSpeichernEingangTeilmenge";
            this.btnSpeichernEingangTeilmenge.Size = new System.Drawing.Size(85, 26);
            this.btnSpeichernEingangTeilmenge.TabIndex = 10;
            this.btnSpeichernEingangTeilmenge.Text = "Speichern";
            this.btnSpeichernEingangTeilmenge.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSpeichernEingangTeilmenge.UseVisualStyleBackColor = true;
            this.btnSpeichernEingangTeilmenge.Click += new System.EventHandler(this.btnSpeichernEingangTeilmenge_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 250);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bezeichnung";
            // 
            // txtBezEingangTeilmenge
            // 
            this.txtBezEingangTeilmenge.Location = new System.Drawing.Point(11, 265);
            this.txtBezEingangTeilmenge.Margin = new System.Windows.Forms.Padding(2);
            this.txtBezEingangTeilmenge.Name = "txtBezEingangTeilmenge";
            this.txtBezEingangTeilmenge.Size = new System.Drawing.Size(153, 20);
            this.txtBezEingangTeilmenge.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Teilmengen";
            // 
            // lstIEingangTeilmengen
            // 
            this.lstIEingangTeilmengen.FormattingEnabled = true;
            this.lstIEingangTeilmengen.Location = new System.Drawing.Point(11, 28);
            this.lstIEingangTeilmengen.Margin = new System.Windows.Forms.Padding(2);
            this.lstIEingangTeilmengen.Name = "lstIEingangTeilmengen";
            this.lstIEingangTeilmengen.Size = new System.Drawing.Size(153, 212);
            this.lstIEingangTeilmengen.TabIndex = 2;
            // 
            // tabPOutput
            // 
            this.tabPOutput.Controls.Add(this.splitContainer1);
            this.tabPOutput.Location = new System.Drawing.Point(4, 22);
            this.tabPOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tabPOutput.Name = "tabPOutput";
            this.tabPOutput.Padding = new System.Windows.Forms.Padding(2);
            this.tabPOutput.Size = new System.Drawing.Size(671, 441);
            this.tabPOutput.TabIndex = 1;
            this.tabPOutput.Text = "Ausgangsmengen";
            this.tabPOutput.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.textBox2);
            this.splitContainer1.Size = new System.Drawing.Size(667, 437);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Eingangsmengen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 328);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 19);
            this.button1.TabIndex = 17;
            this.button1.Text = "Speichern";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(11, 27);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 212);
            this.listBox1.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(214, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 19);
            this.button2.TabIndex = 11;
            this.button2.Text = "Hinzufügen";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(11, 304);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 243);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Bezeichnung";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 289);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Einheit";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(11, 258);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 20);
            this.textBox2.TabIndex = 14;
            // 
            // tabPRule
            // 
            this.tabPRule.Location = new System.Drawing.Point(4, 22);
            this.tabPRule.Margin = new System.Windows.Forms.Padding(2);
            this.tabPRule.Name = "tabPRule";
            this.tabPRule.Padding = new System.Windows.Forms.Padding(2);
            this.tabPRule.Size = new System.Drawing.Size(671, 441);
            this.tabPRule.TabIndex = 2;
            this.tabPRule.Text = "Regeln";
            this.tabPRule.UseVisualStyleBackColor = true;
            // 
            // tabShowOutput
            // 
            this.tabShowOutput.Controls.Add(this.chartAusgabe);
            this.tabShowOutput.Location = new System.Drawing.Point(4, 22);
            this.tabShowOutput.Margin = new System.Windows.Forms.Padding(2);
            this.tabShowOutput.Name = "tabShowOutput";
            this.tabShowOutput.Padding = new System.Windows.Forms.Padding(2);
            this.tabShowOutput.Size = new System.Drawing.Size(671, 441);
            this.tabShowOutput.TabIndex = 3;
            this.tabShowOutput.Text = "Ausgabe";
            this.tabShowOutput.UseVisualStyleBackColor = true;
            // 
            // chartAusgabe
            // 
            this.chartAusgabe.Location = new System.Drawing.Point(15, 237);
            this.chartAusgabe.Name = "chartAusgabe";
            this.chartAusgabe.Size = new System.Drawing.Size(639, 199);
            this.chartAusgabe.TabIndex = 0;
            this.chartAusgabe.Text = "Accord Chart";
            // 
            // btnOffnenDatei
            // 
            this.btnOffnenDatei.Location = new System.Drawing.Point(480, 17);
            this.btnOffnenDatei.Margin = new System.Windows.Forms.Padding(2);
            this.btnOffnenDatei.Name = "btnOffnenDatei";
            this.btnOffnenDatei.Size = new System.Drawing.Size(75, 23);
            this.btnOffnenDatei.TabIndex = 1;
            this.btnOffnenDatei.Text = "Öffnen";
            this.btnOffnenDatei.UseVisualStyleBackColor = true;
            // 
            // btnNeuesSystem
            // 
            this.btnNeuesSystem.Location = new System.Drawing.Point(401, 17);
            this.btnNeuesSystem.Margin = new System.Windows.Forms.Padding(2);
            this.btnNeuesSystem.Name = "btnNeuesSystem";
            this.btnNeuesSystem.Size = new System.Drawing.Size(75, 23);
            this.btnNeuesSystem.TabIndex = 2;
            this.btnNeuesSystem.Text = "Neu";
            this.btnNeuesSystem.UseVisualStyleBackColor = true;
            this.btnNeuesSystem.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFuzzyName);
            this.groupBox1.Controls.Add(this.btnSpeichernDatei);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnOffnenDatei);
            this.groupBox1.Controls.Add(this.btnNeuesSystem);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
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
            // btnSpeichernDatei
            // 
            this.btnSpeichernDatei.Location = new System.Drawing.Point(559, 17);
            this.btnSpeichernDatei.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeichernDatei.Name = "btnSpeichernDatei";
            this.btnSpeichernDatei.Size = new System.Drawing.Size(75, 23);
            this.btnSpeichernDatei.TabIndex = 4;
            this.btnSpeichernDatei.Text = "Speichern";
            this.btnSpeichernDatei.UseVisualStyleBackColor = true;
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
            // btnSpeichernEingang
            // 
            this.btnSpeichernEingang.AutoSize = true;
            this.btnSpeichernEingang.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSpeichernEingang.Image = global::FuzzyInput.Properties.Resources.icons8_save_20;
            this.btnSpeichernEingang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSpeichernEingang.Location = new System.Drawing.Point(124, 336);
            this.btnSpeichernEingang.Margin = new System.Windows.Forms.Padding(2);
            this.btnSpeichernEingang.Name = "btnSpeichernEingang";
            this.btnSpeichernEingang.Size = new System.Drawing.Size(85, 26);
            this.btnSpeichernEingang.TabIndex = 6;
            this.btnSpeichernEingang.Text = "Speichern";
            this.btnSpeichernEingang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSpeichernEingang.UseVisualStyleBackColor = true;
            this.btnSpeichernEingang.Click += new System.EventHandler(this.btnSaveInput_Click);
            // 
            // btnNeuEingang
            // 
            this.btnNeuEingang.AutoSize = true;
            this.btnNeuEingang.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNeuEingang.Image = global::FuzzyInput.Properties.Resources.icons8_add_20;
            this.btnNeuEingang.Location = new System.Drawing.Point(213, 28);
            this.btnNeuEingang.Margin = new System.Windows.Forms.Padding(2);
            this.btnNeuEingang.Name = "btnNeuEingang";
            this.btnNeuEingang.Size = new System.Drawing.Size(26, 26);
            this.btnNeuEingang.TabIndex = 0;
            this.btnNeuEingang.UseVisualStyleBackColor = true;
            this.btnNeuEingang.Click += new System.EventHandler(this.btnNewInput_Click);
            // 
            // btnLoeEingangTeilmenge
            // 
            this.btnLoeEingangTeilmenge.AutoSize = true;
            this.btnLoeEingangTeilmenge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLoeEingangTeilmenge.Image = global::FuzzyInput.Properties.Resources.icons8_cancel_20;
            this.btnLoeEingangTeilmenge.Location = new System.Drawing.Point(171, 58);
            this.btnLoeEingangTeilmenge.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoeEingangTeilmenge.Name = "btnLoeEingangTeilmenge";
            this.btnLoeEingangTeilmenge.Size = new System.Drawing.Size(26, 26);
            this.btnLoeEingangTeilmenge.TabIndex = 11;
            this.btnLoeEingangTeilmenge.UseVisualStyleBackColor = true;
            // 
            // btnNeueEingangTeilmenge
            // 
            this.btnNeueEingangTeilmenge.AutoSize = true;
            this.btnNeueEingangTeilmenge.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNeueEingangTeilmenge.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNeueEingangTeilmenge.Image = global::FuzzyInput.Properties.Resources.icons8_add_20;
            this.btnNeueEingangTeilmenge.Location = new System.Drawing.Point(171, 28);
            this.btnNeueEingangTeilmenge.Margin = new System.Windows.Forms.Padding(2);
            this.btnNeueEingangTeilmenge.Name = "btnNeueEingangTeilmenge";
            this.btnNeueEingangTeilmenge.Size = new System.Drawing.Size(26, 26);
            this.btnNeueEingangTeilmenge.TabIndex = 7;
            this.btnNeueEingangTeilmenge.UseVisualStyleBackColor = true;
            this.btnNeueEingangTeilmenge.Click += new System.EventHandler(this.btnNewTeilmenge_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 577);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabCFuzzy);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "Fuzzy-Mieten";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabCFuzzy.ResumeLayout(false);
            this.tabPInput.ResumeLayout(false);
            this.splitContainerInput.Panel1.ResumeLayout(false);
            this.splitContainerInput.Panel1.PerformLayout();
            this.splitContainerInput.Panel2.ResumeLayout(false);
            this.splitContainerInput.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerInput)).EndInit();
            this.splitContainerInput.ResumeLayout(false);
            this.tabPOutput.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabShowOutput.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCFuzzy;
        private System.Windows.Forms.TabPage tabPInput;
        private System.Windows.Forms.TabPage tabPOutput;
        private System.Windows.Forms.TabPage tabPRule;
        private System.Windows.Forms.TabPage tabShowOutput;
        private System.Windows.Forms.Button btnOffnenDatei;
        private System.Windows.Forms.Button btnNeuesSystem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSpeichernDatei;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFuzzyName;
        private System.Windows.Forms.ListBox lstEingang;
        private System.Windows.Forms.Button btnNeuEingang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSpeichernEingang;
        private System.Windows.Forms.TextBox txtBezEingang;
        private System.Windows.Forms.SplitContainer splitContainerInput;
        private System.Windows.Forms.Button btnNeueEingangTeilmenge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBezEingangTeilmenge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSpeichernEingangTeilmenge;
        private System.Windows.Forms.Button btnLoeEingangTeilmenge;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnEingangFertig;
        public System.Windows.Forms.ListBox lstIEingangTeilmengen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEingangMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEingangMin;
        private Accord.Controls.Chart chartAusgabe;
    }
}

