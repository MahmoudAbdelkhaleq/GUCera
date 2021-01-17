using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Student
{
    public partial class courseInfoEnroll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            if (Session.Count == 1)
            {
                Response.Redirect("courses.aspx");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewCourseContent = new SqlCommand("viewContent", conn);
            viewCourseContent.CommandType = CommandType.StoredProcedure;

            viewCourseContent.Parameters.Add(new SqlParameter("@id", Session["courseID"]));
            conn.Open();
            SqlDataReader rdr = viewCourseContent.ExecuteReader(CommandBehavior.CloseConnection);
            String content = "Content: ";
            String creditHours = "CreditHours: ";
            String courseDes = "CourseDescription: ";
            String price = "Price: ";
            while (rdr.Read())
            {
                creditHours = creditHours + rdr.GetInt32(rdr.GetOrdinal("creditHours"));
                if (!(rdr["content"] == DBNull.Value))
                    content = content + rdr.GetString(rdr.GetOrdinal("content"));
                else
                    content = content + "no provided info";
                if (!(rdr["courseDescription"] == DBNull.Value))
                    courseDes = courseDes + rdr.GetString(rdr.GetOrdinal("courseDescription"));
                else
                    courseDes = courseDes + "no provided info";
                price = price + rdr.GetDecimal(rdr.GetOrdinal("price"));
            }
            TableRow r1 = new TableRow();
            TableCell c1 = new TableCell();
            r1.Controls.Add(c1);
            c1.Text = creditHours;
            TableRow r2 = new TableRow();
            TableCell c2 = new TableCell();
            r2.Controls.Add(c2);
            c2.Text = courseDes;
            TableRow r3 = new TableRow();
            TableCell c3 = new TableCell();
            r3.Controls.Add(c3);
            c3.Text = content;
            TableRow r4 = new TableRow();
            TableCell c4 = new TableCell();
            r4.Controls.Add(c4);
            c4.Text = price;
            Table1.Controls.Add(r1);
            Table1.Controls.Add(r2);
            Table1.Controls.Add(r3);
            Table1.Controls.Add(r4);
            Button1.Visible = true;
            Button1.Text = "Enroll";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand enrollCourse = new SqlCommand("enrollInCourse", conn);
            enrollCourse.CommandType = CommandType.StoredProcedure;

            enrollCourse.Parameters.Add(new SqlParameter("@sid", Session["userId"]));
            enrollCourse.Parameters.Add(new SqlParameter("@cid", Session["courseID"]));
            enrollCourse.Parameters.Add(new SqlParameter("@instr", Session["InstructorID"]));
            SqlParameter message = enrollCourse.Parameters.Add("@message", SqlDbType.VarChar, 50);
            message.Direction = ParameterDirection.Output;
            conn.Open();
            try
            {
                enrollCourse.ExecuteNonQuery();

                if (message.Value.ToString() == "")
                {
                    Label2.Text = "success";

                }
                else
                {
                    Label2.Text = message.Value.ToString();
                }
            }
            catch
            {
                Label2.Text = "you already enrolled in that course";
            }
            conn.Close();
        }
    }
}