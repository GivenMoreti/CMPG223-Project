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
    public partial class CreateSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
    



        public void AddSupplier()
        {
            try
            {

                conn = new SqlConnection(ConnString);
                conn.Open();
                adapter = new SqlDataAdapter();

                string SupplierEmail = supplierEmail.Text;
                string SupplierName = supplierName.Text;

              
                cmd = new SqlCommand("InsertSupplier", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SupplierEmail", SupplierEmail);
                cmd.Parameters.AddWithValue("@SupplierName", SupplierName);

                adapter.InsertCommand = cmd;

                int count = cmd.ExecuteNonQuery();

                if (count > 0)
                {
                    //Redirect to suppliers page
                    FeedbackLbl.Text = "Successfully Created Profile ";
                }
                else
                {
                    FeedbackLbl.Text = "Failed to Create a Supplier profile";
                }


            }
            catch (SqlException error)
            {

                FeedbackLbl.Text = error.ToString();
            }
            finally
            {
                //close connection to database
                conn.Close();
            }


        }

        protected void CreateSupplierBtn_Click(object sender, EventArgs e)
        {
            AddSupplier();
        }
    }
}