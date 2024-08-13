using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Drawing;
using System.Xml.Linq;

namespace InventoryManagementSystemCMPG223
{
    public partial class UpdateCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;




        protected void UpdateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                string keyword = CustomerIdTB.Text;
                string query = "UpdateCustomer";
                UpdateACustomer(query, keyword);
            }
            else
            {
                FeedbackLbl.Text = "Some field(s) are invalid";
            }
        }

        //UPDATE DATABASE
        public void UpdateACustomer(string query, string keyword)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                //GET CUSTOMER DETAILS FROM THE FORM
                int Id = Int32.Parse(CustomerIdTB.Text);
                string Name = CustomerNameTB.Text, Email = CustomerEmailTB.Text;
               

                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //parameters
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
             

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

        //VALIDATE FORM INPUT

        public Boolean IsValidForm()
        {
            return !string.IsNullOrEmpty(CustomerIdTB.Text) && !string.IsNullOrEmpty(CustomerNameTB.Text) && !string.IsNullOrEmpty(CustomerEmailTB.Text);

        }

    }
}