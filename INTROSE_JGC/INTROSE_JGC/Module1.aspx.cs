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
    public partial class Module1 : System.Web.UI.Page
    {
        private DataTable table;
        protected void Page_Load(object sender, EventArgs e)
        {
            table.Columns.Add("PROJECT_ID", typeof(Int32));
            table.Columns.Add("MATERIALS", typeof(String));
            table.Columns.Add("QUANTITY", typeof(Int32));
            table.Columns.Add("REMARKS", typeof(String));
            table.Columns.Add("PRICE", typeof(Single));

            if (!this.IsPostBack)
            {
                //change string connector depending on the configuration of your database
                using (SqlConnection con = new SqlConnection("DATA SOURCE=INTROSE;DBA PRIVILEGE=SYSDBA;USER ID=SYS"))
                {
                    //insert correct query here to get projects below
                    using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name FROM Customers"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            lstProject.DataSource = ds.Tables[0];
                            lstProject.DataTextField = "PROJECT_NAME";
                            lstProject.DataValueField = "PROJECT_ID";
                            lstProject.DataBind();
                        }
                    }
                    //get categories
                    using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name FROM Customers"))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = con;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            lstCategory.DataSource = ds.Tables[0];
                            lstCategory.DataTextField = "CATEGORY";
                            lstCategory.DataValueField = "CATEGORY";
                            lstCategory.DataBind();
                        }
                    }
                }
                lstProject.Items.Insert(0, new ListItem("--Select Project--", "0"));
                lstCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
        }

        protected void proj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            //when category is selected, materials dropdownlist will be filled with data acc. to category
            string category = lstCategory.SelectedValue;
            using (SqlConnection con = new SqlConnection("DATA SOURCE=INTROSE;DBA PRIVILEGE=SYSDBA;USER ID=SYS"))
            {
                //insert correct query here to get material below
                /* use SqlCommand.Parameters
                 * SqlCommand command = new SqlCommand("Select @category from category");
                 * command.Parameters.Add("@category",category); category is the string above.
                 */
                using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name FROM Customers"))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        lstMaterials.DataSource = ds.Tables[0];
                        lstMaterials.DataTextField = "NAME";
                        lstMaterials.DataValueField = "MATERIAL_ID";
                        lstMaterials.DataBind();
                    }
                }
            }
        }

        protected void mat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int intQty = Int32.Parse(txtQuantity.Text);
            string strMaterial = lstMaterials.SelectedValue;
            string strRemarks = txtRemarks.Text;
            //get price of selected material using SQL query
            //float price = qty * priceofmaterial
            DataRow row = table.NewRow();
            row[0] = lstProject.SelectedValue;
            row[1] = lstMaterials.SelectedValue;
            row[2] = intQty;
            row[3] = strRemarks;
            row[4] = 0; //change to price when available
            table.Rows.Add(row);

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //clear gridview or all current additions at datatable
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //send datatable to insert to database
           /* using (var bulkCopy = new SqlBulkCopy(_connection.ConnectionString, SqlBulkCopyOptions.KeepIdentity))
            {
                // my DataTable column names match my SQL Column names, so I simply made this loop. However if your column names don't match, just pass in which datatable name matches the SQL column name in Column Mappings
                foreach (DataColumn col in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                bulkCopy.BulkCopyTimeout = 600;
                bulkCopy.DestinationTableName = destinationTableName;
                bulkCopy.WriteToServer(table);
            }*/
        }

    }
}