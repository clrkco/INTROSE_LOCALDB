using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace INTROSE_JGC
{
    public partial class Module2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lstProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lstSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string strProjname;
            int intProjID= Int32.Parse(lstProject2.SelectedValue);
            string strSoftware = lstSoftware.SelectedValue;
            int intMonths= int.Parse(txtNumofMons.Value);
            
            //create sql connection
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            
            //create DateTime by splitting datetime-local string
            string dt = dtStart.Value;
            string[] separator = { "-", "T", ":" };
            string[] datetime = dt.Split(separator, System.StringSplitOptions.RemoveEmptyEntries);
            Int32 intYear, intMonth, intDay, intHour, intMinute, intSecond;
            intYear = Int32.Parse(datetime[0]);
            intDay = Int32.Parse(datetime[2]);
            intMonth = Int32.Parse(datetime[1]);
            intHour = Int32.Parse(datetime[3]);
            intMinute = Int32.Parse(datetime[4]);
            intSecond = 0;
            DateTime dtDate = new DateTime(intYear, intMonth, intDay, intHour, intMinute, intSecond);
            
            

            SqlCommand cmd = new SqlCommand("INSERT INTO [TEMP_TABLE2] VALUES(@projID,@startdt,@numMo,@software)");
            cmd.Parameters.AddWithValue("@projID", intProjID);
            cmd.Parameters.AddWithValue("@startdt", dtDate);
            cmd.Parameters.AddWithValue("@numMo", intMonths);
            cmd.Parameters.AddWithValue("@software", strSoftware);
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();


            SqlCommand cmd5 = new SqlCommand("SELECT PROJECT_NAME FROM CMT_PROJECT_LIST WHERE PROJECT_ID = @projid ");     
                cmd5.Parameters.AddWithValue("@projid", lstProject2.SelectedValue);
                cmd5.Connection = con;
                using (SqlDataReader sdr1 = cmd5.ExecuteReader())
                {
                    sdr1.Read();
                    System.Diagnostics.Debug.WriteLine(sdr1.GetString(0));
                    strProjname = sdr1.GetValue(0).ToString();
                }

            SqlCommand cmd1 = new SqlCommand("INSERT INTO [TEMP_TABLE2_VIEW] VALUES(@projname,@startdt,@numMo,@software)");
            cmd1.Parameters.AddWithValue("@projname", strProjname);
            cmd1.Parameters.AddWithValue("@startdt", dtDate);
            cmd1.Parameters.AddWithValue("@numMo", intMonths);
            cmd1.Parameters.AddWithValue("@software", strSoftware);
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();

            lblStatus.Text = "Successfully added!";
            con.Close();
            Response.Redirect("Module2.aspx");


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strEmployee;
            string strProjname;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd4 = new SqlCommand("INSERT INTO CMT_MONTHLY_SOFTWARE SELECT * FROM TEMP_TABLE2");
            con.Open();
            cmd4.Connection = con;
            cmd4.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand("INSERT INTO CMV_ActivityLog(EMPLOYEE_NAME,PROJECT_NAME,DATETIME,REMARKS) VALUES(@empname,@projname,@datetime,@rmk)");

            SqlCommand cmd6 = new SqlCommand("SELECT NAME FROM CMT_EMPLOYEES WHERE USERNAME = @user");
            cmd6.Parameters.AddWithValue("@user", User.Identity.Name);
            cmd6.Connection = con;
            using (SqlDataReader sdr = cmd6.ExecuteReader())
            {
                sdr.Read();
                strEmployee = sdr.GetString(0);
            }

            SqlCommand cmd8 = new SqlCommand("SELECT PROJECT_NAME FROM CMT_PROJECT_LIST WHERE PROJECT_ID = @projid ");
            cmd8.Parameters.AddWithValue("@projid", int.Parse(lstProject2.SelectedValue));
            cmd8.Connection = con;
            using (SqlDataReader sdr1 = cmd8.ExecuteReader())
            {
                sdr1.Read();
                System.Diagnostics.Debug.WriteLine(sdr1.GetString(0));
                strProjname = sdr1.GetValue(0).ToString();
            }
            cmd7.Parameters.AddWithValue("@empname", strEmployee);
            cmd7.Parameters.AddWithValue("@projname", strProjname);
            cmd7.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd7.Parameters.AddWithValue("@rmk", "Submitted new form for project: " + strProjname);
            cmd7.Connection = con;
            cmd7.ExecuteNonQuery();
            con.Close();

            lblStatus.Text = "Successfully submitted!";
            Response.Redirect("Module2.aspx");


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd1 = new SqlCommand("DELETE TEMP_TABLE2_VIEW");
            cmd1.Connection = con;
            con.Open();
            cmd1.ExecuteNonQuery();
            SqlCommand cmd2 = new SqlCommand("DELETE TEMP_TABLE2");
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            con.Close();
            lblStatus.Text = "Successfully cleared entries!";
            Response.Redirect("Module2.aspx");
        }



    }
}