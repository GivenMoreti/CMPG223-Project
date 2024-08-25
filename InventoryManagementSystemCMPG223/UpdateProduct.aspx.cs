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
    public partial class UpdateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;


   

        //UPDATE DATABASE
        public void UpdateAProduct(string query, string keyword)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                //GET PRODUCT DETAILS FROM THE FORM
                int id = Int32.Parse(ProductId.Text);
                string ProductName = Name.Text, ProductDescription = Description.Text;
                double price = Double.Parse(Price.Text), ProductSize = Double.Parse(Size.Text);
                
                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                cmd.Parameters.AddWithValue("@ProductSize", ProductSize);
                cmd.Parameters.AddWithValue("@price", price);


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

        protected void UpdateProductBtn_Click(object sender, EventArgs e)
        {
            string keyword = ProductId.Text;
            string query = "UpdateProduct";
            UpdateAProduct(query, keyword);
        }
    }
}