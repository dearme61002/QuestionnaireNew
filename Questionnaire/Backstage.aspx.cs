using System;
using System.Collections.Generic;
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
                        state.Text = "已關閉";
                    }
                    else
                    {
                        Label state = (Label)GridView1.Rows[i].FindControl("state");
                        state.Text = "已開放";
                    }
                }



            }
        }
    }
}