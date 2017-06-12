namespace RestaurantSystem.PDFManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface ISalesPDFManager
    {
        byte[] ExportSalesFile(IList<Sale> sales);
    }
}
