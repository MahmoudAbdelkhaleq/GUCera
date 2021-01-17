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
    public partial class SubmitAssignment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("https://localhost:44350/LoginPage.aspx");

            else
            {

                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //store the student's cids and courses' names  
                SqlCommand viewMyCourses = new SqlCommand("viewStudentCourses", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                viewMyCourses.Parameters.Add(new SqlParameter("@sid", Session["userId"].ToString()));
                Dictionary<String, String> courseIdName = new Dictionary<String, String>();
                conn.Open();
                SqlDataReader rdr = viewMyCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                
                    
                    while (rdr.Read())
                    {
                        String id = rdr.GetValue(rdr.GetOrdinal("cid")).ToString();
                        String c = rdr.GetString(rdr.GetOrdinal("name"));
                        courseIdName.Add(id, c);

                    }
                if (CoursesDropDownList.Items.Count < courseIdName.Count)
                {
                    CoursesDropDownList.Items.Add("--");
                    for (int i=0;i<courseIdName.Count;i++)
                    CoursesDropDownList.Items.Add(courseIdName.Keys.ElementAt(i));

                    AssignmentTypeDropDownList.Items.Add("--");
                    AssignmentTypeDropDownList.Items.Add("quiz");
                    AssignmentTypeDropDownList.Items.Add("exam");
                    AssignmentTypeDropDownList.Items.Add("project");

                    AssignmentNumberDropDownList.Items.Add("--");

                 
                }
                conn.Close();

                if (courseIdName.Count == 0)
                {
                    CourseMessage.Text = "You're not enrolled in any courses";
                }
                else
                {
                    //if there are courses 
                    //add -- to the drop down lists
                   
                    

                    for (int i = 0; i < courseIdName.Count; i++)
                    {
                        //for each course, add the assignment numbers and assignment types
                       
                        SqlCommand viewAssignments = new SqlCommand("viewAssign", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        viewAssignments.Parameters.Add(new SqlParameter("@Sid", Session["userId"]));
                        //for each course, get its assignments and add them to the drop list
                        viewAssignments.Parameters.Add(new SqlParameter("@courseId", courseIdName.Keys.ElementAt(i)));


                        conn.Open();
                        rdr = viewAssignments.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                        while (rdr.Read())
                        {
                            if (!AssignmentNumberDropDownList.Items.Contains(new ListItem(rdr.GetValue(rdr.GetOrdinal("number")).ToString())))
                            {
                                AssignmentNumberDropDownList.Items.Add(rdr.GetValue(rdr.GetOrdinal("number")).ToString());
                            }

                        }
                        conn.Close();
                    }
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            if(CoursesDropDownList.SelectedValue == "--")
            {
                CourseMessage.Text = "Select a course";
            }
            else if(AssignmentTypeDropDownList.SelectedValue == "--")
            {
                CourseMessage.Text = " ";
                AssignmentTypeMessage.Text = "Select the correct assignment type for the course";
            }
            else if(AssignmentNumberDropDownList.SelectedValue== "--")
            {
                AssignmentTypeMessage.Text = " ";
                AssignmentNumberMessage.Text = "Select the correct assignment number for the course ";
            }
            else
            {
                AssignmentNumberMessage.Text = " ";
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //store the student's cids and courses' names  
                SqlCommand AssignmentExist = new SqlCommand("AssignmentExist", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                AssignmentExist.Parameters.Add(new SqlParameter("@cid", CoursesDropDownList.SelectedValue));
                AssignmentExist.Parameters.Add(new SqlParameter("@number", AssignmentNumberDropDownList.SelectedValue));
                AssignmentExist.Parameters.Add(new SqlParameter("@type", AssignmentTypeDropDownList.SelectedValue));

                SqlParameter existOutput = AssignmentExist.Parameters.Add("@output", System.Data.SqlDbType.Bit);
                existOutput.Direction = System.Data.ParameterDirection.Output;

                conn.Open();
                AssignmentExist.ExecuteNonQuery();
                conn.Close();
                if (existOutput.Value.ToString() == "True")
                {
                    SqlCommand alreadySubmitted = new SqlCommand("AssignmentAlreadySubmitted", conn)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    alreadySubmitted.Parameters.Add(new SqlParameter("@cid", CoursesDropDownList.SelectedValue));
                    alreadySubmitted.Parameters.Add(new SqlParameter("@number", AssignmentNumberDropDownList.SelectedValue));
                    alreadySubmitted.Parameters.Add(new SqlParameter("@type", AssignmentTypeDropDownList.SelectedValue));
                    alreadySubmitted.Parameters.Add(new SqlParameter("@sid", Session["userId"]));


                    SqlParameter submittedOutput = alreadySubmitted.Parameters.Add("@output", System.Data.SqlDbType.Bit);
                    submittedOutput.Direction = System.Data.ParameterDirection.Output;

                    conn.Open();
                    alreadySubmitted.ExecuteNonQuery();
                    conn.Close();

                    if (submittedOutput.Value.ToString() == "True")
                    {
                        SubmitMessage.Text = "Already submitted before";
                    }
                    else
                    {
                        SubmitMessage.Text = "the assignment has been submitted";
                        SqlCommand submitAssignment = new SqlCommand("submitAssign", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        submitAssignment.Parameters.Add(new SqlParameter("@sid", Session["userId"]));
                        submitAssignment.Parameters.Add(new SqlParameter("@assignnumber", AssignmentNumberDropDownList.SelectedValue));
                        submitAssignment.Parameters.Add(new SqlParameter("@assignType", AssignmentTypeDropDownList.SelectedValue));
                        submitAssignment.Parameters.Add(new SqlParameter("@cid", CoursesDropDownList.SelectedValue));

                        conn.Open();
                        submitAssignment.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                else
                {
                    Response.Write(existOutput.Value.ToString());
                    SubmitMessage.Text = "Please choose the correct values. this assignment doesn't exist";
                }
               
            }
        }
    }
}