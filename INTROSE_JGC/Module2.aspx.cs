using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace INTROSE_JGC
{
    public partial class Module2 : System.Web.UI.Page
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

        protected void lstProject2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void lstSoftware_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int intProjID= Int32.Parse(lstProject2.SelectedValue);
            string strSoftware = lstSoftware.SelectedValue;
            int intMonths= Int32.Parse(txtNumofMons.Value);

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

            //insert intProjID (PROJECT_ID),strSoftware (SOFTWARE), intMonths(NUMBER_OF_MONTHS), dtDate(START_DATE)
            //push to TEMPTABLE which is shown as view

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //transfer all entries from temp db to orig db
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //delete all entries in temptable with SQLCommand 
            Response.Redirect("Module2.aspx");
        }


    }
}