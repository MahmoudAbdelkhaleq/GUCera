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
    public partial class issuedPromoCodes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
                return;
            }
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand viewPcodes = new SqlCommand("viewPromocode", conn);
            viewPcodes.CommandType = CommandType.StoredProcedure;
            viewPcodes.Parameters.Add(new SqlParameter("@sid", Session["userId"]));

            conn.Open();
            SqlDataReader rdr = viewPcodes.ExecuteReader(CommandBehavior.CloseConnection);
            DataTable d = new DataTable();
            d.Columns.Add("code");
            d.Columns.Add("isuueDate");
            d.Columns.Add("expiryDate");
            d.Columns.Add("discount");
            while (rdr.Read())
            {
                String code = rdr.GetString(rdr.GetOrdinal("code"));
                String issue = "" + rdr.GetDateTime(rdr.GetOrdinal("isuueDate"));
                String expiry = "" + rdr.GetDateTime(rdr.GetOrdinal("expiryDate"));
                String discount = "" + rdr.GetDecimal(rdr.GetOrdinal("discount"));
                d.Rows.Add(code, issue, expiry, discount);
                /*TableCell c1 = new TableCell();
                c1.Text = code;
                TableCell c2 = new TableCell();
                c2.Text = issue;
                TableCell c3 = new TableCell();
                c3.Text = expiry;
                TableCell c4 = new TableCell();
                c4.Text = discount;
                TableRow r = new TableRow();
                r.Controls.Add(c1);
                r.Controls.Add(c2);
                r.Controls.Add(c3);
                r.Controls.Add(c4);
                Table1.Controls.Add(r);*/
            }
            DataView dv = new DataView(d);
            d1.DataSource = dv;
            d1.DataBind();
            form1.Controls.Add(d1);
        }
    }
}