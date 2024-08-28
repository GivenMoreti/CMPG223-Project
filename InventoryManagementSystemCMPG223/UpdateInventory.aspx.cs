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
    public partial class UpdateInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UpdateInventoryBtn_Click(object sender, EventArgs e)
        {
            string keyword = supplierId.Text;
            string query = "UpdateInventory";
            UpdateAnInventory(query, keyword);
        }

        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;

        public void UpdateAnInventory(string query, string keyword)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;


                //get special details
                int Id = int.Parse(inventoryId.Text);
               
                int QuantityInStock = int.Parse(quantityInStock.Text);

                int SupplierId = int.Parse(supplierId.Text);

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
              


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

    }
}