using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COVID19_STATS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SQLiteConnection conn;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            string cs = @"URI=file:C:\Users\evriv\Downloads\COVID19\COVID19\bin\Debug\DBb.db";
            conn = new SQLiteConnection(cs);
            conn.Open();
            SQLiteCommand mycommand = new SQLiteCommand();
            mycommand.Connection = conn;
            mycommand.CommandText = "Select * from COVID";
            using (SQLiteDataReader read = mycommand.ExecuteReader())
            {
                DataTable myDataTable = new DataTable();
                myDataTable.Load(read);
                read.Close();
                conn.Close();
                GridView1.DataSource = myDataTable;
                GridView1.DataBind();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GridView1.Visible = true;
        }
        }
}