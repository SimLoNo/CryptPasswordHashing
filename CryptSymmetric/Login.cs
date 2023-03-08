using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptSymmetric
{
	public class Login
	{
		private readonly string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CryptologyPassword;Integrated Security=True;Connect Timeout=30;Encrypt=False;"; //Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
		public string FindUsername(string username)
		{
			using (SqlConnection _con = new SqlConnection(connectionString))
			{
				string queryString = $"SELECT Salt FROM dbo.Users WHERE Username = '{username}'";
				using (SqlCommand _cmd = new SqlCommand(queryString, _con))
				{
					string salt = "";

					_con.Open();
					SqlDataReader Reader = _cmd.ExecuteReader();
					while (Reader.Read())
					{
						salt = Reader.GetString(0);
					}
					_con.Close();
					return salt;
				}
			}
		}

		public bool Authenticate(string username, string password)
		{
			using (SqlConnection _con = new SqlConnection(connectionString))
			{
				string queryString = @$"SELECT Username FROM dbo.Users WHERE Username = '{username}' AND UserPassword = '{password}'";
				using (SqlCommand _cmd = new SqlCommand(queryString, _con))
				{
					string foundUser = "";

					_con.Open();
					SqlDataReader Reader = _cmd.ExecuteReader();
					while (Reader.Read())
					{
						foundUser = Reader.GetString(0);
					}
					_con.Close();
					if (foundUser != "")
					{
						//GenerateNewSalt(foundUser);
						return true;
					}
					else return false;
				}


			}

		}

		//public void GenerateNewSalt(string username)
		//{
		//	string salt = DateTime.Now.ToString();
		//	using (SqlConnection _con = new SqlConnection(connectionString))
		//	{
		//		string queryString = @$"UPDATE dbo.Users SET Salt = '{salt}' WHERE Username = '{username}'";
		//		using (SqlCommand _cmd = new SqlCommand(queryString, _con))
		//		{
		//			_con.Open();
		//			_cmd.ExecuteNonQuery();
		//			_con.Close();


		//		} 
		//	}
		//}
	}
}
