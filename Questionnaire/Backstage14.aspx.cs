﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class Backstage14 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //送出寫出資料庫按鈕
            //讀資料1
            string Title_Add = TextBox2Title.Text;
            string M_summary_Add = TextBoxM_summary.Text;
            DateTime start_time_Add = Convert.ToDateTime(txtStartDate.Text) ;
            DateTime end_time_Add = Convert.ToDateTime(txtEndDate.Text);
            //讀資料
            
        }

        protected void AddButton2_Click(object sender, EventArgs e)
        {
            //讀資料2
            string D1_title = D1_title_TextBox.Text;
            string D1_type = D1_type_DropDownList.SelectedValue;
            Boolean D1_mustKeyin = D1_mustKeyin_CheckBox.Checked;
            //讀資料
            //讀資料3
            string answer = answer_TextBox.Text;
            // 讀資料

            //GridView1
            //DataTable dt = new DataTable();

            // Add three columns in datatable and their names and data types
            dt.Columns.Add(new DataColumn("id", typeof(int)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("country", typeof(string)));

            // Add five records in datatable
            for (int i = 0; i < 5; i++)
            {
                dt.Rows.Add(i, "Name" + i, "Country" + i);
            }

            GridView1.DataSource = dt; // set your datatable to your gridview as datasource
            GridView1.DataBind(); // bind the gridview with datasource
            //
            String csname1 = "PopupScript";
            Type cstype = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(cstype, csname1))
            {
                StringBuilder cstext1 = new StringBuilder();
                cstext1.Append("<script type=text/javascript> document.getElementById('tab01').style.display = 'none'; document.getElementById('tab02').style.display = 'block'; document.getElementById('litab01top').style.borderBottom = '1px solid #BCBCBC';document.getElementById('litab01top').style.backgroundColor = '#BCBCBC';document.getElementById('litab02top').style.borderBottom = 'none';document.getElementById('litab02top').style.backgroundColor = 'white';  </");
                cstext1.Append("script>");

                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
            }




        }
    }
}