using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID19
{
    public partial class Form4 : Form
    {

        public Form4(string fn, string ln, string pn, string sx, string brday, string ill, string em, string ad, string dt)
        {
            InitializeComponent();
            label2.Text = "Όνομα: " +fn;
            label3.Text = "Επώνυμο: " +ln;
            label4.Text = "Τηλέφωνο Επικοινωνίας: " +pn;
            label5.Text = "Φύλλο: " +sx;
            label6.Text = "Ημερομηνία Γέννησης: " +brday;
            label7.Text = "Νόσημα: " +ill;
            label8.Text = "Email: " +em;
            label9.Text = "Διεύθυνση: " +ad;
            label10.Text = "Ημερονηνία καταχώρισης: " +dt;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
