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

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";
        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;
        protected void SignUpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValidEntry())
                {

                    //get user data
                    string username = Username.Text, password = UserPassword.Text; 
                    int Id = Int32.Parse(UserId.Text);

                    conn = new SqlConnection(ConnString);
                    adapter = new SqlDataAdapter();

                    conn.Open();                        

                    string query = "Insert into UsersTable(Id,username,password)values(@Id,@username,@password)";
                    cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@Id", Id);

                    adapter.InsertCommand = cmd;

                    int count = adapter.InsertCommand.ExecuteNonQuery();
                    if (count > 0)
                    {
                        LblDisplay.Text = $"Successfully registered a user with Id {Id}";
                        
                        
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
            return !string.IsNullOrEmpty(UserPassword.Text) && !string.IsNullOrEmpty(UserId.Text) && !string.IsNullOrEmpty(Username.Text);
        }




    }
}