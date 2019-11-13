using System;
using System.Threading.Tasks;
namespace DBConnection
{
    public abstract class DBConnection
    {
        public String ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }
        public DBConnection(String cString)
        {
            ConnectionString = cString;
            // If the user doesn't enter a string in the time span, the program will exit 
            Task t = Task.Run(() =>
            {
                if (ConnectionString == "" || ConnectionString == null)
                {
                    do
                    {
                        Console.WriteLine("Invalid Connection String... Try again");
                        ConnectionString = Console.ReadLine();
                    }
                    while (ConnectionString == "" || ConnectionString == null);

                }
            });
            TimeSpan tSpan = TimeSpan.FromMilliseconds(5000);
            if (!t.Wait(tSpan))
            {
                Console.WriteLine("The timeout interval elapsed.");
                Environment.Exit(0);
            }
        }
        public abstract void OpenConnection();

        public abstract void CloseConnection();
    }
}