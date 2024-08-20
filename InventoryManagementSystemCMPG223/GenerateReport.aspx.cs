using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InventoryManagementSystemCMPG223
{
    public partial class GenerateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetProductData();
        }



        private DataTable GetProductData()
        {
            DataTable dt = new DataTable();
            string connStr = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True"; ;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //string query = "SELECT OrderNumber, Quantity, OrderDate FROM Orders"; // Adjust your query accordingly

                string query = "select * from products";

                //use join statements to query multiple tables
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                    }
                }
            }
            return dt;
        }





        private void ExportToPDF(DataTable dt)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            PdfPTable table = new PdfPTable(dt.Columns.Count);
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName));
                table.AddCell(cell);
            }

            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    table.AddCell(item.ToString());
                }
            }

            doc.Add(table);
            doc.Close();
            
            Response.ContentType = "application/pdf";
           
            Response.AddHeader("content-disposition", "attachment;filename=ProductReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();
        }

        protected void GenerateReportBtn_Click1(object sender, EventArgs e)
        {
          

            DataTable dt = GetProductData();

           
                ExportToPDF(dt);
            
        }
    }
}