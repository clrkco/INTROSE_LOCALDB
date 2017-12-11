using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Security.Principal;

namespace INTROSE_JGC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
               if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login/Login.aspx");
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int userId = 0;
            string roles = string.Empty;
            
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Value);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Value);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userId = Convert.ToInt32(reader["EMPLOYEE_ID"]);
                    roles = reader["ROLES"].ToString();
                    con.Close();
                }
                if (userId == -1)
                {
                    lblNotif.Text = "Username and/or password is incorrect.";
                }
                else
                {
                    //change add minutes to lessen remember me timeout
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Value, DateTime.Now, DateTime.Now.AddMinutes(300), cbxRememberMe.Checked, roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    if (ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Value, cbxRememberMe.Checked));

                }
            }
        }

        /*protected void ValidateUser(object sender, EventArgs e)
        {
            int userId = 0;
            string roles = string.Empty;
            string constr =" Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\\Users\\clrkco\\Documents\\Visual Studio 2013\\Projects\\INTROSE_JGC\\App_Data\\LocalDB.mdf;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Value);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Value);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    userId = Convert.ToInt32(reader["EMPLOYEE_ID"]);
                    roles = reader["ROLES"].ToString();
                    con.Close();
                }
                if (userId == -1)
                {
                    lblNotif.Text = "Username and/or password is incorrect.";
                }
                else
                {
                    //change add minutes to lessen remember me timeout
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUsername.Value, DateTime.Now, DateTime.Now.AddMinutes(300),cbxRememberMe.Checked, roles, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    if(ticket.IsPersistent)
                    {
                        cookie.Expires = ticket.Expiration;
                    }
                    Response.Cookies.Add(cookie);
                    Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUsername.Value, cbxRememberMe.Checked));
                    
                }
            }
        }*/
        

    }
}