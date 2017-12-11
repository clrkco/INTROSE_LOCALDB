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
using System.Security.Cryptography;
using System.Text;
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

            SqlCommand cmd1 = new SqlCommand("SELECT FIRST_TIME_CHANGED_PASS FROM CMT_EMPLOYEES WHERE USERNAME = @username");
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Validate_User"))
                {
                    con.Open();
                    cmd1.Parameters.AddWithValue("@username", txtUsername.Value);
                    cmd1.Connection = con;
                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Read();
                    int intFirstChange = int.Parse(reader1.GetValue(0).ToString());
                    reader1.Close();

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Username", txtUsername.Value);
                        if (intFirstChange == 1)
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Value);
                        else
                            cmd.Parameters.AddWithValue("@Password", encryption(txtPassword.Value));
                        cmd.Connection = con;
                        
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        userId = Convert.ToInt32(reader["EMPLOYEE_ID"]);
                        roles = reader["ROLES"].ToString();
                        reader.Close();
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
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
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