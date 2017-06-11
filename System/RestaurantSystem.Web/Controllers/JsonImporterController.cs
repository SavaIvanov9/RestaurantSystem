namespace RestaurantSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RestaurantSystem.Data.Abstraction;
    using RestaurantSystem.Infrastructure.Enumerations;
    using RestaurantSystem.JsonManaging;
    using RestaurantSystem.Services.Abstraction;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    public class JsonImporterController : BaseController
    {
        private IJsonProcessingService jsonProcessingService;
        private IJsonManager jsonManager;

        public JsonImporterController(IRestaurantSystemData data, IJsonProcessingService jsonProcessingService,
            IJsonManager jsonManager) : base(data)
        {
            this.jsonProcessingService = jsonProcessingService;
            this.jsonManager = jsonManager;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ImportFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                //formFile.Length;

                if (formFile.Length > 0)
                {
                    //using (var stream = new FileStream(filePath, FileMode.Create))
                    //{
                    //    await formFile.CopyToAsync(stream);
                    //}

                    using (var stream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            //this.jsonProcessingService.ImportDocument(ImportingType.Products, this.Data, this.jsonManager)

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(/*new { count = files.Count, size, filePath }*/);
        }
    }
}
