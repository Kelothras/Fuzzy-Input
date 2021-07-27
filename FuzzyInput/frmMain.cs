using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Accord;
using Accord.Fuzzy;
using Rule = Accord.Fuzzy.Rule;

namespace FuzzyInput
{
    public partial class frmMain : Form
    {
        public Database fuzzyDB;
        public LinguisticVariable lvEingang;
        public LinguisticVariable lvAusgang;
        public Rulebase rulebase;
        public Menge Eingangsmenge;
        public Menge Ausgangmenge;
        public List<Menge> Eingangsmengen;
        public List<Menge> Ausgangsmengen;

        public frmMain()
        {
            InitializeComponent();
        }

        // Eingangsvariable speichern
        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            string strInputBez = txtBezEingang.Text;
            float fInputMin = float.Parse(txtEingangMin.Text);
            float fInputMax = float.Parse(txtEingangMax.Text);

            // Prüfen ob Eingangsvariable bereits vorhanden ist
            if (lstEingang.Items.Contains(strInputBez) == true)
            {
                MessageBox.Show("Eingangsgröße bereits vorhanden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();

            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
            
            deaktiviereEingangsControls();
            aktiviereEingangsTeilmengenControls();

            txtBezEingang.Text = "";
            txtEingangMin.Text = "0";
            txtEingangMax.Text = "100";

            txtBezEingang.BackColor = Color.White;
            txtEingangMax.BackColor = Color.White;
            txtEingangMin.BackColor = Color.White;
        }


        private void deaktiviereEingangsControls()
        {   
            // Eingangsmengen
            txtBezEingang.Enabled = false;
            txtEingangMin.Enabled = false;
            txtEingangMax.Enabled = false;
            btnSpeichernEingang.Enabled = false;

            // EingangsTeilmengen
            txtBezEingangTeilmenge.Enabled = false;
            txtEingangTeilStart.Enabled = false;
            txtEingangTeilMin.Enabled = false;
            txtEingangTeilMax.Enabled = false;
            btnNeueEingangTeilmenge.Enabled = false;
            btnSpeichernEingangTeilmenge.Enabled = false;
            btnLoeEingangTeilmenge.Enabled = false;
        }
        private void aktiviereAusgangsControls()
        {
            txtBezAusgang.Enabled = true;
            txtAusgangMin.Enabled = true;
            txtAusgangMax.Enabled = true;
            btnSpeichernAusgang.Enabled = true;
            btnNeuAusgang.Enabled = false;
        }
        private void aktiviereEingangsControls()
        {
            txtBezEingang.Enabled = true;
            txtEingangMin.Enabled = true;
            txtEingangMax.Enabled = true;
            btnSpeichernEingang.Enabled = true;
            btnNeuEingang.Enabled = false;
        }

        private void aktiviereEingangsTeilmengenControls()
        {
            btnSpeichernEingangTeilmenge.Enabled = true;
            btnNeueEingangTeilmenge.Enabled = true;
            btnLoeEingangTeilmenge.Enabled = true;
        }

        private void deaktiviereEingangsTeilmengenControls()
        {
            txtBezEingangTeilmenge.Enabled = false;
            btnSpeichernEingangTeilmenge.Enabled = false;
        }

        // Neue Eingangsvariable
        private void btnNewInput_Click(object sender, EventArgs e)
        {
            // Felder aktivieren und Farbe ändern
            aktiviereEingangsControls();
            txtBezEingang.BackColor = Color.LightYellow;
            txtEingangMax.BackColor = Color.LightYellow;
            txtEingangMin.BackColor = Color.LightYellow;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Programmstart
            //tabCFuzzy.Enabled = false;
            //deaktiviereEingangsControls();

        }

        // Neues Fuzzy-System
        private void btnNew_Click(object sender, EventArgs e)
        {
            // Input-Dialog
            string strResponse = Interaction.InputBox("Name des Systems", "Neues Fuzzy-System anlegen");
            if (strResponse != "")
            {
                txtFuzzyName.Text = strResponse;
                tabCFuzzy.Enabled = true;
            }

            
        }

        // Neue Teilmenge anlegen
        private void btnNewTeilmenge_Click(object sender, EventArgs e)
        {
            // Felder aktivieren und Farbe ändern
            txtBezEingangTeilmenge.Enabled = true; txtBezEingangTeilmenge.BackColor = Color.LightYellow;
            txtEingangTeilStart.Enabled = true; txtEingangTeilStart.BackColor = Color.LightYellow;
            txtEingangTeilMin.Enabled = true; txtEingangTeilMin.BackColor = Color.LightYellow;
            txtEingangTeilMax.Enabled = true; txtEingangTeilMax.BackColor = Color.LightYellow;
            btnSpeichernEingangTeilmenge.Enabled = true;
        }

        private void lstEingang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnSpeichernEingangTeilmenge_Click(object sender, EventArgs e)
        {
            string strEingangTeilmenge = txtBezEingangTeilmenge.Text;
            float fEingangTeilStart = float.Parse(txtEingangTeilStart.Text);
            float fEingangTeilMax = float.Parse(txtEingangTeilMax.Text);
            float fEingangTeilMin = float.Parse(txtEingangTeilMin.Text);

            lstIEingangTeilmengen.Items.Add(strEingangTeilmenge);
            lstIEingangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            TrapezoidalFunction trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            FuzzySet fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);
            
            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            /*
            double[,] coolValues = new double[20, 2];
            for (int i = 0; i < 30; i++)
            {
                coolValues[i - 10, 0] = i;
                coolValues[i - 10, 1] = fuzzySet.GetMembership(i);
            }
            chartAusgabe.UpdateDataSeries("COOL", coolValues);
            */

            // Felder leeren
            txtBezEingangTeilmenge.Text = "";
            txtEingangTeilStart.Text = "0";
            txtEingangTeilMax.Text = "0";
            txtEingangTeilMin.Text = "0";

            // Felder deaktivieren und Farbe ändern
            txtBezEingangTeilmenge.Enabled = false; txtBezEingangTeilmenge.BackColor = Color.White;
            txtEingangTeilStart.Enabled = false; txtEingangTeilStart.BackColor = Color.White;
            txtEingangTeilMax.Enabled = false; txtEingangTeilMax.BackColor = Color.White;
            txtEingangTeilMin.Enabled = false; txtEingangTeilMin.BackColor = Color.White;

            btnTeilMengenOK.Enabled = true;
            btnSpeichernEingangTeilmenge.Enabled = false;
            btnNeuEingang.Enabled = true;
        }

