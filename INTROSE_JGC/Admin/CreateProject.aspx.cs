using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
namespace INTROSE_JGC.Admin
{
    public partial class CreateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strDept = tbxDepartment.Text;
            string strName = tbxProjectName.Text;
            string strLeadEng = tbxLeadEng.Text;
            int intMonths = int.Parse(tbxDuration.Text);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("INSERT INTO CMT_PROJECT_LIST(PROJECT_NAME, DEPARTMENT, LEAD_ENGINEER,DURATION_IN_MONTHS) VALUES(@projName,@dept,@leadeng,@duration)");
            cmd.Parameters.AddWithValue("@projName", strName);
            cmd.Parameters.AddWithValue("@dept", strDept);
            cmd.Parameters.AddWithValue("@leadeng", strLeadEng);
            cmd.Parameters.AddWithValue("@duration", intMonths);
            cmd.Parameters.AddWithValue("@price", 100);

            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }
    }
}