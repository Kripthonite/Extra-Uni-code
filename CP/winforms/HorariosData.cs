using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;


namespace WinFormsApp1
{
    public partial class HorariosData : Form
    {
        public HorariosData(DataTable dt)
        {
            InitializeComponent();

            DataTable dtCloned = dt.Clone();
            dtCloned.Columns[2].DataType = typeof(String);
            dtCloned.Columns[3].DataType = typeof(String);

            foreach (DataRow row in dt.Rows)
            {
                dtCloned.ImportRow(row);
            }

            foreach (DataRow row in dtCloned.Rows)
            {

                row["HoraSaida"] = (row["HoraSaida"].ToString()).Split(" ")[1];
                row["HoraChegada"] = (row["HoraChegada"].ToString()).Split(" ")[1];

            }


            dataGridView1.DataSource = dtCloned;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
