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
    public partial class Products : System.Web.UI.Page
    {


        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        protected void ProductsGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SelectProduct")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = ProductsGridView.Rows[index];
                string productId = selectedRow.Cells[0].Text;

                // Store the selected product in a session or cookie
                List<string> selectedProducts = Session["SelectedProducts"] as List<string> ?? new List<string>();
                selectedProducts.Add(productId);
                Session["SelectedProducts"] = selectedProducts;

                // Redirect to the order page
                Response.Redirect("Order.aspx");
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //IF NOT POSTBACK
            if (!IsPostBack)
            {
              // GetProducts("SELECT * FROM producttable");
                GetProducts();

            }
        }


        //RETRIEVALS
        //generic search

        public void GetProducts()
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand("SelectAllProducts", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                ProductsGridView.DataSource = ds;
                ProductsGridView.DataBind();
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


        public void GetProducts(string query)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand(query, conn);


                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                ProductsGridView.DataSource = ds;

                ProductsGridView.DataBind();

            }
            catch (SqlException ex)
            {
                ex.ToString();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            finally
            {
                conn.Close();
            }
        }

        
        //query specify get by id,*, or other args
        public void GetProducts(string query, string searchKey)
            {
                try
                {
                    conn = new SqlConnection(ConnString);
                    adapter = new SqlDataAdapter();
                    ds = new DataSet();
                    conn.Open();

                    cmd = new SqlCommand(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("searchKey",searchKey);
                    
                    
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    ProductsGridView.DataSource = ds;

                    ProductsGridView.DataBind();

                }
                catch (SqlException ex)
                {
                    ex.ToString();
                }
                catch (Exception e)
                {
                    e.ToString();
                }
                finally
                {
                    conn.Close();
                }
            }

 
        
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            
             string searchKey = SearchItem.Text;
            //string query ="Select * from products where name like @searchKey or description like @searchKey or price like @searchKey or size like @searchKey";
            string query = "SearchProducts";
             if (!string.IsNullOrEmpty(searchKey))
             {
                 GetProducts(query, searchKey);

             }
             else
             {
                 FeedbackLbl.Text = "search box empty";
                 GetProducts("SelectAllProducts");
             }

             

        }

    }
}