using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace StockMarket.Data
{
    public class ADODotNetClass
    {
        public static DataTable GetDataUsingAdapter(int PageIndex,int PageSize,string SortCol,string SortDir,string Search)
        {
            //var dataSet = new DataSet("StockMarket");
            const string connectionString = "Server = DESKTOP-56016FA; Database = StockMarket; User Id = armanabdullah; Password = with0ut;";
            var dataTable = new DataTable("Customers");
            string sql = "spReturnPagedData";
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        var adapter = new SqlDataAdapter(command);
                        command.Parameters.Add(new SqlParameter("@PageIndex", SqlDbType.Int)).Value = PageIndex;
                        command.Parameters.Add(new SqlParameter("@PageSize", SqlDbType.Int)).Value = PageSize;
                        command.Parameters.Add(new SqlParameter("@SortCol", SqlDbType.VarChar)).Value = SortCol;
                        command.Parameters.Add(new SqlParameter("@SortDir", SqlDbType.VarChar)).Value = SortDir;
                        command.Parameters.Add(new SqlParameter("@Search", SqlDbType.VarChar)).Value = Search;

                        dataTable.Columns.Add(new DataColumn("Id"));
                        dataTable.Columns.Add(new DataColumn("Name"));
                        dataTable.Columns.Add(new DataColumn("MinPrice"));
                        dataTable.Columns.Add(new DataColumn("MaxPrice"));
                        dataTable.Columns.Add(new DataColumn("TradingDay"));

                        adapter.Fill(dataTable);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection?.Close();
                }

                return dataTable;
            }
        }
    }
}
