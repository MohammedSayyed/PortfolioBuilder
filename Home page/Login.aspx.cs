using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace PortfolioBuilder.Home_page
{
    public partial class Login : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if(email.Value!="" && password.Value!="" )
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select count(*) from persons where email='" + email.Value + "'and password='" + password.Value+ "';", con);
                int rc = (int)cmd.ExecuteScalar();
                if(rc!=0)
                {
                    Session.Add("email", email.Value);
                    Session.Add("pwd", password.Value);
                    Response.Write("<script language='javascript'>window.alert('Login Successfull!!');window.location='/portfolio/homepage.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('Login Credential invalid')</script>");
                }
            }
        }
    }
}