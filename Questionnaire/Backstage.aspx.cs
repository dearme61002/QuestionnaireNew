using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class Backstage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //開放
               if(Request.QueryString["open_state"]!=null & Request.QueryString["M_id"]!=null)
                {
                    string get_open = Request.QueryString["open_state"];
                    string get_M_id = Request.QueryString["M_id"];
                    if(get_open== "open")
                    {
                        string change_open_sql = "Update Question_M Set M_open= 0 where M_id=@M_id";
                        SqlParameter[] sqlParameters_change_open = new SqlParameter[]
                        {
                            new SqlParameter("@M_id",get_M_id)
                        };
                        sqlhelp.executeNonQuerysql(change_open_sql, sqlParameters_change_open, false);

                    }
                    else
                    {
                        string change_open_sql = "Update Question_M Set M_open= 1 where M_id=@M_id";
                        SqlParameter[] sqlParameters_change_open = new SqlParameter[]
                        {
                            new SqlParameter("@M_id",get_M_id)
                        };
                        sqlhelp.executeNonQuerysql(change_open_sql, sqlParameters_change_open, false);
                    }
                }
                //開放

                GridView1.DataSourceID = "SqlDataSourceALL";
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    DateTime lastTime = DateTime.Parse(((Label)GridView1.Rows[i].FindControl("Label1")).Text);
                    if (DateTime.UtcNow > lastTime)
                    {
                        //HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                        //dd.NavigateUrl = string.Empty;
                        Label state = (Label)GridView1.Rows[i].FindControl("state");
                        state.Text = "已完結";
                    }
                    else
                    {
                        Label state = (Label)GridView1.Rows[i].FindControl("state");
                        state.Text = "投票中";
                    }
                }
                //開放
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    string my_min = GridView1.Rows[i].Cells[1].Text;
                    string opensql = "select M_open from Question_M where M_id=@M_id";
                    SqlParameter[] sqlParameters_open = new SqlParameter[]
                    {
                        new SqlParameter("M_id",my_min)
                    };
                    Boolean open_bool = Convert.ToBoolean(sqlhelp.executeScalarsql(opensql, sqlParameters_open, false));
                    if (open_bool)
                    {
                        //HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                        //dd.NavigateUrl = string.Empty;
                        HyperLink hyperLink_open = (HyperLink)GridView1.Rows[i].FindControl("HyperLink_open");
                        hyperLink_open.NavigateUrl = "Backstage.aspx?open_state=open&"+"M_id="+my_min;
                        hyperLink_open.Text = "開放";
                    }
                    else
                    {
                        HyperLink hyperLink_open = (HyperLink)GridView1.Rows[i].FindControl("HyperLink_open");
                        hyperLink_open.NavigateUrl = "Backstage.aspx?open_state=close&" + "M_id=" + my_min;
                        hyperLink_open.Text = "關閉";
                    }
                }
                //
            }

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            List<object> parameters = new List<object>();
            List<Object> parameters_value = new List<object>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox checkBox_Delete = (CheckBox)GridView1.Rows[i].FindControl("CheckBox1");
                if (checkBox_Delete.Checked == true)
                {
                    parameters.Add("@M_id");
                    parameters_value.Add(GridView1.Rows[i].Cells[1].Text);
                }

            }
            if (parameters.Count != 0)
            {
                for (int i = 0; i < parameters_value.Count; i++)
                {
                    //刪除問題
                    string sql = "DELETE FROM Question_M WHERE M_id = @M_id";
                    SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                    new SqlParameter("@M_id",parameters_value[i].ToString())

                    };
                    sqlhelp.executeNonQuerysql(sql, sqlParameters, false);

                    sql = "DELETE FROM Question_D1 WHERE M_id = @M_id";
                    SqlParameter[] sqlParameters2 = new SqlParameter[]
                    {
                    new SqlParameter("@M_id",parameters_value[i].ToString())

                    };
                    sqlhelp.executeNonQuerysql(sql, sqlParameters2, false);

                    sql = "DELETE FROM Question_D2 WHERE M_id = @M_id";
                    SqlParameter[] sqlParameters3 = new SqlParameter[]
                    {
                    new SqlParameter("@M_id",parameters_value[i].ToString())

                    };
                    sqlhelp.executeNonQuerysql(sql, sqlParameters3, false);
                    //刪除問題
                    //刪除回答
                    sql = "select AM_id from Answer_M WHERE M_id = @M_id";
                    SqlParameter[] sqlParameters5 = new SqlParameter[]
                    {
                    new SqlParameter("@M_id",parameters_value[i].ToString())

                    };
                    SqlDataReader sqlData = sqlhelp.executeReadesql(sql, sqlParameters5, false);
                    List<string> AM_IDList = new List<string>();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            AM_IDList.Add(sqlData["AM_id"].ToString());
                        }
                    };
                    sqlData.Close();
                    foreach (string item in AM_IDList)
                    {
                        sql = "DELETE FROM  Answer_D1 WHERE AM_id = @AM_id";
                        SqlParameter[] getsqlpar = new SqlParameter[]
                        {
                        new SqlParameter("@AM_id",item)
                        };
                        sqlhelp.executeNonQuerysql(sql, getsqlpar, false);

                    }
                    //AM_ID D1 刪除好了
                    sql = "DELETE FROM  Answer_M  WHERE M_id = @M_id";
                    SqlParameter[] sqlParameters4 = new SqlParameter[]
                    {
                    new SqlParameter("@M_id",parameters_value[i].ToString())

                    };
                    sqlhelp.executeNonQuerysql(sql, sqlParameters4, false);

                    //刪除回答
                   
                }



            }
            //刪除成功
            //賦歸
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                DateTime lastTime = DateTime.Parse(((Label)GridView1.Rows[i].FindControl("Label1")).Text);
                if (DateTime.UtcNow > lastTime)
                {
                    //HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                    //dd.NavigateUrl = string.Empty;
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "已完結";
                }
                else
                {
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "投票中";
                }
            }

        }

        protected void ADDButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Backstage14.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBoxSearch.Text == string.Empty && txtStartDate.Text == string.Empty && txtEndDate.Text == string.Empty)
            {
                GridView1.DataSourceID = "SqlDataSourceALL";
            }
            else if (TitleTextBoxSearch.Text != string.Empty && txtStartDate.Text == string.Empty && txtEndDate.Text == string.Empty)
            {
                GridView1.DataSourceID = "SqlDataSource1";
            }
            else if (TitleTextBoxSearch.Text == string.Empty && txtStartDate.Text != string.Empty && txtEndDate.Text != string.Empty)
            {
                GridView1.DataSourceID = "SqlDataSourceTIME";
            }
            else if (TitleTextBoxSearch.Text != string.Empty && txtStartDate.Text != string.Empty && txtEndDate.Text != string.Empty)
            {
                GridView1.DataSourceID = "SqlDataSourcefalst";

            }
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                DateTime lastTime = DateTime.Parse(((Label)GridView1.Rows[i].FindControl("Label1")).Text);
                if (DateTime.UtcNow > lastTime)
                {
                    //HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                    //dd.NavigateUrl = string.Empty;
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "已完結";
                }
                else
                {
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "投票中";
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            TitleTextBoxSearch.Text = string.Empty;
            txtStartDate.Text = string.Empty;
            txtEndDate.Text = string.Empty;
            GridView1.DataSourceID = "SqlDataSourceALL";
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                DateTime lastTime = DateTime.Parse(((Label)GridView1.Rows[i].FindControl("Label1")).Text);
                if (DateTime.UtcNow > lastTime)
                {
                    HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                    dd.NavigateUrl = string.Empty;
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "已完結";
                }
                else
                {
                    Label state = (Label)GridView1.Rows[i].FindControl("state");
                    state.Text = "投票中";
                }
            }
        }
    }
}