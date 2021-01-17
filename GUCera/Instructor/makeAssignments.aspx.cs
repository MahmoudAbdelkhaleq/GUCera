using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Instructor
{
    public partial class makeAssignments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int courseID, assignmentNumber, fullGrade;
            decimal weight;
            DateTime deadline;
            try
            {
                courseID = Int16.Parse(TextBox1.Text);
                assignmentNumber = Int16.Parse(TextBox2.Text);
                fullGrade = Int16.Parse(TextBox4.Text);
                weight = decimal.Parse(TextBox5.Text);

            }
            catch
            {

                Label1.Text = "Please enter a number in course ID, Assignment number, full grade, and weight";
                return;
            }

            try
            {
                deadline = Convert.ToDateTime(TextBox6.Text);
            }
            catch
            {
                Label1.Text = "Enter a valid date (DD/MM/YYYY)";
                return;
            }




            string content = TextBox7.Text;
            string type = TextBox3.Text;


            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addAssignment = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            addAssignment.CommandType = CommandType.StoredProcedure;

            addAssignment.Parameters.Add(new SqlParameter("@cid", courseID));
            addAssignment.Parameters.Add(new SqlParameter("@number", assignmentNumber));
            addAssignment.Parameters.Add(new SqlParameter("@type", type));
            addAssignment.Parameters.Add(new SqlParameter("@fullGrade", fullGrade));
            addAssignment.Parameters.Add(new SqlParameter("@weight", weight));
            addAssignment.Parameters.Add(new SqlParameter("@deadline", deadline));
            addAssignment.Parameters.Add(new SqlParameter("@content", content));
            addAssignment.Parameters.Add(new SqlParameter("@instId", Session["userId"]));

            conn.Open();

            try
            {
                addAssignment.ExecuteNonQuery();
                Label1.Text = "Success";
            }
            catch
            {
                Label1.Text = "Error";
            }



            conn.Close();
        }
    }
}