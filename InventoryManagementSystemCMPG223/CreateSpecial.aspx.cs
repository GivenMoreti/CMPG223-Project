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
      
            }
           
        }


        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
 

        public void AddSpecial() {
            try
            {
                //Connecting to Database
                conn = new SqlConnection(ConnString);
                conn.Open();
      
                adapter = new SqlDataAdapter();

                cmd = new SqlCommand("InsertSpecial", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                //get special details
                string ProductId = txtProductId.Text;
                string Discount = txtDiscount.Text;
                DateTime StartDate = GetStartDate();
                DateTime EndDate = GetEndDate();


                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);


                adapter.InsertCommand = cmd;

            
               int count = cmd.ExecuteNonQuery();
                if(count > 0)
                {

                    errorLabel.Text = "Successfully added a special";
                }
                else
                {

                    errorLabel.Text = "Failed to add a special";
                }
                                     
            }
            catch (SqlException error)
            {
         
                errorLabel.Text = error.ToString();
            }
            finally
            {
                conn.Close();
            }

   
        }

        public DateTime GetStartDate()
        {
            DateTime startDate = txtStartDate.SelectedDate.Date;
            DateTime endDate = txtEndDate.SelectedDate.Date;

            if(startDate > endDate)
            {
                errorLabel.Text = $"Start date:{startDate} and end date: {endDate} invalid";
            }

            return startDate;


        }

        public DateTime GetEndDate()
        {
            DateTime startDate = txtStartDate.SelectedDate.Date;
            DateTime endDate = txtEndDate.SelectedDate.Date;

            if (startDate > endDate)
            {
                errorLabel.Text = $"Start date:{startDate} and end date: {endDate} invalid";
            }

            return endDate;


        }

        protected void CreateSpecialBtn_Click(object sender, EventArgs e)
        {
            AddSpecial();
        }
    }
    }
