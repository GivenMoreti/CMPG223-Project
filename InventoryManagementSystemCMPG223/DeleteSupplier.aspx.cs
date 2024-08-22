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
    public partial class DeleteSupplier : System.Web.UI.Page
    {
        protected void DeleteSupplierBtn_Click(object sender, EventArgs e)
        {
            DeleteASupplier();
        }

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;

        public void DeleteASupplier()
        {
   
            try
            {
                conn.Open();

                //use DeleteSupplier procedure
                string sql = "DeleteSupplier";
                cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", txtSupplierId.Text);
                cmd.ExecuteNonQuery();

                int count = cmd.ExecuteNonQuery();
                if(count > 0 )
                {
                    FeedbackLbl.Text = "Successfully deleted a supplier profile";
                    Response.Redirect("Suppliers.aspx");
                }
                else
                {
                    FeedbackLbl.Text = "Failed to delete a supplier profile";
                }
            
            }catch(SqlException ex)
            {
                FeedbackLbl.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}