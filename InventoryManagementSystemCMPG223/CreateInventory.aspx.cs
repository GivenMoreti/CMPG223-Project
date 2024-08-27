using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Org.BouncyCastle.Math;
using System.Drawing;

namespace InventoryManagementSystemCMPG223
{
    public partial class CreateInventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        public void InsertInventory(string query)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();


                cmd = new SqlCommand(query, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                //GET PRODUCT DETAILS FROM THE FORM

               int QuantityInStock = int.Parse(quantityInStock.Text);
            
                
               int SupplierId = int.Parse(supplierId.Text);


                // Add parameters to the command
                cmd.Parameters.AddWithValue("@QuantityInStock", QuantityInStock);
                cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
            


                // Execute the stored procedure
                int countUpdated = cmd.ExecuteNonQuery();

                if (countUpdated > 0)
                {
                    FeedbackLbl.Text = "Added Ineventory successfully";
                    //TAKE USER TO PRODUCTS PAGE
                    Response.Redirect("Inventory.aspx");
                }
                else
                {
                    FeedbackLbl.Text = "Failed to add";
                }
            }
            catch (SqlException ex)
            {
                FeedbackLbl.Text = $"SQL Error: {ex.Message}";
            }
            catch (Exception e)
            {
                FeedbackLbl.Text = $"Error: {e.Message}";
            }
            finally
            {
                conn.Close();
            }
        }

       
        protected void AddInventoryBtn_Click(object sender, EventArgs e)
        {
            string query = "InsertInventory";
            InsertInventory(query);
        }
    }
}