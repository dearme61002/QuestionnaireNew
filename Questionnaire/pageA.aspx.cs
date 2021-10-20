using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            int M_id = 0;
            int D1_id = 0;
            string D1_title, D1_summary, D1_mustKeyin;
            string sql = "SELECT top 1 * from Question_M where M_id=1";
            SqlDataReader dr = sqlhelp.executeReadesql(sql);
            if (dr.HasRows)
            {
                dr.Read();
                Lable_M_title.Text = dr["M_title"].ToString();
                Lable_M_Summary.Text = dr["M_summary"].ToString();
                M_id = (int)dr["M_id"];
                dr.Close();
            }
        }
    }
}