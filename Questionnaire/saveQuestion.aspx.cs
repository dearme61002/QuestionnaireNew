using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class saveQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Add_Click(object sender, EventArgs e)
        {
            string name = TextBox1_name.Text;
            string question = TextBox2_question.Text;
            string answer = TextBox1_answer.Text;
            string type = DropDownList1_type.SelectedValue;
            string sql_add = "INSERT INTO My_save (save_name,save_question,save_answer,save_type)values(@save_name,@save_question,@save_answer,@save_type)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@save_name",name),
                new SqlParameter("@save_question",question),
                new SqlParameter("@save_answer",answer),
                new SqlParameter("@save_type",type)
            };
            sqlhelp.executeNonQuerysql(sql_add,sqlParameters,false);
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
                     
            //  Label mytype_label =  (Label)GridView1.Rows[i].FindControl("My_type");
            //    string Mytype_value = GridView1.Rows[i].Cells[0].Text;
            //    string value_type=string.Empty;
            //    switch (Mytype_value)
            //    {
            //        case "RB"://單選選(RadioButton)
            //            value_type = "單選題";
            //            break;
            //        case "CB"://複選(checkboxlist)
            //            value_type = "複選題";
            //            break;

            //        default:
            //            value_type = "文字框";
            //            break;
            //    }
            //    mytype_label.Text = value_type;
            //}
            GridView1.DataBind();
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                //要隱藏的欄位    
                e.Row.Cells[0].Visible = false;
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                Label mytype_label = (Label)GridView1.Rows[i].FindControl("My_type");
                string Mytype_value = GridView1.Rows[i].Cells[0].Text.Replace(" ", String.Empty); ;
                string value_type = string.Empty;
                switch (Mytype_value)
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
                mytype_label.Text = value_type;
            }
 

        }
    }
}