        public void neuesFuzzySystem()
        {
            fuzzyDB = new Database();
        }

        private void btnEingangFertig_Click(object sender, EventArgs e)
        {

        }


        private void btnTeilMengenOK_Click(object sender, EventArgs e)
        {
            if(fuzzyDB == null){ fuzzyDB = new Database(); }
            if (Eingangsmengen == null) { Eingangsmengen = new List<Menge>(); }

            fuzzyDB.AddVariable(lvEingang);
            Eingangsmengen.Add(Eingangsmenge);

            lvEingang = null;
            btnTeilMengenOK.Enabled = false;
            btnNeuEingang.Enabled = true;
            lstIEingangTeilmengen.Items.Clear();
        }

        private void btnNeuAusgang_Click(object sender, EventArgs e)
        {
            // Felder aktivieren und Farbe ändern
            aktiviereEingangsControls();
            txtBezAusgang.BackColor = Color.LightYellow;
            txtAusgangMax.BackColor = Color.LightYellow;
            txtAusgangMin.BackColor = Color.LightYellow;
        }

        private void btnSpeichernAusgang_Click(object sender, EventArgs e)
        {
            string strAusgangBez = txtBezAusgang.Text;
            float fAusgangMin = float.Parse(txtAusgangMin.Text);
            float fAusgangMax = float.Parse(txtAusgangMax.Text);

            // Prüfen ob Eingangsvariable bereits vorhanden ist
            if (lstAusgang.Items.Contains(strAusgangBez) == true)
            {
                MessageBox.Show("Ausgangsgröße bereits vorhanden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            lstAusgang.Items.Add(strAusgangBez);
            lstAusgang.EndUpdate();

            lvAusgang = new LinguisticVariable(strAusgangBez, fAusgangMin, fAusgangMax);

            txtBezAusgang.Text = "";
            txtAusgangMin.Text = "0";
            txtAusgangMax.Text = "100";

            txtBezAusgang.BackColor = Color.White;
            txtAusgangMin.BackColor = Color.White;
            txtAusgangMax.BackColor = Color.White;
        }

        private void btnGenRules_Click(object sender, EventArgs e)
        {
            // Regelbasis löschen bzw. instanzieren
            if(rulebase == null)
            {
                rulebase = new Rulebase();
            }
            else
            {
                rulebase.ClearRules();
            }
            // Creating the inference system
            InferenceSystem IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));

            int a = 0, b = 0, nachsteRegelB = 0, startpunkt = 0; 
            string strBasis = "";
            string strRegelNr = "";

            // Anzahl der Eingänge und Teilmengen berechnen --> Grundlage für Regelbildung
            int AnzTeilmengen = 0;
            int AnzEingaenge = Eingangsmengen.Count();
            foreach(Menge Eingang in Eingangsmengen)
            {
                AnzTeilmengen = AnzTeilmengen + Eingang.fuzzySets.Count();
            }
            // max. Anzahl Regeln
            int AnzRegeln = AnzTeilmengen * AnzEingaenge;
            List<string> Regeln = new List<string>();

            // Regelstart wird gebildet für erstes Fuzzy-Set
            Menge Startmenge = Eingangsmengen[0];
            strBasis = "IF " + Startmenge.linguisticVariable.Name.ToString();
            foreach (FuzzySet fuzzySet in Startmenge.fuzzySets)
            {
                string strFuzzyRegel = strBasis + " IS " + fuzzySet.Name.ToString();
                while(a < AnzTeilmengen) { Regeln.Add(strFuzzyRegel);  a++; }
                a = 0;
            }
            
            // 0 -> + AnzTeilmengen + 1

            // alle weiteren Eingangsmengen abhandeln
            for(int i = 1; i <= Eingangsmengen.Count; i++)
            {
                Menge menge = Eingangsmengen[i];
                List<string> UntermengenRegeln = iterateUntermengen(menge);
                foreach(string Regel in UntermengenRegeln)
                {
                    for (b = nachsteRegelB; b < AnzRegeln;)
                    {
                        // x - mal pro Eingang anfügen
                        while (a < AnzEingaenge) 
                        {
                            string strRegel = Regeln[b].ToString() + Regel.ToString();
                            Regeln[b] = strRegel;
                            a++; b++;
                        };
                        a = 0;
                        nachsteRegelB = startpunkt + nachsteRegelB + AnzTeilmengen;
                    }
                    startpunkt = startpunkt + Eingangsmengen.Count;
                    
                }
            }


            /*
                foreach (Menge menge in Eingangsmengen)
            {   
                foreach(FuzzySet fuzzySet in menge.fuzzySets)
                {
                    // Regel aufbauen -> Basis 
                    //strRegelNr = "Regel " + Convert.ToString(i);
                    strBasis = "IF " + menge.linguisticVariable.Name.ToString() + " IS " + fuzzySet.Name.ToString();
                    //i += 1;


                    if (Eingangsmengen.Count > 1)
                    {
                        // Regel um jede andere Eingangsvariable erweitern
                        foreach (Menge untermenge in Eingangsmengen)
                        {
                            if (untermenge.linguisticVariable.Name != menge.linguisticVariable.Name)
                            {
                                List<string> UntermengenRegeln = iterateUntermengen(untermenge);
                              
                                
                                    foreach(string strRegel in UntermengenRegeln)
                                    {
                                        Regeln.Add(strRegel);
                                    }
                                
                            }

                        }
                    }
                }
            }
            */
            

            //Rule r1 = new Rule(fuzzyDB, "Test1", "WENN Steel is not Cold and Stove is Hot then Pressure is Low");

        }

