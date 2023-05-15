using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tp_DevSi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadDataIntoGRidView();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy";
            dateTimePicker2.ShowUpDown = true;

        }

        private void LoadDataIntoGRidView()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = " SELECT * FROM codj";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            aj();
        }

        private void aj()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO  codj (  Id , Name ,  Prenom , Promo ,  anne , sp ) " + " VALUES ( @id , @name , @prenom , @promo , @anne , @sp )";
            cmd.Parameters.AddWithValue("@id", dateTimePicker2.Text + dateTimePicker1.Text + comboBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@promo", dateTimePicker2.Text);
            cmd.Parameters.AddWithValue("@anne", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@sp", comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ajoutee");
            refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mod();
        }

        private void Mod()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE codj SET Id = @id , Name = @name , Prenom = @prenom  WHERE Id =@id ";
            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("modifier");
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            efa();

        }

        private void efa()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM  codj  WHERE Id =@id";
            cmd.Parameters.AddWithValue("@id", textBox5.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("effacé");
            refresh();
        }

        private void text1(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("404");
            }
            if (char.IsLetter(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(char.IsLetter) >= 10)
                {
                    e.Handled = true;
                    MessageBox.Show("404");
                }
            }
        }

        private void text2(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("404");
            }
            if (char.IsLetter(e.KeyChar))
            {
                if ((sender as TextBox).Text.Count(char.IsLetter) >= 10)
                {
                    e.Handled = true;
                    MessageBox.Show("404");
                }
            }
        }

       
        public void refresh()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM  codj  WHERE 1";
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            refresh();
        }

     
    }
}
