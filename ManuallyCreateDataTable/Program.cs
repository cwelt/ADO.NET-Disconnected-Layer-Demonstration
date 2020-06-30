using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManuallyCreateDataTable
{
    class Program
    {
        static void Main(string[] args)
        {

            BuildDataSet(null, null);

            // Create a data table named students 
            DataTable studentsTable = new DataTable(tableName: "Students");

            /* define the table's schema */
            studentsTable.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn(columnName: "Id", dataType: typeof(string)),
                    new DataColumn(columnName: "Name", dataType: typeof(string)),
                    new DataColumn(columnName: "Birthdate", dataType: typeof(DateTime)),
                });

            // define  the primary key columns 
            DataColumn keyColumn = studentsTable.Columns[name: "Id"];
            studentsTable.PrimaryKey = new DataColumn[] { keyColumn };

            // create a new student record 
            DataRow studentRow = studentsTable.NewRow();
            studentRow[columnName: "Id"] = "007";
            studentRow[columnIndex: 1] = "JamesBond";
            studentRow[column: keyColumn] = "JamesBond";

            // add the record to the table 
            studentsTable.Rows.Add(studentRow);
        }


        public static void AccessDataTableRecordsWithDataReader(DataTable table)
        {
            // create a data reader for this data table
            DataTableReader dataReader = table.CreateDataReader();

            // iterate over row results 
            while (dataReader.Read())
            {
                // iterate over columns 
                for (int i = 0; i < dataReader.FieldCount; i++)
                    Console.WriteLine($"Column {i} = {dataReader[ordinal: i]}");
            }
        }

        public static void AccessDataTableRecordsWithIndexers(DataTable table)
        {
            // iterate over over all rows
            for (int i = 0; i < table.Rows.Count; i++)
            {
                // iterate over all columns 
                for (int j = 0; j < table.Rows[i].ItemArray.Length; j++)
                {
                    Console.WriteLine($"[i][j] = {table.Rows[i][j]}");
                }
            }
        }

        public static DataSet BuildDataSet(DataTable productsTable, DataTable ordersTable)
        {
            // add a foreign key constraint between prodcuts and orders
            ordersTable.Constraints.Add(
                name: "OrdersProductsFK",
                primaryKeyColumn: productsTable.Columns["ProductId"],
                foreignKeyColumn: ordersTable.Columns["ProductId"]);

            // initialize a new empty data 
            DataSet inventoryDataSet = new DataSet(dataSetName: "Inventory Data Set");

            // add the data tables from input to the data set 
            inventoryDataSet.Tables.Add(productsTable);
            inventoryDataSet.Tables.Add(ordersTable);

            // define a foreign key relationship between the products and orders tables 
            DataRelation productOrderRealtion = new DataRelation(
                relationName: "OrdersProductsFK",
                parentColumn: productsTable.Columns["ProductId"],
                childColumn: ordersTable.Columns["ProductId"]);

            // add the realtion to the dataset 
            inventoryDataSet.Relations.Add(productOrderRealtion);

            // return the initialized data set 
            return inventoryDataSet; 
        }

    }
}
