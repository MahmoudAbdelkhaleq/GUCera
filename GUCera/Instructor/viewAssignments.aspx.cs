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
    public partial class viewAssignments : System.Web.UI.Page
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

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewAssignment = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            viewAssignment.CommandType = CommandType.StoredProcedure;

            viewAssignment.Parameters.Add(new SqlParameter("@cid", Int16.Parse(TextBox1.Text)));
            viewAssignment.Parameters.Add(new SqlParameter("@instrId", Session["userId"]));

            conn.Open();
            SqlDataReader rdr = viewAssignment.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string sid = "" + rdr.GetInt16(rdr.GetOrdinal("sid"));
                string cid = "" + rdr.GetInt16(rdr.GetOrdinal("cid"));
                string assignmentNumber = "" + rdr.GetInt16(rdr.GetOrdinal("assignmentNumber"));
                string grade = "" + rdr.GetInt16(rdr.GetOrdinal("grade"));
                string assignmenttype = "" + rdr.GetInt16(rdr.GetOrdinal("assignmenttype"));

                TableCell c1 = new TableCell();
                c1.Text = sid;
                TableCell c2 = new TableCell();
                c2.Text = cid;
                TableCell c3 = new TableCell();
                c3.Text = assignmentNumber;
                TableCell c4 = new TableCell();
                c4.Text = grade;
                TableCell c5 = new TableCell();
                c5.Text = assignmenttype;
                TableRow r = new TableRow();


                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                r.Controls.Add(c5);
                Table1.Controls.Add(r);
            }

        }
    }
}