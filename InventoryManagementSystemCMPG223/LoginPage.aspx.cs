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

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";
        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
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

        public bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;


            try
            {
                conn = new SqlConnection(ConnString);
                string query = "SELECT Password FROM Userstable WHERE username = @username";
                adapter = new SqlDataAdapter();
                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@username", username);
                adapter.SelectCommand = cmd;
                conn.Open();

                //used to retrieve password from the database for selected username.
                object result = cmd.ExecuteScalar();

                string storedPassword;

                if (result != null)
                {
                    storedPassword = result.ToString();
                }
                else
                {
                    storedPassword = null;
                }

                // Compare the retrieved password with the password entered by the user
                if (storedPassword != null && storedPassword.Equals(password))
                {
                    // Authentication successful
                    isAuthenticated = true;
                }
                else
                {
                    isAuthenticated = false;
                    LblDisplay.Text = "Invalid password or username";
                }

            }
            catch (SqlException ex)
            {
                LblDisplay.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }

            return isAuthenticated;
        }
    }
}