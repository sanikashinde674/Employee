using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Employee
{
    public partial class Profile : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connstr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] != null)
            {
                if (!IsPostBack)
                {
                    getEmployeeData();
                }

            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void getEmployeeData()
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("select * from Register where Srno=@id", con);
            cmd.Parameters.AddWithValue("@id", Session["EmployeeId"]);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtName.Text = sdr.GetValue(1).ToString();
                txtEmail.Text = sdr.GetValue(2).ToString();
                txtContact.Text = sdr.GetValue(3).ToString();
                txtdept.Text = sdr.GetValue(4).ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            con.Close();
            SqlCommand cmd = new SqlCommand("update Register set Name=@name,Contact=@contact,Email=@email where Srno=@id", con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@contact", txtContact.Text);
            cmd.Parameters.AddWithValue("@email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@id", Session["EmployeeId"]);
            con.Open();
            cmd.ExecuteNonQuery();
            getEmployeeData();
        }
    }
}
