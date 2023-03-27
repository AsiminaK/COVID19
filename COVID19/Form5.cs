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
    public partial class Form5 : Form
    {
        String connectionString = "Data Source=DBb.db;Version=3;";
        SQLiteConnection conn;
        string illness = "ΧΩΡΙΣ ΥΠΟΚΕΙΜΕΝΟ ΝΟΣΗΜΑ";
        string covidtime;
        string sex;
        string cbirthday;
        string startname;

        public Form5(bool del)
        {
            InitializeComponent();

            if (del == true)
            {
                panel1.Visible = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);

            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = new DateTime(1998, 5, 1);
            DateTime birthday;
            birthday = dateTimePicker2.Value;
            cbirthday = birthday.ToString();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            covidtime = DateTime.Now.ToString();

            conn.Open();
            string updateQuery = "update COVID set FirstName='" + textBox4.Text +
                "',LastName='" + textBox2.Text + "',Phonenumber='" + textBox3.Text + 
                "',Sex='" + sex + "',Birthday='" + cbirthday.ToString() +
                "',Illness='" + illness + "',Email='" + textBox7.Text + 
                "',Adress='" + textBox8.Text + "',Date='" + covidtime +
                "' where FirstName='" + startname + "'";
            SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn);
            int v = cmd.ExecuteNonQuery();
            MessageBox.Show(v.ToString()+".Το καταχωρημένο κρούσμα τροποποιήθηκε με επιτυχία!");
            conn.Close();

            DialogResult dialogResult = MessageBox.Show("Εάν όχι θα οδηγηθείτε στην αρχική σελίδα!", "Θέλετε να παραμείνετε στη σελίδα τροποποίησης κρουσμάτων;", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sex = "Άνδρας";
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                sex = "Γυναίκα";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            String selectQuery = "Select ID,LastName,Phonenumber,Sex,Birthday,Illness,Email,Adress,Date from COVID where FirstName='" + textBox4.Text + "'";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Υπάρχει καταχωρημένο κρούσμα συνεχίστε στην τροποιποίησή του!");
                startname = textBox4.Text;
                textBox4.Clear();
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει καταχωρημένο κρούσμα με αυτό το όνομα!");
                textBox4.Clear();
            }
            conn.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox6.Visible = true;
                illness = textBox6.Text;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            label4.Text = "Είστε σιγουροι ότι θέλετε να διαγράψετε\r\n το κρούσμα με όνομα " + textBox1.Text+";";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            conn.Open();
            string deleteQuery = "delete from COVID where FirstName='" + textBox1.Text + "'";
            SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn);
            int v = cmd.ExecuteNonQuery();
            MessageBox.Show(v.ToString() + ".Το καταχωρημένο κρούσμα διαγράφηκε με επιτυχία!");
            conn.Close();

            DialogResult dialogResult = MessageBox.Show("Εάν όχι θα οδηγηθείτε στην αρχική σελίδα!", "Θέλετε να παραμείνετε στη σελίδα διαγραφής κρουσμάτων;", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                panel1.Visible = false;
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.Close();
        }

    }
}
