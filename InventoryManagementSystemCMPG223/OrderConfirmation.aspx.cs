﻿using iTextSharp.text;
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
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetOrderProduct();
            }
        }

        readonly string ConnString = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommand cmd;
        DataSet ds;


        public void GetOrderProduct()
        {
            try
            {
                conn = new SqlConnection(ConnString);
                adapter = new SqlDataAdapter();
                ds = new DataSet();
                conn.Open();

                cmd = new SqlCommand("SelectAllOrderProducts", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

                OrderProductGridView.DataSource = ds;
                OrderProductGridView.DataBind();
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


     

    }
}