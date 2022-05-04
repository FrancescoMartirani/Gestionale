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

            var sql = @"
                    SELECT [Id]
                          ,[Name]
                          ,[Surname]
                          ,[BirthDay]
                          ,[Gender]
                          ,[Address]
                      FROM [dbo].[Person]";

            var listResult = new List<Persona>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var person = new Persona
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Surname = reader["Surname"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    Address = reader["Address"].ToString()

                };

                listResult.Add(person);
            }

            return listResult;
        }

    }
}
