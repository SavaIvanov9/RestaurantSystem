using RestaurantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantSystem.PDFManaging
{
    public interface IProductsPDFManager
    {
        byte[] ExportProductsFile(IList<Product> products);
    }
}
