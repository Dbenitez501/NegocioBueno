using MySql.Data.MySqlClient;
using Comun.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class UserData : ConnectionToMySql
    {
        string estado_emp;

        public string Login(string id, string pass)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using(var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM empleados WHERE (id_emp=@id and cont_emp=@pass)";
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;

                    MySqlDataReader row = command.ExecuteReader();

                    if (row.HasRows)
                    {
                        while (row.Read())
                        {
                            UserCache.IdEmp = row.GetInt32(0);
                            UserCache.NomEmp = row.GetString(1);
                            UserCache.AppEmp = row.GetString(2);
                            UserCache.ApmEmp = row.GetString(3);
                            UserCache.TelEmp = row.GetString(4);
                            UserCache.EstadoEmp = row.GetInt16(5);
                            UserCache.ContEmp = row.GetString(6);

                            estado_emp = Convert.ToString(UserCache.EstadoEmp);
                        }
                        return estado_emp;
                    }
                    else
                    {
                        return estado_emp;
                    }
                }
            }
        }
    }
}
