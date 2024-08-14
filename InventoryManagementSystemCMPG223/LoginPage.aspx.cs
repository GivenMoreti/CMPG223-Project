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
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES


        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;



        protected void SignInBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEntry() && AuthenticateUser(Username.Text, UserPassword.Text))
                {
                    HttpCookie cookie = new HttpCookie("userDetails");

                    //store user login details in a cookie

                    if (cookie != null)
                    {
                        cookie["username"] = Username.Text;
                        cookie["password"] = UserPassword.Text;
                        cookie.Expires = DateTime.Now.AddMinutes(20);       //cookie will expire after 20 minutes.
                        Response.Cookies.Add(cookie);

                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        LblDisplay.Text = "No saved cookies";               //empty cookie feedback
                    }

                }
                else
                {

                    LblDisplay.Text = "Username or password invalid";
                }
            }
            catch (Exception ex)
            {
                LblDisplay.Text = ex.Message;       //caught exceptions
            }

        }

        private bool IsValidEntry()
        {
            return !string.IsNullOrEmpty(Username.Text) && !string.IsNullOrEmpty(UserPassword.Text);
        }

        public bool AuthenticateUser(string Username, string Password)
        {
            bool isAuthenticated = false;

            try
            {
                using (conn = new SqlConnection(ConnString))
                {
                    conn.Open();

                    using (cmd = new SqlCommand("LoginUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        cmd.Parameters.AddWithValue("@Username", Username);
                        cmd.Parameters.AddWithValue("@Password", Password);

                        // Execute the stored procedure and get the result
                        int result = (int)cmd.ExecuteScalar();

                        // If the result is 1, authentication is successful
                        if (result == 1)
                        {
                            isAuthenticated = true;
                        }
                        else
                        {
                            LblDisplay.Text = "Invalid username or password";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                LblDisplay.Text = ex.Message;
            }

            return isAuthenticated;
        }

    }
}