using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;


namespace WinFormsApp1
{
    public partial class FrmComboios : Form
    {
        public FrmComboios()
        {
            InitializeComponent();
            DataTable dt2 = SelectAllComboios();
            dataGridComboios.DataSource = dt2;
            DataTable dt3 = SelectAllCarruagens();
            dataGridView1.DataSource = dt3;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }


        public DataTable SelectAllComboios()
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
                        //sample stored procedure with parameter:
                        // "exec yourstoredProcedureName '" + param1+ "','" + param2+ "'";
 
                            cmd.CommandText = "select * from ListComboios ()";
                            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                            {
                                adp.Fill(dt);
                                return dt;
                            
                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
            }

            return dt;

        }


        private void buttonAdicionarComboio_Click(object sender, EventArgs e)
        {

            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            try { 
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("CreateComboio", con);
                sc.CommandType = CommandType.StoredProcedure;
                if (textBox5.Text == "")
                {
                    sc.Parameters.Add(new SqlParameter("@Revisor", DBNull.Value));
                }
                else
                {
                    sc.Parameters.Add(new SqlParameter("@Revisor", textBox5.Text));
                }
                if (textBox4.Text == "")
                {
                    sc.Parameters.Add(new SqlParameter("@Condutor", DBNull.Value));

                }
                else
                {
                    sc.Parameters.Add(new SqlParameter("@Condutor", textBox4.Text));
                }

                sc.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
                MessageBox.Show("Someting went Wrong inserting Data");
            }
        }

        private void buttonRemoverComboio_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            String Query = "DELETE FROM Comboio WHERE id="+textBox2.Text+"";
            SqlConnection con = new SqlConnection(connectionStr);
            con.Open();
            SqlCommand sc = new SqlCommand(Query, con);
            sc.ExecuteNonQuery();
            con.Close();
        }

        private void buttonUpdateComboio_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("alterComboio", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@ID", textBox8.Text));
                if (textBox7.Text == "")
                {
                    sc.Parameters.Add(new SqlParameter("@Revisor", DBNull.Value));
                }
                else
                {
                    sc.Parameters.Add(new SqlParameter("@Revisor", textBox7.Text));
                }
                if (textBox6.Text == "")
                {
                    sc.Parameters.Add(new SqlParameter("@Condutor", DBNull.Value));

                }
                else
                {
                    sc.Parameters.Add(new SqlParameter("@Condutor", textBox6.Text));
                }

                sc.ExecuteNonQuery();
                con.Close();

            }
            catch
            {
                MessageBox.Show("Someting went Wrong inserting Data \n Tenha a certeza que o Comboio ou Funcionários existem");
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            DataTable dt2 = SelectAllComboios();
            dataGridComboios.DataSource = dt2;
        }


        public DataTable SelectAllCarruagens()
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
                        //sample stored procedure with parameter:
                        // "exec yourstoredProcedureName '" + param1+ "','" + param2+ "'";

                        cmd.CommandText = "select * from ListCarruagens ()";
                        using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                        {
                            adp.Fill(dt);
                            return dt;

                        }
                    }
                }
            }
            catch (Exception sqlEx)
            {
                Console.WriteLine(@"：Unable to establish a connection: {0}", sqlEx);
            }

            return dt;

        }
        private void button1_Click(object sender, EventArgs e)
        {

            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("CreateCarruagem", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@ComboioID", textBox9.Text));
                sc.Parameters.Add(new SqlParameter("@NLugares", textBox10.Text));

                sc.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Someting went Wrong inserting Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try { 
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            String Query = "delete from Carruagem where (Carruagem.N_Carruagem = "+textBox11.Text+ " and Comboio_ID = "+ textBox12.Text  +" ) ";
            SqlConnection con = new SqlConnection(connectionStr);
            con.Open();
            SqlCommand sc = new SqlCommand(Query, con);
            sc.ExecuteNonQuery();
            con.Close();
            }
            catch
            {
                MessageBox.Show("Someting went Wrong Deleting Data");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dt2 = SelectAllCarruagens();
            dataGridView1.DataSource = dt2;
        }
    }
}
