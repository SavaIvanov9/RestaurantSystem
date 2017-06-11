﻿namespace RestaurantSystem.PDFManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IPDFManager
    {
        byte[] ExportSalesFile(IList<Sale> sales);
    }
}