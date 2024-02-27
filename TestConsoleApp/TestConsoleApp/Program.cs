using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			string strA = null;
		}
		public string ConnectionString { get; set; } = "Server=10.0.0.101;Database=CustomerData";

		public SqlConnection ConnectToDatabase()
		{
			string connectionString = string.Format("{0};User ID={1};Password={2}",
				ConnectionString,"username","pwd");

			SqlConnection connection = new SqlConnection();
			connection.ConnectionString = connectionString; // Noncompliant
			connection.Open();
			return connection;
		}
	}

}
