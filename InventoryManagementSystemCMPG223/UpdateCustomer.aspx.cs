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

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";
        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;



        protected void UpdateCustomerBtn_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                string keyword = CustomerIdTB.Text;
                string query = "Update customertable set id=@id,name=@name,email=@emailwhere id=@id";
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
                int id = Int32.Parse(CustomerIdTB.Text);
                string name = CustomerNameTB.Text, email = CustomerEmailTB.Text;
               

                cmd = new SqlCommand(query, conn);

                //parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@email", email);
             

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