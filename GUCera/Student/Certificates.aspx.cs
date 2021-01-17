using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Student
{
    public partial class Certificates : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("https://localhost:44350/LoginPage.aspx");

            else
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                //store the student's cids and courses' names  
                SqlCommand viewMyCourses = new SqlCommand("viewStudentCourses", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                viewMyCourses.Parameters.Add(new SqlParameter("@sid", Session["userId"].ToString()));

                Dictionary<String, String> courseIdName = new Dictionary<String, String>();
                conn.Open();
                SqlDataReader rdr = viewMyCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String id = rdr.GetValue(rdr.GetOrdinal("cid")).ToString();
                    String c = rdr.GetString(rdr.GetOrdinal("name"));
                    courseIdName.Add(id, c);

                }
                conn.Close();

                if (courseIdName.Count > 0)
                {
                    
                    CertificatesTable.Visible = true;

                    for(int i=0; i < courseIdName.Count; i++)
                    {
                        //for every course add its certificate to the table

                        SqlCommand viewCertificate = new SqlCommand("viewCertificate", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        viewCertificate.Parameters.Add(new SqlParameter("@sid",Session["userID"]));
                        viewCertificate.Parameters.Add(new SqlParameter("@cid",courseIdName.Keys.ElementAt(i)));

                        TableRow currentRow = new TableRow();
                        currentRow.Cells.Add(new TableCell()
                        {
                            Text = courseIdName.Values.ElementAt(i)
                        });
                        currentRow.Cells.Add(new TableCell()
                        {//course name
                            Text = courseIdName.Keys.ElementAt(i)
                        });


                        conn.Open();
                        rdr = viewCertificate.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (rdr.Read())
                        {
                            currentRow.Cells.Add(new TableCell()
                            {//course name
                                Text = rdr.GetValue(rdr.GetOrdinal("issueDate")).ToString()
                            });

                        }
                        conn.Close();
                        if(currentRow.Cells.Count ==3)
                        CertificatesTable.Rows.Add(currentRow);

                    }

                }

            }
        }
    }
}