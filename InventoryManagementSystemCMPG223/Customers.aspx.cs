using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class Customers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                GetCustomers("SelectAllCustomers");
     
            }
        }

        //DEPENDENCIES

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        public void GetCustomers(string query)
        {
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

                CustomerGridView.DataSource = ds;

                CustomerGridView.DataBind();

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


        //SPECIFIC RETRIEVAL QUERY I.E. GET BY ID,NAME,EMAIL.
        public void GetCustomer(string query, string searchKey)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("searchKey", searchKey);


                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

               CustomerGridView.DataSource = ds;

                CustomerGridView.DataBind();

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

       

        protected void SearchBtn_Click1(object sender, EventArgs e)
        {
            string searchKey = SearchItem.Text;
            string query = "select * from CUSTOMERTABLE where name like @searchKey or email like @searchKey";

            if (!string.IsNullOrEmpty(searchKey))
            {
                GetCustomer(query, searchKey);

            }
            else
            {
                //  WHEN THE SEARCHBOX IS EMPTY RETRIEVE DATA

                FeedbackLbl.Text = "search box empty";
                GetCustomers("SelectAllCustomers");
            }
        }
    }
}