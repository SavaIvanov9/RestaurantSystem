using RestaurantSystem.FileManager;

namespace JsonFileGenerator
{
    public class Launcher
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();

            var engine = new JsonGeneratorEngine(fileManager);
            engine.Start();
        }
    }
}