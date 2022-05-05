using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class PersisterDelete
    {

        private readonly string ConnectionString;
        public PersisterDelete(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void DeleteStudent(Studente studente)
        {

            var sql = @"DELETE FROM [dbo].[Student] WHERE [Matricola]=@Matricola";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Matricola", studente.Matricola);
            command.ExecuteNonQuery();

        }


        public void DeletePerson(Persona person)
        {

            var sql = @"DELETE FROM [dbo].[Person] 
                            WHERE [Name] =@Name AND [Surname]=@Surname AND [BirthDay]=@BirthDay AND [Gender]=@Gender AND [Address]=@Address";
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.ExecuteNonQuery();

        }

    }
}
