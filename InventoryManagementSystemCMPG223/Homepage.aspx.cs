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
                //assign lables to the main dashboard
                int productCount = GetCount("CountProducts");
                ProductCountLbl.Text = productCount.ToString() + " Products";

               int customerCount = GetCount("CountCustomers");
               CustomerCountLbl.Text = customerCount.ToString() +  " Customers";

               

                int countUsers = GetCount("CountAllUsers");
                UsersCountLbl.Text = countUsers.ToString() + " Users";


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