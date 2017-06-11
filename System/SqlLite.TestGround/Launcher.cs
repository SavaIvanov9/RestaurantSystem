namespace SqlLite.TestGround
{
    class Launcher
    {
        static void Main(string[] args)
        {
            var engine = new SqlLiteEngine();
            engine.Start();
        }
    }
}
