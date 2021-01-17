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
    public partial class viewFeedback : System.Web.UI.Page
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

            SqlCommand viewFeedback = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            viewFeedback.CommandType = CommandType.StoredProcedure;

            viewFeedback.Parameters.Add(new SqlParameter("@cid", Int16.Parse(TextBox1.Text)));
            viewFeedback.Parameters.Add(new SqlParameter("@instrId", Session["userId"]));

            conn.Open();
            SqlDataReader rdr = viewFeedback.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                string number = "" + rdr.GetInt16(rdr.GetOrdinal("number"));
                string comment = "" + rdr.GetInt16(rdr.GetOrdinal("comment"));
                string numberOfLikes = "" + rdr.GetInt16(rdr.GetOrdinal("numberOfLikes"));

                TableCell c1 = new TableCell();
                c1.Text = number;
                TableCell c2 = new TableCell();
                c2.Text = comment;
                TableCell c3 = new TableCell();
                c3.Text = numberOfLikes;

                TableRow r = new TableRow();


                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                Table1.Controls.Add(r);
            }
        }
    }
}