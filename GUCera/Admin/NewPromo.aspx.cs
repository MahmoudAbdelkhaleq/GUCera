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
    public partial class NewPromoCode : System.Web.UI.Page
    {

        protected void submit_click(object sender, EventArgs e)
        {
              String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
              SqlConnection conn = new SqlConnection(connStr);
            // Set Flags for Suring
            bool flag2;
            bool flag3;
            decimal Discount = 0;
            // create new DateTime for issue and expiry
            DateTime issueDate = new DateTime( Int16.Parse(IssueDateYear.Text), Int16.Parse(IssueDateMonth.Text)
                , Int16.Parse(IssueDateDay.Text) , 0,0,0);
            DateTime expiryDate = new DateTime(Int16.Parse(ExpiryDateYear.Text), Int16.Parse(ExpiryDateMonth.Text)
                , Int16.Parse(ExpiryDateDay.Text), 0, 0, 0);

            if (decimal.TryParse(discount.Text, out _))
            {
                flag2 = true;
                messageDiscount.Text = "";
                Discount = decimal.Parse(discount.Text); 
            }
            else
            {
                flag2 = false;
                messageDiscount.Text = "Invaild Discount Amount";
            }

            if (DateTime.Compare(issueDate, expiryDate) < 0)
            {
                flag3 = true;
                messageIssueDate.Text = "";
                messageExpiryDate.Text = "";
            }
            else
            {
                flag3 = false;
                messageIssueDate.Text = "Issue date can't be after expiry date";
                messageExpiryDate.Text = "expiry date should be after issue date";
            }
            if (Int16.TryParse(adminId.Text, out _))
            {
                
                messageAdminId.Text = "";
                int AdminId = Int16.Parse(adminId.Text);
                SqlCommand checkAdmin = new SqlCommand("checkAdminId", conn);
                checkAdmin.CommandType = System.Data.CommandType.StoredProcedure;
                checkAdmin.Parameters.Add(new SqlParameter("@id", AdminId));
                SqlParameter success = checkAdmin.Parameters.Add("@success", SqlDbType.Int);
                success.Direction = ParameterDirection.Output;
                conn.Open();
                checkAdmin.ExecuteNonQuery();
                conn.Close();
               
                if (success.Value.ToString() == "1" && flag2 && flag3)
                { 
                    SqlCommand checkPromo = new SqlCommand("CheckPromoCodeExist", conn);
                    checkPromo.CommandType = System.Data.CommandType.StoredProcedure;
                    checkPromo.Parameters.Add(new SqlParameter("@code", code.Text));
                    checkPromo.Parameters.Add(new SqlParameter("@adminId", AdminId));
                    SqlParameter success2 = checkPromo.Parameters.Add("@success", SqlDbType.Int);
                    success2.Direction = ParameterDirection.Output;
                    conn.Open();
                    checkPromo.ExecuteNonQuery();
                    conn.Close();
                    if (success2.Value.ToString() == "1") 
                    {
                        SqlCommand add = new SqlCommand("AdminCreatePromocode", conn);
                        add.CommandType = System.Data.CommandType.StoredProcedure;
                        add.Parameters.Add(new SqlParameter("@code", code.Text));
                        add.Parameters.Add(new SqlParameter("@isuueDate", issueDate));
                        add.Parameters.Add(new SqlParameter("@expiryDate", expiryDate));
                        add.Parameters.Add(new SqlParameter("@discount", Discount));
                        add.Parameters.Add(new SqlParameter("@adminId", AdminId));
                        conn.Open();
                        add.ExecuteNonQuery();
                        conn.Close();
                        messageAdminId.Text = "The Promo Code Has Been Added ";
                    }
                    else 
                    {
                        messageAdminId.Text = "The Promo Code Has Already Been Created Before";
                    } 
                }
                else
                {
                    messageAdminId.Text = "Admin is not in the DB";
                }
            }
            else
            {
                messageAdminId.Text = "Invaild Admin Id";
            }
                    }
          
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
            }
            {
                if (!Page.IsPostBack)
                {
                    //Fill Years
                    for (int i = 2020; i <= 2030; i++)
                    {
                        IssueDateYear.Items.Add(i.ToString());
                        ExpiryDateYear.Items.Add(i.ToString());
                    }
                    IssueDateYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
                    ExpiryDateYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;

                    //Fill Months
                    for (int i = 1; i <= 12; i++)
                    {
                        IssueDateMonth.Items.Add(i.ToString());
                        ExpiryDateMonth.Items.Add(i.ToString());
                    }
                    IssueDateMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
                    ExpiryDateMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true;
                    //Fill days
                    FillDays();
                }
            }
        }

        public void FillDays()
        {
            IssueDateDay.Items.Clear();
            ExpiryDateDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays1 = DateTime.DaysInMonth(Convert.ToInt32(IssueDateYear.SelectedValue), Convert.ToInt32(IssueDateMonth.SelectedValue));
            int noofdays2 = DateTime.DaysInMonth(Convert.ToInt32(ExpiryDateYear.SelectedValue), Convert.ToInt32(ExpiryDateMonth.SelectedValue));
            //Fill days
            for (int i = 1; i <= noofdays1; i++)
            {
                IssueDateDay.Items.Add(i.ToString());
            }
            for (int i = 1; i <= noofdays2; i++)
            {
                ExpiryDateDay.Items.Add(i.ToString());
            }
            IssueDateDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
            ExpiryDateDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;
        }

        protected void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }

        protected void Month_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }

    }
    } 