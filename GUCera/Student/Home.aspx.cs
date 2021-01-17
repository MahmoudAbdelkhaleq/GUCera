using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            else
            {
                // writes the name of the user After "Welcome, "
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

                SqlConnection conn = new SqlConnection(connStr);

                SqlCommand StudentInfo = new SqlCommand("viewMyProfile", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                StudentInfo.Parameters.Add(new SqlParameter("@id", Session["userId"].ToString()));

                conn.Open();
                SqlDataReader rdr = StudentInfo.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (rdr.Read())
                    StudentName.Text = rdr.GetString(rdr.GetOrdinal("firstName"));
                conn.Close();

            }
        }

        protected void ViewAssignments_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assignments.aspx");
        }

        protected void SubmitAssignment_Click(object sender, EventArgs e)
        {
            Response.Redirect("SubmitAssignment.aspx");
        }

        protected void ViewGrades_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignmentsGrades.aspx");
        }

        protected void AddFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("Feedback.aspx");
        }

        protected void ViewCertificates_Click(object sender, EventArgs e)
        {
            Response.Redirect("Certificates.aspx");
        }

        protected void CreditCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("addCreditCard.aspx");
        }

        protected void StudentProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("myProfile.aspx");
        }

        protected void ViewCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("courses.aspx");
        }

        protected void PromoCodes_Click(object sender, EventArgs e)
        {
            Response.Redirect("issuedPromoCodes.aspx");
        }
    }
}