using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptSymmetric
{
	public class CreateUser
	{
		private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CryptologyPassword;Integrated Security=True;Connect Timeout=30;Encrypt=False;"; //Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
		public void InsertUser()
		{
			hashing hashingClass = new hashing();

			DateTime newTime = DateTime.Now;
            Console.WriteLine("Indtast kodeord.");
			string pwd = Console.ReadLine();
            Console.WriteLine("Indtast brugernavn");
			string username = Console.ReadLine();
            string password = hashingClass.HashPassword(pwd, newTime.ToString());
			using (SqlConnection _con = new SqlConnection(connectionString))
			{
				string queryString = $"INSERT INTO dbo.Users (Username, UserPassword,Salt) VALUES ('{username}','{password}','{newTime.ToString()}')";
				using (SqlCommand _cmd = new SqlCommand(queryString, _con))
				{

					_con.Open();
					_cmd.ExecuteNonQuery();
					_con.Close();
				}
			}
		}
	}
}
