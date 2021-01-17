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
    public partial class gradeAssignments : System.Web.UI.Page
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
            int sid, cid, assignmentNumber, grade;
            try
            {
                sid = Int16.Parse(TextBox1.Text);
                cid = Int16.Parse(TextBox2.Text);
                assignmentNumber = Int16.Parse(TextBox3.Text);
                grade = Int16.Parse(TextBox5.Text);
            }
            catch
            {
                Label1.Text = "Enter a valid int in sid, cid, number, grade";
                return;
            }



            string type = TextBox4.Text;

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand gradeAssignment = new SqlCommand("InstructorgradeAssignmentOfAStudent", conn);
            gradeAssignment.CommandType = CommandType.StoredProcedure;

            gradeAssignment.Parameters.Add(new SqlParameter("@sid", sid));
            gradeAssignment.Parameters.Add(new SqlParameter("@cid", cid));
            gradeAssignment.Parameters.Add(new SqlParameter("@assignmentNumber", assignmentNumber));
            gradeAssignment.Parameters.Add(new SqlParameter("@type", type));
            gradeAssignment.Parameters.Add(new SqlParameter("@grade", grade));
            gradeAssignment.Parameters.Add(new SqlParameter("@instrId", Session["userId"]));

            conn.Open();

            try
            {
                gradeAssignment.ExecuteNonQuery();
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