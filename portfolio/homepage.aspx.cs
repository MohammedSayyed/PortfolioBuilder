using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortfolioBuilder.portfolio
{
    
    public partial class homepage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('" + Session["email"].ToString() + "')</script>");
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("select count(*) from persons where email='" + Session["email"].ToString() + "'and password='" + Session["pwd"].ToString() + "';", con);
            int rc = (int)cmd.ExecuteScalar();
            SqlDataReader dr;
            //Response.Write("<script>alert('" + rc + "')</script>");
            if (rc == 1)
            {
                cmd.CommandText = "select * from persons where email = '" + Session["email"].ToString() + "'and password = '" + Session["pwd"].ToString() + "';";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("name", dr[1].ToString());
                    Session.Add("gender", dr[2].ToString());
                    Session.Add("dob", dr[3].ToString());
                    Session.Add("jobrole", dr[4].ToString());
                    Session.Add("about", dr[6].ToString());
                    Session.Add("website", dr[7].ToString());
                    Session.Add("skills", dr[8].ToString());
                    Session.Add("profile_pic", dr[9].ToString());
                    Session.Add("resume", dr[10].ToString());
                    Session.Add("address", dr[11].ToString());
                    Session.Add("phone", dr[12].ToString());
                }
                dr.Close();
            }

            String[] NameArray = Session["name"].ToString().Split(' ');
            String[] DobArray = Session["dob"].ToString().Split('-');
            String[] Skill = Session["skills"].ToString().Split(',');
            // Response.Write("<script>alert('" + NameArray[0] +" wa " + NameArray[1] +" wa " + NameArray[2] + "')</script>");
            name.InnerText = "I'm " + NameArray[0];
            expertise.InnerText = Session["jobrole"].ToString();
            profile_img.Src = "/portfolio/uploads/Profile Pics/" + Session["profile_pic"].ToString();
            info.InnerText = Session["about"].ToString();
            fullname.InnerText = Session["name"].ToString();
            int year = Int32.Parse(DobArray[0]);
            int month = Int32.Parse(DobArray[1]);
            int day = Int32.Parse(DobArray[2]);
            DateTime dt = new DateTime(year, month, day);
            String bday = String.Format("{0:ddd, MMM d, yyyy}", dt);
            //Response.Write("<script>alert('" + bday + "')</script>");
            dob.InnerText = bday;
            resumeDownload.InnerHtml = "<a href='/portfolio/uploads/Resume/'" + Session["resume"] + "' download='" + Session["resume"] + "'  title='Download Resume' class='button button-primary'>Download Resume</a>";

            website.InnerText = Session["website"].ToString();
            mail.InnerText = Session["email"].ToString();
            skills.InnerHtml = "<ul class='skill-bars'>";
            for (int i = 0; i < Skill.Length - 1; i++)
            {
                skills.InnerHtml += "<li>" +
                               "<div class='progress percent90'><span>90%</span></div>" +
                               "<strong>" + Skill[i] + "<strong></li>\n";
            }
            skills.InnerHtml += "</ul>";
            //skills.InnerHtml = "<ul class='skill-bars'>" +
            //                    "<li><div class='progress percent90'><span>90%</span></div>" +
            //                   "<strong>" + "WALLA" + "<strong></li>" + "\n"+
            //                    "<li><div class='progress percent40'><span>40%</span></div>" +
            //                   "<strong>" + NameArray[0] + "<strong></li>" +
            //                    "</ul>";

            cmd.CommandText = "select count(*) from work_exp where email = '" + Session["email"].ToString() + "'";
            rc = (int)cmd.ExecuteScalar();
            if (rc != 0)
            {
                cmd.CommandText = "select * from work_exp where email = '" + Session["email"].ToString() + "'";

                dr = cmd.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    Session.Add("role" + i, dr[1].ToString());
                    Session.Add("company" + i, dr[2].ToString());
                    Session.Add("job_info" + i, dr[3].ToString());
                    Session.Add("WorkDuration" + i, dr[4].ToString());
                    i++;
                }
                dr.Close();
                for (int j = 0; j < rc; j++)
                {
                    work_exp.InnerHtml += "<div class='timeline-block'>" +
                                                      "<div class='timeline-ico'>" +
                                                      "<i class='fa fa-briefcase'></i>" +
                                                      "</div>" +
                                                      "<div class='timeline-header'>" +
                                                          "<h3>" + Session["role" + j].ToString() + "</h3>" +
                                                          "<p>" + Session["WorkDuration" + j].ToString() + "</p>" +
                                                        "</div>" +
                                                      "<div class='timeline-content'>" +
                                                      "<h4>" + Session["company" + j].ToString() + "</h4>" +
                                                          "<p>" + Session["job_info" + j].ToString() + "</p>"
                                                      + "</div>" +
                                                  "</div>";
                }
            }

            cmd.CommandText = "select count(*) from master_degree where email = '" + Session["email"].ToString() + "'";
            rc = (int)cmd.ExecuteScalar();
            if (rc != 0)
            {
                cmd.CommandText = "select * from master_degree where email = '" + Session["email"].ToString() + "'";

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("mdegree", dr[1].ToString());
                    Session.Add("mduration", dr[2].ToString());
                    Session.Add("mcollege", dr[3].ToString());
                }
                dr.Close();
                education.InnerHtml += "<div class='timeline-block'>" +
                                    "<div class='timeline-ico'>" +
                                    "<i  class='fa fa-graduation-cap'></i>" +
                                    "</div>" +
                                    "<div class='timeline-header'>" +
                                        "<h3>" + Session["mdegree"].ToString() + "</h3>" +
                                        "<p>" + Session["mduration"].ToString() + "</p>" +
                                    "</div>" +
                                    "<div class='timeline-content'>" +
                                    "<h4>" + Session["mcollege"].ToString() + "</h4>" +
                                        "<p style='color:#ebebeb;'>asdasdasdasdasdasdasdasdasdasdasd</p>"
                                    + "</div>" +
                                "</div>";
            }

            cmd.CommandText = "select count(*) from bachelor_degree where email = '" + Session["email"].ToString() + "'";
            rc = (int)cmd.ExecuteScalar();
            if (rc != 0)
            {
                cmd.CommandText = "select * from bachelor_degree where email = '" + Session["email"].ToString() + "'";

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("bdegree", dr[1].ToString());
                    Session.Add("bduration", dr[2].ToString());
                    Session.Add("bcollege", dr[3].ToString());
                }
                dr.Close();
                education.InnerHtml += "<div class='timeline-block'>" +
                                        "<div class='timeline-ico'>" +
                                        "	<i class='fa fa-graduation-cap'></i>" +
                                        "</div>" +
                                        "<div class='timeline-header'>" +
                                            "<h3>" + Session["bdegree"].ToString() + "</h3>" +
                                            "<p>" + Session["bduration"].ToString() + "</p>" +
                                        "</div>" +
                                        "<div class='timeline-content'>" +
                                            "<h4>" + Session["bcollege"].ToString() + "</h4>" +
                                            "<p style='color:#ebebeb;'>asdasdasdasdasdasdasdasdasdasdasd</p>" +
                                        "</div>" +
                                    "</div>";
            }
            cmd.CommandText = "select count(*) from junior_college where email = '" + Session["email"].ToString() + "'";
            rc = (int)cmd.ExecuteScalar();
            if (rc != 0)
            {
                cmd.CommandText = "select * from junior_college where email = '" + Session["email"].ToString() + "'";

                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session.Add("jstream", dr[1].ToString());
                    Session.Add("jduration", dr[2].ToString());
                    Session.Add("jcollege", dr[3].ToString());
                }
                dr.Close();
                education.InnerHtml += "<div class='timeline-block'>" +
                                    "<div class='timeline-ico'>" +
                                    "<i  class='fa fa-graduation-cap'></i>" +
                                    "</div>" +
                                    "<div class='timeline-header'>" +
                                        "<h3>" + Session["jstream"].ToString() + "</h3>" +
                                        "<p>" + Session["jduration"].ToString() + "</p>" +
                                    "</div>" +
                                    "<div class='timeline-content'>" +
                                    "<h4>" + Session["jcollege"].ToString() + "</h4>" +
                                        "<p style='color:#ebebeb;' >asdasdasdasdasdasdasdasdasdasdasd</p>"
                                    + "</div>" +
                                "</div>";
            }
            address.InnerText = Session["address"].ToString();
            phone.InnerText += Session["phone"].ToString();
            contactMail.InnerText = Session["email"].ToString();






            //"<div class='timeline-block'>:" +
            //                            "<div class='timeline-ico'>" +
            //                            "	<i style='top:30%;' class='fa fa-graduation-cap'></i>" +
            //                            "</div>" +
            //                            "<div class='timeline-header'>" +
            //                                "<h3>" + Session["mdegree"].ToString() + "</h3>" +
            //                                "<p>" + Session["mduration"].ToString() + "</p>" +
            //                            "</div>" +
            //                            "<div class='timeline-content'>" +
            //                                "<h4>" + Session["mcollege"].ToString() + "</h4>" +
            //                            "</div>" +
            //                        "</div>";









            //name.InnerText = "Mohammed ";

            //skills.InnerHtml = "<ul class='skill-bars'>";

            //skills.InnerHtml += "<li>" +
            //                   "<div class='progress percent90'><span>90%</span></div>" +
            //                   "<strong>HTML5</strong>" +
            //               "</li>" +
            //               "<li>" +
            //                   "<div class='progress percent85'><span>85%</span></div>" +
            //                   "<strong>CSS3</strong>" +
            //               "</li>" +
            //               "<li>" +
            //                   "<div class='progress percent70'><span>70%</span></div>" +
            //                   "<strong>JQuery</strong>" +
            //            "</ul>";
            //work_exp.InnerHtml =
            //    "<div class='timeline-block'>" +
            //           "<div class='timeline-ico'>" +
            //           "<i class='fa fa-briefcase'></i>" +
            //           "</div>" +
            //           "<div class='timeline-header'>" +
            //               "<h3>UI Designer</h3>" +
            //               "<p>July 2015 - Present</p>" +
            //             "</div>" +
            //           "<div class='timeline-content'>" +
            //           "<h4>Awesome Studio</h4>" +
            //               "<p>Lorem ipsum Occaecat do esse ex et dolor culpa nisi ex in magna consectetur nisi cupidatat laboris esse eiusmod deserunt aute do quis velit esse sed Ut proident cupidatat nulla esse cillum laborum occaecat nostrud sit dolor incididunt amet est occaecat nisi.</p>"
            //           + "</div>" +
            //       "</div>";
            //education.InnerHtml = "<div class='timeline-block'>:" +
            //            "<div class='timeline-ico'>" +
            //            "	<i class='fa fa-graduation-cap'></i>" +
            //            "</div>" +
            //            "<div class='timeline-header'>" +
            //                "<h3>Master Degree</h3>" +
            //                "<p>July 2015 - Present</p>" +
            //            "</div>" +
            //            "<div class='timeline-content'>" +
            //                "<h4>University of Life</h4>" +
            //                "<p>Lorem ipsum Occaecat do esse ex et dolor culpa nisi ex in magna consectetur nisi cupidatat laboris esse eiusmod deserunt aute do quis velit esse sed Ut proident cupidatat nulla esse cillum laborum occaecat nostrud sit dolor incididunt amet est occaecat nisi.</p>" +
            //            "</div>" +
            //        "</div>";
            //education.InnerHtml += "<div class='timeline-block'>:" +
            //           "<div class='timeline-ico'>" +
            //           "	<i class='fa fa-graduation-cap'></i>" +
            //           "</div>" +
            //           "<div class='timeline-header'>" +
            //               "<h3>Master Degree</h3>" +
            //               "<p>July 2015 - Present</p>" +
            //           "</div>" +
            //           "<div class='timeline-content'>" +
            //               "<h4>University of Life</h4>" +
            //               "<p>Lorem ipsum Occaecat do esse ex et dolor culpa nisi ex in magna consectetur nisi cupidatat laboris esse eiusmod deserunt aute do quis velit esse sed Ut proident cupidatat nulla esse cillum laborum occaecat nostrud sit dolor incididunt amet est occaecat nisi.</p>" +
            //           "</div>" +
            //       "</div>";
        }

      

        protected void download_Click(object sender, EventArgs e)
        {
            string filePath = "/portfolio/uploads/Resume/" + Session["resume"].ToString();
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                // Clear Rsponse reference  
                Response.Clear();
                // Add header by specifying file name  
                Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
                // Add header for content length  
                Response.AddHeader("Content-Length", file.Length.ToString());
                // Specify content type  
                Response.ContentType = "text/plain";
                // Clearing flush  
                Response.Flush();
                // Transimiting file  
                Response.TransmitFile(file.FullName);
                Response.End();
            }
        }
    }
}