﻿using lom;
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
        //DataTable dt = new DataTable();
        // Add three columns in datatable and their names and data types
        

        //AddButton2_Click


        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {  
                if (Request.QueryString["Change_id"] != null)
            {//編寫功能
                string my_chang_value = Request.QueryString["Change_id"];
                //取得資料
                p15 myp15s4 = (p15)Session["mydata"];
                int i_my_chang_value = Convert.ToInt32(my_chang_value);
                //接著寫 取值 給值
                p15 my_get_p15 = myp15s4.getp15_At_data(i_my_chang_value);
                    //button_edit_chang_i = i_my_chang_value;
                   Session["button_edit_chang_i"] = i_my_chang_value;
                D1_title_TextBox.Text = my_get_p15.問題;
                answer_TextBox.Text = my_get_p15.回答;
                D1_mustKeyin_CheckBox.Checked = my_get_p15.必須;

                switch (my_get_p15.種類)
                {
                    case "單選題"://單選選(RadioButton)
                        D1_type_DropDownList.SelectedValue = "RB";
                        break;
                    case "複選題"://複選(checkboxlist)
                        D1_type_DropDownList.SelectedValue = "CB";
                        break;

                    default:
                        D1_type_DropDownList.SelectedValue = "TB";
                        break;
                }

                AddButton2.Text = "更改";

            }
          
                //接著寫 取值 給值


            }


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
            if(AddButton2.Text == "加入")
            {
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
            
            myp15s2.setp15_data(D1_title_TextBox.Text, value_type, answer_TextBox.Text, D1_mustKeyin_CheckBox.Checked);

            Session["mydata"]= myp15s2;

            //寫入資料
            }
   
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
            if (AddButton2.Text == "更改")
            {
                //跟新資料更改 
                p15 myp15s3 = (p15)Session["mydata"];
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
                string ddd= D1_title_TextBox.Text;
                int tttttt = (int)Session["button_edit_chang_i"];
                myp15s3.changp15_data(tttttt, D1_title_TextBox.Text, value_type, answer_TextBox.Text, D1_mustKeyin_CheckBox.Checked);
            
                Session["mydata"] = myp15s3;
                AddButton2.Text = "加入";



            }




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
                ChangeHyperLink3.NavigateUrl = "Backstage14.aspx?Change_id=" + i;//應後要改]
                
            }

            //編輯功能
            //編輯功能02
            


            //編輯功能02
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

        protected void Button2_Click(object sender, EventArgs e)
        {

            //刪除int i=list.Count-1;i>=0;i--
            p15 myp15s2 = (p15)Session["mydata"];//先取出值
            for (int i = GridView1.Rows.Count-1; i >=0; i--)//要使用到續法刪除
            {
              CheckBox checkBox_Delete = (CheckBox)GridView1.Rows[i].FindControl("GridView_CheckBox2");
            if (checkBox_Delete.Checked == true)
            {
                    //刪除資料
                   
                    myp15s2.deletep15_data(i);
                }
            }
            Session["mydata"] = myp15s2;
            //刪除
            GridView1.DataBind();
        }
    }
}