        public List<string>iterateUntermengen(Menge untermenge)
        {
            List<string> rules = new List<string>();
            foreach (FuzzySet fuzzySetUntermenge in untermenge.fuzzySets)
            {
                string strErweiterung = " AND " + untermenge.linguisticVariable.Name.ToString() + " IS " + fuzzySetUntermenge.Name.ToString();
                rules.Add(strErweiterung);
            }
            return rules;
        }

        private void beispieldatenGenerierenToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            // vorhandene Daten löschen
            lvEingang = null; Eingangsmenge = null; ; Ausgangsmenge = null;
            fuzzyDB = null; Eingangsmengen = null; Ausgangsmengen = null;
            lstEingang.Items.Clear(); lstIEingangTeilmengen.Items.Clear();
            lstAusgang.Items.Clear(); lstAusgangTeilmengen.Items.Clear();

            if (fuzzyDB == null) { fuzzyDB = new Database(); }
            if (Eingangsmengen == null) { Eingangsmengen = new List<Menge>(); }
            if(Ausgangsmengen == null) { Ausgangsmengen = new List<Menge>(); }

            // Eingang Baujahr generieren
            string strInputBez = "Baujahr";
            float fInputMin = 1918f;
            float fInputMax = 2016f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
            fuzzyDB.AddVariable(lvEingang);
            Eingangsmengen.Add(Eingangsmenge);
            
