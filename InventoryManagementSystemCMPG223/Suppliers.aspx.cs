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
    public partial class Suppliers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetSuppliers();
            }
        }
      
        public SqlConnection conn = new SqlConnection(@"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True");
        public SqlCommand comm;
        public DataSet ds;
        public SqlDataAdapter adap;

        //GET ALL THE SUPPLIERS IN THE DB
        public void GetSuppliers()
        {
            try
            {
                string sql_state = "SelectAllSuppliers";
                conn.Open();
                ds = new DataSet();
                adap = new SqlDataAdapter();

                comm = new SqlCommand(sql_state, conn);
                adap.SelectCommand = comm;
                comm.CommandType = CommandType.StoredProcedure;
                adap.Fill(ds);

                SuppliersGridView.DataSource = ds;
                SuppliersGridView.DataBind();


             
            }
            catch(SqlException e) {

                lblSpecials.Text = e.ToString();
            }
            finally
            {
                conn.Close();
            }

        }
    }
}