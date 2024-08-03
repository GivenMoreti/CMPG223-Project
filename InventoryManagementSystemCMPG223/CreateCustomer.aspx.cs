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

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";

        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        protected void CreateCustomerProfileBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                InsertCustomer("Insert into customertable(id,email,name)values(@id,@email,@name)");

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

                //GET CUSTOMER DETAILS FROM THE FORM
                int id = Int32.Parse(CustomerIdTB.Text);
                string name = CustomerNameTB.Text, email = CustomerEmailTB.Text;
               

                //parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
          
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
            return !string.IsNullOrEmpty(CustomerIdTB.Text) && !string.IsNullOrEmpty(CustomerNameTB.Text) && !string.IsNullOrEmpty(CustomerEmailTB.Text);
               
        }

    }
}