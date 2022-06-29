// See https://aka.ms/new-console-template for more information
using System.Data.Common;

Console.WriteLine("Hello, World!");

var conString = "Server=(localdb)\\mssqllocaldb;Database=HalloEfCore;Trusted_Connection=true";

DbProviderFactory factory = null;
if ("SQLSERVER" == "SQLSERVER")
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
else
    factory = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance;


DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

DbCommand cmd = factory.CreateCommand();
cmd.CommandText = "SELECT * FROM Person";
cmd.Connection = con;

DbDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine(reader.GetString(reader.GetOrdinal("Name")));
}



