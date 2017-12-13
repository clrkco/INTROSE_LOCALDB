using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace INTROSE_JGC
{
    public partial class Module7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void btnCreateAcc_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/CreateProject.aspx");
        }

        protected void btnUserMgt_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/UserManagement.aspx");
        }
    }
}