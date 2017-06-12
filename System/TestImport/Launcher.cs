using JsonFilesGenerator;
using RestaurantSystem.FileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestImport
{
    public class Launcher
    {
        public static void Main()
        {
            FileManager fileManager = new FileManager();
            TestObjectRandomGenerator objectGenerator = new TestObjectRandomGenerator();

            var engine = new Engine(fileManager, objectGenerator);
            engine.Start();

        }
    }
}
