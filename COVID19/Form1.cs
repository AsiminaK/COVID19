using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID19
{
    public partial class Form1 : Form
    {
        String connectionString = "Data Source=DBab.db;Version=3;";
        SQLiteConnection conn;

        List<USERS> users = new List<USERS>();

        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            String selectQuery = "Select Username from EMPLOYEES where Username='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Form2 myForm = new Form2(textBox1.Text);
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong student name and/or password");
            }
            conn.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == textBox5.Text)//Αν είναι σωστά μετάβαση στη φόρμα1 για είσοδο στο παιχνίδι
            {
                conn.Open();
                String insertQuery = "Insert into EMPLOYEES(Username, password) values('" + textBox3.Text + "','" + textBox4.Text + "')";
                SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
                int count = cmd.ExecuteNonQuery();
                MessageBox.Show(count.ToString() + ".Ο λογαριασμός σας δημιουργήθηκε επιτυχώς!");
                conn.Close();
                USERS myUser = new USERS(textBox3.Text, textBox4.Text);
                users.Add(myUser);
                panel1.Visible = false;
                panel2.Visible = true;
                richTextBox1.Text += "Όνομα: " +myUser.name + " || Κωδικός: " +myUser.password+ Environment.NewLine;
            }
            else
            {
                MessageBox.Show("Παρακαλώ πληκτρολογήστε ξανά τον κωσικό σας!");
                textBox4.Clear();
                textBox5.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var answer = MessageBox.Show("Είστε σίγουροι οτι επιθυμείτε να κλείσετε την εφαρμογή;", "Αποχώρηση από την εφαρμογή COVID-19", MessageBoxButtons.YesNo);
                if (answer == DialogResult.No)
                {
                    /* Cancel the Closing event from closing the form. */
                    e.Cancel = true;
                }

                else if (answer == DialogResult.Yes)
                {
                    /* Closing the form. */
                    e.Cancel = false;
                    Application.Exit();
                }
            }
        }
    }
}
