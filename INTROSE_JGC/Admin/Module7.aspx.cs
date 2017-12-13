using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Spire.Xls;

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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            Workbook workbook = new Workbook();
            DataTable dt = GetDataTableFromDB("select * from CMT_EMPLOYEES");
            workbook.Worksheets[0].InsertDataTable(dt, true, 1, 1);
            dt = GetDataTableFromDB("select * from CMT_MATERIALS_MASTERLIST");
            workbook.Worksheets[1].InsertDataTable(dt, true, 1, 1);
            dt = GetDataTableFromDB("select * from CMT_MONTHLY_SOFTWARE");
            workbook.Worksheets[2].InsertDataTable(dt, true, 1, 1);
            /* dt = GetDataTableFromDB("select * from CMT_PROJECT_LIST");
             workbook.Worksheets[3].InsertDataTable(dt, true, 1, 1);
             dt = GetDataTableFromDB("select * from CMT_SOFTWARE_USAGE");
             workbook.Worksheets[4].InsertDataTable(dt, true, 1, 1);
             dt = GetDataTableFromDB("select * from PROJECT_DETAILS");
             workbook.Worksheets[5].InsertDataTable(dt, true, 1, 1*/
            workbook.SaveToFile("INTROSE_JGC.xlsx", ExcelVersion.Version2010);
            System.Diagnostics.Process.Start("INTROSE_JGC.xlsx");
        }
        static DataTable GetDataTableFromDB(string cmdText)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(cmdText, con);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
}