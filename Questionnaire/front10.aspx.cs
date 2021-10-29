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
            string getM_id = Request.QueryString["M_id"];//??
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
            SqlDataReader sqlDataReader = sqlhelp.executeReadesql(sql, sqlParameters, false);
            sqlDataReader.Read();
            LabelTitle.Text = sqlDataReader["M_title"].ToString();
            LabelM_summary.Text = sqlDataReader["M_summary"].ToString();
            sqlDataReader.Close();
            //取問題資料
            sql = "select count(1) from Question_D1 where M_id = @M_id";
            SqlParameter[] sqlParameters2 = new SqlParameter[]
            {
                new SqlParameter("@M_id",getM_id)
            };
            countQuestion_D1 = Convert.ToInt32(sqlhelp.executeScalarsql(sql, sqlParameters2, false));
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
                    cstext1.Append("<div id='piechart_" + i + "' style='width: 900px; height: 500px; ' ></div>");//html
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
                //取 Answer_M的AMID值用來統計
                string sqlAnswer_M = "select AM_id from Answer_M where M_id =@M_id";
                SqlParameter[] sqlAnswer_Ms = new SqlParameter[]
                {
                    new SqlParameter("@M_id",getM_id)
                };
                SqlDataReader DBAM_AD = sqlhelp.executeReadesql(sqlAnswer_M, sqlAnswer_Ms, false);
                List<string> AM_id = new List<string>();//統計用
                if (DBAM_AD.HasRows)
                {
                    while (DBAM_AD.Read())
                    {
                        AM_id.Add(DBAM_AD["AM_id"].ToString());
                    }

                }
                //取 Answer_M的AMID值用來統計
                for (int i = 0; i < countQuestion_D1; i++) //javascript
                {
                    //取D1_title與D1_id與D1_type


                    DBQuestion_D1.Read();
                    D1_title = DBQuestion_D1["D1_title"].ToString();
                    //
                    //抓選項的值的
                    string sqlQuestion_D2 = "select * from Question_D2 where M_id =@M_id and D1_id=@D1_id";
                    SqlParameter[] parameterssqlQuestion_D2 = new SqlParameter[]
                    {
                        new SqlParameter("@M_id",getM_id),
                        new SqlParameter("@D1_id",DBQuestion_D1["D1_id"].ToString())
                    };
                    SqlDataReader sqlDataReader_Question_D2 = sqlhelp.executeReadesql(sqlQuestion_D2, parameterssqlQuestion_D2, false);


                    string answer_D2 = string.Empty;
                    string[] answer_D2s = { };
                    if (sqlDataReader_Question_D2.HasRows)
                    {
                        sqlDataReader_Question_D2.Read();
                        answer_D2 = sqlDataReader_Question_D2["answer"].ToString();
                        answer_D2s = answer_D2.Split(';');
                    }
                    if (DBQuestion_D1["D1_type"].ToString() == "RB")//只統計單選題
                    {

                        //抓選項的值的
                        cstext1.Append("google.charts.load('current', {packages:['corechart']});");
                        cstext1.Append("google.charts.setOnLoadCallback(drawChart" + i + ");");
                        cstext1.Append("function drawChart" + i + "() {");
                        cstext1.Append("var data = google.visualization.arrayToDataTable([");
                        cstext1.Append("['Task', 'Hours per Day'],");
                        //跑回圈

                        for (int j = 0; j < answer_D2s.Count(); j++)
                        {
                            String ddd = DBQuestion_D1["D1_type"].ToString();




                            //統計
                            int count = 0;

                            for (int aa = 0; aa < AM_id.Count; aa++)
                            {
                                string sqlAnswer_D1_answer = "select count(1) from Answer_D1 where D1_id=@D1_id and AM_id=@AM_id and Answer=@Answer";
                                SqlParameter[] sqlParameterssqlAnswer_D1_answer = new SqlParameter[]
                                {
                                new SqlParameter("@AM_id",AM_id[aa]),
                                new SqlParameter("@D1_id",DBQuestion_D1["D1_id"].ToString()),
                                new SqlParameter("@Answer",answer_D2s[j])
                                };

                                count = count + Convert.ToInt32(sqlhelp.executeScalarsql(sqlAnswer_D1_answer, sqlParameterssqlAnswer_D1_answer, false));
                            }
                            //統計





                            cstext1.Append("['" + answer_D2s[j] + "'," + count + "]");
                            if (j < answer_D2s.Count() - 1)
                            {
                                cstext1.Append(",");
                            };




                        }
                        //跑回圈
                        cstext1.Append(" ]);");
                        cstext1.Append("var options = {title: '" + D1_title + "',is3D: true,}; ");//設定主題
                        cstext1.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_" + i + "'));");
                        cstext1.Append("chart.draw(data, options);}");
                    }
                     else if(DBQuestion_D1["D1_type"].ToString() == "TB")
                    {
                        cstext1.Append("document.getElementById('piechart_" + i + "').innerHTML='題目:"+ D1_title + "  (因為是文字方塊題所以不能統計)';");
                        cstext1.Append("document.getElementById('piechart_" + i + "').style.height='50px';");
                        cstext1.Append("document.getElementById('piechart_" + i + "').style.textAlign='center';");

                    }else if(DBQuestion_D1["D1_type"].ToString() == "CB")//複選
                    {
                        cstext1.Append("google.charts.load('current', {packages:['corechart']});");
                        cstext1.Append("google.charts.setOnLoadCallback(drawChart" + i + ");");
                        cstext1.Append("function drawChart" + i + "() {");
                        cstext1.Append("var data = google.visualization.arrayToDataTable([");
                        cstext1.Append("['Task', 'Hours per Day'],");
                        //跑回圈

                        for (int j = 0; j < answer_D2s.Count(); j++)
                        {
                            String ddd = DBQuestion_D1["D1_type"].ToString();




                            //統計
                            int count = 0;
                            string ALLAnswer_D1_answer = string.Empty;
                            for (int aa = 0; aa < AM_id.Count; aa++)
                            {
                                string sqlAnswer_D1_answer = "select Answer from Answer_D1 where D1_id=@D1_id and AM_id=@AM_id";
                                SqlParameter[] sqlParameterssqlAnswer_D1_answer = new SqlParameter[]
                                {
                                new SqlParameter("@AM_id",AM_id[aa]),
                                new SqlParameter("@D1_id",DBQuestion_D1["D1_id"].ToString()),
                                };

                                ALLAnswer_D1_answer = ALLAnswer_D1_answer + sqlhelp.executeScalarsql(sqlAnswer_D1_answer, sqlParameterssqlAnswer_D1_answer, false).ToString();
                            }
                            string[] ALLAnswer_D1_answerALL= ALLAnswer_D1_answer.Split(';');
                            foreach (var item in ALLAnswer_D1_answerALL)
                            {
                                if(item == answer_D2s[j])
                                {
                                    count = count+1;
                                }
                            }
                            //統計





                            cstext1.Append("['" + answer_D2s[j] + "'," + count + "]");
                            if (j < answer_D2s.Count() - 1)
                            {
                                cstext1.Append(",");
                            };




                        }
                        //跑回圈
                        cstext1.Append(" ]);");
                        cstext1.Append("var options = {title: '" + D1_title + "',is3D: true,}; ");//設定主題
                        cstext1.Append("var chart = new google.visualization.PieChart(document.getElementById('piechart_" + i + "'));");
                        cstext1.Append("chart.draw(data, options);}");



                    }


                    //跑大回圈
                    ////


                }

                cstext1.Append("</script>");

                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("front06.aspx");
        }
    }
}
