namespace RestaurantSystem.FileManager
{
    using System;
    using System.IO;

    public class FileManager : IFileManager
    {
        public byte[] ReadFile(string path)
        {
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                return bytes;
            }
        }

        public Tuple<bool, string> WriteFile(byte[] file, string directory, string fileName)
        {
            try
            {
                directory = directory ?? System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = Path.Combine(directory, fileName);

                File.WriteAllBytes(path, file);

                return new Tuple<bool, string>(true, "");
            }
            catch(Exception ex)
            {
                return new Tuple<bool, string>(false, ex.ToString());
            }
        }
    }
}
