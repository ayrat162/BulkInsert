using Dapper.Contrib.Extensions;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace BulkInsertDemo
{
    public class DbService
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TEST;";

        public static void BulkInsert<T>(IEnumerable<T> items) where T : class
        {
            using var sqlCopy = new SqlBulkCopy(ConnectionString);
            sqlCopy.DestinationTableName = GetTableName<T>();
            sqlCopy.BatchSize = 10000;

            var x = typeof(T).GetProperties().Select(p => p.Name).ToArray();

            using var reader = ObjectReader.Create(items, x);
            sqlCopy.WriteToServer(reader);

        }

        private static string GetTableName<T>()
        {
            if (SqlMapperExtensions.TableNameMapper != null)
                return SqlMapperExtensions.TableNameMapper(typeof(T));

            string getTableName = "GetTableName";
            var getTableNameMethod = typeof(SqlMapperExtensions).GetMethod(getTableName, BindingFlags.NonPublic | BindingFlags.Static);

            if (getTableNameMethod == null)
                throw new ArgumentOutOfRangeException($"Method '{getTableName}' is not found in '{nameof(SqlMapperExtensions)}' class.");

            return getTableNameMethod.Invoke(null, new object[] { typeof(T) }) as string;
        }
    }
}
