using System;

namespace DBConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            //Null connection String to test null values and timespan functionality
            // String connect = null;

            // OracleConnection OC = new OracleConnection(connect);
            // OC.OpenConnection();
            // OC.CloseConnection();
            String sqlString = "SQL Connection";
            SqlConnection sqlConnect = new SqlConnection(sqlString);
            DBCommand newCommand = new DBCommand(sqlConnect);
            newCommand.checkIfConnOpen();

            // sqlConnect.OpenConnection();
            // sqlConnect.CloseConnection();
        }
    }
}
