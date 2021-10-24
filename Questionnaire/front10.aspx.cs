using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class front10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取資料
            //int getM_id = Request.QueryString["M_id"];//等等使用
            int getM_id = 1;
            string title = string.Empty;
            int countTitle = 0;


            //取主題
            string sql = "SELECT top 1 M_title from Question_M where M_id = @M_id ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@M_id",getM_id)
             };
            title = sqlhelp.executeScalarsql(sql, sqlParameters, false).ToString();

            //取資料


            // Define the name and type of the client scripts on the page.
            String csname1 = "PopupScript";
                Type cstype = this.GetType();

                // Get a ClientScriptManager reference from the Page class.
                ClientScriptManager cs = Page.ClientScript;

                // Check to see if the startup script is already registered.
                if (!cs.IsStartupScriptRegistered(cstype, csname1))
                {

                    StringBuilder cstext1 = new StringBuilder();
                ///
                cstext1.Append("<div id='piechart_3d' style='width: 900px; height: 500px; ' ></div>");//html
                cstext1.Append("<div id='piechart_2d' style='width: 900px; height: 500px; ' ></div>");//html
                cstext1.Append("<script type=text/javascript>");
                cstext1.Append("google.charts.load('current', {packages:['corechart']});");
                cstext1.Append("google.charts.setOnLoadCallback(drawChart);");
                cstext1.Append("function drawChart() {");
                cstext1.Append("var data = google.visualization.arrayToDataTable([");
                cstext1.Append("['Task', 'Hours per Day'],");
                cstext1.Append("['Work',     11]");
                cstext1.Append(" ]);");
                cstext1.Append("var options = {title: '"+title+ "',is3D: true,}; ");//設定主題
                cstext1.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));");
                cstext1.Append("chart.draw(data, options);}");


                ////
                cstext1.Append("google.charts.load('current', {packages:['corechart']});");
                cstext1.Append("google.charts.setOnLoadCallback(drawChart2);");
                cstext1.Append("function drawChart2() {");
                cstext1.Append("var data = google.visualization.arrayToDataTable([");
                cstext1.Append("['Task', 'Hours per Day'],");
                cstext1.Append("['Work',     11]");
                cstext1.Append(" ]);");
                cstext1.Append("var options = {title: '" + title + "wqwqw',is3D: true,}; ");//設定主題
                cstext1.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_2d'));");
                cstext1.Append("chart.draw(data, options);}");



                cstext1.Append("</script>");

                    cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
                }


            }
        }
    }
