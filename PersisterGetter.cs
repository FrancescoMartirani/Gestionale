using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class PersisterGetter
    {
        private readonly string ConnectionString;
        public PersisterGetter(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string GetStudentsNameByMatricola(string matricola)
        {
            var sql = @"
                    SELECT [Name]
                          ,[Surname]
                      FROM [dbo].[Person]
                        JOIN [dbo].[Student] ON [dbo].[Student].IdPerson = [dbo].[Person].Id
                    WHERE [Matricola] = @matricola ";

            var result = new String("");
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@matricola", matricola);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {


                result = $"{reader["Name"]} {reader["Surname"].ToString()}";

            }

            return result;

        }

        public string GetTeachersNameByMatricola(string matricola)
        {

            var sql = @"
                    SELECT [Name]
                          ,[Surname]
                      FROM [dbo].[Person]
                        JOIN [dbo].[Teacher] ON [dbo].[Teacher].IdPerson = [dbo].[Person].Id
                    WHERE [Matricola] = @matricola";

            var result = string.Empty;
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@matricola", matricola);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {

                result = $"{reader["Name"]} {reader["Surname"].ToString()}";

            }

            return result;

        }

        public int GetIdPerson(Persona persona)
        {

            var sql = @"
                    SELECT [Id]
                      FROM [dbo].[Person]
                    WHERE [Name] = @Name AND [Surname]=@Surname AND [Gender] = @Gender AND [BirthDay]=@BirthDay AND [Address]=@Address";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", persona.Name);
            command.Parameters.AddWithValue("@Surname", persona.Surname);
            command.Parameters.AddWithValue("@Gender", persona.Gender);
            command.Parameters.AddWithValue("@BirthDay", persona.Birthday);
            command.Parameters.AddWithValue("@Address", persona.Address);
            return Convert.ToInt32(command.ExecuteScalar());

        }
        public List<Persona> GetPeople()
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


                Persona person = new Persona
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


        public int GetIdTeachersByMatricola(string matricola)
        {

            var sql = @"
                    SELECT [IdTeacher]
                      FROM [dbo].[Teacher]
                       WHERE [Matricola] =@Matricola";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Matricola", matricola);
            var idteacher = Convert.ToInt32(command.ExecuteScalar());

            return idteacher;
        }

        public int GetIdStudentByMatricola(string matricola)
        {

            var sql = @"
                    SELECT [IdStudente]
                      FROM [dbo].[Student]
                       WHERE [Matricola] =@Matricola";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Matricola", matricola);
            var idstudent = Convert.ToInt32(command.ExecuteScalar());

            return idstudent;
        }

        public int GetIdExamByDateAndName(DateTime dataesame, string nomemateriaesame)
        {

            var sql = @"
                    SELECT [IdExam]
                      FROM [dbo].[Exam]
                       JOIN [Subject] ON [Subject].[IdSubject] = [Exam].[IdSubject]
                       WHERE [Exam].[Date] =@Date AND [Subject].[Name]=@SubjectName";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Date", dataesame);
            command.Parameters.AddWithValue("@SubjectName", nomemateriaesame);
            var idesame = Convert.ToInt32(command.ExecuteScalar());

            return idesame;
        }

        public int GetIdSubjectsBySubjectsName(string nomemateria)
        {

            var sql = @"
                    SELECT [IdSubject]
                      FROM [dbo].[Subject]
                       WHERE [Name] =@NomeMateria";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@NomeMateria", nomemateria);
            var idsubject = Convert.ToInt32(command.ExecuteScalar());

            return idsubject;
        }

    }
}
