using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace TestDB
{
    internal class DataBase
    {
        MySqlConnection sqlConnection = new MySqlConnection("server=127.0.0.1;user id=root;password=1234;database=mydb");

        public void openConnection()
        {
            if(sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }    
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return sqlConnection;
        }

    }
}
