using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace INTROSE_JGC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            


        }

        protected void ActivityLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
           /* string strDept;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT DEPARTMENT FROM CMT_EMPLOYEES WHERE USERNAME = @username");
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@username", User.Identity.Name);
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            strDept = dr.GetString(0);
            dr.Close();

            SqlCommand cmd1 = new SqlCommand("SELECT PROJECT_NAME, LEAD_ENGINEER, DEPARTMENT, DURATION_IN_MONTHS, TOTAL_PRICE FROM CMT_PROJECT_LIST WHERE DEPARTMENT = @DEPARTMENT");
            cmd1.Parameters.AddWithValue("@DEPARTMENT", strDept);
            System.Diagnostics.Debug.WriteLine(strDept);
            cmd1.Connection = con;
            cmd1.CommandType = CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            tblMATLIST.DataSource = dt;
            tblMATLIST.DataBind();*/

        }
    }
}