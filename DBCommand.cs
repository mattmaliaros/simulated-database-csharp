using System;
using System.Threading.Tasks;
namespace DBConnection
{
    public class DBCommand : SqlConnection
    {
        public String DBInstruction { get; set; }
        public Boolean isOpen { get; set; }
        //First time is a boolean to test if it's the "First Time" checking the connection: If it is the first time the Console will not write the "Else" Statement below
        public Boolean firstTime { get; set; }
        //DBCommand needs a DBConnection Object and a Connection String in order to execute methods
        public DBCommand(DBConnection db) : base(db.ConnectionString)
        {
            firstTime = true;
            checkIfConnOpen();

        }
        //Also uses an Execute Method but mainly shows whether a connection is opened or not
        public void checkIfConnOpen()
        {
            //Task Runner will stop the program and exit after the program has been running for 2 minutes
            Task c = Task.Run(() =>
            {
                if (isOpen)
                {
                    Console.WriteLine("Connection: {0} is currently open", ConnectionString);
                }
                else if (firstTime == true)
                {
                    firstTime = false;
                }
                else
                {
                    Console.WriteLine("Connection not opened.  Cannot close or run commands");
                }


                Console.WriteLine("What would you like to do?");
                DBInstruction = Console.ReadLine();
                Execute();
            });
            TimeSpan tSpan = TimeSpan.FromMinutes(2);
            //2 Minutes
            if (!c.Wait(tSpan))
            {
                Console.WriteLine("The timeout interval elapsed.");
                Environment.Exit(0);
            }
        }
        public void Execute()
        {
            switch (DBInstruction.ToUpper())
            {
                case "OPEN":
                    if (isOpen)
                    {
                        Console.WriteLine("Connection already opened");
                        Console.WriteLine("Would you like to close the current connection?");
                        String answer = Console.ReadLine();
                        if (answer.ToUpper() == "YES" || answer.ToUpper() == "Y")
                        {
                            CloseConnection();
                        }
                        else
                        {
                            checkIfConnOpen();
                        }
                        break;
                    }
                    OpenConnection();
                    isOpen = true;
                    break;
                case "CLOSE":
                    if (!isOpen)
                    {

                        checkIfConnOpen();

                    }
                    else
                    {
                        CloseConnection();
                        isOpen = false;

                    }
                    break;
                case "RUN":
                    if (!isOpen)
                    {
                        checkIfConnOpen();

                    }
                    else
                    {
                        Console.WriteLine("Running instruction: Succeeded");
                        Console.WriteLine("Would you like to close the connection?");
                        String answer = Console.ReadLine();
                        if (answer.ToUpper() == "YES" || answer.ToUpper() == "Y")
                        {
                            CloseConnection();
                        }
                        else
                        {
                            checkIfConnOpen();
                        }
                    }
                    break;
                default:
                    do
                    {
                        Console.WriteLine("Invalid: Re-Enter Instruction");
                        DBInstruction = Console.ReadLine();
                    } while (DBInstruction == default);
                    Execute();
                    break;
            }
        }

    }


}


