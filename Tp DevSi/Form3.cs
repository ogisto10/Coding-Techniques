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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadDataIntoGRidView();
            
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;
        }

        private void LoadDataIntoGRidView()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = " SELECT * FROM codh";
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                Aj();
            
        }

        private void Aj()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO codh(  Id , Nom , Prenom, promo ,  Specialite ,  Niveau  ) " + "  VALUES ( @id , @nom , @prenom ,@promo , @specialite , @niveau )";
            cmd.Parameters.AddWithValue("@id",dateTimePicker1.Text+comboBox1.Text+comboBox3.Text);
            cmd.Parameters.AddWithValue("@nom",textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            cmd.Parameters.AddWithValue("@promo", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@specialite", comboBox1.Text);
            cmd.Parameters.AddWithValue("@niveau", comboBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Ajoutee");
            refresh();
        }

        //---------------------------------------------
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
            cmd.CommandText = "UPDATE codh SET Id = @id , Nom = @nom , Prenom = @prenom   WHERE  Id =@id ";
            cmd.Parameters.AddWithValue("@id", textBox3.Text);
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
            //cmd.Parameters.AddWithValue("@promo", textBox4.Text);
            //cmd.Parameters.AddWithValue("@specialite", comboBox1.Text);
            //cmd.Parameters.AddWithValue("@niveau", comboBox3.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("modifier");
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ef();
        }

        private void ef()
        {
            MySqlConnection con = new MySqlConnection(data.dbcon());
            con.Open();
            MySqlCommand cmd;
            cmd = con.CreateCommand();
            cmd.CommandText = "DELETE FROM  codh  WHERE Id=@id";
            cmd.Parameters.AddWithValue("@id", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Effacé");
            refresh();
        }

        private void text1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("404");
            }
            if(char.IsLetter(e.KeyChar))
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
            cmd.CommandText = "SELECT * FROM  codh  WHERE 1";
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            refresh();
        }

        
    }
}
