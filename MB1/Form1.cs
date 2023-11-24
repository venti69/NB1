using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace MB1
{
    public partial class Form1 : Form
    {
        public static MySqlConnection conn = null;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string cStr = "server=localhost;database=nb1;username=root;password=";
            conn = new MySqlConnection(cStr);
            conn.Open();
            dataGridViewFeltolt();
            conn.Close();
        }

        private void Feltolt_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string neve = textBox2.Text;
            string sta = textBox3.Text;
            string tel = textBox4.Text;
            string alap = textBox5.Text;
            string connStr = $"insert into csapatok (id, neve, stadion, telepules, alapitas) values ('{id}', '{neve}', '{sta}', '{tel}', '{alap}')";
            MySqlCommand cmd = new MySqlCommand(connStr, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            dataGridViewFeltolt();
            conn.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }
        private void dataGridViewFeltolt()
        {
            string ConnStri = "Select id, neve, stadion, telepules, alapitas tantargy from csapatok";
            MySqlCommand cmd = new MySqlCommand(ConnStri, conn);
            MySqlDataAdapter mda = new MySqlDataAdapter();
            mda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            mda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];

            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();
            textBox5.Text = selectedRow.Cells[4].Value.ToString();
        }

    }
}
