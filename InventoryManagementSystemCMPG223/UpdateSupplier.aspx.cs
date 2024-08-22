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
    public partial class UpdateSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public SqlConnection conn = new SqlConnection(@"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True");
        public SqlCommand comm;
        public DataSet ds;
        public SqlDataAdapter adap;
        public void UpdateASupplier()
        {
            try
            {

                // Open Connection to database
                conn.Open();

                //use Update procedure
                string sql = "UpdateSupplier";
                comm = new SqlCommand(sql, conn);
                comm.CommandType = CommandType.StoredProcedure;
                
                comm.Parameters.AddWithValue("@SupplierName", txtName.Text);
                comm.Parameters.AddWithValue("@Id", txtSupplierId.Text);
                comm.Parameters.AddWithValue("@SupplierEmail", txtEmail.Text);
                comm.ExecuteNonQuery();

               int count = comm.ExecuteNonQuery();
                if (count > 0)
                {
                    FeedbackLbl.Text = "Successfully added updated supplier";
                    Response.Redirect("Suppliers.aspx");
                }
                else
                {
                    FeedbackLbl.Text = "Failed to update a supplier";
                }

             
            }catch (SqlException ex)
            {
                FeedbackLbl.Text = ex.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        protected void UpdateSupplierBtn_Click(object sender, EventArgs e)
        {
            UpdateASupplier();
        }
    }
}