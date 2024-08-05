using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace InventoryManagementSystemCMPG223
{
    public partial class CreateProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {}

        //DEPENDENCIES

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";

        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        //-----------CUSTOM METHODS------------
        //INSERTION

        public void InsertProduct(string query)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                conn.Open();
                ds = new DataSet();
                adapter = new SqlDataAdapter();


                cmd = new SqlCommand(query, conn);

                //GET PRODUCT DETAILS FROM THE FORM
                int id = Int32.Parse(ProductId.Text);
                string name = Name.Text, description = Description.Text;
                double price = Double.Parse(Price.Text), size = Double.Parse(Size.Text);


                //parameters
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@size", size);
                cmd.Parameters.AddWithValue("@price", price);

                adapter.InsertCommand = cmd;

                int countUpdated = adapter.InsertCommand.ExecuteNonQuery();

                if (countUpdated > 0)
                {
                    FeedbackLbl.Text = $"Added product successfully";
                    
                    //TAKE USER TO PRODUCTS PAGE
                    Response.Redirect("Products.aspx");
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
            return !string.IsNullOrEmpty(ProductId.Text)&&!string.IsNullOrEmpty(Name.Text) && !string.IsNullOrEmpty(Price.Text) && 
                !string.IsNullOrEmpty(Description.Text) && !string.IsNullOrEmpty(Size.Text);
        }


        protected void AddProduct_Click(object sender, EventArgs e)
        {
            //add product to database
            try
            {
                    //VALIDATE ENTRY
                if (IsValidForm())
                {
                    string query = "Insert into producttable(id,name,description,price,size)values(@id,@name,@description,@price,@size)";
                    InsertProduct(query);   
                }
                else
                {
                    FeedbackLbl.Text = "All the field(s) are required";
                }

            }catch(SqlException ex)
            {
                ex.ToString();
            }catch(Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                conn.Close();
            }
                
        }
    }
}