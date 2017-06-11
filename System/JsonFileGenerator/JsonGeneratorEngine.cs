using RestaurantSystem.FileManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace JsonFileGenerator
{
    public class JsonGeneratorEngine
    {
        private IFileManager fileManager;

        public JsonGeneratorEngine(IFileManager fileManager)
        {
            this.fileManager = fileManager;
        }

        public void Start()
        {

        }
    }
}
