using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID19
{

    public partial class Form6 : Form
    {
        String connectionString = "Data Source=DBb.db;Version=3;";
        SQLiteConnection conn;

        List<CovidCases> covidCases = new List<CovidCases>();

        public Form6()
        {
            InitializeComponent();
        }

        public void showmydata()
        {

            conn.Open();
            String selectQuery = "select Sex, Count(*) FROM COVID GROUP BY Sex;";
            SQLiteCommand command = new SQLiteCommand(selectQuery, conn);
            using (SQLiteDataReader read = command.ExecuteReader())
            {
                DataTable myDataTable = new DataTable();
                myDataTable.Load(read);
                read.Close();
                conn.Close();
                foreach (DataRow dataRow in myDataTable.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {

                        CovidCases mycovidCases = new CovidCases("", "", item.ToString(), "");
                        covidCases.Add(mycovidCases);
                       
                    }
                }
            }

            for (int i = 0; i < covidCases.Count; i++)
            {
                if (i % 2 != 0)
                {
                    if (i < 2)
                    {
                        chart1.Series["ΑΝΔΡΕΣ"].Points.AddXY("", covidCases[i].sex);
                    }
                    else
                    {
                        chart1.Series["ΓΥΝΑΙΚΕΣ"].Points.AddXY("", covidCases[i].sex);
                    }
                }

            }

            conn.Open();
            String selectQuery2 = "select Birthday, Count(*) FROM COVID GROUP BY Sex;";
            SQLiteCommand command2 = new SQLiteCommand(selectQuery2, conn);
            using (SQLiteDataReader read2 = command2.ExecuteReader())
            {
                DataTable myDataTable2 = new DataTable();
                myDataTable2.Load(read2);
                read2.Close();
                conn.Close();
                foreach (DataRow dataRow in myDataTable2.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        //MessageBox.Show(item.ToString());
                        CovidCases mycovidCases = new CovidCases("", "", "",item.ToString());
                        covidCases.Add(mycovidCases);

                    }
                }
            }

            for (int i = 4; i < covidCases.Count; i++)
            {
                if (i % 2 != 0)
                {
                    chart2.Series["ΗΜΕΡΟΜΗΝΙΑ ΓΕΝΝΗΣΗΣ"].Points.AddXY(covidCases[i-1].birthday, covidCases[i].birthday);
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            conn = new SQLiteConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showmydata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
