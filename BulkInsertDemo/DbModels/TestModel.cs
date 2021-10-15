using Dapper.Contrib.Extensions;

namespace BulkInsertDemo.DbModels
{
    // CREATE TABLE [dbo].[TestTable](
    // [Id] [int] IDENTITY(1,1) NOT NULL,
    // [Col1] [nvarchar](255) NULL,
    // [Col2] [nvarchar](255) NULL)

    [Table("TestTable")]
    public class TestModel
    {
        public int Id { get; set; }
        public string Col1 { get; set; }
        public string Col2 { get; set; }
    }
}
