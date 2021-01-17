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
    public partial class issueCertificate : System.Web.UI.Page
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
            int sid, cid;
            DateTime issueDate;
            try
            {
                cid = Int16.Parse(TextBox1.Text);
                sid = Int16.Parse(TextBox2.Text);
            }
            catch
            {
                Label1.Text = "Enter a valid integer in cid, sid";
                return;
            }

            try
            {
                issueDate = Convert.ToDateTime(TextBox3.Text);
            }
            catch
            {
                Label1.Text = "Enter a valid date (DD/MM/YYYY)";
                return;
            }



            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand issueCertificate = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            issueCertificate.CommandType = CommandType.StoredProcedure;

            issueCertificate.Parameters.Add(new SqlParameter("@sid", sid));
            issueCertificate.Parameters.Add(new SqlParameter("@cid", cid));
            issueCertificate.Parameters.Add(new SqlParameter("@issueDate", issueDate));
            issueCertificate.Parameters.Add(new SqlParameter("@insId", Session["userId"]));

            conn.Open();

            try
            {
                issueCertificate.ExecuteNonQuery();

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