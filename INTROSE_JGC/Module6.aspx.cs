using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace INTROSE_JGC
{
    public partial class Module6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //add sqlconnection
            //add sql command for fetching project data
            //get data using SqlDataAdapter
            DataTable dt = new DataTable();
            //  sda.Fill(dt); //sda is data adapter
            lstProject2.DataSource = dt;
            lstProject2.DataBind();

            //add sql command for getting software list
            ///get data using SqlDataAdapter
            DataTable dt1 = new DataTable();
            //sda1.Fill(dt1);
            lstSoftware.DataSource = dt1;
            lstSoftware.DataBind();
            
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Int32 intProjected = Int32.Parse(txtProjToBeUsed.Value);
            Int32 intActual = Int32.Parse(txtActualUsed.Value);
            int intProjectID = int.Parse(lstProject2.SelectedValue);
            string strSoftware = lstSoftware.SelectedValue;
            //create DateTime by splitting datetime-local string
            string dt = dtMonth.Value;
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

            //INSERT intProjectID(PROJECT_ID)(TO another trash table for Software list view
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //INSERT each entry in view to db 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Module6.aspx");
        }

    }
}