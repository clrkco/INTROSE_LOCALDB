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

namespace INTROSE_JGC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Value;
            string pass = txtPassword.Value;
            System.Diagnostics.Debug.WriteLine(user + " " + pass);
            //get user role then redirect to corresponding role default page
            Response.Redirect("Default.aspx");
        }

        

        
   // btnLogin_Click(Object sender, EventArgs e)
    }
}