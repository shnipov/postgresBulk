using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Data;

namespace PostgresCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new List<Test>();

            for (int i = 0; i < 1000000; i++)
            {
                collection.Add(new Test { Id = i, Code = $"C{i}" });
            }

            var stopwatch = Stopwatch.StartNew();

            // ProviderSpecific для PostgreSQL реализован только начиная с версии linq2sb 2.0.0-rc2
            //  с ним работает COPY "public".test (id, code) FROM STDIN (FORMAT BINARY)
            //  без него дольше минуты
            var bulkCopyOptions = new BulkCopyOptions { BulkCopyType = BulkCopyType.ProviderSpecific };
            using (var db = new Db())
            {
                // TODO Перед запуском truncate table test, иначе упадёт
                db.BulkCopy(bulkCopyOptions, collection);
            }

            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}
