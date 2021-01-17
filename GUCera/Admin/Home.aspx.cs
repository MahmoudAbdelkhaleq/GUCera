using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
                Response.Redirect("https://localhost:44350/LoginPage.aspx");
           
        }

        protected void ViewAllCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCourses.aspx");
        }

        protected void UnacceptedCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("NotAcceptedCourses.aspx");
        }

        protected void AcceptCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("AcceptCourses.aspx");
        }

        protected void NewPromo_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewPromo.aspx");
        }

        protected void IssuePromo_Click(object sender, EventArgs e)
        {
            Response.Redirect("IssuePromo.aspx");
        }

        protected void Suicide_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://www.guc.edu.eg/");
        }
    }
}