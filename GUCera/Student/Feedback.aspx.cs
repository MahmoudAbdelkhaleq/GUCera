using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Student
{
    public partial class Feedback : System.Web.UI.Page
    {
        Dictionary<String, String> courseIdName = new Dictionary<String, String>();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
            else
            {

                //first get all the courses for the student for the dropDown list
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //store the student's cids and courses' names  
                SqlCommand viewMyCourses = new SqlCommand("viewStudentCourses", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                viewMyCourses.Parameters.Add(new SqlParameter("@sid", Session["userId"].ToString()));

                
                conn.Open();
                SqlDataReader rdr = viewMyCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                if(courseIdName.Count==0)
                while (rdr.Read())
                {
                    String id = rdr.GetValue(rdr.GetOrdinal("cid")).ToString();
                    String c = rdr.GetString(rdr.GetOrdinal("name"));
                    courseIdName.Add(id, c);

                }
                conn.Close();

                if(courseIdName.Count == 0)
                {
                    SubmitMessage.Text = "You're not enrolled in any courses";
                }
                else
                {
                    SubmitMessage.Text = " ";
                    //populate the dropDown list

                    for(int i = 0; CourseDropDownList.Items.Count < courseIdName.Count && i < courseIdName.Count(); i++)
                    {
                        CourseDropDownList.Items.Add(new ListItem()
                        {
                            Text = courseIdName.Values.ElementAt(i)
                        });
                    }



                }
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (courseIdName.Count == 0)
            {
                SubmitMessage.Text = " you're not enrolled in any courses";
            }
            else
            {

                if (FeedBackTextBox.Text == "")
                {
                    SubmitMessage.Text = "unfortunately, unlike GUC, you need to enter your feedback";
                }
                else
                {
                    String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                    SqlConnection conn = new SqlConnection(connStr);
                    //get the course ID corresponding to the selected course name in the drop down list
                    String courseId="";
                    for(int i =0;  i < courseIdName.Count; i++)
                    {
                        if(CourseDropDownList.SelectedValue == courseIdName.Values.ElementAt(i))
                        {
                            courseId = courseIdName.Keys.ElementAt(i);
                            break;
                        }
                    }
                    //add the feedback
                        SqlCommand addFeedback = new SqlCommand("addFeedback", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        addFeedback.Parameters.Add(new SqlParameter("@cid", courseId));
                        addFeedback.Parameters.Add(new SqlParameter("@sid", Session["userId"]));
                        addFeedback.Parameters.Add(new SqlParameter("@comment",FeedBackTextBox.Text ));
                        conn.Open();
                        addFeedback.ExecuteNonQuery();
                        conn.Close();
                        SubmitMessage.Text = "Your feedback has been recorded";

                }
            }
        }
    }
}