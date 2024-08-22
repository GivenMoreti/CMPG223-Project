using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagementSystemCMPG223
{
    public partial class CreateSpecial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                AddSpecial();
            }
           
        }


        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;

        public void AddSpecial() {
            try
            {
                //Connecting to Database
                conn.Open();

                cmd = new SqlCommand("InsertSpecial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductId", int.Parse(txtProductId.Text));
                cmd.Parameters.AddWithValue("@Discount", float.Parse(txtDiscount.Text));
                cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(txtStartDate.Text));
                cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(txtEndDate.Text));
                adapter = new SqlDataAdapter();
                adapter.InsertCommand = cmd;

                adapter.InsertCommand.ExecuteNonQuery();

                //Closing Connection to Database
                conn.Close();
            }
            catch (SqlException error)
            {
                //Error shown if Connection Failed 
                errorLabel.Text = $"{error.Message}";
            }

            //Redirect to Specials page
            Response.Redirect("Specials.aspx");
        }
    }
    }
