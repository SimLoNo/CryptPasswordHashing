using CryptSymmetric;
using System.Security.Cryptography;

bool isLoggedIn = false;
string username;
string password;
Login loginClass = new Login();
hashing hashingClass = new hashing();
CreateUser createUser = new CreateUser();
//createUser.InsertUser();
for (int i = 0; i < 5; i++)
{
	username = "";
	password = "";
	//Console.Clear();
	if (i != 0)
	{ 
        Console.WriteLine("Brugernavn eller adgangskode er forkert.");
    }
    Console.WriteLine("Indtast brugernavn.");
	username = Console.ReadLine();
    Console.WriteLine("Indtast kodeord.");
	password = Console.ReadLine();

	string salt = loginClass.FindUsername(username);
	if (salt != "")
	{
		string saltedPassword = hashingClass.HashPassword(password, salt);
		isLoggedIn = loginClass.Authenticate(username, saltedPassword);
	}
	if (isLoggedIn)
	{

		break;
	}


}
if (isLoggedIn)
{
    Console.WriteLine("Du er logged ind.");
	Console.ReadLine();
}
else
{
    Console.WriteLine("Du er løbet tør for forsøg.");
	Console.ReadLine();
}


