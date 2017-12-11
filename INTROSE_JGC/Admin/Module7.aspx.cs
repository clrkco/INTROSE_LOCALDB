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
            if (!this.IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    Response.Redirect("~/Login/Login.aspx");
                }
                if (this.Page.User.IsInRole("Administrator"))
                {
                    gvUsers.DataSource = GetData("SELECT EMPLOYEE_ID, USERNAME, ROLES FROM CMT_EMPLOYEES");
                    gvUsers.DataBind();
                }
            }
        }

        private DataTable GetData(string query)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlRoles = (e.Row.FindControl("ddlRoles") as DropDownList);
                ddlRoles.DataSource = GetData("SELECT ROLES FROM Roles");
                ddlRoles.DataTextField = "ROLES";
                ddlRoles.DataValueField = "ROLES";
                ddlRoles.DataBind();

                string assignedRole = (e.Row.DataItem as DataRowView)["ROLES"].ToString();
                ddlRoles.Items.FindByValue(assignedRole).Selected = true;
            }
        }
        protected void UpdateRole(object sender, EventArgs e)
        {
            GridViewRow row = ((sender as Button).NamingContainer as GridViewRow);
            int userId = int.Parse((sender as Button).CommandArgument);
            string role = (row.FindControl("ddlRoles") as DropDownList).SelectedItem.Value.ToString();
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE CMT_EMPLOYEES SET ROLES = @role WHERE EMPLOYEE_ID = @UserId"))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    lblState.Text = "User Permission Changed!";
                    con.Close();
                }
            }
        }
    }
}