using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Admin
{
    public partial class NotAcceptedCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            else
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand allCourses = new SqlCommand("AdminViewNonAcceptedCourses", conn);
                allCourses.CommandType = System.Data.CommandType.StoredProcedure;

                conn.Open();
                SqlDataReader reader = allCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    String name = reader.GetString(reader.GetOrdinal("name"));
                    String creditHours = reader.GetValue(reader.GetOrdinal("creditHours")).ToString();
                    String price = reader.GetValue(reader.GetOrdinal("price")).ToString();
                    String content;
                    if (reader.GetValue(reader.GetOrdinal("content")) == null)
                        content = "NO CONTENT YET";
                    else
                        content = reader.GetValue(reader.GetOrdinal("content")).ToString();

                    TableRow x = new TableRow();
                    x.Cells.Add(new TableCell()
                    {
                        Text = name
                    });
                    x.Cells.Add(new TableCell()
                    {
                        Text = creditHours
                    });
                    x.Cells.Add(new TableCell()
                    {
                        Text = price
                    });
                    x.Cells.Add(new TableCell()
                    {
                        Text = content
                    });
                    CoursesTable.Rows.Add(x);

                }
                conn.Close();

            }
        }
    }
}