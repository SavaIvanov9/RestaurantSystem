namespace RestaurantSystem.PDFManaging
{
    using RestaurantSystem.Models;
    using System;
    using System.Collections.Generic;

    public class PDFManager : IPDFManager
    {
        public byte[] ExportSalesFile(ICollection<Sale> sales)
        {
            throw new NotImplementedException();
        }
    }
}
