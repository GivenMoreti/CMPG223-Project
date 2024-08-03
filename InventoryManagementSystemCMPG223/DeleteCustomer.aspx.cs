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
    public partial class DeleteCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";

        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;

       

        public void DeleteACustomer(string query, int Id)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", Id);

                adapter.DeleteCommand = cmd;

                int CountDeleted = adapter.DeleteCommand.ExecuteNonQuery();

                if (CountDeleted > 0)
                {
                    FeedbackLbl.Text = $"Successfully deleted {Id}";
                }
                else
                {
                    FeedbackLbl.Text = $"Failed to delete {Id}";
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

        public Boolean IsValidId()
        {
            return !string.IsNullOrEmpty(CustomerIdTB.Text);
        }

      
        protected void DeleteCustomerBtn_Click1(object sender, EventArgs e)
        {
            if (IsValidId())
            {
                string query = "Delete from customertable where id=@id";

                if (int.TryParse(CustomerIdTB.Text, out int id))
                {
                    DeleteACustomer(query, id);
                }
                else
                {
                    FeedbackLbl.Text = "Error encountered with id or input field";
                }
            }
            else
            {
                FeedbackLbl.Text = "Some input(s) fields empty";
            }
        }
    }
}