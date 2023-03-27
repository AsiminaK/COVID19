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
using System.Diagnostics;

namespace COVID19
{
    public partial class Form2 : Form
    {
        String connectionString = "Data Source=DBb.db;Version=3;";
        SQLiteConnection conn;
        string myusername;
        bool delete;

        public Form2(String username)
        {
            InitializeComponent();
            label2.Text = username;
            myusername = username;
        }

        private void επιστροφήΣτηνΕίσοδοToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Εάν αποσυνδεθείτε θα πρέπει να εισάγετε ξανά τα στοιχεία σας!", "Είστε σιγουροι ότι θέλετε να αποσυνδεθείτε;", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Form1 myForm = new Form1();
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void βοήθειαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void εισαγωγήΚρούσματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 myForm = new Form3(myusername);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void αναζήτησηΜεΌνομαToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label3.Text = "ΑΝΑΖΗΤΗΣΗ ΜΕ ΟΝΟΜΑ";
            textBox1.Visible = true;
            dateTimePicker1.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectionstring = "Data Source=DBb.db;Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);

            if (label3.Text == "ΑΝΑΖΗΤΗΣΗ ΜΕ ΟΝΟΜΑ")
            {
                conn.Open();
                String selectQuery = "Select ID,LastName,Phonenumber,Sex,Birthday,Illness,Email,Adress,Date from COVID where FirstName='" + textBox1.Text + "'";
                SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    new Form4(textBox1.Text, reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)).Show();
                }
                else
                {
                    panel3.Visible = true;
                }
                conn.Close();
            }
            else if (label3.Text == "ΑΝΑΖΗΤΗΣΗ ΜΕ ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ")
            {
                DateTime birthday;
                birthday = dateTimePicker1.Value;
                conn.Open();
                String selectQuery = "Select ID,FirstName,LastName,Phonenumber,Sex,Illness,Email,Adress,Date from COVID where Birthday='" + birthday.ToString() + "'";
                SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    new Form4(reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), birthday.ToString(), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8)).Show();
                }
                else
                {
                    panel5.Visible = true;
                }
                conn.Close();
            }

        }


        private void αναζήτησηΜεΗμερομηνίαΚαταγραφήςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label3.Text = "ΑΝΑΖΗΤΗΣΗ ΜΕ ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ";
            textBox1.Visible = false;
            dateTimePicker1.Visible = true;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void τροποποίησηΚρούσματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete = false;
            Form5 myForm = new Form5(delete);
            myForm.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);

            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = new DateTime(1998, 5, 1);
        }

        private void διαγραφήΚρούσματοςToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete = true;
            Form5 myForm = new Form5(delete);
            myForm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 myForm = new Form6();
            myForm.ShowDialog();
        }


        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://localhost:44353/WebForm1.aspx");
        }
    }
}
