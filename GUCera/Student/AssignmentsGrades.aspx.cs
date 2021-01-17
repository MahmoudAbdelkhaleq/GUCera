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
    public partial class AssignmentsGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
            else { 
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

                if (courseIdName.Count == 0)
                {
                    GradesMessage.Text = "You're not enrolled in any courses";
                }
                else
                {
                    GradesMessage.Text = " ";
                    GradesTable.Visible = true;


                    for (int i = 0; i < courseIdName.Count; i++)
                    {
                        //for each course look for submmitted assignments and display their grades, if not graded display --
                        //first we get all the assignments and store them in assignmentNumberType dictionary
                        Dictionary<String, String> assignmentNumberType = new Dictionary<string, string>();
                        SqlCommand viewAssignments = new SqlCommand("viewAssign", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        viewAssignments.Parameters.Add(new SqlParameter("@Sid", Session["userId"]));
                        //for each course, get its assignments and add them to the table
                        viewAssignments.Parameters.Add(new SqlParameter("@courseId", courseIdName.Keys.ElementAt(i)));
                        conn.Open();
                         rdr = viewAssignments.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (rdr.Read())
                        {
                            assignmentNumberType.Add(rdr.GetValue(rdr.GetOrdinal("number")).ToString()
                                ,rdr.GetString(rdr.GetOrdinal("type")));
                        }
                        conn.Close();
                        //now we which assignments are submitted or not
                        for (int j = 0; j < assignmentNumberType.Count; j++) {
                            SqlCommand viewGrades = new SqlCommand("viewAssignGrades", conn)
                            {
                                CommandType = System.Data.CommandType.StoredProcedure
                            };

                            viewGrades.Parameters.Add(new SqlParameter("@cid", courseIdName.Keys.ElementAt(i)));
                            viewGrades.Parameters.Add(new SqlParameter("@sid", Session["userId"]));
                            viewGrades.Parameters.Add(new SqlParameter("@assignnumber", assignmentNumberType.Keys.ElementAt(j)));
                            viewGrades.Parameters.Add(new SqlParameter("@assignType", assignmentNumberType.Values.ElementAt(j)));
                            SqlParameter grade = viewGrades.Parameters.Add("@assignGrade", System.Data.SqlDbType.Int);
                            grade.Direction = System.Data.ParameterDirection.Output;

                            conn.Open();
                            viewGrades.ExecuteNonQuery();
                            conn.Close();

                            //make the table
                            TableRow currentRow = new TableRow();

                            currentRow.Cells.Add(new TableCell()
                            {
                                Text = courseIdName.Values.ElementAt(i)
                            });
                            currentRow.Cells.Add(new TableCell()
                            {
                                Text = courseIdName.Keys.ElementAt(i)
                            });
                            currentRow.Cells.Add(new TableCell()
                            {
                                Text = assignmentNumberType.Keys.ElementAt(j)
                            });
                            currentRow.Cells.Add(new TableCell()
                            {
                                Text = assignmentNumberType.Values.ElementAt(j)
                            });

                           
                            currentRow.Cells.Add(new TableCell()
                            {
                                    Text = grade.Value.ToString()
                            }) ;

                            GradesTable.Rows.Add(currentRow);

                        }
                    }

                }
            }
        }
    }
}