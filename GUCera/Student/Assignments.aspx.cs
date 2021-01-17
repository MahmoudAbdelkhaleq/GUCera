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
    public partial class Assignments : System.Web.UI.Page
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
                viewMyCourses.Parameters.Add(new SqlParameter("@sid",Session["userId"].ToString()));

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

                if(courseIdName.Count == 0)
                {
                    AssignmentMessage.Text = "You're not enrolled in any courses";
                }
                else
                {   
                    AssignmentMessage.Text = " ";

                    

                    for(int i = 0; i < courseIdName.Count; i++)
                    {
                        SqlCommand viewAssignments = new SqlCommand("viewAssign", conn)
                        {
                            CommandType = System.Data.CommandType.StoredProcedure
                        };

                        viewAssignments.Parameters.Add(new SqlParameter("@Sid", Session["userId"]));
                        //for each course, get its assignments and add them to the table
                        viewAssignments.Parameters.Add(new SqlParameter("@courseId", courseIdName.Keys.ElementAt(i)));
                        string[] cells = new string[6];
                        
                        conn.Open();
                        rdr = viewAssignments.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (rdr.Read())
                        {
                             cells[0] = rdr.GetValue(rdr.GetOrdinal("number")).ToString();
                             cells[1] = rdr.GetString(rdr.GetOrdinal("type"));
                             cells[2] = rdr.GetValue(rdr.GetOrdinal("fullGrade")).ToString();
                             cells[3] = rdr.GetValue(rdr.GetOrdinal("weight")).ToString();
                             cells[4] = rdr.GetValue(rdr.GetOrdinal("deadline")).ToString();
                             cells[5] = rdr.GetString(rdr.GetOrdinal("content"));

                            if(cells[0] == "")
                            {
                                break;
                            }
                            else
                            {
                                TableRow currentRow = new TableRow();
                                currentRow.Cells.Add(new TableCell()
                                {//course name
                                    Text = courseIdName.Values.ElementAt(i)
                                });
                                currentRow.Cells.Add(new TableCell()
                                {//course id
                                    Text = courseIdName.Keys.ElementAt(i)
                                });
                                for (int j = 0; j < 6; j++)
                                {
                                    currentRow.Cells.Add(new TableCell()
                                    {
                                        Text = cells[j]
                                    });

                                }
                                AssignmentsTable.Rows.Add(currentRow);

                            }

                        }
                        conn.Close();

                        

                        
  
                    }
                  
                }

            }
        }
    }
}