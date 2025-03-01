using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
    public partial class Employee_Management_System : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] != null)
            {
                lilogout.Visible = true;
                lilogin.Visible = false;
                liregister.Visible = false;
            }
            else
            {
                lilogout.Visible = false;
                lilogin.Visible = true;
                liregister.Visible = true;
            }

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Index.aspx");
        }
    }
}