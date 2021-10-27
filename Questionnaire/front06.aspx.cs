using System;
using System.Collections.Generic;
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
                


            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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