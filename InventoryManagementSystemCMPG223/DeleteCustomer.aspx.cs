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


        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;



        public void DeleteACustomer(string query, int Id)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
                string query = "DeleteCustomer";

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