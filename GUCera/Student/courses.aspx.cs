using System;
using System.Collections;
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
    public partial class courses : System.Web.UI.Page
    {
        ArrayList Cour = new ArrayList();
        ArrayList btns = new ArrayList();
        ArrayList inst = new ArrayList();
        ArrayList rows = new ArrayList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewCourse = new SqlCommand("availableCourses", conn);
            viewCourse.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = viewCourse.ExecuteReader(CommandBehavior.CloseConnection);

            while (rdr.Read())
            {
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Cour.Add(rdr.GetInt32(rdr.GetOrdinal("id")));
                inst.Add(rdr.GetInt32(rdr.GetOrdinal("instructorId")));

                TableRow r = new TableRow();
                TableCell c1 = new TableCell();
                TableCell c2 = new TableCell();

                c1.Text = courseName;
                r.Cells.Add(c1);
                list.Rows.Add(r);
                Button en = new Button();
                en.Click += new EventHandler(button_Click3);
                btns.Add(en);
                rows.Add(r);

                c2.Controls.Add(en);
                en.Text = "View INFO";
                r.Cells.Add(c2);
            }
        }
        protected void button_Click3(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            for (int i = 0; i < btns.Count; i++)
            {
                if (btns[i] == btn)
                {
                    Session["courseID"] = Cour[i];
                    Session["InstructorID"] = inst[i];
                }
            }
            Response.Redirect("courseInfoEnroll.aspx");

        }
    }
}