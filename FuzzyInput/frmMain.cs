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
        public List<Menge> Eingangsmengen;

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

            zeichneAusgabe();
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

        // Clear all data series data
        private void ClearDataSeries()
        {

        }

        private void zeichneAusgabe() 
        {
            chartAusgabe.RangeX = new Range(0, 20);
            chartAusgabe.AddDataSeries("Test", Color.CornflowerBlue, Accord.Controls.Chart.SeriesType.Line, 3, true);
            chartAusgabe.AddDataSeries("COOL", Color.LightBlue, Accord.Controls.Chart.SeriesType.Line, 3, true);
            chartAusgabe.AddDataSeries("WARM", Color.LightCoral, Accord.Controls.Chart.SeriesType.Line, 3, true);
            chartAusgabe.AddDataSeries("HOT", Color.Firebrick, Accord.Controls.Chart.SeriesType.Line, 3, true);
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

            int i = 1;
            string strBasis = "";
            string strRegelNr = "";
            foreach (Menge menge in Eingangsmengen)
            {   
                foreach(FuzzySet fuzzySet in menge.fuzzySets)
                {
                    // Regel aufbauen -> Basis 
                    strRegelNr = "Regel " + Convert.ToString(i);
                    strBasis = "IF " + menge.linguisticVariable.Name.ToString() + " IS " + fuzzySet.Name.ToString();
                    i += 1;

                    if (Eingangsmengen.Count > 1)
                    {
                        // Regel um jede andere Eingangsvariable erweitern
                        foreach (Menge untermenge in Eingangsmengen)
                        {
                            if (untermenge.linguisticVariable.Name != menge.linguisticVariable.Name)
                            {
                                List<string> rules = iterateUntermengen(strBasis, untermenge);
                            }

                        }
                    }
                }
            }

            

            //Rule r1 = new Rule(fuzzyDB, "Test1", "WENN Steel is not Cold and Stove is Hot then Pressure is Low");

        }

        public List<string>iterateUntermengen(string regel, Menge untermenge)
        {
            List<string> rules = new List<string>();
            foreach (FuzzySet fuzzySetUntermenge in untermenge.fuzzySets)
            {
                string strErweiterung = " AND " + untermenge.linguisticVariable.Name.ToString() + " IS " + fuzzySetUntermenge.Name.ToString();
                rules.Add(strErweiterung);
            }
            return rules;
        }


    }
}
