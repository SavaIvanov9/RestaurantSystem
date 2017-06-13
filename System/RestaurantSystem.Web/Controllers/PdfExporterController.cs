namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.PDFManaging;
    using System.Linq;

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
