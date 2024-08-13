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
    public partial class CreateCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        protected void CreateCustomerProfileBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                InsertCustomer("InsertCustomer");

            }
            else
            {
                FeedbackLbl.Text = "Some field(s) invalid";
            }
        }

        //-----------CUSTOM METHODS------------


        //INSERTION

        public void InsertCustomer(string query)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();

                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //GET CUSTOMER DETAILS FROM THE FORM
   
                string Name = CustomerNameTB.Text, Email = CustomerEmailTB.Text;
               

                //parameters
          
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@Email", Email);
          
                adapter.InsertCommand = cmd;

                int countUpdated = adapter.InsertCommand.ExecuteNonQuery();

                if (countUpdated > 0)
                {
                    FeedbackLbl.Text = $"Customer Profile added successfully ";

                    //TAKE USER TO CUSTOMERS PAGE
                    Response.Redirect("Customers.aspx");
                }
                else
                {
                    FeedbackLbl.Text = $"Failed to add";
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

        //VALIDATE FORM INPUT

        public Boolean IsValidForm()
        {
            return !string.IsNullOrEmpty(CustomerNameTB.Text) && !string.IsNullOrEmpty(CustomerEmailTB.Text);
               
        }

    }
}