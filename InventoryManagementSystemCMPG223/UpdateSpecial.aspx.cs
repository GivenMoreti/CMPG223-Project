using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace InventoryManagementSystemCMPG223
{
    public partial class UpdateSpecial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //DEPENDENCIES
        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
  
      

        public void UpdateASpecial(string query, string keyword)
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                conn.Open();

                cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

          
                //get special details
                int Id = int.Parse(SpecialId.Text);
                string ProductId = pId.Text;
                string Discount = txtDiscount.Text;

                DateTime StartDate = GetStartDate();
                DateTime EndDate = GetEndDate();

                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@Discount", Discount);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                


                adapter.UpdateCommand = cmd;

                int countUpdated = adapter.UpdateCommand.ExecuteNonQuery();
                if (countUpdated > 0)
                {
                    FeedbackLbl.Text = $"Successfully updated {keyword}";
                }
                else
                {
                    FeedbackLbl.Text = $"Failed to update {keyword}";
                }

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

        public DateTime GetStartDate()
        {
            DateTime startDate = StartDate.SelectedDate.Date;
            DateTime endDate = EndDate.SelectedDate.Date;

            if (startDate > endDate)
            {
                FeedbackLbl.Text = $"Start date:{startDate} and end date: {endDate} invalid";
            }

            return startDate;


        }

        public DateTime GetEndDate()
        {
            DateTime startDate = StartDate.SelectedDate.Date;
            DateTime endDate = EndDate.SelectedDate.Date;

            if (startDate > endDate)
            {
                FeedbackLbl.Text = $"Start date:{startDate} and end date: {endDate} invalid";
            }

            return endDate;


        }

        protected void UpdateSpecialBtn_Click1(object sender, EventArgs e)
        {
            string keyword = SpecialId.Text;
            string query = "UpdateSpecial";
            UpdateASpecial(query, keyword);
        }
    }
}