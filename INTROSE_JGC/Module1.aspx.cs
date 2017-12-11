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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!this.IsPostBack)
            {
                //change string connector depending on the configuration of your database
             //   OracleConnection con = new OracleConnection();
                try
                {
                    //con.Open();
                    //insert correct query here to get projects below
                  //  OracleCommand cmd = new OracleCommand("SELECT PROJECT FROM TEMPTABLE", con);
                    

                       // cmd.CommandType = CommandType.Text;
                        //cmd.Connection = con;
                    //    OracleDataReader dr = cmd.ExecuteReader();
                      //  dr.Read();
                        {

                           // lstProject.Items.Add(dr.GetString(0));
                            /*lstProject.DataTextField = "PROJECT_NAME";
                            lstProject.DataValueField = "PROJECT_ID";
                            lstProject.DataBind();*/
                        }
                    

                    //get categories
                    /*  using (OracleCommand cmd = new OracleCommand("SELECT CustomerId, Name FROM Customers"))
                      {
                          cmd.CommandType = CommandType.Text;
                          cmd.Connection = con;
                          using (OracleDataAdapter sda = new OracleDataAdapter(cmd))
                          {
                              DataSet ds = new DataSet();
                              sda.Fill(ds);
                              lstCategory.DataSource = ds.Tables[0];
                              lstCategory.DataTextField = "CATEGORY";
                              lstCategory.DataValueField = "CATEGORY";
                              lstCategory.DataBind();
                          }
                      }
                  }*/
                    lstProject.Items.Insert(0, new ListItem("--Select Project--", "0"));
                }
                catch
                {

                }
                //lstCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
            }
        }

        protected void proj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void cat_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("CHANGED");
            string category = lstCategory.SelectedValue;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT MATERIAL_ID, NAME FROM CMT_MATERIALS_MASTERLIST WHERE CATEGORY = @category"))
                {
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataSet ds= new DataSet();
                        sda.Fill(ds);
                        System.Diagnostics.Debug.WriteLine(ds.Tables[0]);
                        lstMaterials.DataSource = ds.Tables[0];
                        lstMaterials.DataTextField = "NAME";
                        lstMaterials.DataValueField = "MATERIAL_ID";
                        lstMaterials.DataBind();
                    }
                    con.Close();
                }

            }
        }

        protected void mat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int intQty = int.Parse(txtQuantity.Text);
            string strMaterial = lstMaterials.SelectedValue;
            string strRemarks = txtRemarks.Text;
            string strPrice;
            float fPrice, fTotal = 0;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            using (SqlCommand cmd = new SqlCommand("SELECT PRICE FROM CMT_MATERIALS_MASTERLIST WHERE MATERIAL_ID = @matID"))
            {
                cmd.Parameters.AddWithValue("@matID", strMaterial);
                cmd.Connection = con;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                strPrice = sdr.GetValue(0).ToString();
                fPrice = float.Parse(strPrice);
                fTotal = fPrice * intQty;
                sdr.Close();
               
                
            }

            SqlCommand cmd3 = new SqlCommand("INSERT INTO [TEMP_TABLE1] VALUES(@projID,@matID,@qty,@rmk,@price)");
                cmd3.Parameters.AddWithValue("@projID",lstProject.SelectedValue);
                cmd3.Parameters.AddWithValue("@matID", strMaterial);
                cmd3.Parameters.AddWithValue("@price",fTotal);
                cmd3.Parameters.AddWithValue("@rmk", strRemarks);
                cmd3.Parameters.AddWithValue("@qty", intQty);
                cmd3.Connection = con;
                cmd3.ExecuteNonQuery();
                lblStatus.Text = "Successfully added!";
                con.Close();
                Response.Redirect("Module1.aspx");
        
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("DELETE TEMP_TABLE1");
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            lblStatus.Text = "Successfully cleared entries!";
            con.Close();
            Response.Redirect("Module1.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("INSERT INTO CMT_PROJECT_DETAILS SELECT * FROM TEMP_TABLE1");
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            lblStatus.Text = "Successfully submitted!";
            SqlCommand cmd2 = new SqlCommand("DELETE TEMP_TABLE1");
            cmd2.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Module1.aspx");
            
        }

    }
}