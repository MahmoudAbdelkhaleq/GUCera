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
    public partial class addNewCourse : System.Web.UI.Page
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
            int creditHours;
            decimal coursePrice;
            try
            {
                creditHours = Int16.Parse(TextBox1.Text);
                coursePrice = decimal.Parse(TextBox3.Text);
            }
            catch
            {
                Label1.Text = "Enter a valid integer in credit hours, course pirce";
                return;
            }


            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            String courseName = TextBox2.Text;
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand addCourse = new SqlCommand("InstAddCourse", conn);
            addCourse.CommandType = CommandType.StoredProcedure;

            addCourse.Parameters.Add(new SqlParameter("@creditHours", creditHours));
            addCourse.Parameters.Add(new SqlParameter("@name", courseName));
            addCourse.Parameters.Add(new SqlParameter("@price", coursePrice));
            addCourse.Parameters.Add(new SqlParameter("@instructorId", Session["userId"]));

            conn.Open();

            try
            {
                addCourse.ExecuteNonQuery();
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