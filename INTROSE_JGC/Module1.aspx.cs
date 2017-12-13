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
            string strProjname;
            string strMatname;
            string strPrice;
            float fPrice, fTotal = 0;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            using (SqlCommand cmd = new SqlCommand("SELECT PRICE FROM CMT_MATERIALS_MASTERLIST WHERE MATERIAL_ID = @matID"))
            {
                cmd.Parameters.AddWithValue("@matID", strMaterial);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    strPrice = sdr.GetValue(0).ToString();
                    fPrice = float.Parse(strPrice);
                    fTotal = fPrice * intQty;
                }
                
            }

            SqlCommand cmd3 = new SqlCommand("INSERT INTO [TEMP_TABLE1] VALUES(@projID,@matID,@qty,@rmk,@price)");
                cmd3.Parameters.AddWithValue("@projID",lstProject.SelectedValue);
                cmd3.Parameters.AddWithValue("@matID", strMaterial);
                cmd3.Parameters.AddWithValue("@price",fTotal);
                cmd3.Parameters.AddWithValue("@rmk", strRemarks);
                cmd3.Parameters.AddWithValue("@qty", intQty);
                cmd3.Connection = con;
                cmd3.ExecuteNonQuery();
                
            SqlCommand cmd5 = new SqlCommand("SELECT PROJECT_NAME FROM CMT_PROJECT_LIST WHERE PROJECT_ID = @projid ");     
                cmd5.Parameters.AddWithValue("@projid", int.Parse(lstProject.SelectedValue));
                cmd5.Connection = con;
                using (SqlDataReader sdr1 = cmd5.ExecuteReader())
                {
                    sdr1.Read();
                    System.Diagnostics.Debug.WriteLine(sdr1.GetString(0));
                    strProjname = sdr1.GetValue(0).ToString();
                }

            SqlCommand cmd7 = new SqlCommand("SELECT NAME FROM CMT_MATERIALS_MASTERLIST WHERE MATERIAL_ID = @matid");
                cmd7.Parameters.AddWithValue("@matid", strMaterial);
                cmd7.Connection = con;
                using (SqlDataReader sdr3 = cmd7.ExecuteReader()) 
                {
                    sdr3.Read();
                    strMatname = sdr3.GetValue(0).ToString();
                }

            SqlCommand cmd4 = new SqlCommand("INSERT INTO TEMP_TABLE VALUES(@projname,@matname,@cat,@qty,@rmk,@price)");
                cmd4.Parameters.AddWithValue("@projname", strProjname);
                cmd4.Parameters.AddWithValue("@matname", strMatname);
                cmd4.Parameters.AddWithValue("@cat", lstCategory.SelectedValue);
                cmd4.Parameters.AddWithValue("@qty", intQty);
                cmd4.Parameters.AddWithValue("@rmk", txtRemarks.Text);
                cmd4.Parameters.AddWithValue("@price", fTotal);
                cmd4.Connection = con;
                cmd4.ExecuteNonQuery();
                con.Close();

            lblStatus.Text = "Successfully added!";
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
            SqlCommand cmd3 = new SqlCommand("DELETE TEMP_TABLE");
            cmd3.Connection = con;
            cmd3.ExecuteNonQuery();
            lblStatus.Text = "Successfully cleared entries!";
            con.Close();
            Response.Redirect("Module1.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strProjname;
            string strEmployee;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd4 = new SqlCommand("INSERT INTO PROJECT_DETAILS SELECT * FROM TEMP_TABLE1");
            con.Open();
            cmd4.Connection = con;
            cmd4.ExecuteNonQuery();
            lblStatus.Text = "Successfully submitted!";
            SqlCommand cmd2 = new SqlCommand("DELETE TEMP_TABLE1");
            cmd2.Connection = con;
            cmd2.ExecuteNonQuery();
            SqlCommand cmd3 = new SqlCommand("DELETE TEMP_TABLE");
            cmd3.Connection = con;
            cmd3.ExecuteNonQuery();

            SqlCommand cmd7 = new SqlCommand("INSERT INTO CMV_ActivityLog(EMPLOYEE_NAME,PROJECT_NAME,DATETIME,REMARKS) VALUES(@empname,@projname,@datetime,@rmk)");

            SqlCommand cmd6 = new SqlCommand("SELECT NAME FROM CMT_EMPLOYEES WHERE USERNAME = @user");
            cmd6.Parameters.AddWithValue("@user", User.Identity.Name);
            cmd6.Connection = con;
            using(SqlDataReader sdr = cmd6.ExecuteReader()){
                sdr.Read();
                strEmployee = sdr.GetString(0);
            }

            SqlCommand cmd8 = new SqlCommand("SELECT PROJECT_NAME FROM CMT_PROJECT_LIST WHERE PROJECT_ID = @projid ");
            cmd8.Parameters.AddWithValue("@projid", int.Parse(lstProject.SelectedValue));
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
            lblStatus.Text = "Successfully submitted form!";
            Response.Redirect("Module1.aspx");
        }

    }
}