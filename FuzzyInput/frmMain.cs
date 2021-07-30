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
        InferenceSystem IS;
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
        private void deaktiviereAusgangsControls()
        {
            // Ausgangsmengen
            txtBezAusgang.Enabled = false;
            txtAusgangMin.Enabled = false;
            txtAusgangMax.Enabled = false;
            btnSpeichernAusgang.Enabled = false;

            // AusgangsTeilmengen
            txtBezAusgangTeilmenge.Enabled = false;
            txtAusgangTeilStart.Enabled = false;
            btnNeuAusgangTeilmenge.Enabled = false;
            btnSpeichernAusgangTeilmenge.Enabled = false;
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
            
            deaktiviereEingangsControls();
            deaktiviereAusgangsControls();
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
            if(Ausgangsmengen.Count > 0) { MessageBox.Show("Zur Zeit ist nur die Eingabe von einer Ausgangsmenge erlaubt","Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
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
            // DataGrid Regeln aufbauen
            RegelGridGenerieren();

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
            AnzTeilmengen = 1;
            Menge Startmenge = Eingangsmengen[0];
            foreach (FuzzySet fuzzySet in Startmenge.fuzzySets)
            {
                // Eingangsvariable 2 inkl. aller Fuzzy-Mengen
                string strMengeVar2 = Eingangsmengen[1].linguisticVariable.Name;
                foreach(FuzzySet fuzzySetVar2 in Eingangsmengen[1].fuzzySets)
                {
                    if(Eingangsmengen.Count == 3)
                    {
                        // Eingangsvariable 3 inkl. aller Fuzzy-Mengen
                        string strMengeVar3 = Eingangsmengen[2].linguisticVariable.Name;
                        foreach (FuzzySet fuzzySetVar3 in Eingangsmengen[2].fuzzySets)
                        {
                            dtRegeln.Rows.Add(AnzTeilmengen, "IF", fuzzySet.Name.ToString(), "AND", fuzzySetVar2.Name.ToString(), "AND", fuzzySetVar3.Name.ToString(), "THEN");
                            AnzTeilmengen++;
                        }
                    }
                    else { 
                        dtRegeln.Rows.Add(AnzTeilmengen, "IF", fuzzySet.Name.ToString(), "AND", fuzzySetVar2.Name.ToString(), "THEN");
                        AnzTeilmengen++;
                    }
                }
            }
            
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
            IS = null;
            lstEingang.Items.Clear(); lstIEingangTeilmengen.Items.Clear();
            lstAusgang.Items.Clear(); lstAusgangTeilmengen.Items.Clear();

            if (fuzzyDB == null) { fuzzyDB = new Database(); }
            if (Eingangsmengen == null) { Eingangsmengen = new List<Menge>(); }
            if (Ausgangsmengen == null) { Ausgangsmengen = new List<Menge>(); }

            // Eingang Baujahr generieren
            string strInputBez = "Baujahr";
            float fInputMin = 1918f;
            float fInputMax = 2016f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
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
            fuzzyDB.AddVariable(lvEingang);

            lvEingang = null; Eingangsmenge = null;

            // Eingang Wohnungsgröße generieren
            strInputBez = "Wohnungsgröße";
            fInputMin = 15f;
            fInputMax = 165f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
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
            fuzzyDB.AddVariable(lvEingang);

            lvEingang = null; Eingangsmenge = null;

            // Eingang Wohnlage generieren
            strInputBez = "Wohnlage";
            fInputMin = -0.6f;
            fInputMax = 1.96f;
            lstEingang.Items.Add(strInputBez);
            lstEingang.EndUpdate();
            lvEingang = new LinguisticVariable(strInputBez, fInputMin, fInputMax);
            Eingangsmenge = new Menge(lvEingang);
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

            fuzzyDB.AddVariable(lvEingang);

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
            lstAusgangTeilmengen.Items.Add(strAusgangTeilmenge);
            lstAusgangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            SingletonFunction singletonFunction = new SingletonFunction(fAusgangTeilStart);
            fuzzySet = new FuzzySet(strAusgangTeilmenge, singletonFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvAusgang.AddLabel(fuzzySet);
            Ausgangmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Preis niedrig generieren
            strAusgangTeilmenge = "mittel";
            fAusgangTeilStart = 12.2650f;
            lstAusgangTeilmengen.Items.Add(strAusgangTeilmenge);
            lstAusgangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            singletonFunction = new SingletonFunction(fAusgangTeilStart);
            fuzzySet = new FuzzySet(strAusgangTeilmenge, singletonFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvAusgang.AddLabel(fuzzySet);
            Ausgangmenge.neuesFuzzySet(fuzzySet);

            // Teilmenge Preis niedrig generieren
            strAusgangTeilmenge = "hoch";
            fAusgangTeilStart = 17.98f;
            lstAusgangTeilmengen.Items.Add(strAusgangTeilmenge);
            lstAusgangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            singletonFunction = new SingletonFunction(fAusgangTeilStart);
            fuzzySet = new FuzzySet(strAusgangTeilmenge, singletonFunction);

            // Fuzzy-Menge zu Eingangsgröße hinzufügen
            lvAusgang.AddLabel(fuzzySet);
            Ausgangmenge.neuesFuzzySet(fuzzySet);
            fuzzyDB.AddVariable(lvAusgang);
        }

        private void RegelGridGenerieren()
        {
            // Eingangsmengen zur Auswahl geben
            DataGridViewComboBoxColumn Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangmenge"];
            Eingang.Items.Clear();
            Eingang.Name = Eingangsmengen[0].linguisticVariable.Name;
            Eingang.HeaderText = Eingangsmengen[0].linguisticVariable.Name;
            foreach (FuzzySet fuzzySet in Eingangsmengen[0].fuzzySets)
            {
                Eingang.Items.Add(fuzzySet.Name);
            }

            // Eingangsmenge 2
            Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangsmenge_2"];
            Eingang.Items.Clear();
            Eingang.Name = Eingangsmengen[1].linguisticVariable.Name;
            Eingang.HeaderText = Eingangsmengen[1].linguisticVariable.Name;
            foreach (FuzzySet fuzzySet in Eingangsmengen[1].fuzzySets)
            {
                Eingang.Items.Add(fuzzySet.Name);
            }

            // Eingangsmenge 3
            if (Eingangsmengen.Count == 3) { 
                Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Eingangsmenge_3"];
                Eingang.Items.Clear();
                Eingang.Name = Eingangsmengen[2].linguisticVariable.Name;
                Eingang.HeaderText = Eingangsmengen[2].linguisticVariable.Name;
                foreach (FuzzySet fuzzySet in Eingangsmengen[2].fuzzySets)
                {
                    Eingang.Items.Add(fuzzySet.Name);
                }
            }
            else { 
                dtRegeln.Columns.Remove(Eingang);
                Eingang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Operator_2"];
                dtRegeln.Columns.Remove(Eingang);
            }

            // Ausgangsmenge
            DataGridViewComboBoxColumn Ausgang = (DataGridViewComboBoxColumn)this.dtRegeln.Columns["Ausgangsmenge"];
            Ausgang.Items.Clear();
            Ausgang.Name = Ausgangsmengen[0].linguisticVariable.Name;
            Ausgang.HeaderText = Ausgangsmengen[0].linguisticVariable.Name; 
            foreach (FuzzySet fuzzySet in Ausgangsmengen[0].fuzzySets)
            {
                Ausgang.Items.Add(fuzzySet.Name);
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

        private void btnAusgabe_Click(object sender, EventArgs e)
        {
            IS = null;
            if(IS == null)
            {
                IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));
            }

            foreach(DataGridViewRow row in dtRegeln.Rows)
            {
                if(row.Cells[1].Value != null) { 
                    string strRule = row.Cells[1].Value.ToString() + " " + dtRegeln.Columns[2].HeaderText + " IS " + row.Cells[2].Value + " " + row.Cells[3].Value + " " + dtRegeln.Columns[4].HeaderText + " IS " + row.Cells[4].Value;
                    if(Eingangsmengen.Count == 3)
                    {
                        strRule = strRule + " " + row.Cells[5].Value + " " + dtRegeln.Columns[6].HeaderText + " IS " + row.Cells[6].Value; 
                    }
                    strRule = strRule + " " + row.Cells["Schlussfolgerung"].Value + " " + dtRegeln.Columns[Ausgangsmengen[0].linguisticVariable.Name].HeaderText + " IS " + row.Cells[Ausgangsmengen[0].linguisticVariable.Name].Value;
                    IS.NewRule("Rule " + row.Cells[0].Value.ToString(), strRule);
                }
            }



            //// setting inputs
            //IS.SetInput("Baujahr", 2010);
            //IS.SetInput("Wohnungsgröße", 110);
            //IS.SetInput("Wohnlage", 0.69f);

            //// getting outputs
            //try
            //{
            //    FuzzyOutput fuzzyOutput = IS.ExecuteInference("Preis");

            //    // showing the fuzzy output
            //    foreach (FuzzyOutput.OutputConstraint oc in fuzzyOutput.OutputList)
            //    {
            //        Console.WriteLine(oc.Label + " - " + oc.FiringStrength.ToString());
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }
    }
}
