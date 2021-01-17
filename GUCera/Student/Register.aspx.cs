using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class StudentRej : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegisterStudent_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();

            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand registerStudent = new SqlCommand("studentRegister", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure

            };
            SqlCommand existDuplicateEmail = new SqlCommand("existDuplicateEmail", conn)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            String firstName = FirstNameBox.Text;
            String lastName = LastNameBox.Text;
            String password = PasswordBox.Text;
            String email = EmailBox.Text;
            String address = AddressBox.Text;
            bool genderChecked = false;
            SqlParameter emailDuplicated;
            if (Male.Checked)
            {
                registerStudent.Parameters.Add(new SqlParameter("@gender", "1"));
                GenderMessage.Text = " ";
                genderChecked = true;
            }
            else if (Female.Checked)
            {
                registerStudent.Parameters.Add(new SqlParameter("@gender", "0"));
                GenderMessage.Text = " ";
                genderChecked = true;
            }
            else
            {
                GenderMessage.Text = "Please Select your Gender";
                genderChecked = false;
            }

            registerStudent.Parameters.Add(new SqlParameter("@first_name", firstName));
            registerStudent.Parameters.Add(new SqlParameter("@last_name", lastName));
            registerStudent.Parameters.Add(new SqlParameter("@password", password));
            registerStudent.Parameters.Add(new SqlParameter("@address", address));

            existDuplicateEmail.Parameters.Add(new SqlParameter("@email", email));
            emailDuplicated = existDuplicateEmail.Parameters.Add("@output",System.Data.SqlDbType.Bit);
            emailDuplicated.Direction = System.Data.ParameterDirection.Output;

            conn.Open();
            existDuplicateEmail.ExecuteNonQuery();
            conn.Close();
            Response.Write(emailDuplicated.Value.ToString());
            if (emailDuplicated.Value.ToString()=="False")
            {
                registerStudent.Parameters.Add(new SqlParameter("@email", email));
                EmailMessage.Text = " ";
            }
            else
            {
                EmailMessage.Text = "Email already exists";
            }
            if (genderChecked && emailDuplicated.Value.ToString() =="False")
            {
                conn.Open();
                
                registerStudent.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
        }
    }
}