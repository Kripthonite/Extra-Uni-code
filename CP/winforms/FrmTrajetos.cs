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
    public partial class FrmTrajetos : Form
    {
        public FrmTrajetos()
        {
            InitializeComponent();
            var dt = SelectAllEstacoes();
            dt.Columns.Add(new DataColumn("Selected", typeof(bool))); //this will show checkboxes

            dataGridView1.DataSource = dt;


            DataTable dt2 = SelectAllTrajetos();
            dataGridView3.DataSource = dt2;
        }


        public DataTable SelectAllEstacoes()
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
                        cmd.CommandText = "select * from GetEstacoes ()";
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
                MessageBox.Show("Something went Wrong");
            }

            return dt;

        }


        private void ButtonAdicionarTrajeto_Click(object sender, EventArgs e)
        {

            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            int id = 0;
            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("CreateTrajecto", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@partida", textBox1.Text));
                sc.Parameters.Add(new SqlParameter("@chegada", textBox2.Text));

                sc.Parameters.Add("@output", SqlDbType.VarChar, 250);

                sc.Parameters["@output"].Direction = ParameterDirection.Output;

                sc.Parameters.Add("@id", SqlDbType.Int);

                sc.Parameters["@id"].Direction = ParameterDirection.Output;

                sc.ExecuteNonQuery();

                if ((Convert.ToString(sc.Parameters["@output"].Value)) != "")
                {
                    MessageBox.Show((Convert.ToString(sc.Parameters["@output"].Value)));
                    return;
                }
                id = Convert.ToInt32(sc.Parameters["@id"].Value);

                con.Close();



            }
            catch
            {
                MessageBox.Show("Erro a inserir dados\n");
            }

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((row.Cells["Selected"].Value.ToString()) == "True"){
                    String estação = row.Cells["Estações"].Value.ToString();
                    Debug.WriteLine("  " + id.ToString() + estação);

                    SqlConnection con = new SqlConnection(connectionStr);
                    con.Open();
                    SqlCommand sc = new SqlCommand("CreateFazParagem", con);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.Add(new SqlParameter("@ID", id));
                    sc.Parameters.Add(new SqlParameter("@estacao", estação));

                    sc.ExecuteNonQuery();



                    con.Close();
                }

            }
        }

        private void ButtonRemoverTrajeto_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("RemoveTrajecto", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@id", textBox3.Text));


                sc.ExecuteNonQuery();


                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a eliminar dados\n");
            }
        }

        public DataTable SelectAllTrajetos()
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
                        cmd.CommandText = "select ID, EstaçãoPartida AS Partida,EstaçãoChegada as Chegada from Trajeto";
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
                MessageBox.Show("Something went Wrong");
            }

            return dt;

        }


        public DataTable SelectAllParagens()
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
                        cmd.CommandText = "select * from GetParagens ("+textBox4.Text+")";
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
                MessageBox.Show("Something went Wrong");
            }

            return dt;

        }

        private void buttonVerParagens_Click(object sender, EventArgs e)
        {
            DataTable dt = SelectAllParagens();
            dataGridView2.DataSource = dt;

            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("GETPartidaChegada", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@id", textBox4.Text));
                sc.Parameters.Add("@partida", SqlDbType.VarChar, 250);

                sc.Parameters["@partida"].Direction = ParameterDirection.Output;
                sc.Parameters.Add("@chegada", SqlDbType.VarChar, 250);

                sc.Parameters["@chegada"].Direction = ParameterDirection.Output;
                sc.ExecuteNonQuery();
                //Debug.WriteLine(Convert.ToString(sc.Parameters["@chegada"].Value));
                //Debug.WriteLine(Convert.ToString(sc.Parameters["@partida"].Value));
                label7.Text = (Convert.ToString(sc.Parameters["@partida"].Value));
                label8.Text = (Convert.ToString(sc.Parameters["@chegada"].Value));

                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a recolher dados\n");
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = SelectAllTrajetos();
            dataGridView3.DataSource = dt;
        }
    }
}
