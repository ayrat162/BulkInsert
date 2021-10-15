# BulkInsert Demo
Demo Implementation of SqlBulkCopy for Generic Database Model. 

This repository was created as a simplified version of Dapper Plus - Bulk Insert.



It uses [Dapper.Contrib](https://github.com/DapperLib/Dapper.Contrib), [FastMember](https://github.com/mgravell/fast-member), and [SqlBulkCopy](https://docs.microsoft.com/ru-ru/dotnet/api/system.data.sqlclient.sqlbulkcopy) for uploading large chunks of data to MS SQL Server.



Known issues:

- If the field is to be truncated, the app throws an error and crashes
- 
