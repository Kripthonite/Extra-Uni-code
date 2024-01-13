using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        private Form AtivoFrm;

        public Form1()
        {
            InitializeComponent();
        }


        private void FormShow(Form frm)
        {
            ActiveFormClose();
            AtivoFrm = frm;
            frm.TopLevel = false;
            panelForms.Controls.Add(frm);
            frm.BringToFront();
            frm.Show();
        }

        private void ActiveFormClose()
        {
            if (AtivoFrm != null)
            {
                AtivoFrm.Close();
            }
        }

        private void ActiveButton(Button Activo)
        {
            foreach (Control ctrl in PanelPrincipal.Controls)
            {
                if (ctrl != PanelEstações)
                {
                    ctrl.BackColor = Color.ForestGreen;
                }
            }
            Activo.BackColor = Color.PaleGreen;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

 



        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
       
        }

        private void ButtonEstações_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonEstações);
            FormShow(new FrmEstações());
        }

        private void ButtonComboios_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonComboios);
            FormShow(new FrmComboios());
        }

        private void ButtonBilhetes_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonBilhetes);
            FormShow(new FrmBilhetes());
        }

        private void ButtonFuncionários_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonFuncionários);
            FormShow(new FrmFuncionários());
        }

        private void ButtonHorários_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonHorários);
            FormShow(new FrmHorários());
        }

        private void ButtonTrajetos_Click(object sender, EventArgs e)
        {
            ActiveButton(ButtonTrajetos);
            FormShow(new FrmTrajetos());
        }


    }
}
