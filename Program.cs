using System;
using System.Data.SQLite;

namespace SQLcountries
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCountries();
        }
        private static void ReadCountries()
        {
            Database databaseObj = new Database();
            string query = "select Country.countryname, Capital.capitalname from Capital Join Country on Capital.countryId = Country.rowid";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObj.myConnection);
            databaseObj.OpenConnection();

            SQLiteDataReader data = myCommand.ExecuteReader();

            if (data.HasRows)
            {
                while (data.Read())
                {
                    Console.WriteLine($"Country: {data["Country"]}. Capital: {data["Capital"]}");
                }
            }
            databaseObj.CloseConnection();
        }
    }
}