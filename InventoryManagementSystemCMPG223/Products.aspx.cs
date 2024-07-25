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

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        protected void Page_Load(object sender, EventArgs e)
        {
            //IF NOT POSTBACK
            if (!IsPostBack)
            {
                GetProducts("select * from producttable");

            }
        }
           
            //CreateProduct cp = new CreateProduct();
            //cp.GetProducts(query);




            //RETRIEVALS

            //query specify get by id,*, or other args
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
        
    }
}