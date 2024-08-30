using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //DEPENDENCIES

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;



        public void UpdateAUser(string query, string keyword)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                //GET USER DETAILS FROM THE FORM
                int ID = Int32.Parse(UserIdTB.Text);
                string Username = UsernameTB.Text, Password = UserPassword.Text;


                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parameters
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.Parameters.AddWithValue("@Password", Password);


                adapter.UpdateCommand = cmd;

                int countUpdated = adapter.UpdateCommand.ExecuteNonQuery();

                if (countUpdated > 0)
                {
                    FeedbackLbl.Text = $"Successfully updated {keyword}";
                }
                else
                {
                    FeedbackLbl.Text = $"Failed to update {keyword}";
                }

            }
            catch (SqlException ex)
            {
                FeedbackLbl.Text = ex.ToString();
            }
            catch (Exception e)
            {
                FeedbackLbl.Text = e.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        //VALIDATE FORM INPUT

        public Boolean IsValidForm()
        {
            return !string.IsNullOrEmpty(UserIdTB.Text) && !string.IsNullOrEmpty(UsernameTB.Text) && !string.IsNullOrEmpty(UserPassword.Text);

        }

        protected void UpdateUserBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                string keyword = UserIdTB.Text;
                string query = "UpdateUser";
                UpdateAUser(query, keyword);
            }
            else
            {
                FeedbackLbl.Text = "Some field(s) are invalid";
            }
        }
    }
}