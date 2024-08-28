using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace InventoryManagementSystemCMPG223
{
    public partial class GenerateReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private DataTable GetProductData(string userQuery)
        {
            DataTable dt = new DataTable();
            string connStr = @"Data Source=GIVEN\SQLEXPRESS;Initial Catalog=InventoryManSysDB;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(userQuery, conn))
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

        private void ExportToPDF(Document doc, DataTable dt, string tableTitle)
        {
            if (dt.Rows.Count > 0)
            {
                // Add a title for the table
                Paragraph title = new Paragraph(tableTitle, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
                title.Alignment = Element.ALIGN_CENTER;
                title.SpacingAfter = 10;
                doc.Add(title);

                PdfPTable table = new PdfPTable(dt.Columns.Count);

                // Adding headers
                foreach (DataColumn col in dt.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }

                // Adding data rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        table.AddCell(item.ToString());
                    }
                }

                doc.Add(table);
                doc.Add(new Paragraph("\n")); // Add space between tables
            }
        }

        protected void GenerateReportBtn_Click1(object sender, EventArgs e)
        {
            // Initialize the PDF document
            Document doc = new Document();
            PdfWriter.GetInstance(doc, Response.OutputStream);
            doc.Open();

            // Retrieve data for each table and add to the PDF
            ExportToPDF(doc, GetProductData("SelectAllProducts"), "Product Report");
            ExportToPDF(doc, GetProductData("SelectAllUsers"), "Users Report");
            ExportToPDF(doc, GetProductData("SelectAllCustomers"), "Customers Report");
            ExportToPDF(doc, GetProductData("SelectAllSpecials"), "Specials Report");
            ExportToPDF(doc, GetProductData("SelectAllSuppliers"), "Suppliers Report");
            ExportToPDF(doc, GetProductData("SelectAllInventory"), "Inventory Report");

            //ExportToPDF(doc, GetProductData("SelectAllOrders"), "Orders Report");
            //ExportToPDF(doc, GetProductData("SelectAllOrderedProducts"), "Ordered Product Report");



            doc.Close();

            // Prepare response for the client
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=CombinedReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();
        }
    }
}
