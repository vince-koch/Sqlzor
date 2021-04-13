using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sqlzor.Data.Schema
{
    ////MetaDataCollections loaded in 00:00:00.2069165 [19 rows]
    ////DataSourceInformation loaded in 00:00:00.2108632 [2 rows]
    ////DataTypes loaded in 00:00:00.2386257 [35 rows]
    ////Restrictions loaded in 00:00:00.2176358 [48 rows]
    ////ReservedWords loaded in 00:00:00.2133238 [235 rows]
    ////Databases loaded in 00:00:00.3305727 [9 rows]
    ////Tables loaded in 00:00:00.3370131 [59 rows]
    ////Columns loaded in 00:00:00.5478555 [417 rows]
    ////Exception thrown: 'MySql.Data.MySqlClient.MySqlException' in MySql.Data.dll
    ////Users failed after 00:00:00.3503026 [SELECT command denied to user 'rfamro'@'cpe-74-139-172-96.kya.res.rr.com' for table 'user']
    ////Foreign Keys loaded in 00:00:00.3326985 [50 rows]
    ////Exception thrown: 'System.Data.SqlTypes.SqlNullValueException' in MySql.Data.dll
    ////IndexColumns failed after 00:00:03.4537890 [Data is Null. This method or property cannot be called on Null values.]
    ////Indexes loaded in 00:00:06.6028120 [111 rows]
    ////Foreign Key Columns loaded in 00:00:00.3249657 [50 rows]
    ////'iisexpress.exe' (CoreCLR: clrhost): Loaded 'C:\Program Files\dotnet\shared\Microsoft.NETCore.App\3.1.11\System.Resources.ResourceManager.dll'. Skipped loading symbols. Module is optimized and the debugger option 'Just My Code' is enabled.
    ////Exception thrown: 'MySql.Data.MySqlClient.MySqlException' in MySql.Data.dll
    ////UDF failed after 00:00:00.3500571 [An error occured attempting to enumerate the user-defined functions.  Do you have SELECT privileges on the mysql.func table?]
    ////The thread 0x5444 has exited with code 0 (0x0).
    ////Views loaded in 00:00:00.3187401 [0 rows]
    ////ViewColumns loaded in 00:00:00.3328792 [0 rows]
    ////Procedure Parameters loaded in 00:00:00.4368934 [0 rows]
    ////Procedures loaded in 00:00:00.4234087 [0 rows]
    ////Triggers loaded in 00:00:00.3238696 [0 rows]
    /*
    public class SchemaTreeBuilder
    {
        public List<Database> BuildSchemaTree(List<DataTable> schema)
        {
            var databases = BuildDatabases(schema);
            return databases;
        }

        private List<Database> BuildDatabases(List<DataTable> schema)
        {
            var databases = schema
                .Where(item => item.TableName == "Databases")
                .ToList();

            var tableCatalogs = schema
                .Where(item => item.TableName == "Tables")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Select(row => row["TABLE_CATALOG"].ToString())
                .Distinct()
                .ToArray();

            foreach (var tableCatalog in tableCatalogs)
            {
//                databases.Select(row => )
//                .SelectMany(table => table.Rows.Cast<DataRow>())
//                .Select(row => BuildDatabase(schema, row))
//                .ToList();
            }

            if (!databases.Any())
            {
                var tableRows = schema
                    .Where(item => item.TableName == "Tables")
                    .SelectMany(table => table.Rows.Cast<DataRow>())
                    .ToArray();

                var databaseName = tableRows
                    .GroupBy(row => row["TABLE_CATALOG"].ToString())
                    .Select(group => new { group.Key, Count = group.Count() })
                    .OrderByDescending(anon => anon.Count)
                    .Select(anon => anon.Key)
                    .FirstOrDefault();

                var database = new Database();
                database.Name = databaseName;
                //databases.Add(database);
            }

            //return databases;
            throw new NotImplementedException();
        }

        private Database BuildDatabase(List<DataTable> schema, DataRow schemaRow)
        {
            var database = new Database();
            database.Name = schemaRow["Database_Name"].ToString();

            database.Tables = schema
                .Where(item => item.TableName == "Tables")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Where(row => row["TABLE_CATALOG"].ToString() == database.Name)
                .Select(row=> BuildTable(schema, row))
                .OrderBy(table => table.Catalog)
                .ThenBy(table => table.Schema)
                .ThenBy(table => table.Name)
                .ToList();

            database.Views = schema
                .Where(item => item.TableName == "Views")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Select(row => BuildView(schema, row))
                .OrderBy(view => view.Catalog)
                .ThenBy(view => view.Schema)
                .ThenBy(view => view.Name)
                .ToList();

            return database;
        }

        private Table BuildTable(List<DataTable> schema, DataRow schemaRow)
        {
            var table = new Table();
            table.Catalog = schemaRow["TABLE_CATALOG"].ToString();
            table.Schema = schemaRow["TABLE_SCHEMA"].ToString();
            table.Name = schemaRow["TABLE_NAME"].ToString();

            table.Columns = schema.Where(table => table.TableName == "Columns")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Where(row => row["TABLE_CATALOG"].ToString() == schemaRow["TABLE_CATALOG"].ToString())
                .Where(row => row["TABLE_CATALOG"].ToString() == schemaRow["TABLE_SCHEMA"].ToString())
                .Where(row => row["TABLE_NAME"].ToString() == schemaRow["TABLE_NAME"].ToString())
                .Select(row => BuildColumn(schema, row))
                .OrderBy(column => column.Ordinal)
                .ToList();

            return table;
        }

        private Column BuildColumn(List<DataTable> schema, DataRow schemaRow)
        {
            var column = new Column();
            column.Name = schemaRow["COLUMN_NAME"].ToString();
            column.DataType = schemaRow["DATA_TYPE"].ToString();
            column.Ordinal = (int)schemaRow["ORDINAL_POSITION"];
            return column;
        }

        private View BuildView(List<DataTable> schema, DataRow schemaRow)
        {
            var view = new View();
            view.Catalog = schemaRow["TABLE_CATALOG"].ToString();
            view.Schema = schemaRow["TABLE_SCHEMA"].ToString();
            view.Name = schemaRow["TABLE_NAME"].ToString();

            view.Columns = schema.Where(item => item.TableName == "ViewColumns")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Where(row => row["VIEW_CATALOG"].ToString() == view.Catalog)
                .Where(row => row["VIEW_SCHEMA"].ToString() == view.Schema)
                .Where(row => row["VIEW_NAME"].ToString() == view.Name)
                .Select(row => BuildViewColumn(schema, row))
                .ToList();

            return view;
        }

        private Column BuildViewColumn(List<DataTable> schema, DataRow schemaRow)
        {
            var column = new Column();
            column.Name = schemaRow["COLUMN_NAME"].ToString();

            column.DataType = schema.Where(table => table.TableName == "Columns")
                .SelectMany(table => table.Rows.Cast<DataRow>())
                .Where(row => row["TABLE_CATALOG"].ToString() == schemaRow["TABLE_CATALOG"].ToString())
                .Where(row => row["TABLE_CATALOG"].ToString() == schemaRow["TABLE_SCHEMA"].ToString())
                .Where(row => row["TABLE_NAME"].ToString() == schemaRow["TABLE_NAME"].ToString())
                .Where(row => row["COLUMN_NAME"].ToString() == schemaRow["COLUMN_NAME"].ToString())
                .Select(row => row["DATA_TYPE"].ToString()) // todo: deal with precisioon and stuff
                .SingleOrDefault();

            return column;
        }
    }
    */
}