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
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> selectedProducts = Session["SelectedProducts"] as List<string>;
                if (selectedProducts != null)
                {
                    // Retrieve product details from the database
                    string connStr = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        string query = "SELECT * FROM Products WHERE ID IN (" + string.Join(",", selectedProducts) + ")";
                        SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        SelectedProductsGridView.DataSource = dt;
                        SelectedProductsGridView.DataBind();
                    }
                }
            }
        }

        protected void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            string connStr = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // Insert the order
                    SqlCommand orderCmd = new SqlCommand("INSERT INTO Orders (OrderDate, CustomerID) OUTPUT INSERTED.OrderID VALUES (@OrderDate, @CustomerID)", conn, transaction);
                    orderCmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                    orderCmd.Parameters.AddWithValue("@CustomerID", 1); // Example CustomerID
                    int orderId = (int)orderCmd.ExecuteScalar();

                    // Insert the ordered products
                    foreach (GridViewRow row in SelectedProductsGridView.Rows)
                    {
                        string productId = row.Cells[0].Text;
                        TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                        int quantity = int.Parse(quantityTextBox.Text);

                        SqlCommand orderProductCmd = new SqlCommand("INSERT INTO OrderProduct (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)", conn, transaction);
                        orderProductCmd.Parameters.AddWithValue("@OrderID", orderId);
                        orderProductCmd.Parameters.AddWithValue("@ProductID", productId);
                        orderProductCmd.Parameters.AddWithValue("@Quantity", quantity);
                        orderProductCmd.ExecuteNonQuery();
                    }

                    // Commit the transaction
                    transaction.Commit();

                    // Clear the session
                    Session["SelectedProducts"] = null;

                    // Redirect to a confirmation page
                    Response.Redirect("OrderConfirmation.aspx");
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if something goes wrong
                    transaction.Rollback();
                    throw new Exception("An error occurred while placing the order: " + ex.Message);
                }
            }
        }
    }
}