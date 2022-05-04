using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class Persister
    {

        private readonly string ConnectionString;
        public Persister(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List <Persona> GetPeople()
        {

            var id = 0;
            var name = "";
            var surname = "";
            var gender = "";
            DateTime birthday = DateTime.Now;
            var address = "";

            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Persons]";

            var listResult = new List<Persona>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = Convert.ToInt32(reader["Id"]);
                name = reader["Name"].ToString();
                surname = reader["Surname"].ToString();
                gender = reader["Gender"].ToString();
                birthday = Convert.ToDateTime(reader["Birthday"]);
                address = reader["Address"].ToString();

                Persona person = new Persona(id, name, surname,gender,birthday,address);

                listResult.Add(person);
            }

            return listResult;
        }

    }
}
