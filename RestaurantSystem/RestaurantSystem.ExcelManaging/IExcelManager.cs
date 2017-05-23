﻿namespace RestaurantSystem.ExcelManaging
{
    using RestaurantSystem.Models;
    using System.Collections.Generic;

    public interface IExcelManager
    {
        ICollection<Product> ImportFile(byte[] document);
    }
}
