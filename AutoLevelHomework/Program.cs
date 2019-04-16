using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLevelHomework
{
    class Program
    {
        static void Main(string[] args)
        {

            DataSet dataSet = new DataSet("shopDB");

            #region ordersTable
            DataTable ordersTable = new DataTable("Orders");
            ordersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "CustomerId",
                DataType = typeof(int)
            });
            ordersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "OrderDetailsId",
                DataType = typeof(int)
            });
            ordersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "ProductId",
                DataType = typeof(int)
            });
            ordersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "EmployeeId",
                DataType = typeof(int)
            });
            #endregion

            #region customersTable
            DataTable customersTable = new DataTable("Customers");
            customersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            customersTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "Name",
                DataType = typeof(string),
            });

            #endregion

            #region employeesTable
            DataTable employeesTable = new DataTable("Employees");
            employeesTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            employeesTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "Name",
                DataType = typeof(string),
            });
            #endregion

            #region orderDetailsTable
            DataTable orderDetailsTable = new DataTable("OrderDetails");
            orderDetailsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            orderDetailsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "Details",
                DataType = typeof(string),
            });
            #endregion

            #region productsTable
            DataTable productsTable = new DataTable("Products");
            productsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "Id",
                DataType = typeof(int),
                Unique = true
            });
            productsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "Name",
                DataType = typeof(string),
            });
            productsTable.Columns.Add(new DataColumn
            {
                AllowDBNull = false,
                ColumnName = "Price",
                DataType = typeof(int),
            });
            #endregion

            orderDetailsTable.PrimaryKey = new DataColumn[] { orderDetailsTable.Columns["Id"] };
            employeesTable.PrimaryKey = new DataColumn[] { employeesTable.Columns["Id"] };
            productsTable.PrimaryKey = new DataColumn[] { productsTable.Columns["Id"] };
            customersTable.PrimaryKey = new DataColumn[] { customersTable.Columns["Id"] };
            ordersTable.PrimaryKey = new DataColumn[] { ordersTable.Columns["Id"] };

            dataSet.Tables.Add(orderDetailsTable);
            dataSet.Tables.Add(employeesTable);
            dataSet.Tables.Add(productsTable);
            dataSet.Tables.Add(customersTable);
            dataSet.Tables.Add(ordersTable);

            dataSet.Relations.Add("orders_customer_fk", ordersTable.Columns["CustomerId"], customersTable.Columns["Id"]);
            dataSet.Relations.Add("orders_employees_fk", ordersTable.Columns["EmployeeId"], customersTable.Columns["Id"]);
            dataSet.Relations.Add("orders_products_fk", ordersTable.Columns["ProductId"], customersTable.Columns["Id"]);
            dataSet.Relations.Add("orders_orderDetails_fk", ordersTable.Columns["orderDetailsId"], customersTable.Columns["Id"]);
        }
    }
}