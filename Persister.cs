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

        public String GetStudentsNameByMatricola(int matricola)
        {

            var sql = @"
                    SELECT [Name]
                          ,[Surname]
                      FROM [dbo].[Person]
                        JOIN [dbo].[Student] ON [dbo].[Student].IdPerson = [dbo].[Person].Id
                    WHERE [Matricola] = "+matricola;

            var result = new String("");
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {


                result = reader["Name"].ToString() + reader["Surname"].ToString();

            }

            return result;

        }

        public string GetTeachersNameByMatricola(int matricola)
        {

            var sql = @"
                    SELECT [Name]
                          ,[Surname]
                      FROM [dbo].[Person]
                        JOIN [dbo].[Teacher] ON [dbo].[Teacher].IdPerson = [dbo].[Person].Id
                    WHERE [Matricola] = " + matricola;

            var result = new String("");
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {

                result = reader["Name"].ToString() + reader["Surname"].ToString();

            }

            return result;

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

        public bool AddPerson(Persona person)
        {
            var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name]
                                   ,[Surname]
                                   ,[BirthDay]
                                   ,[Gender]
                                   ,[Address])
                             VALUES
                                   (@Name
                                   ,@Surname
                                   ,@BirthDay
                                   ,@Gender
                                   ,@Address)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            return command.ExecuteNonQuery() > 0;
        }

        public bool AddStudent(Studente studente)
        {

            var sql = @"
                        INSERT INTO [dbo].[Student]
                                   ([Matricola]
                                    ,[IdPerson]
                                   ,[DataIscrizione])
                             VALUES
                                   (@Matricola
                                   ,@IdPerson
                                   ,@DataIscrizione)";

            var sql2 = @"
                    SELECT MAX([Id])
                      FROM [dbo].[Person]";

            

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            using var command2 = new SqlCommand(sql2, connection);
            var idperson = Convert.ToInt32(command2.ExecuteScalar());

            command.Parameters.AddWithValue("@Matricola", studente.Matricola);
            command.Parameters.AddWithValue("@IdPerson", idperson);
            command.Parameters.AddWithValue("@DataIscrizione", studente.DataIscrizione);
            return command.ExecuteNonQuery() > 0;
        }

        public int GetIdTeachersByMatricola(int matricola)
        {

            var sql = @"
                    SELECT [IdTeacher]
                      FROM [dbo].[Teacher]
                       WHERE [Matricola] ="+matricola;

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var idteacher = Convert.ToInt32(command.ExecuteScalar());

            return idteacher;
        }

        public int GetIdStudentByMatricola(int matricola)
        {

            var sql = @"
                    SELECT [IdStudente]
                      FROM [dbo].[Student]
                       WHERE [Matricola] =" + matricola;

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var idstudent = Convert.ToInt32(command.ExecuteScalar());

            return idstudent;
        }

        public int GetIdExamByDateAndName(DateTime dataesame, string nomemateriaesame)
        {

            var sql = @"
                    SELECT [IdExam]
                      FROM [dbo].[Exam]
                       JOIN [Subject] ON [Subject].[IdSubject] = [Exam].[IdSubject]
                       WHERE [Exam].[Date] ='" + dataesame + "'AND [Subject].[Name]='"+nomemateriaesame+"'";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var idesame = Convert.ToInt32(command.ExecuteScalar());

            return idesame;
        }

        public int GetIdSubjectsBySubjectsName(string nomemateria)
        {

            var sql = @"
                    SELECT [IdSubject]
                      FROM [dbo].[Subject]
                       WHERE [Name] ='"+nomemateria+"'";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var idsubject = Convert.ToInt32(command.ExecuteScalar());

            return idsubject;
        }

        public bool AddTeacher(Insegnante insegnante)
        {

            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([Matricola]
                                    ,[IdPerson]
                                   ,[DataAssunzione])
                             VALUES
                                   (@Matricola
                                   ,@IdPerson
                                   ,@DataAssunzione)";

            var sql2 = @"
                    SELECT MAX([Id])
                      FROM [dbo].[Person]";



            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            using var command2 = new SqlCommand(sql2, connection);
            var idperson = Convert.ToInt32(command2.ExecuteScalar());

            command.Parameters.AddWithValue("@Matricola", insegnante.Matricola);
            command.Parameters.AddWithValue("@IdPerson", idperson);
            command.Parameters.AddWithValue("@DataAssunzione", insegnante.DataAssunzione);
            return command.ExecuteNonQuery() > 0;
        }

        public bool AddSubject(Materia materia)
        {

            var sql = @"
                        INSERT INTO [dbo].[Subject]
                                   ([Name]
                                    ,[Description]
                                   ,[Credits]
                                    ,[Hours])
                             VALUES
                                   (@NomeMateria
                                   ,@Descrizione
                                   ,@Crediti
                                    ,@Ore)";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@NomeMateria", materia.NomeMateria);
            command.Parameters.AddWithValue("@Descrizione", materia.Descrizione);
            command.Parameters.AddWithValue("@Crediti", materia.Crediti);
            command.Parameters.AddWithValue("@Ore", materia.Ore);

            return command.ExecuteNonQuery() > 0;
        }

        public bool AddExam(Esame esame)
        {

            var sql = @"
                        INSERT INTO [dbo].[Exam]
                                   ([Date]
                                    ,[IdTeacher]
                                   ,[IdSubject])
                             VALUES
                                   (@Data
                                   ,@IdInsegnante
                                   ,@IdMateria)";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Data", esame.Data);
            command.Parameters.AddWithValue("@IdInsegnante", esame.IdInsegnante);
            command.Parameters.AddWithValue("@IdMateria", esame.IdMateria);

            return command.ExecuteNonQuery() > 0;
        }


        public bool AddExamDetails(EsameDettaglio esamedettaglio)
        {

            var sql = @"
                        INSERT INTO [dbo].[ExamDetail]
                                   ([IdStudent]
                                   ,[IdExam])
                             VALUES
                                   (@IdStudent
                                   ,@IdExam)";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            
            command.Parameters.AddWithValue("@IdStudent", esamedettaglio.IdStudente);
            command.Parameters.AddWithValue("@IdExam", esamedettaglio.IdEsame);

            return command.ExecuteNonQuery() > 0;
        }

        public bool AddVoto(int matricola, int voto)
        {

            var sql = @"
                            UPDATE [dbo].[ExamDetail]
                             SET [Voto] = @Voto
                            WHERE [ExamDetail].[IdStudent] =" + this.GetIdStudentByMatricola(matricola);
                            ;

            var sql2 = @"SELECT [ExamDetail].[Voto]
                        FROM [dbo].[ExamDetail]
                        JOIN [Student] ON [Student].[IdStudente] = [ExamDetail].[IdStudent]
                        JOIN [Exam] ON [Exam].[IdExam] = [ExamDetail].[IdExam]
                        WHERE [ExamDetail].[IdStudent] = 10 AND [ExamDetail].[Voto] IS NULL AND [Exam].[Date] <= CURRENT_TIMESTAMP";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            using var command2 = new SqlCommand(sql2, connection);
            var result = 0;

            if (command2.ExecuteNonQuery() > 0)
            {

                command.Parameters.AddWithValue("@Voto", voto);
                result = command.ExecuteNonQuery();

            }

            return result>0;
        }

        public bool AddLesson (Lezione lezione)
        {

            var sql = @"
                        INSERT INTO [dbo].[Lesson]
                                   ([IdSubject]
                                   ,[IdTeacher])
                             VALUES
                                   (@IdSubject
                                   ,@IdTeacher)";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@IdSubject", lezione.IdMateria);
            command.Parameters.AddWithValue("@IdTeacher", lezione.IdInsegnante);

            return command.ExecuteNonQuery() > 0;
        }
    }
}