            // Teilmenge Baujahre alt generieren
            string strEingangTeilmenge = "alt";
            float fEingangTeilStart = 1918f;
            float fEingangTeilMax = 1918f;
            float fEingangTeilMin = 1967f;
            lstIEingangTeilmengen.Items.Add(strEingangTeilmenge);
            lstIEingangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            TrapezoidalFunction trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            FuzzySet fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Baujahre mittel generieren
            strEingangTeilmenge = "mittel";
            fEingangTeilStart = 1918f;
            fEingangTeilMax = 1967f;
            fEingangTeilMin = 2016f;
            lstIEingangTeilmengen.Items.Add(strEingangTeilmenge);
            lstIEingangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Baujahre neu generieren
            strEingangTeilmenge = "neu";
            fEingangTeilStart = 1918f;
            fEingangTeilMax = 2016f;
            fEingangTeilMin = 1967f;
            lstIEingangTeilmengen.Items.Add(strEingangTeilmenge);
            lstIEingangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, TrapezoidalFunction.EdgeType.Right);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            lvEingang = null; Eingangsmenge = null;

            // Eingang Wohnungsgröße generieren
            strInputBez = "Wohnungsgröße";
            fInputMin = 15f;
            fInputMax = 165f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
            fuzzyDB.AddVariable(lvEingang);
            Eingangsmengen.Add(Eingangsmenge);

