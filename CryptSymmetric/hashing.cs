using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptSymmetric
{
	public class hashing
	{
		public string HashPassword(string password, string salt)
		{
			Byte[] saltByte = new byte[salt.Length];
			for (int i = 0; i < salt.Length; i++)
			{
				saltByte[i] = Convert.ToByte(salt[i]);
			}
			using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, saltByte))
			{
				hashGenerator.IterationCount = 1000;
				byte[] hashedBytes = new byte[10];
				hashedBytes = hashGenerator.GetBytes(10);
				string hashedString = "";

				for (int i = 0; i < hashedBytes.Length; i++)
				{
					hashedString += Convert.ToChar(hashedBytes[i]);
				}
				return hashedString;
			}
		}
	}
}
