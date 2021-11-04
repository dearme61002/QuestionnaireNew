using lom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class Backstage14 : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        // Add three columns in datatable and their names and data types
      

        //AddButton2_Click


        //
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //送出寫出資料庫按鈕
            //讀資料1
            string Title_Add = TextBox2Title.Text;
            string M_summary_Add = TextBoxM_summary.Text;
            DateTime start_time_Add = Convert.ToDateTime(txtStartDate.Text);
            DateTime end_time_Add = Convert.ToDateTime(txtEndDate.Text);
            //讀資料

        }

        protected void AddButton2_Click(object sender, EventArgs e)
        {
            //ghhg

           



            //

            //寫入資料
            p15 myp15s2 = (p15)Session["mydata"];
            string value_type;
            switch (D1_type_DropDownList.SelectedValue)
            {
                case "RB"://單選選(RadioButton)
                    value_type = "單選題";
                    break;
                case "CB"://複選(checkboxlist)
                    value_type = "複選題";
                    break;

                default:
                    value_type = "文字框";
                    break;
            }
            
            myp15s2.setp15_data(D1_title_TextBox.Text, value_type);
            Session["mydata"]= myp15s2;

            //寫入資料
            ////GridView1這邊是用舊的技術 上面是改良
            //DataTable dt = new DataTable();

            ////// Add three columns in datatable and their names and data types
            //dt.Columns.Add(new DataColumn("#", typeof(int)));
            //dt.Columns.Add(new DataColumn("問題", typeof(string)));
            //dt.Columns.Add(new DataColumn("種類", typeof(string)));
            //dt.Columns.Add(new DataColumn("必須", typeof(Boolean)));


            //// Add five records in datatable
            ////for (int i = 0; i < 5; i++)
            ////{
            ////    dt.Rows.Add(i, "Name" + i, "Country" + i);
            ////}
            //for (int i = 0; i < D1_title.Count; i++)
            //{
            //    dt.Rows.Add(i, D1_title[i], D1_typelist[i], true);
            //}


            //GridView1.DataSource = dt; // set your datatable to your gridview as datasource
            //GridView1.DataBind(); // bind the gridview with datasource
            //資料讀取 
            ////調轉到tab02
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
            //調轉到tab02

            GridView1.DataBind();

        }

        protected void GridView1_CallingDataMethods(object sender, CallingDataMethodsEventArgs e)
        {
            p15 ss = (p15)Session["mydata"];
            if (ss != null)
            {

                e.DataMethodsObject = ss;
            }
            else
            {
                p15 p15 = new p15();
                e.DataMethodsObject = p15;
                Session["mydata"] = p15;
            }
            //#號製作
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label inner_one_Label = (Label)GridView1.Rows[i].FindControl("Grid_inner_one");
                inner_one_Label.Text = i.ToString();
            }
            //#號製


            //編輯功能
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                HyperLink ChangeHyperLink3 = (HyperLink)GridView1.Rows[i].FindControl("ChangeHyperLink3");
                ChangeHyperLink3.NavigateUrl = "http://www.microsoft.com?id=" + i;//應後要改]
            }

            //編輯功能

            //DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_DataBinding(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            
        }
    }
}