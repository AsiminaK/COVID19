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
    public partial class Form3 : Form
    {
        String connectionString = "Data Source=DBb.db;Version=3;";
        SQLiteConnection conn;
        string sex;
        string illness = "ΧΩΡΙΣ ΥΠΟΚΕΙΜΕΝΟ ΝΟΣΗΜΑ";
        string covidtime;
        string myusername;
        

        public Form3(string username)
        {
            InitializeComponent();
            myusername = username;
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = new DateTime(1998, 5, 1);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                illness = textBox6.Text;
            }
            DateTime birthday;
            birthday = dateTimePicker1.Value;
            covidtime = DateTime.Now.ToString();

            conn.Open();
            String insertQuery = "Insert into COVID(FirstName,LastName,Phonenumber,Sex,Birthday,Illness,Email,Adress,Date) values('" + textBox1.Text + 
                "','" + textBox2.Text + "','" + textBox3.Text + 
                "','" + sex + "','" + birthday.ToString() + "','" 
                + illness + "','" + textBox7.Text + "','" 
                + textBox8.Text + "','" + covidtime + "')";
            SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Το νέο κρούσμα καταχωρήθηκε επιτυχώς!");
            conn.Close();


            DialogResult dialogResult = MessageBox.Show("Εάν όχι θα οδηγηθείτε στην αρχική σελίδα!", "Θέλετε να παραμείνετε στη σελίδα καταχώρισης κρουσμάτων;", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                Form2 myForm = new Form2(myusername);
                this.Hide();
                myForm.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 myForm = new Form2(myusername);
            this.Hide();
            myForm.ShowDialog();
            this.Close();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox3.Checked)
            {
                textBox6.Visible = true;
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
            if (checkBox2.Checked)
            {
                sex = "Γυναίκα";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            CovidCases myCases = new CovidCases(textBox1.Text, textBox2.Text,"","");
            richTextBox1.Text += "Όνομα: " + myCases.name + " || Επώνυμο: " + myCases.lastname + Environment.NewLine;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

    }
}
