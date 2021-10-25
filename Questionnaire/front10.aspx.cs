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
            int countQuestion_D1 = 0;
            string M_summary = string.Empty;
            string D1_title = string.Empty;

            //取主題
            string sql = "SELECT top 1 M_title,M_summary from Question_M where M_id = @M_id ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@M_id",getM_id)
             };
            SqlDataReader sqlDataReader= sqlhelp.executeReadesql(sql, sqlParameters, false);
            sqlDataReader.Read();
            LabelTitle.Text = sqlDataReader["M_title"].ToString();
            LabelM_summary.Text= sqlDataReader["M_summary"].ToString();
            sqlDataReader.Close();
            //取問題資料
            sql = "select count(1) from Question_D1 where M_id = @M_id";
            SqlParameter[] sqlParameters2 = new SqlParameter[]
            {
                new SqlParameter("@M_id",getM_id)
            };
            countQuestion_D1 =Convert.ToInt32(sqlhelp.executeScalarsql(sql, sqlParameters2, false));
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
                //跑大回圈
                ///
                for (int i = 0; i < countQuestion_D1; i++)
                {
                cstext1.Append("<div id='piechart_"+i+"' style='width: 900px; height: 500px; ' ></div>");//html
                }
                cstext1.Append("<script type=text/javascript>");
                //取D1_title與D1_id與D1_type
                string sqlQuestion_D1 = "select * from Question_D1 where M_id =@M_id";
                    SqlParameter[] parameterssqlQuestion_D1 = new SqlParameter[]
                    {
                        new SqlParameter("@M_id",getM_id)
                    };
                 SqlDataReader DBQuestion_D1 = sqlhelp.executeReadesql(sqlQuestion_D1, parameterssqlQuestion_D1, false);
                //取D1_title與D1_id與D1_type
                for (int i = 0; i < countQuestion_D1; i++)
                {
                    //取D1_title與D1_id與D1_type
                    
                    
                    DBQuestion_D1.Read();
                    D1_title = DBQuestion_D1["D1_title"].ToString();

                cstext1.Append("google.charts.load('current', {packages:['corechart']});");
                cstext1.Append("google.charts.setOnLoadCallback(drawChart"+i+");");
                cstext1.Append("function drawChart"+i+"() {");
                cstext1.Append("var data = google.visualization.arrayToDataTable([");
                cstext1.Append("['Task', 'Hours per Day'],");
                //跑回圈
                cstext1.Append("['Work',     11]");
                //跑回圈
                cstext1.Append(" ]);");
                cstext1.Append("var options = {title: '"+D1_title+ "',is3D: true,}; ");//設定主題
                cstext1.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_" + i + "'));");
                cstext1.Append("chart.draw(data, options);}");
                }


                //跑大回圈
                ////




                cstext1.Append("</script>");

                    cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
                }


            }
        }
    }
