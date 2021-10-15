using BulkInsertDemo.DbModels;
using System.Collections.Generic;

namespace BulkInsertDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = new List<TestModel>
            {
                new TestModel { Col1 = "Value1", Col2 = "Value2" },
                new TestModel { Col1 = "Value3", Col2 = "Value4" },
                new TestModel { Col1 = "Value5", Col2 = "Value6" }
            };
            DbService.BulkInsert(rows);
        }
    }
}
