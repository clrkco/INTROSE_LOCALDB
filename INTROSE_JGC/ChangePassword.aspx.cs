using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
namespace INTROSE_JGC
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            int intFirstTime;
            //get if changed pass already
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand("SELECT FIRST_TIME_CHANGED_PASS FROM CMT_EMPLOYEES WHERE USERNAME=@username");
            cmd.Parameters.AddWithValue("@username", User.Identity.Name);
            cmd.Connection = con;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            intFirstTime = int.Parse(dr.GetValue(0).ToString());
            dr.Close();

            SqlCommand cmd1 = new SqlCommand("UPDATE CMT_EMPLOYEES SET PASSWORD=@password WHERE USERNAME=@user");
            if (intFirstTime == 0)
            {
               
                //get old encrypted pass
                SqlCommand cmd2 = new SqlCommand("SELECT PASSWORD FROM CMT_EMPLOYEES WHERE USERNAME=@user1");
                string strEncrypt = encryption(txtOld.Value);
                System.Diagnostics.Debug.WriteLine("ENCRYPT" + strEncrypt);
                cmd2.Parameters.AddWithValue("@user1", User.Identity.Name);
                cmd2.Connection = con;
                SqlDataReader dr1 = cmd2.ExecuteReader();
                dr1.Read();
                string strEncryptedOld = dr1.GetValue(0).ToString();
                System.Diagnostics.Debug.WriteLine("OLD" + strEncryptedOld);
                dr1.Close();

                if(strEncryptedOld == strEncrypt)
                {
                    if (txtNew.Value == txtNewC.Value)
                    {
                        System.Diagnostics.Debug.WriteLine("IN");
                        string encrypt = encryption(txtNew.Value);
                        cmd1.Parameters.AddWithValue("@password", encrypt);
                        cmd1.Parameters.AddWithValue("@user", User.Identity.Name);
                        cmd1.Connection = con;
                        cmd1.ExecuteNonQuery();
                        lblStatus.Text = "";
                        lblSuccess.Text = "Successfully changed!";
                        con.Close();
                    }
                    else
                    {
                        lblSuccess.Text = "";
                        lblStatus.Text = "New passwords do not match.";
                    }
                }
                else{
                    lblSuccess.Text = "";
                    lblStatus.Text = "Old password does not match with existing.";
                }
            }
            else
            {
                if (txtNew.Value == txtNewC.Value)
                {
                    string encrypt = encryption(txtNew.Value);
                    SqlCommand cmd3 = new SqlCommand("UPDATE CMT_EMPLOYEES SET FIRST_TIME_CHANGED_PASS = 0 WHERE USERNAME=@user2");
                    cmd1.Parameters.AddWithValue("@password", encrypt);
                    cmd1.Parameters.AddWithValue("@user", User.Identity.Name);
                    cmd1.Connection = con;
                    cmd1.ExecuteNonQuery();
                    lblSuccess.Text = "Successfully changed!";
                    cmd3.Parameters.AddWithValue("@user2", User.Identity.Name);
                    cmd3.Connection = con;
                    cmd3.ExecuteNonQuery();
                    con.Close();
                   
                }
                else
                {
                    lblSuccess.Text = "";
                    lblStatus.Text = "New passwords do not match.";
                }
            }
        }
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
    }
}