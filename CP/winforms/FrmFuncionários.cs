using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FrmFuncionários : Form
    {
        public FrmFuncionários()
        {
            InitializeComponent();

            DataTable db = SelectAllTipoFunc();
            dataGridView1.DataSource = db;
        }

        private void ButtonAdicionarCliente_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("AddNewEmployee", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@id", textBox10.Text));
                sc.Parameters.Add(new SqlParameter("@salario", textBox2.Text));
                sc.Parameters.Add(new SqlParameter("@fname", textBox12.Text));
                sc.Parameters.Add(new SqlParameter("@mname", textBox6.Text));
                sc.Parameters.Add(new SqlParameter("@lname", textBox7.Text));
                sc.Parameters.Add(new SqlParameter("@num_tel", textBox11.Text));
                sc.Parameters.Add(new SqlParameter("@morada", textBox1.Text));
                sc.Parameters.Add(new SqlParameter("@funcid", textBox8.Text));
                sc.Parameters.Add("@data_nascimento", SqlDbType.Date).Value = dateTimePicker1.Value.Date;



                sc.ExecuteNonQuery();


                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a inserir dados\n");
            }
        }


        public DataTable SelectAllTipoFunc()
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
                        cmd.CommandText = "select * from ListTipos ()";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ButtonRemoverFuncionário_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

            try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("RemoveEmployee", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@id", textBox3.Text));


                sc.ExecuteNonQuery();


                con.Close();

            }
            catch
            {
                MessageBox.Show("Erro a inserir dados\n");
            }
        }

        private void ButtonAdicionarTipoFuncionário_Click(object sender, EventArgs e)
        {
            String connectionStr = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;

           try
            {
                SqlConnection con = new SqlConnection(connectionStr);
                con.Open();
                SqlCommand sc = new SqlCommand("CreateFunc", con);
                sc.CommandType = CommandType.StoredProcedure;
                sc.Parameters.Add(new SqlParameter("@idFunc", textBox4.Text));
                sc.Parameters.Add(new SqlParameter("@Func", textBox5.Text));
                sc.Parameters.Add("@output", SqlDbType.VarChar, 250);

                sc.Parameters["@output"].Direction = ParameterDirection.Output;

                sc.ExecuteNonQuery();
                if ((Convert.ToString(sc.Parameters["@output"].Value)) !=  ""){
                    MessageBox.Show((Convert.ToString(sc.Parameters["@output"].Value)));
                }

                con.Close();

            }
           catch
            {
                MessageBox.Show("Erro a inserir dados\n");
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefreshTipos_Click(object sender, EventArgs e)
        {
            DataTable db = SelectAllTipoFunc();
            dataGridView1.DataSource = db;
        }
    }
}
