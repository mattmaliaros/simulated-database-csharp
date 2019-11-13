using System;
namespace DBConnection
{
    public class OracleConnection : DBConnection
    {
        public OracleConnection(String cString) : base(cString)
        {
        }
        public override void OpenConnection()
        {
            Console.WriteLine("Opened Connection: " + ConnectionString);
        }
        public override void CloseConnection()
        {
            Console.WriteLine("Closed Connection: " + ConnectionString);
        }
    }
}