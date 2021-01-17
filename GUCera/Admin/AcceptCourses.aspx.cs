using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Admin
{
    public partial class AcceptCourses : System.Web.UI.Page
    {
        protected void Accept_click(object sender, EventArgs e)
        {
            if (Int16.TryParse(adminId.Text, out _))
            {
                int id = Int16.Parse(adminId.Text);
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //Check if adminId exists in database..  
                SqlCommand checkAdmin = new SqlCommand("checkAdminId", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                checkAdmin.CommandType = System.Data.CommandType.StoredProcedure;
                checkAdmin.Parameters.Add(new SqlParameter("@id", id));
                SqlParameter success = checkAdmin.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                if (CoursesDropDownList.SelectedValue=="" || CoursesDropDownList.SelectedValue=="--")
                    courseMessage.Text = "Please Choose the Course";
                else
                    courseMessage.Text = "";
                conn.Open();
                checkAdmin.ExecuteNonQuery();
                conn.Close();
                if (success.Value.ToString() == "1"&&(CoursesDropDownList.SelectedValue!=""&&CoursesDropDownList.SelectedValue!="--"))
                {
                    int courseId = Int16.Parse(CoursesDropDownList.SelectedValue);
                    //Accept the chosen Course..  
                    SqlCommand accept = new SqlCommand("AdminAcceptRejectCourse", conn);
                    accept.CommandType = System.Data.CommandType.StoredProcedure;
                    accept.Parameters.Add(new SqlParameter("@adminid", id));
                    accept.Parameters.Add(new SqlParameter("@courseId", courseId));
                    conn.Open();
                    accept.ExecuteNonQuery();
                    conn.Close();
                    CoursesDropDownList.Items.RemoveAt(Int16.Parse(CoursesDropDownList.SelectedIndex.ToString()));
                    message.Text = "The CourseID " + courseId + " has been accepted";
                }
                else
                {
                    message.Text = "invalid Admin ID or Course ID";
                }

            }
            else {
                message.Text = "Invalid Admin ID ";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
                 if (Session.Count == 0)
                    Response.Redirect("https://localhost:44350/LoginPage.aspx");

                  else
                {

                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //CoursesDropDownList.Items.Clear();
                //store the unaccepted courses ids and names  
                SqlCommand viewMyCourses = new SqlCommand("ViewUnacceptedCoursesByID", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                Dictionary<String, String> courseIdName = new Dictionary<String, String>();
                conn.Open();
                SqlDataReader rdr = viewMyCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);


                while (rdr.Read())
                {
                    String id = rdr.GetValue(rdr.GetOrdinal("id")).ToString();
                    String c = rdr.GetString(rdr.GetOrdinal("name"));
                    courseIdName.Add(id, c);

                }
                if (CoursesDropDownList.Items.Count < courseIdName.Count)
                {
                    CoursesDropDownList.Items.Add("--");
                    for (int i = 0; i < courseIdName.Count; i++)
                        CoursesDropDownList.Items.Add(courseIdName.Keys.ElementAt(i));

                }
                conn.Close();

            }
            
        }

        
    }
}