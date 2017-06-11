using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLite.TestGround
{
    public class SqlLiteEngine
    {
        private readonly SQLiteDbContext db = new SQLiteDbContext();

        public void Start()
        {
            Console.WriteLine("SqlLiteEngine started");

            //var c = db.Items.ToList().Count();

            //Console.WriteLine(c);
        }
    }
}
