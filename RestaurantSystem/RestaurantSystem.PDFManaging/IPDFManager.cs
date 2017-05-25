namespace RestaurantSystem.PDFManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IPDFManager
    {
        void ExportSalesFile(IList<Sale> sales);
    }
}
