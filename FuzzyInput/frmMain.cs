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

namespace FuzzyInput
{
    public partial class frmMain : Form
    {
        public Database fuzzyDB;
        public LinguisticVariable lvEingang;
        public Menge mEingang;

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
            mEingang = new Menge(lvEingang);
            
            deaktiviereEingangsControls();
            aktiviereEingangsTeilmengenControls();
            leereEingangsControls();
        }

        private void leereEingangsControls()
        {
            txtBezEingang.Text = "";
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
            btnNeueEingangTeilmenge.Enabled = false;
            btnSpeichernEingangTeilmenge.Enabled = false;
            btnLoeEingangTeilmenge.Enabled = false;
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
            aktiviereEingangsControls();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Programmstart
            tabCFuzzy.Enabled = false;
            deaktiviereEingangsControls();
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
            txtBezEingangTeilmenge.Enabled = true;
            btnSpeichernEingangTeilmenge.Enabled = true;
        }

        private void lstEingang_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Wechsel");
        }

        private void btnSpeichernEingangTeilmenge_Click(object sender, EventArgs e)
        {
            string strEingangTeilmenge = txtBezEingangTeilmenge.Text;
            lstIEingangTeilmengen.Items.Add(strEingangTeilmenge);
            lstIEingangTeilmengen.EndUpdate();

            // Neues Fuzzy-Set anlegen (Teilmenge) 
            TrapezoidalFunction trapezoidalFunction = new TrapezoidalFunction(6, 6, TrapezoidalFunction.EdgeType.Right);
            FuzzySet fuzzySet = new FuzzySet(strEingangTeilmenge, trapezoidalFunction);

            
            double[,] coolValues = new double[20, 2];
            for (int i = 0; i < 30; i++)
            {
                coolValues[i - 10, 0] = i;
                coolValues[i - 10, 1] = fuzzySet.GetMembership(i);
            }
            chartAusgabe.UpdateDataSeries("COOL", coolValues);
            

            txtBezEingangTeilmenge.Enabled = false;
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

    }
}
