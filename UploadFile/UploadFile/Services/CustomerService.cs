using ClosedXML.Excel;
using UploadFile.Models;

namespace UploadFile.Services
{
    public class CustomerService
    {
        public CustomerService()
        {

        }

        /// <summary>
        /// Perform logic here to generate an excel document and ensure to return a byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] GetReport()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer() { Id = 1, Age = 12, Name = "Justin" } ,
                new Customer() { Id = 2, Age = 21, Name = "Phil" },
                new Customer() { Id = 3, Age = 62, Name = "Jared" }
            };

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Customer");
            worksheet.Cell(1, 1).InsertData(customers);

            var workbookBytes = new byte[0];
            using (var ms = new MemoryStream())
            {
                workbook.SaveAs(ms);
                workbookBytes = ms.ToArray();
            }
            return workbookBytes;
        }
    }
}
