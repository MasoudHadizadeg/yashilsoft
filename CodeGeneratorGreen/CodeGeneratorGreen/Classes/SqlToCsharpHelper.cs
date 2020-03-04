using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CodeGeneratorGreen.Models;
using DevExpress.Printing.Native.PrintEditor;

namespace CodeGeneratorGreen.Classes
{
    public class SqlToCsharpHelper
    {
        public static Tables dbTables;
        public static List<Table> allTables = new List<Table>();
        public static Table table { get; set; }

        public static string GetNetDataType(string sqlDataTypeName)
        {
            switch (sqlDataTypeName.ToLower())
            {
                case "bigint":
                    return "Int64";
                case "binary":
                case "image":
                case "varbinary":
                    return "byte[]";
                case "bit":
                    return "bool";
                case "char":
                    return "char";
                case "datetime":
                case "smalldatetime":
                    return "DateTime";
                case "decimal":
                case "money":
                case "numeric":
                    return "decimal";
                case "float":
                    return "double";
                case "int":
                    return "int";
                case "nchar":
                case "nvarchar":
                case "text":
                case "varchar":
                case "xml":
                    return "string";
                case "real":
                    return "single";
                case "smallint":
                    return "Int16";
                case "tinyint":
                    return "byte";
                case "uniqueidentifier":
                    return "Guid";
                default:
                    return null;
            }
        }

        public static bool IsPropertyNumer(string sqlDataTypeName)
        {
            var dataType = sqlDataTypeName.ToLower();
            return dataType == "bigint" || dataType == "decimal" || dataType == "float" || dataType == "int" ||
                   dataType == "real" || dataType == "smallint" || dataType == "tinyint";
        }

        public static void Add(Table tbl)
        {
            allTables.Add(tbl);
        }
    }
}