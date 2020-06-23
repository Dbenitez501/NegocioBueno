﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    class ConnectionToMySql
    {
        private readonly string connectionString;

        public ConnectionToMySql()
        {
            //connectionString = "Server=(LocalDB)\\LocalDBDemo;DataBase=negocio; integrated security = true";
            connectionString = "Server=localhost; DataBase=negocio; User=root; port=3306; password=;";
        }

        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}