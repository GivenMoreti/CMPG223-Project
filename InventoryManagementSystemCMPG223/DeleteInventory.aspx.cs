using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class DeleteInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DeleteInventoryBtn_Click(object sender, EventArgs e)
        {
            string query = "DeleteInventory";

            if (int.TryParse(inventoryId.Text, out int id))
            {
                DeleteAnInventory(query, id);
            }
            else
            {
                FeedbackLbl.Text = "Error encountered with id or input field";
            }
        }

        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;

        public void DeleteAnInventory(string query, int Id)
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
                    Response.Redirect("Inventory.aspx");
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
    }
}