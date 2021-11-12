using DAL;
using lom;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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
    public partial class Backstage17 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["M_id"] != null && Request.QueryString["AM_id"] != null)
                {
                    string answer_M_id = Request.QueryString["M_id"];
                    string answer_AM_id = Request.QueryString["AM_id"];
                    //List<string> answer_list = new List<string>();
                    ////取Answer
                    //string answer_d1_sql = "select Answer  from Answer_D1 where AM_id=@AM_id";
                    //SqlParameter[] sqlParameters_answer_d1 = new SqlParameter[]
                    //{
                    //    new SqlParameter("@AM_id",answer_AM_id)
                    //};
                    //SqlDataReader sqlDataReader_answer_d1 = sqlhelp.executeReadesql(answer_d1_sql, sqlParameters_answer_d1, false);

                    //if (sqlDataReader_answer_d1.HasRows)
                    //{
                    // while (sqlDataReader_answer_d1.Read())
                    //{
                    //        answer_list.Add(sqlDataReader_answer_d1["Answer"].ToString());
                    //}
                    //}
                    //固定問題
                    Label3.Visible = true;
                    Label4.Visible = true;
                    Label5.Visible = true;
                    Label6.Visible = true;

                    string sql_name = "select name from Answer_M where AM_id =@AM_id";
                    SqlParameter[] sqlParameters_name = new SqlParameter[]
                    {
                        new SqlParameter("@AM_id",answer_AM_id)
                    };
                    name.Text = sqlhelp.executeScalarsql(sql_name, sqlParameters_name, false).ToString();
                    name.Visible = true;
                    string sql_phone = "select phone from Answer_M where AM_id =@AM_id";
                    SqlParameter[] sqlParameters_phone = new SqlParameter[]
                    {
                        new SqlParameter("@AM_id",answer_AM_id)
                    };
                    phone.Text = sqlhelp.executeScalarsql(sql_phone, sqlParameters_phone, false).ToString();
                    phone.Visible = true;
                    string sql_email = "select email from Answer_M where AM_id =@AM_id";
                    SqlParameter[] sqlParameters_email = new SqlParameter[]
                    {
                        new SqlParameter("@AM_id",answer_AM_id)
                    };
                    email.Text = sqlhelp.executeScalarsql(sql_email, sqlParameters_email, false).ToString();
                    email.Visible = true;


                    string sql_age = "select age from Answer_M where AM_id =@AM_id";
                    SqlParameter[] sqlParameters_age = new SqlParameter[]
                    {
                        new SqlParameter("@AM_id",answer_AM_id)
                    };
                    age.Visible = true;
                    age.Text = sqlhelp.executeScalarsql(sql_age, sqlParameters_age, false).ToString();

                    //固定問題
                    GridView1.Visible = false;
                    Button_outData.Visible = false;

                    //
                    int D1_id = 0;
                    string D1_title, D1_summary;
                    Boolean D1_mustKeyin;
                    string StarTime = string.Empty;
                    string Endtime = string.Empty;
                    //get的值
                    string getM_id = Request.QueryString["M_id"];
                    //取資料入的值
                    string sql = "SELECT top 1 * from Question_M where M_id=@M_id";
                    SqlParameter[] Getsqls = new SqlParameter[]
                    {
                new SqlParameter("@M_id",getM_id)
                    };
                    SqlDataReader dr = sqlhelp.executeReadesql(sql, Getsqls, false);
                    Literal br = new Literal();
                    br.Text = "</br>";




                    //讀取這一份問卷的每一個題目
                    string sql2 = "select * from Question_D1 where M_id=@M_id";
                    SqlParameter[] sqlParameters = new SqlParameter[]
                    {
                new SqlParameter("@M_id",answer_M_id)
                    };
                    SqlDataReader dr2 = sqlhelp.executeReadesql(sql2, sqlParameters, false);
                    if (dr2.HasRows)
                    {
                        Label label_table_start = new Label();
                        label_table_start.Text = "<table  width=\"100%\" id=\"table1\" style=\"border: 1px solid black; \">";
                        PlaceHolder1.Controls.Add(label_table_start);
                        int table_i = 0;
                        while (dr2.Read())
                        {
                            D1_id = (int)dr2["D1_id"];
                            D1_title = dr2["D1_title"].ToString();

                            D1_mustKeyin = Convert.ToBoolean(dr2["D1_mustKeyin"]);

                            if (!DBNull.Value.Equals(dr2["D1_summary"]))//可能為null特別處理一下
                            {
                                D1_summary = dr2["D1_summary"].ToString();
                            }
                            else
                            {
                                D1_summary = string.Empty;
                            }
                            String D1_type = dr2["D1_type"].ToString();
                            //已取得資料後接著要產生這一個問卷的每一題的類別(重要)
                            Literal label_table_tr = new Literal();//美觀而已
                            if ((table_i % 2) == 0)
                            {
                                label_table_tr.Text = "<tr><td>";
                            }
                            else
                            {
                                label_table_tr.Text = "<tr><td bgcolor=\"#E3E3E3\">";
                            }
                            PlaceHolder1.Controls.Add(label_table_tr);
                            //共用部分(主題，說明，是否要填寫)
                            Literal label_D1_context = new Literal();
                            label_D1_context.Text = "<div id=" + D1_id + ">" + D1_title + "</br>" + D1_summary + "</div>";

                            if (D1_mustKeyin == true)
                            {
                                label_D1_context.Text = "<div id=" + D1_id + " must=true>" + D1_title + "(這題必須要回答喔)</br><p>註解:" + D1_summary + "</p></div>";
                            }
                            PlaceHolder1.Controls.Add(label_D1_context);
                            //選項產生
                            string sqlmidAndD1id = "select * from Question_D2 where D1_id = @D1_id and M_id = @M_id";
                            SqlParameter[] SqlParameters = new SqlParameter[]
                                    {
                                new SqlParameter("@D1_id",D1_id),
                                new SqlParameter("@M_id",answer_M_id)
                                    };
                            switch (D1_type)
                            {
                                case "CB"://複選(checkboxlist)
                                    CheckBoxList CB_Q1 = new CheckBoxList();
                                    CB_Q1.ID = "D1_" + D1_id;

                                    SqlDataReader sqlDataReader = sqlhelp.executeReadesql(sqlmidAndD1id, SqlParameters, false);
                                    sqlDataReader.Read();
                                    string answer = sqlDataReader["answer"].ToString();
                                    string[] answers = answer.Split(';');
                                    foreach (var item in answers)
                                    {
                                        CB_Q1.Items.Add(item);
                                    }
                                    PlaceHolder1.Controls.Add(CB_Q1);
                                    sqlDataReader.Close();
                                    break;
                                case "RB"://單選選(RadioButton)
                                    RadioButtonList CB_Q2 = new RadioButtonList();
                                    CB_Q2.ID = "D1_" + D1_id;

                                    SqlDataReader sqlDataReaderRB = sqlhelp.executeReadesql(sqlmidAndD1id, SqlParameters, false);
                                    sqlDataReaderRB.Read();
                                    string answerRB = sqlDataReaderRB["answer"].ToString();
                                    string[] answersRB = answerRB.Split(';');
                                    foreach (var item in answersRB)
                                    {
                                        CB_Q2.Items.Add(item);
                                    }
                                    PlaceHolder1.Controls.Add(CB_Q2);
                                    sqlDataReaderRB.Close();
                                    break;
                                case "TB"://文字輸入框(TextBox)
                                    TextBox CB_Q3 = new TextBox();
                                    CB_Q3.ID = "D1_" + D1_id;
                                    PlaceHolder1.Controls.Add(CB_Q3);

                                    break;
                                default:
                                    break;
                            }
                            Literal trtdend = new Literal();
                            trtdend.Text = "</td></tr>";
                            PlaceHolder1.Controls.Add(trtdend);
                            table_i++;
                        }

                        Literal end = new Literal();
                        end.Text = "</table>";
                        PlaceHolder1.Controls.Add(end);


                    }



                    //
                    //給值
                    getPageA getPageA = new getPageA();
                    int Qno = getPageA.Compute_QNo(Convert.ToInt32(answer_M_id)); /*算出有幾個題目*/
                    //
                    string answer_d1_sql = "select * from Answer_D1 where AM_id=@AM_id";
                    SqlParameter[] sqlParameters_answer_d1 = new SqlParameter[]
                    {
                        new SqlParameter("@AM_id",answer_AM_id)
                    };
                    SqlDataReader sqlDataReader_answer_d1 = sqlhelp.executeReadesql(answer_d1_sql, sqlParameters_answer_d1, false);

                    if (sqlDataReader_answer_d1.HasRows)
                    {
                        while (sqlDataReader_answer_d1.Read())
                        {
                            //
                            for (int i = 0; i < Qno; i++)
                            {

                                String WebcontrolID = "D1_" + sqlDataReader_answer_d1["D1_id"].ToString();

                                switch (PlaceHolder1.FindControl(WebcontrolID).ToString())
                                {
                                    case "System.Web.UI.WebControls.RadioButtonList":
                                        RadioButtonList CBL2 = (RadioButtonList)PlaceHolder1.FindControl(WebcontrolID);

                                        for (int C = 0; C < (CBL2.Items.Count); C++)
                                        {
                                            if (CBL2.Items[C].Text == sqlDataReader_answer_d1["Answer"].ToString())
                                            {
                                                CBL2.Items[C].Selected = true;
                                            }
                                        }
                                        CBL2.Enabled = false;



                                        break;
                                    case "System.Web.UI.WebControls.CheckBoxList":
                                        CheckBoxList CBL1 = (CheckBoxList)PlaceHolder1.FindControl(WebcontrolID);

                                        String[] value_all = sqlDataReader_answer_d1["Answer"].ToString().Split(';');
                                        for (int j = 0; j < (value_all.Count()); j++)
                                        {
                                            for (int jj = 0; jj < (CBL1.Items.Count); jj++)
                                            {


                                                if (CBL1.Items[jj].Text == value_all[j].ToString())
                                                {
                                                    CBL1.Items[jj].Selected = true;
                                                };
                                            }
                                        }

                                        CBL1.Enabled = false;
                                        break;
                                    case "System.Web.UI.WebControls.TextBox":
                                        TextBox CBL3 = (TextBox)PlaceHolder1.FindControl(WebcontrolID);
                                        CBL3.Text = sqlDataReader_answer_d1["Answer"].ToString();
                                        CBL3.Enabled = false;

                                        break;
                                    default:
                                        break;
                                };
                            };
                            //
                        }
                    }




                }
                else
                {
                    GridView1.Visible = true;
                    Button_outData.Visible = true;




                    //



                    //
                }



                //
            }
            /////
            string all_title_sql = "select* from Question_D1 where M_id = 24";
            string[] all_list = { };
            StringBuilder HtmlstringBuilder = new StringBuilder();
            SqlDataReader sqlData_all = sqlhelp.executeReadesql(all_title_sql);
           StringBuilder cstext1 = new StringBuilder();
 ClientScriptManager cs = Page.ClientScript;
 String csname1 = "PopupScript";
                    Type cstype = this.GetType();
            if (sqlData_all.HasRows)
            {
                while (sqlData_all.Read())
                {
                    string iii_D1 = "select answer from Question_D2 where D1_id=@D1_id";
                    SqlParameter[] sqlParameters_iii_d1 = new SqlParameter[]
                    {
                            new SqlParameter("D1_id",sqlData_all["D1_id"].ToString())
                    };
                    string want_data = sqlhelp.executeScalarsql(iii_D1, sqlParameters_iii_d1, false).ToString();
                    all_list = want_data.Split(';');


                    // Define the name and type of the client scripts on the page.
                   

                    // Get a ClientScriptManager reference from the Page class.
                   
                    HtmlstringBuilder.Append("<canvas id = 'myChart"+ sqlData_all["D1_id"].ToString()+"' width = '400' height = '400' ></canvas>");
                    Literal1.Text= HtmlstringBuilder.ToString();
                    // Check to see if the startup script is already registered.
                   

                   


                        cstext1.Append("<script type=text/javascript>");
                        //01
                        cstext1.Append("var ctx = document.getElementById('myChart"+ sqlData_all["D1_id"].ToString() + "');");
                        cstext1.Append("var myChart = new Chart(ctx, {");
                        cstext1.Append("type: 'bar',");
                        cstext1.Append("data: {");

                        cstext1.Append("labels: [");


                        for (int i = 0; i < all_list.Count(); i++)
                        {
                            cstext1.Append("'" + all_list[i] + "'");
                            for (int j = 0; j < all_list.Length - 1; j++)
                            {
                                cstext1.Append(",");
                            }
                        }
                        //cstext1.Append("'一月', '二月'");

                        cstext1.Append("],");
                        cstext1.Append(" datasets: [{");
                        cstext1.Append(" backgroundColor: [");
                        cstext1.Append("'rgba(255, 99, 132, 0.2)',");
                        cstext1.Append("'rgba(54, 162, 235, 0.2)'");
                        cstext1.Append(" ],");
                        cstext1.Append("borderColor: [");
                        cstext1.Append("'rgba(255,99,132,1)',");
                        cstext1.Append("'rgba(54, 162, 235, 1)',");
                        cstext1.Append("'rgba(255, 206, 86, 1)',");
                        cstext1.Append("'rgba(75, 192, 192, 1)'");
                        cstext1.Append("],");
                        cstext1.Append("borderWidth: 1,");
                        cstext1.Append("label: '測試單選(必填)',");

                        cstext1.Append("data: [60, 49, 72]");

                        cstext1.Append("}]");
                        cstext1.Append("}");
                        cstext1.Append("});");
                        //01
                       
                        cstext1.Append("</script>");

             
                }


       cs.RegisterStartupScript(cstype, csname1, cstext1.ToString());    
                    ////////////////
                    ///     }
               
            }
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                //要隱藏的欄位    
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void TOP_Button1_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["AM_id"] != null)
            {
                Response.Redirect("Backstage17.aspx?M_id=" + Request.QueryString["M_id"].ToString());
            }
            else
            {
                Response.Redirect("Backstage.aspx");
            }

        }

        protected void Button_outData_Click(object sender, EventArgs e)
        {

            /////
            //寫入資料
            string M_id_b17 = Request.QueryString["M_id"];
            string sql_Mydata = "SELECT  name,phone,email,age, writeTime,start_time,email,M_title,M_summary,end_time FROM Answer_M  INNER JOIN Question_M on Answer_M.M_id=Question_M.M_id  WHERE Answer_M.M_id = @M_id ";
            SqlParameter[] sqlParameters_b17 = new SqlParameter[]
            {
                new SqlParameter("@M_id",M_id_b17)
            };

            List<B17exel> mydata_b17s_list = new List<B17exel>();

            SqlDataReader sqlData_b17 = sqlhelp.executeReadesql(sql_Mydata, sqlParameters_b17, false);
            if (sqlData_b17.HasRows)
            {
                while (sqlData_b17.Read())
                {
                    B17exel my_out_b17 = new B17exel();
                    my_out_b17.M_title = (string)sqlData_b17["M_title"];
                    my_out_b17.M_summary = (string)sqlData_b17["M_summary"];
                    
        
                    my_out_b17.name = (string)sqlData_b17["name"];
                    my_out_b17.age = (int)sqlData_b17["age"];
                    my_out_b17.email = (string)sqlData_b17["email"];
                    my_out_b17.phone = (string)sqlData_b17["phone"];
                    my_out_b17.writeTime = sqlData_b17["writeTime"].ToString();
                    my_out_b17.start_time = sqlData_b17["start_time"].ToString();
                    my_out_b17.end_time = sqlData_b17["end_time"].ToString();
                    mydata_b17s_list.Add(my_out_b17);
                };
            }
            sqlData_b17.Close();


            ////System.Windows.Forms.FolderBrowserDialog path = new System.Windows.Forms.FolderBrowserDialog();
            ////path.Description = "請選擇欲轉換的主目錄,程序會找到底下的子目錄及檔案";
            ////path.ShowDialog();
            string my_title_sql = "select M_title from Question_M where M_id=@M_id";
            SqlParameter[] sqlParameter_MY_title = new SqlParameter[]
            {
                new SqlParameter("@M_id",M_id_b17)
            };
            string my_title = sqlhelp.executeScalarsql(my_title_sql, sqlParameter_MY_title, false).ToString();

            DAL.Open_urlPath open_UrlPath = new Open_urlPath();
            open_UrlPath.setExcel_Title(my_title,"標題","副標題", "開始時間", "結束時間","姓名", "電話", "電子郵件","年齡","填寫時間");
            open_UrlPath.setExcel_MyList_data(mydata_b17s_list);
            System.Threading.Thread s = new System.Threading.Thread(new System.Threading.ThreadStart(open_UrlPath.getExcel));
            s.ApartmentState = System.Threading.ApartmentState.STA;
            s.Start();


            //建立環境
            //Response.Clear();
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //XSSFWorkbook workbook = new XSSFWorkbook();
            //ISheet u_sheet = workbook.CreateSheet(" 簡單統計報表_sjeet");

           
            //




        }
    }
}