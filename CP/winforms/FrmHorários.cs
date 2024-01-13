using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class FrmHorários : Form
    {
        private HorariosData moreForm;

        public FrmHorários()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FrmHorários_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonAdicionarFuncionário_Click(object sender, EventArgs e)
        {


            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "select * from GetHorário ('"+textBox1.Text+ "', '"+textBox2.Text+"')";
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);

                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
                MessageBox.Show("Something went Wrong");
            }



            moreForm = new HorariosData(dt);
            moreForm.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void ButtonPesquisarTrajeto_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionStr))
                {
                    con.Open();
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.CommandText = "select * from GetHorasTrajeto ("+textBox3.Text+")";
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);

                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
                MessageBox.Show("Something went Wrong");
            }

            try { 
            label10.Text = dt.Rows[0][0].ToString();
            label11.Text = dt.Rows[0][1].ToString();
            label12.Text = dt.Rows[0][2].ToString().Split(" ")[1];
            label13.Text = dt.Rows[0][3].ToString().Split(" ")[1];
            }
            catch
            {
                MessageBox.Show("Não Existe Tal ID");
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
