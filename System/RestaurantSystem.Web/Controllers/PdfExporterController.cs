namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.DataImporter.SupplyDocumentImporter.Abstraction;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.JsonManaging;
    using RestaurantSystem.PDFManaging;
    using RestaurantSystem.Services.Abstraction;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class PdfExporterController : BaseController
    {
        private readonly IProductsPDFManager productsPDFManager;

        public PdfExporterController(IRestaurantSystemData data, IProductsPDFManager productsPDFManager) : base(data)
        {
            this.productsPDFManager = productsPDFManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
        {
            var products = this.Data.Products
                .All()
                .ToList();

            var file = this.productsPDFManager.ExportProductsFile(products);

            return File(file, "application/pdf", "ProductsReport.pdf");
        }
    }
}
