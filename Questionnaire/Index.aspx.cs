using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Questionnaire
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["passworld_my"] == "OK")
            {
                Label2_account.Visible = false;
                Label1_account.Visible = false;
                TextBox_account.Visible = false;
                TextBox_passworld.Visible = false;
                Button_submit.Visible = false;
                Button_front.Visible = true;
                Button_back.Visible = true;
                Label1_p.Visible = true;
            }
            else
            {
                Label2_account.Visible = true;
                Label1_account.Visible = true;
                TextBox_account.Visible = true;
                TextBox_passworld.Visible = true;
                Button_submit.Visible = true;
                Button_front.Visible = false;
                Button_back.Visible = false;
                Label1_p.Visible = false;
            }
        }

        protected void Button_submit_Click(object sender, EventArgs e)
        {
            if(TextBox_account.Text!= "admin" & TextBox_passworld.Text!= "admin")
            {
                ClientScript.RegisterStartupScript(GetType(),"message", "<script> alert('帳號密碼錯誤');</script>");
                return;
            }
            Session["passworld_my"] = "OK";
            Label2_account.Visible = false;
            Label1_account.Visible = false;
            TextBox_account.Visible = false;
            TextBox_passworld.Visible = false;
            Button_submit.Visible = false;
            Button_front.Visible = true;
            Button_back.Visible = true;
            Label1_p.Visible = true;
        }

        protected void Button_front_Click(object sender, EventArgs e)
        {
            Response.Redirect("front06.aspx");
        }

        protected void Button_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Backstage.aspx");
        }
    }
}