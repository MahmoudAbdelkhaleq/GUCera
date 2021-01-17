using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            int id = Int16.Parse(username.Text);
            String pass = password.Text;

            SqlCommand userLogin = new SqlCommand("userLogin",conn);
            userLogin.CommandType = System.Data.CommandType.StoredProcedure;
            userLogin.Parameters.Add(new SqlParameter("@id", id));
            userLogin.Parameters.Add(new SqlParameter("@password", pass));
            SqlParameter success = userLogin.Parameters.Add("@success", SqlDbType.Int);
            SqlParameter type = userLogin.Parameters.Add("@type", SqlDbType.Int);

            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.Open();
            userLogin.ExecuteNonQuery();
            conn.Close();

            if(success.Value.ToString() == "1")
            {
                Session["userId"] = id;
                if (type.Value.ToString() == "0")
                    Response.Redirect("Instructor/Home.aspx");
                else if (type.Value.ToString() == "2")
                    Response.Redirect("Student/Home.aspx");
                else
                    Response.Redirect("Admin/Home.aspx");
               

            }
            else
            {
                message.Text = "invalid username or password";
            }
           

        }


        protected void StudentRej_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student/Register.aspx");
        }

        protected void InstructorRej_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instructor/Register.aspx");
        }
    }
}