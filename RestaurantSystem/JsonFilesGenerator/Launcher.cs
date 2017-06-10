﻿using RestaurantSystem.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonFilesGenerator
{
    class Launcher
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            TestObjectRandomGenerator objectGenerator = new TestObjectRandomGenerator();

            var engine = new Engine(fileManager, objectGenerator);
            engine.Start();
        }
    }
}
