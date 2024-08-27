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
                //ADD COUNTS FOR ENTITIES HERE
       
                int productCount = GetCount("CountProducts");
                
                if(productCount > 1)
                {
                    ProductCountLbl.Text = productCount.ToString() + " Products";
                }
                else
                {
                    ProductCountLbl.Text = productCount.ToString() + " Product";
                }
                

               int customerCount = GetCount("CountCustomers");
               
                if(customerCount > 1)
                {
                    CustomerCountLbl.Text = customerCount.ToString() + " Customers";
                }
                else
                {
                    CustomerCountLbl.Text = customerCount.ToString() + " Customer";
                }
               

               

                int countUsers = GetCount("CountAllUsers");
                
                if(countUsers > 1)
                {
                    UsersCountLbl.Text = countUsers.ToString() + " Active Users";
                }
                else
                {
                    UsersCountLbl.Text = countUsers.ToString() + " Active User";
                }
              


                int countSuppliers = GetCount("CountSuppliers");
                
                if( countSuppliers > 1)
                {

               
                SuppliersCountLbl.Text = countSuppliers.ToString() + " Suppliers";
                }
                else
                {
                    SuppliersCountLbl.Text = countSuppliers.ToString() + " Supplier";
                }

                //count specials


                int countSpecials = GetCount("CountSpecials");
                if(countSpecials > 1)
                {
                    SpecialsCountLbl.Text = countSpecials.ToString() + " Specials";
                }
                else
                {
                    SpecialsCountLbl.Text = countSpecials.ToString() + " Special";
                }

                //count inventory items
                int countInventory = GetCount("CountInventory");
                if (countInventory > 1)
                {
                    InventoryCountLbl.Text = countInventory.ToString() + " items in Inventory ";
                }
                else
                {
                    InventoryCountLbl.Text = countInventory.ToString() + " item in Inventory";
                }






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

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
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
                cmd.CommandType = CommandType.StoredProcedure;


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