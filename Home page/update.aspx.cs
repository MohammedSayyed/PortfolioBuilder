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
    public partial class WebForm2 : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // Response.Write("<script>alert('page load');</script>");
                if (Session["email"].ToString() != "" && Session["pwd"].ToString() != "")
                {
                    name.Value = Session["name"].ToString();
                    if (Session["gender"].ToString().ToLower() == "male")
                        Male.Checked = true;
                    else
                        Female.Checked = true;
                    dob.Value = Session["dob"].ToString();

                    //Request.Form["user_job"] = Session["jobrole"].ToString();
                    mail.Value = Session["email"].ToString();
                    mail.Disabled = true;
                    Address.Value = Session["address"].ToString();
                    phone.Value = Session["phone"].ToString();
                    about.Value = Session["about"].ToString();
                    website.Value = Session["website"].ToString();
                    String[] skills = Session["skills"].ToString().Split(',');

                    foreach (String skill in skills)
                    {
                        SelectCheckBoxList(skill);
                    }

                    if (Session["mdegree"] != null)
                    {
                        MDegree.Value = Session["mdegree"].ToString();
                        MDuration.Value = Session["mduration"].ToString();
                        MCollege.Value = Session["mcollege"].ToString();
                    }
                    if (Session["bdegree"] != null)
                    {
                        Bdegree.Value = Session["bdegree"].ToString();
                        BDuration.Value = Session["bduration"].ToString();
                        BCollege.Value = Session["bcollege"].ToString();
                    }
                    if (Session["jstream"] != null)
                    {
                        JCStream.Value = Session["jstream"].ToString();
                        JCDuration.Value = Session["jduration"].ToString();
                        JCCollege.Value = Session["jcollege"].ToString();
                    }
                    if (Session["role0"] != null)
                    {
                        role1.Value = Session["role0"].ToString();
                        duration1.Value = Session["WorkDuration0"].ToString();
                        company1.Value = Session["company0"].ToString();
                        job1.Value = Session["job_info0"].ToString();
                    }

                    if (Session["role1"] != null)
                    {
                        role2.Value = Session["role1"].ToString();
                        duration2.Value = Session["WorkDuration1"].ToString();
                        company2.Value = Session["company1"].ToString();
                        job2.Value = Session["job_info1"].ToString();
                    }
                    if(Session["role2"]!=null)
                    {
                        role3.Value = Session["role2"].ToString();
                        duration3.Value = Session["WorkDuration2"].ToString();
                        company3.Value = Session["company2"].ToString();
                        job3.Value = Session["job_info2"].ToString();
                    }
                }
            }
           
        }

        private void SelectCheckBoxList(string valueToSelect)
        {
            ListItem listItem = this.CheckBoxList1.Items.FindByText(valueToSelect);

            if (listItem != null) listItem.Selected = true;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            try
            {
                //Response.Write("<script>alert('" + MDegree.Value + " and " + Address.Value + "');</script>");
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
               // Response.Write("<script>alert('" + password1.Value + " and " + password2.Value + "');</script>");
                if (password1.Value.Trim() == password2.Value.Trim())
                {
                    string str = "", gender, user_job;
                    string date = DateTime.Now.ToString("yyyyMMddHHmmss");

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
                    if (Profile_img.HasFile)
                    {
                        String fileExtension1 = System.IO.Path.GetExtension(Profile_img.FileName);

                        if (fileExtension1.ToLower() != ".img" && fileExtension1.ToLower() != ".jpg" && fileExtension1.ToLower() != ".jpeg")
                        {
                            Response.Write("<script>alert('Please Select valid Profile Pic');</script>");
                            return;
                        }
                        else
                        {
                            Session["profile_pic"] = date + Profile_img.FileName;
                            Profile_img.SaveAs(Server.MapPath("~/portfolio/uploads/Profile Pics/" + date + Profile_img.FileName));
                        }
                    }
                    if (Resume.HasFile)
                    {
                        String fileExtension2 = System.IO.Path.GetExtension(Resume.FileName);
                        if (fileExtension2.ToLower() != ".pdf" && fileExtension2.ToLower() != ".doc" && fileExtension2.ToLower() != ".docx")
                        {
                            Response.Write("<script>alert('Please Select valid Resume ');</script>");
                            return;
                        }
                        else
                        {
                            Session["resume"] = date + Resume.FileName;
                            Resume.SaveAs(Server.MapPath("~/portfolio/uploads/Resume/" + date + Resume.FileName));
                        }

                    }
                    user_job = Request.Form["user_job"];

                    //Response.Write("<script>alert('" + user_job + "')</script>");
                    SqlCommand cmd = new SqlCommand("update Persons set name=@name,gender=@gender,DOB=@DOB,job_role=@job_role,password=@password,about=@about," +
                        "website=@website,skills=@skills,profile_pic=@profile_pic,resume=@resume,address=@address,phone=@phone where email=@email", con);
                    cmd.Parameters.AddWithValue("@email", mail.Value);
                    cmd.Parameters.AddWithValue("@name", name.Value);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@DOB", dob.Value);
                    cmd.Parameters.AddWithValue("@job_role", user_job);
                    cmd.Parameters.AddWithValue("@password", password1.Value);
                    cmd.Parameters.AddWithValue("@about", about.Value);
                    cmd.Parameters.AddWithValue("@website", website.Value);
                    cmd.Parameters.AddWithValue("@skills", str);
                    cmd.Parameters.AddWithValue("@profile_pic", Session["profile_pic"].ToString());
                    cmd.Parameters.AddWithValue("@resume", Session["resume"].ToString());
                    cmd.Parameters.AddWithValue("@address", Address.Value);
                    cmd.Parameters.AddWithValue("@phone", phone.Value);
                    int r = cmd.ExecuteNonQuery();
                    //Response.Write("<script>alert('person=" + r + "')</script>");
                    cmd.CommandText = "delete from work_exp where email='" + mail.Value + "'";
                    r = cmd.ExecuteNonQuery();
                    //Response.Write("<script>alert('Deleted work =" + r + "')</script>");

                    cmd.CommandText = "delete from master_degree where email='" + mail.Value + "'";
                    r = cmd.ExecuteNonQuery();
                    //Response.Write("<script>alert('Deleted Master =" + r + "')</script>");

                    cmd.CommandText = "delete from bachelor_degree where email='" + mail.Value + "'";
                    r = cmd.ExecuteNonQuery();
                    //Response.Write("<script>alert('Deleted bachelor =" + r + "')</script>");

                    cmd.CommandText = "delete from junior_college where email='" + mail.Value + "'";
                    r = cmd.ExecuteNonQuery();
                    //Response.Write("<script>alert('Deleted college =" + r + "')</script>");

                    if (role1.Value != "" && duration1.Value != "" && company1.Value != "" && job1.Value != "")
                    {
                        cmd.CommandText = "insert into work_exp (email,role,company,job_info,duration) VALUES" +
                        "(@email1,@role1,@company1,@job_info1,@duration1)";
                        cmd.Parameters.AddWithValue("@email1", mail.Value);
                        cmd.Parameters.AddWithValue("@role1", role1.Value);
                        cmd.Parameters.AddWithValue("@company1", company1.Value);
                        cmd.Parameters.AddWithValue("@job_info1", job1.Value);
                        cmd.Parameters.AddWithValue("@duration1", duration1.Value);
                        r = cmd.ExecuteNonQuery();
                       // Response.Write("<script>alert('work 1 =" + r + "')</script>");

                    }
                    if (role2.Value != "" && duration2.Value != "" && company2.Value != "" && job2.Value != "")
                    {
                        cmd.CommandText = "insert into work_exp(email, role, company, job_info, duration) VALUES" +
                        "(@email2,@role2,@company2,@job_info2,@duration2)";
                        cmd.Parameters.AddWithValue("@email2", mail.Value);
                        cmd.Parameters.AddWithValue("@role2", role2.Value);
                        cmd.Parameters.AddWithValue("@company2", company2.Value);
                        cmd.Parameters.AddWithValue("@job_info2", job2.Value);
                        cmd.Parameters.AddWithValue("@duration2", duration2.Value);
                        r = cmd.ExecuteNonQuery();
                        //Response.Write("<script>alert('work 2=" + r + "')</script>");

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
                        r = cmd.ExecuteNonQuery();
                        //Response.Write("<script>alert('work 3=" + r + "')</script>");
                    }
                    if (MDegree.Value != "" && MDuration.Value != "" && MCollege.Value != "")
                    {
                        cmd.CommandText = "insert into master_degree (email,mdegree,duration,college) VALUES" +
                                    "(@email4,@degree1,@Mduration,@college1)";
                        cmd.Parameters.AddWithValue("@email4", mail.Value);
                        cmd.Parameters.AddWithValue("@degree1", MDegree.Value);
                        cmd.Parameters.AddWithValue("@Mduration", MDuration.Value);
                        cmd.Parameters.AddWithValue("@college1", MCollege.Value);
                        r=cmd.ExecuteNonQuery();
                       // Response.Write("<script>alert('inserted Master =" + r + "')</script>");
                    }

                    if (Bdegree.Value != "" && BDuration.Value != "" && BCollege.Value != "")
                    {
                        cmd.CommandText = "insert into bachelor_degree (email,bdegree,duration,college) VALUES" +
                                    "(@email5,@degree2,@Bduration,@college2)";
                        cmd.Parameters.AddWithValue("@email5", mail.Value);
                        cmd.Parameters.AddWithValue("@degree2", Bdegree.Value);
                        cmd.Parameters.AddWithValue("@Bduration", BDuration.Value);
                        cmd.Parameters.AddWithValue("@college2", BCollege.Value);
                        r=cmd.ExecuteNonQuery();
                       // Response.Write("<script>alert('bachelor=" + r + "')</script>");
                    }
                    if (JCStream.Value != "" && JCDuration.Value != "" && JCCollege.Value != "")
                    {
                        cmd.CommandText = "insert into junior_college (email,stream,duration,college) VALUES" +
                                   "(@email6,@stream,@Jduration,@college3)";
                        cmd.Parameters.AddWithValue("@email6", mail.Value);
                        cmd.Parameters.AddWithValue("@stream", JCStream.Value);
                        cmd.Parameters.AddWithValue("@Jduration", JCDuration.Value);
                        cmd.Parameters.AddWithValue("@college3", JCCollege.Value);
                        r=cmd.ExecuteNonQuery();
                        //Response.Write("<script>alert('junior=" + r + "')</script>");
                    }
                    con.Close();
                    Session.Clear();
                    Session.Add("email", mail.Value);
                    Session.Add("pwd", password1.Value);
                    //Response.Write("<script>alert('Sign Up Successfull!!')</script>");
                    Response.Write("<script language='javascript'>window.alert('Information Updated!!');window.location='/portfolio/homepage.aspx';</script>");
                    //Response.Redirect("/portfolio/homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Password are not same!!')</script>");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}