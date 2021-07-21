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

namespace FuzzyInput
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            string strInputBez = txtBez.Text;
            string strInputEinheit = txtEinheit.Text;
            // Prüfen ob Eingangsvariable bereits vorhanden ist
            if (lstInputs.Items.Contains(strInputBez) == true)
            {
                MessageBox.Show("Eingangsgröße bereits vorhanden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            };

            lstInputs.Items.Add(strInputBez);
            lstInputs.EndUpdate();
            deactivateControls();
        }

        private void deactivateControls()
        {
            txtBez.Enabled = false;
            txtEinheit.Enabled = false;
        }
        private void activateControls()
        {
            txtBez.Enabled = true;
            txtEinheit.Enabled = true;
        }

        private void btnNewInput_Click(object sender, EventArgs e)
        {
            activateControls();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Programmstart
            deactivateControls();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            // Input-Dialog
            string strResponse = Interaction.InputBox("Name des Systems", "Neues Fuzzy-System anlegen");
            if(strResponse != "")
            {

            }
        }
    }
}
