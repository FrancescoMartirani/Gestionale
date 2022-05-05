using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class PersisterController
    {

        private readonly string ConnectionString;
        public PersisterController(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool ControlPerson(Persona person)
        {

            var controllo = @"SELECT COUNT(*) FROM [dbo].[Person] 
                            WHERE [Name] =@Name AND [Surname]=@Surname AND [BirthDay]=@BirthDay AND [Gender]=@Gender AND [Address]=@Address";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(controllo, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            var result = Convert.ToInt32(command.ExecuteScalar());
            return result > 0;

        }

    }
}
