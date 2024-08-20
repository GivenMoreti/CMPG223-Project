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


        protected void Page_Load(object sender, EventArgs e)
        {
            //IF NOT POSTBACK
            if (!IsPostBack)
            {
              // GetProducts("SELECT * FROM producttable");
                GetProducts();

            }
        }

        //CreateProduct cp = new CreateProduct();
        //cp.GetProducts(query);


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
           /*
            string searchKey = SearchItem.Text;
            string query ="select * from producttable where name like @searchKey or description like @searchKey or price like @searchKey or size like @searchKey";

            if (!string.IsNullOrEmpty(searchKey))
            {
                GetProducts(query, searchKey);

            }
            else
            {
                FeedbackLbl.Text = "search box empty";
                GetProducts("select * from producttable");
            }

            */
            
        }
        
    }
}