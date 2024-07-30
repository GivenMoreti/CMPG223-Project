using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class DeleteProduct : System.Web.UI.Page
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
        DataSet ds;


        public void DeleteAProduct(string query,int Id)
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

   

        protected void DeleteProducts(object sender, EventArgs e)
        {
         
            string query = "Delete from producttable where id=@id";

            if (int.TryParse(ProductId.Text,out int id))
            {
                DeleteAProduct(query, id);
            }
            else
            {
                FeedbackLbl.Text = "Error encountered with id or input field";
            }
        }
    }
}