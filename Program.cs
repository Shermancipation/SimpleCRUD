using System;
using DbConnection;

namespace CRUDMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            AllUsers();
            UpdateUser("Brad", "Sherman", 5, "whatever1", "whatever2", "whatever3", 2);
            AllUsers();

            // Small user interface to add users, Delete/Update not currently implemented

            // string confirmation = "Y";
            // while (confirmation == "Y" || confirmation == "y")
            // {
            //     System.Console.WriteLine("Please add a new user.");
            //     NewUser();
            //     System.Console.WriteLine("Would you like to add another user? (Y/N)");
            //     confirmation = Console.ReadLine();
            // }
            // System.Console.WriteLine("Thanks for using the app!");
            // System.Environment.Exit(1);

        }
        public static void AllUsers()
        {
            System.Console.WriteLine("Please see all users below:");
            var sql = DbConnector.Query("SELECT * FROM Users");
            foreach (var item in sql)
            {
                System.Console.WriteLine(item["id"] + " " + item["FirstName"] + " " + item["LastName"] + "'s favorite number is " + item["FavoriteNumber"] + ".");
            }
        }
        public static void NewUser()
        {
            System.Console.WriteLine("Enter first name.");
            string firstname = Console.ReadLine();
            System.Console.WriteLine("Enter last name.");
            string lastname = Console.ReadLine();
            System.Console.WriteLine("Enter favorite number.");
            string favoriteNumberString = Console.ReadLine();
            int favoriteNumber = Convert.ToInt32(favoriteNumberString);
            System.Console.WriteLine("Enter whatever you want!");
            string DummyData1 = Console.ReadLine();
            System.Console.WriteLine("Enter another thing you want!");
            string DummyData2 = Console.ReadLine();
            System.Console.WriteLine("Enter one more thing you want!");            
            string DummyData3 = Console.ReadLine();
            DbConnector.Execute($"INSERT into Users (FirstName, LastName, FavoriteNumber, DummyData1, DummyData2, DummyData3) VALUES ('{firstname}', '{lastname}', '{favoriteNumber}', '{DummyData1}', '{DummyData2}', '{DummyData3}')");
            AllUsers();
        }
        public static void DeleteUser(string name)
        {
            DbConnector.Execute($"DELETE FROM Users WHERE (FirstName = '{name}') or (LastName = '{name}')");
            AllUsers();
        }
        public static void UpdateUser(string fname, string lname, int favnum, string dummy1, string dummy2, string dummy3, int userid)
        {
            DbConnector.Execute($"UPDATE Users SET FirstName = \'{fname}\', LastName = \'{lname}\', FavoriteNumber = \'{favnum}\', DummyData1 = \'{dummy1}\', DummyData2 = \'{dummy2}\', DummyData3 = \'{dummy3}\' WHERE id = \'{userid}\'");
            AllUsers();
        }

    }
}
