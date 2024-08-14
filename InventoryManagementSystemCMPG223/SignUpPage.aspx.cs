using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class SignUpPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
     


        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEntry())
                {

                    //get user data
                    string Username = Username1.Text, Password = UserPassword.Text; 
                 

                    conn = new SqlConnection(ConnString);
                    adapter = new SqlDataAdapter();

                    conn.Open();                        

                    string query = "InsertUser";
                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                

                    adapter.InsertCommand = cmd;

                    int count = adapter.InsertCommand.ExecuteNonQuery();
                    if (count > 0)
                    {
                        LblDisplay.Text = $"Successfully registered a user with username {Username}";
                        
                        
                        //TAKE USER TO LOGIN PAGE
                        Response.Redirect("LoginPage.aspx");
                    }
                    else
                    {
                        LblDisplay.Text = "Failed to create account";
                    }

                }
                else
                {
                    LblDisplay.Text = "Some field(s) empty";
                }
            }
            catch (SqlException ex)
            {
                LblDisplay.Text = ex.Message;
            }
            catch (Exception ex)
            {
                LblDisplay.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        private bool IsValidEntry()
        {
            return !string.IsNullOrEmpty(UserPassword.Text) && !string.IsNullOrEmpty(Username1.Text);
        }




    }
}