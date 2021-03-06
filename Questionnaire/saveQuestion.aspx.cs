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
            if (Session["passworld_my"] != "OK")
            {
                Response.Redirect("Index.aspx");
            }
        }

        protected void Button1_Add_Click(object sender, EventArgs e)
        {
            //驗證
            if(TextBox1_name.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script> alert('常用問題選項名子沒填');</script>");

                return;
            }else if(TextBox2_question.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script> alert('問題沒填');</script>");

                return;
            }else if(TextBox1_answer.Text.Trim() == string.Empty)
            {
                ClientScript.RegisterStartupScript(GetType(), "message", "<script> alert('回答沒填');</script>");

                return;
            }



            //驗證

            string name = TextBox1_name.Text.Trim();
            string question = TextBox2_question.Text.Trim();
            string answer = TextBox1_answer.Text.Trim();
            string type = DropDownList1_type.SelectedValue;
            string sql_add = "INSERT INTO My_save (save_name,save_question,save_answer,save_type)values(@save_name,@save_question,@save_answer,@save_type)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@save_name",name),
                new SqlParameter("@save_question",question),
                new SqlParameter("@save_answer",answer),
                new SqlParameter("@save_type",type)
            };
            sqlhelp.executeNonQuerysql(sql_add, sqlParameters, false);
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
                string Mytype_value = GridView1.Rows[i].Cells[0].Text.Replace(" ", String.Empty); 
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //試試不一樣的解法
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string sql = "DELETE FROM My_save WHERE save_id=@save_id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@save_id",id)
             };
            sqlhelp.executeNonQuerysql(sql, sqlParameters, false);
         }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
    }
}