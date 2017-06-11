namespace RestaurantSystem.FileManager
{
    using System;

    public interface IFileManager
    {
        byte[] ReadFile(string path);

        Tuple<bool, string> WriteFile(byte[] file, string directory, string fileName);
    }
}
