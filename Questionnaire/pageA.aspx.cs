using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace Questionnaire
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int M_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            int D1_id = 0;
            string D1_title, D1_summary;
            Boolean D1_mustKeyin;
            string StarTime=string.Empty;
            string Endtime = string.Empty;
            //get的值
            string getM_id = Request.QueryString["M_id"];
            //取資料入的值
            string sql = "SELECT top 1 * from Question_M where M_id=@M_id";
            SqlParameter[] Getsqls = new SqlParameter[]
            {
                new SqlParameter("@M_id",getM_id)
            };
            SqlDataReader dr = sqlhelp.executeReadesql(sql, Getsqls,false);
            Literal br = new Literal();
            br.Text = "</br>";
            
          
           
            if (dr.HasRows)
            {
                dr.Read();
                Lable_M_title.Text = dr["M_title"].ToString();
                Lable_M_Summary.Text = dr["M_summary"].ToString(); 
                StarTime = string.Format("{0:yyyy/MM/dd}", dr["start_time"]);
                Endtime = string.Format("{0:yyyy/MM/dd}", dr["end_time"]);
                M_id = (int)dr["M_id"];
                dr.Close();
            }
            //投票中的時間
            
            frontLabel1.Text = StarTime + "~" + Endtime;
            //讀取這一份問卷的每一個題目
            string sql2 = "select * from Question_D1 where M_id=@M_id";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@M_id",M_id)
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
                                new SqlParameter("@M_id",M_id)
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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getPageA getPageA = new getPageA();
            int Qno = getPageA.Compute_QNo(M_id);//算出有幾個題目
            ArrayList D1_AL = getPageA.Take_D1_ID(M_id);
            string AM_id = Guid.NewGuid().ToString();

            //寫入Answer_M tabley 資料
            DB into_Answer = new DB();
            int getage;
            try
            {
              getage = Convert.ToInt32(age.Text);
            }
            catch (Exception)
            {
                getage = 0;
                return;
            }
             
            into_Answer.pageAtoAnswer_M(AM_id, M_id,name.Text,phone.Text,email.Text, getage);


            for (int i = 0; i < Qno; i++)
            {
                String WebcontrolID = "D1_" + D1_AL[i];

                switch (PlaceHolder1.FindControl(WebcontrolID).ToString())
                {
                    case "System.Web.UI.WebControls.RadioButtonList":
                        RadioButtonList CBL2 = (RadioButtonList)PlaceHolder1.FindControl(WebcontrolID);
                        if (CBL2.SelectedItem == null)
                        {
                            Response.Write("null");
                            into_Answer.pageAtoAnswer_D1(AM_id, Convert.ToInt32(D1_AL[i]), string.Empty);
                        }
                        else
                        {
                            into_Answer.pageAtoAnswer_D1(AM_id, Convert.ToInt32(D1_AL[i]), CBL2.SelectedItem.Text);
                            Response.Write(CBL2.SelectedItem.Text);
                        }
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        CheckBoxList CBL1 = (CheckBoxList)PlaceHolder1.FindControl(WebcontrolID);
                        String CBL1_Value = string.Empty;
                        for (int j = 0; j < (CBL1.Items.Count); j++)
                        {
                            if (CBL1.Items[j].Selected)
                            {
                                CBL1_Value = CBL1_Value + CBL1.Items[j].Text + ";";
                            }
                        }
                        into_Answer.pageAtoAnswer_D1(AM_id, Convert.ToInt32(D1_AL[i]), CBL1_Value);
                        Response.Write(CBL1_Value);
                        break;
                        case "System.Web.UI.WebControls.TextBox":
                        TextBox CBL3 = (TextBox)PlaceHolder1.FindControl(WebcontrolID);
                        Response.Write(CBL3.Text);
                        into_Answer.pageAtoAnswer_D1(AM_id, Convert.ToInt32(D1_AL[i]), CBL3.Text);
                        break;
                    default:
                        break;
                };
            };

            Response.Redirect("front10.aspx?M_id="+M_id);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("front06.aspx");
        }
    }
}