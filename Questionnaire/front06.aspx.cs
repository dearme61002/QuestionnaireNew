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
    public partial class front06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["passworld_my"] != "OK" )
                {
                    Response.Redirect("Index.aspx");
                }

                    GridView1.DataSourceID = "SqlDataSourceALL";
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
                //關閉開啟表單
                string sql_open_state = "select * from Question_M";
                SqlDataReader sqlDataReader_open = sqlhelp.executeReadesql(sql_open_state);
                if (sqlDataReader_open.HasRows)
                {
                    int i = 0;
                    while (sqlDataReader_open.Read())
                    {
                        if (GridView1.Rows[i].Cells[0].Text == sqlDataReader_open["M_id"].ToString())
                        {
                            if (!(Boolean)sqlDataReader_open["M_open"])
                            {
                                HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                                dd.NavigateUrl = string.Empty;

                            }

                        }
                        i++;
                    }
                }
                ////關閉開啟表單
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            //驗證



            //驗證



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
            GridView1.DataBind();
            //關閉開啟表單
            string sql_open_state = "select * from Question_M  where M_open=0";
            SqlDataReader sqlDataReader_open = sqlhelp.executeReadesql(sql_open_state);
            if (sqlDataReader_open.HasRows)
            {
                List<string> ffdd_dds = new List<string>();
                while (sqlDataReader_open.Read())
                {
                    ffdd_dds.Add(sqlDataReader_open["M_id"].ToString());
                }

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {


                    // string fdf = sqlDataReader_open["M_id"].ToString();
                    try
                    {

                        foreach (var item in ffdd_dds)
                        {
                            if (GridView1.Rows[i].Cells[0].Text == item)
                            {
                               
                                    HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                                    dd.NavigateUrl = string.Empty;
                                
                            }
                        }



                    }
                    catch (Exception f)
                    {


                    }
                }
            }
            ////關閉開啟表單


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
            //關閉開啟表單
            string sql_open_state = "select * from Question_M";
            SqlDataReader sqlDataReader_open = sqlhelp.executeReadesql(sql_open_state);
            if (sqlDataReader_open.HasRows)
            {
                int i = 0;
                while (sqlDataReader_open.Read())
                {
                    if (GridView1.Rows[i].Cells[0].Text == sqlDataReader_open["M_id"].ToString())
                    {
                        if (!(Boolean)sqlDataReader_open["M_open"])
                        {
                            HyperLink dd = (HyperLink)GridView1.Rows[i].FindControl("HyperLink1");
                            dd.NavigateUrl = string.Empty;
                        }

                    }
                    i++;
                }
            }
            ////關閉開啟表單
        }
    }
}