            // Teilmenge Wohnungsgröße niedrig generieren
            strEingangTeilmenge = "niedrig";
            fEingangTeilStart = 15f;
            fEingangTeilMax = 15f;
            fEingangTeilMin = 90f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Wohnungsgröße mittel generieren
            strEingangTeilmenge = "mittel";
            fEingangTeilStart = 15f;
            fEingangTeilMax = 90f;
            fEingangTeilMin = 165f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Wohnungsgröße hoch generieren
            strEingangTeilmenge = "hoch";
            fEingangTeilStart = 15f;
            fEingangTeilMax = 165f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, TrapezoidalFunction.EdgeType.Right);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);
            lvEingang = null; Eingangsmenge = null;

            // Eingang Wohnlage generieren
            strInputBez = "Wohnlage";
            fInputMin = -0.6f;
            fInputMax = 1.96f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
            fuzzyDB.AddVariable(lvEingang);
            Eingangsmengen.Add(Eingangsmenge);

            // Teilmenge Wohnlage niedrig generieren
            strEingangTeilmenge = "einfach";
            fEingangTeilStart = -0.6f;
            fEingangTeilMax = -0.6f;
            fEingangTeilMin = 0.68f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Wohnlage mittel generieren
            strEingangTeilmenge = "mittel";
            fEingangTeilStart = -0.6f;
            fEingangTeilMax = 0.68f;
            fEingangTeilMin = 1.96f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, fEingangTeilMin);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Wohnlage gut generieren
            strEingangTeilmenge = "gut";
            fEingangTeilStart = -0.6f;
            fEingangTeilMax = 1.96f;
            fEingangTeilMin = 0.68f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fEingangTeilStart, fEingangTeilMax, TrapezoidalFunction.EdgeType.Right);
            fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvEingang.AddLabel(fuzzySet);
            Eingangsmenge.neuesFuzzySet(fuzzySet);

            lvEingang = null; Eingangsmenge = null;

            // Ausgang generieren
            string strAusgangBez = "Preis";
            float fAusgangMin = 6.55f;
            float fAusgangMax = 17.98f;
            lstAusgang.Items.Add(strAusgangBez);
            lstAusgang.EndUpdate();
            lvAusgang = new LinguisticVariable(strAusgangBez, fAusgangMin, fAusgangMax);
            Ausgangmenge = new Menge(lvAusgang);
            Ausgangsmengen.Add(Ausgangmenge);

            // Teilmenge Preis niedrig generieren
            string strAusgangTeilmenge = "niedrig";
            float fAusgangTeilStart = 6.55f;
            float fAusgangTeilMax = 6.55f;
            float fAusgangTeilMin = 8.55f;

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            trapezoidalFunction = new TrapezoidalFunction(fAusgangTeilStart, fAusgangTeilMax, fAusgangTeilMin);
            fuzzySet = new FuzzySet(strAusgangTeilmenge, trapezoidalFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvAusgang.AddLabel(fuzzySet);
            Ausgangmenge.neuesFuzzySet(fuzzySet);


            RegelbasisGenerieren();
            InferenceSystem IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));
            //IS.NewRule("Rule 1", "IF FrontalDistance IS Far THEN Angle IS Zero");
            //IS.NewRule("Rule 2", "IF FrontalDistance IS Near THEN Angle IS Positive");


        }

        private void RegelbasisGenerieren()
        {
            // Eingangsmengen zur Auswahl geben
            DataGridViewComboBoxColumn Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangmenge"];
            Eingang.Items.Clear();
            foreach(Menge menge in Eingangsmengen)
            {
                Eingang.Items.Add(menge.linguisticVariable.Name.ToString());
            }

            // Eingangsmenge 2
            Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangsmenge_2"];
            Eingang.Items.Clear();
            foreach (Menge menge in Eingangsmengen)
            {
                Eingang.Items.Add(menge.linguisticVariable.Name.ToString());
            }
            // Eingangsmenge 3
            Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangsmenge_3"];
            Eingang.Items.Clear();
            foreach (Menge menge in Eingangsmengen)
            {
                Eingang.Items.Add(menge.linguisticVariable.Name.ToString());
            }
            // Ausgangsmenge
            DataGridViewComboBoxColumn Ausgang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Ausgangsmenge"];
            Ausgang.Items.Clear();
            foreach (Menge menge in Ausgangsmengen)
            {
                Ausgang.Items.Add(menge.linguisticVariable.Name.ToString());
            }
        }

        private void dtRegeln_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(dtRegeln.RowCount < 2) { return; }

            // Eingangsmenge
            if(e.ColumnIndex == 2)
            {
                DataGridViewComboBoxCell currentCb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (currentCb.Value != null)
                {
                    foreach(Menge menge in Eingangsmengen)
                    {
                        if (menge.linguisticVariable.Name.ToString().Equals(currentCb.Value.ToString()))
                        {
                            DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells[3];
                            cb.Items.Clear();
                            foreach (FuzzySet fuzzySet in menge.fuzzySets) { cb.Items.Add(fuzzySet.Name.ToString()); }
                        }
                    }
                }
            }
        }

        private void dtRegeln_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this.dtRegeln.IsCurrentCellDirty)
            {
                // This fires the cell value changed handler below
                dtRegeln.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dtRegeln_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Festwerte für Auswahl der Operatoren
            DataGridViewComboBoxCell currentCb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells["Start"];
            currentCb.Value = "IF";
            currentCb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells["Operator"];
            currentCb.Value = "AND";
            currentCb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells["Operator_2"];
            currentCb.Value = "AND";
            currentCb = (DataGridViewComboBoxCell)dtRegeln.Rows[e.RowIndex].Cells["Schlussfolgerung"];
            currentCb.Value = "THEN";
        }
    }
}
