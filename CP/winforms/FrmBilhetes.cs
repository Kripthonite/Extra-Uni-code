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
    public partial class FrmBilhetes : Form
    {
        public FrmBilhetes()
        {
            InitializeComponent();
            DataTable dt = SelectAllBilhetes();
            dataGridView3.DataSource = dt;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        public DataTable SelectAllTicketsCC()
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

                        cmd.CommandText = "select * from FindTicketsByCC ("+ textBox8.Text +")";
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

        public DataTable SelectAllBilhetes()
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

                        cmd.CommandText = "select * from BilhetesVW ()";
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


        public DataTable SelectAllbyTicket()
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

                        cmd.CommandText = "select * from FindTicketsById (" + textBox9.Text + ")";
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

        private void buttonCriarBilhete_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

         try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("AddBilhete", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@numcc", textBox3.Text));
                sc.Parameters.Add(new SqlParameter("@partida", textBox1.Text));
                sc.Parameters.Add(new SqlParameter("@chegada", textBox2.Text));
                sc.Parameters.Add("@output", SqlDbType.VarChar, 250);

                sc.Parameters["@output"].Direction = ParameterDirection.Output;

                sc.ExecuteNonQuery();
                MessageBox.Show((Convert.ToString(sc.Parameters["@output"].Value)));


                con.Close();

           }
           catch
           {
                MessageBox.Show("Erro a inserir dados\nTem a certeza que existem as Estações");
            }
            
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("UpdateBilhete", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@idBilhete", textBox7.Text));
                sc.Parameters.Add(new SqlParameter("@numcc", textBox4.Text));
                sc.Parameters.Add(new SqlParameter("@partida", textBox6.Text));
                sc.Parameters.Add(new SqlParameter("@chegada", textBox5.Text));
                sc.Parameters.Add("@output", SqlDbType.VarChar, 250);

                sc.Parameters["@output"].Direction = ParameterDirection.Output;

                sc.ExecuteNonQuery();
                MessageBox.Show((Convert.ToString(sc.Parameters["@output"].Value)));


                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a inserir dados\nTem a certeza que existem as Estações");
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonVerBilhetesCC_Click(object sender, EventArgs e)
        {
            DataTable dt2 = SelectAllTicketsCC();
            dataGridView1.DataSource = dt2;

        }

        private void ButtonInfoBilhete_Click(object sender, EventArgs e)
        {
            DataTable dt2 = SelectAllbyTicket();
            dataGridView2.DataSource = dt2;
        }

        private void ButtonAdicionarCliente_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("AddNewClient", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@numcc", textBox10.Text));
                sc.Parameters.Add(new SqlParameter("@num_tel", textBox11.Text));
                sc.Parameters.Add(new SqlParameter("@fname", textBox12.Text));
                sc.Parameters.Add(new SqlParameter("@mname", textBox14.Text));
                sc.Parameters.Add(new SqlParameter("@lname", textBox15.Text));
                sc.Parameters.Add("@data_nascimento", SqlDbType.Date).Value = dateTimePicker1.Value.Date;



                sc.ExecuteNonQuery();


                con.Close();

            }
           catch
            {
                MessageBox.Show("Erro a inserir dados\n");
            }
        }

        private void buttonRemoverCliente_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("RemoveClient", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@numcc", textBox13.Text));




                sc.ExecuteNonQuery();


                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a remover dados\n");
            }
        }
    }
}
