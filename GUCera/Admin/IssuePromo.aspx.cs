using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera.Admin
{
    public partial class IssuePromo : System.Web.UI.Page
    {


        protected void submit_click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            String code = Code.Text;
            if (code == "")
            {
                message.Text = "Please Insert The Promo Code";
            }
            else
            {
                SqlCommand checkPromo = new SqlCommand("checkPromoCode", conn);
                checkPromo.CommandType = System.Data.CommandType.StoredProcedure;
                checkPromo.Parameters.Add(new SqlParameter("@code", code));
                SqlParameter success = checkPromo.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                conn.Open();
                checkPromo.ExecuteNonQuery();
                conn.Close();
                if (success.Value.ToString() == "1") 
                {
                    SqlCommand checkStudentPromo = new SqlCommand("checkStudentHasPromoCode", conn);
                    checkStudentPromo.CommandType = System.Data.CommandType.StoredProcedure;
                    checkStudentPromo.Parameters.Add( new SqlParameter("@sid", Int16.Parse(Students.SelectedValue)) );
                    checkStudentPromo.Parameters.Add(new SqlParameter("@code", code));
                    SqlParameter success2 = checkStudentPromo.Parameters.Add("@success", SqlDbType.Int);
                    success2.Direction = ParameterDirection.Output;
                    conn.Open();
                    checkStudentPromo.ExecuteNonQuery();
                    conn.Close();
                    if (success2.Value.ToString() == "0")
                    {
                        SqlCommand addStudentPromo = new SqlCommand("AdminIssuePromocodeToStudent", conn);
                        addStudentPromo.CommandType = System.Data.CommandType.StoredProcedure;
                        addStudentPromo.Parameters.Add(new SqlParameter("@sid", Int16.Parse(Students.SelectedValue)));
                        addStudentPromo.Parameters.Add(new SqlParameter("@pid", code));
                        conn.Open();
                        addStudentPromo.ExecuteNonQuery();
                        conn.Close();
                        message.Text = "Student Now Has The Promo Code";
                    }
                    else 
                    { message.Text = "Can't Be Issued Because Student Already Has This Promo Code"; }
                }
                else { message.Text = "Promo Code Doesn't Exist"; }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
            else
            {
                String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand allCourses = new SqlCommand("showStudentIds", conn);
                allCourses.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader reader = allCourses.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {

                    String id = reader.GetValue(reader.GetOrdinal("id")).ToString();
                    Students.Items.Add(id);
                }
                conn.Close();
            }
        }
    }
}