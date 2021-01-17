using System;
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
    public partial class addCreditCard : System.Web.UI.Page
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
            DateTime t;
            String CardNumber = TextBox1.Text;
            String name = TextBox2.Text;
            try
            {
                t = Convert.ToDateTime(TextBox3.Text);
            }
            catch
            {
                Label3.Text = "not a valid date";
                return;
            }
            String cvv = TextBox4.Text;

            SqlCommand acc = new SqlCommand("addCreditCard", conn);
            acc.CommandType = CommandType.StoredProcedure;

            acc.Parameters.Add(new SqlParameter("@sid", Session["userId"]));
            acc.Parameters.Add(new SqlParameter("@number", CardNumber));
            acc.Parameters.Add(new SqlParameter("@cardHolderName", name));
            acc.Parameters.Add(new SqlParameter("@expiryDate", t));
            acc.Parameters.Add(new SqlParameter("@cvv", cvv));
            try
            {
                conn.Open();
                acc.ExecuteNonQuery();
                conn.Close();
                Label1.Text = "Success";
            }
            catch
            {
                Label1.Text = "Already Added";
            }
        }
    }
}