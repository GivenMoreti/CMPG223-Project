using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               //assign lables to the main dashboard
                int productCount = GetCount("SELECT COUNT(*) FROM producttable");
                ProductCountLbl.Text = productCount.ToString() + " Products";

                int customerCount = GetCount("Select count(*) from customertable");
                CustomerCountLbl.Text = customerCount.ToString() +  " Customers";

                //ADD COUNTS FOR OTHER ENTITIES HERE




                //HANDLE COOKIES
                HttpCookie cookie = Request.Cookies["userDetails"];

                if(cookie != null)
                {
                    LblGreet.Text = "Hello, " + cookie["username"];
                }
                else
                {
                    LblGreet.Text = "Hello User";
                }
            }
        }

        //DEPENDENCIES

        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\InventoryManagementSystemDB.mdf;Integrated Security=True";
        //readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManagementSystemDB;Integrated Security=True;Trust Server Certificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        public int GetCount(string query)
        {
            int count = 0;
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand(query, conn);


                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                count = (int)cmd.ExecuteScalar();




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
            return count;
        }

    }
}