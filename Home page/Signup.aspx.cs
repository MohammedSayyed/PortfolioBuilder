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
    public partial class Signup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signup_Click(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('WALLA');</script>");

            try
            {
                if (password1.Value == password2.Value)
                {
                    string date = DateTime.Now.ToString("yyyyMMddHHmmss");
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select count(*) from persons where email='" + mail.Value + "';", con);
                    int rc = (int)cmd.ExecuteScalar();
                    if (rc == 1)
                    {
                        Response.Write("<script>alert('E-mail already Exists.Please Select another E-mail ID or try Logging in.');</script>");
                    }
                    else
                    {
                        if (Profile_img.HasFile && Resume.HasFile)
                        {
                            String fileExtension1 = System.IO.Path.GetExtension(Profile_img.FileName);
                            String fileExtension2 = System.IO.Path.GetExtension(Resume.FileName);
                            if ((fileExtension1.ToLower() != ".img" && fileExtension1.ToLower() != ".jpg" && fileExtension1.ToLower() != ".jpeg") || (fileExtension2.ToLower() != ".pdf" && fileExtension2.ToLower() != ".doc" && fileExtension2.ToLower() != ".docx"))
                            {
                                Response.Write("<script>alert('Please Select valid Resume and Profile Pic');</script>");
                            }

                            else
                            {
                                string str = "", gender, user_job;

                                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                                {
                                    if (CheckBoxList1.Items[i].Selected == true)
                                    {
                                        str += CheckBoxList1.Items[i].Value + ",";
                                    }
                                }
                                if (Male.Checked)
                                    gender = "Male";
                                else
                                    gender = "Female";

                                user_job = Request.Form["user_job"];
                                //Response.Write("<script>alert('" + user_job + "')</script>");

                                cmd.CommandText = "insert into Persons (email,name,gender,DOB,job_role,password,about,website,skills,profile_pic,resume,address,phone) VALUES" +
                                "(@email,@name,@gender,@DOB,@job_role,@password,@about,@website,@skills,@profile_pic,@resume,@address,@phone)";
                                cmd.Parameters.AddWithValue("@email", mail.Value);
                                cmd.Parameters.AddWithValue("@name", name.Value);
                                cmd.Parameters.AddWithValue("@gender", gender);
                                cmd.Parameters.AddWithValue("@DOB", dob.Value);
                                cmd.Parameters.AddWithValue("@job_role", user_job);
                                cmd.Parameters.AddWithValue("@password", password1.Value);
                                cmd.Parameters.AddWithValue("@about", about.Value);
                                cmd.Parameters.AddWithValue("@website", website.Value);
                                cmd.Parameters.AddWithValue("@skills", str);
                                cmd.Parameters.AddWithValue("@profile_pic", date + Profile_img.FileName);
                                cmd.Parameters.AddWithValue("@resume", date + Resume.FileName);
                                cmd.Parameters.AddWithValue("@address", Address.Value);
                                cmd.Parameters.AddWithValue("@phone", phone.Value);
                                cmd.ExecuteNonQuery();
                                if (role1.Value != "" && duration1.Value != "" && company1.Value != "" && job1.Value != "")
                                {
                                    cmd.CommandText = "insert into work_exp (email,role,company,job_info,duration) VALUES" +
                                    "(@email1,@role1,@company1,@job_info1,@duration1)";
                                    cmd.Parameters.AddWithValue("@email1", mail.Value);
                                    cmd.Parameters.AddWithValue("@role1", role1.Value);
                                    cmd.Parameters.AddWithValue("@company1", company1.Value);
                                    cmd.Parameters.AddWithValue("@job_info1", job1.Value);
                                    cmd.Parameters.AddWithValue("@duration1", duration1.Value);
                                    cmd.ExecuteNonQuery();
                                }
                                if (role2.Value != "" && duration2.Value != "" && company2.Value != "" && job2.Value != "")
                                {
                                    cmd.CommandText = "insert into work_exp (email,role,company,job_info,duration) VALUES" +
                                    "(@email2,@role2,@company2,@job_info2,@duration2)";
                                    cmd.Parameters.AddWithValue("@email2", mail.Value);
                                    cmd.Parameters.AddWithValue("@role2", role2.Value);
                                    cmd.Parameters.AddWithValue("@company2", company2.Value);
                                    cmd.Parameters.AddWithValue("@job_info2", job2.Value);
                                    cmd.Parameters.AddWithValue("@duration2", duration2.Value);
                                    cmd.ExecuteNonQuery();
                                }
                                if (role3.Value != "" && duration3.Value != "" && company3.Value != "" && job3.Value != "")
                                {
                                    cmd.CommandText = "insert into work_exp (email,role,company,job_info,duration) VALUES" +
                                    "(@email3,@role3,@company3,@job_info3,@duration3)";
                                    cmd.Parameters.AddWithValue("@email3", mail.Value);
                                    cmd.Parameters.AddWithValue("@role3", role3.Value);
                                    cmd.Parameters.AddWithValue("@company3", company3.Value);
                                    cmd.Parameters.AddWithValue("@job_info3", job3.Value);
                                    cmd.Parameters.AddWithValue("@duration3", duration3.Value);
                                    cmd.ExecuteNonQuery();
                                }
                                if (MDegree.Value != "" && MDuration.Value != "" && MCollege.Value != "")
                                {
                                    cmd.CommandText = "insert into master_degree (email,mdegree,duration,college) VALUES" +
                                    "(@email4,@degree1,@Mduration,@college1)";
                                    cmd.Parameters.AddWithValue("@email4", mail.Value);
                                    cmd.Parameters.AddWithValue("@degree1", MDegree.Value);
                                    cmd.Parameters.AddWithValue("@Mduration", MDuration.Value);
                                    cmd.Parameters.AddWithValue("@college1", MCollege.Value);
                                    cmd.ExecuteNonQuery();
                                }

                                if (Bdegree.Value != "" && BDuration.Value != "" && BCollege.Value != "")
                                {
                                    cmd.CommandText = "insert into bachelor_degree (email,bdegree,duration,college) VALUES" +
                                    "(@email5,@degree2,@Bduration,@college2)";
                                    cmd.Parameters.AddWithValue("@email5", mail.Value);
                                    cmd.Parameters.AddWithValue("@degree2", Bdegree.Value);
                                    cmd.Parameters.AddWithValue("@Bduration", BDuration.Value);
                                    cmd.Parameters.AddWithValue("@college2", BCollege.Value);
                                    cmd.ExecuteNonQuery();
                                }
                                if (JCStream.Value != "" && JCDuration.Value != "" && JCCollege.Value != "")
                                {
                                    cmd.CommandText = "insert into junior_college (email,stream,duration,college) VALUES" +
                                    "(@email6,@stream,@Jduration,@college3)";
                                    cmd.Parameters.AddWithValue("@email6", mail.Value);
                                    cmd.Parameters.AddWithValue("@stream", JCStream.Value);
                                    cmd.Parameters.AddWithValue("@Jduration", JCDuration.Value);
                                    cmd.Parameters.AddWithValue("@college3", JCCollege.Value);
                                    cmd.ExecuteNonQuery();
                                }
                                con.Close();
                                Session.Add("email", mail.Value);
                                Session.Add("pwd", password1.Value);
                                Profile_img.SaveAs(Server.MapPath("~/portfolio/uploads/Profile Pics/" + date + Profile_img.FileName));
                                Resume.SaveAs(Server.MapPath("~/portfolio/uploads/Resume/" + date + Resume.FileName));
                                //Response.Write("<script>alert('Sign Up Successfull!!')</script>");
                                Response.Write("<script language='javascript'>window.alert('Sign Up Successfull!!');window.location='/portfolio/homepage.aspx';</script>");
                                //Response.Redirect("/portfolio/homepage.aspx");
                            }

                        }
                        else
                        {
                            Response.Write("<script>alert('Please Select ProFile Image and Resume!!')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Password are not same!!')</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                throw;
            }

        }
    }
}