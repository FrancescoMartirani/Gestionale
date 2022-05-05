using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class PersisterAdder
    {

        private readonly string ConnectionString;
        public PersisterAdder(string connectionString)
        {
            ConnectionString = connectionString;
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
            var persisterController = new PersisterController(ConnectionString);
            connection.Open();
            var result = 0;

            if (!persisterController.ControlPerson(person))
            {

                using var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Surname", person.Surname);
                command.Parameters.AddWithValue("@BirthDay", person.Birthday);
                command.Parameters.AddWithValue("@Gender", person.Gender);
                command.Parameters.AddWithValue("@Address", person.Address);
                result = command.ExecuteNonQuery();

            }

            return result > 0;
        }


        public bool AddStudent(Studente studente)
        {

            var controllo = @"SELECT COUNT(*) FROM [dbo].[Student] WHERE [Matricola] =@Matricola";

            var sqlStudent = @"
                        INSERT INTO [dbo].[Student]
                                   ([Matricola]
                                    ,[IdPerson]
                                   ,[DataIscrizione])
                             VALUES
                                   (@Matricola
                                   ,@IdPerson
                                   ,@DataIscrizione)";



            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var persisterController = new PersisterController(ConnectionString);
            using var control = new SqlCommand(controllo, connection);
            control.Parameters.AddWithValue("@Matricola", studente.Matricola);
            var result = 0;

            if (Convert.ToInt32(control.ExecuteScalar()) > 0)
            {

                return false;

            }

            if (!persisterController.ControlPerson(studente))
            {
                AddPerson(studente);

            }

            var persisterGetter = new PersisterGetter(ConnectionString);
            var idperson = persisterGetter.GetIdPerson(studente);


            using var commandStudent = new SqlCommand(sqlStudent, connection);


            commandStudent.Parameters.AddWithValue("@Matricola", studente.Matricola);
            commandStudent.Parameters.AddWithValue("@IdPerson", idperson);
            commandStudent.Parameters.AddWithValue("@DataIscrizione", studente.DataIscrizione);

            return commandStudent.ExecuteNonQuery() > 0;
        }

       

        public bool AddTeacher(Insegnante insegnante)
        {
            var controllo = @"SELECT COUNT(*) FROM [dbo].[Student] WHERE [Matricola] =@Matricola";

            var sql = @"
                        INSERT INTO [dbo].[Teacher]
                                   ([Matricola]
                                    ,[IdPerson]
                                   ,[DataAssunzione])
                             VALUES
                                   (@Matricola
                                   ,@IdPerson
                                   ,@DataAssunzione)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var persisterController = new PersisterController(ConnectionString);
            using var control = new SqlCommand(controllo, connection);
            control.Parameters.AddWithValue("@Matricola", insegnante.Matricola);   

            if (Convert.ToInt32(control.ExecuteScalar()) > 0)
            {

                return false;

            }

            if (!persisterController.ControlPerson(insegnante))
            {
                AddPerson(insegnante);

            }

            var persisterGetter = new PersisterGetter(ConnectionString);
            var idperson = persisterGetter.GetIdPerson(insegnante);

            using var command = new SqlCommand(sql, connection);
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
                        INSERT INTO [dbo].[ExamDetails]
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

        public bool AddVoto(string matricola, int voto)
        {

            var sql = @"
                            UPDATE [dbo].[ExamDetails]
                             SET [Voto] = @Voto
                            WHERE [ExamDetails].[IdStudent] =@IdStudent";
            ;

            var sql2 = @"SELECT [ExamDetails].[Voto]
                        FROM [dbo].[ExamDetails]
                        JOIN [Student] ON [Student].[IdStudente] = [ExamDetails].[IdStudent]
                        JOIN [Exam] ON [Exam].[IdExam] = [ExamDetails].[IdExam]
                        WHERE [ExamDetails].[IdStudent] = 10 AND [ExamDetails].[Voto] IS NULL AND [Exam].[Date] <= CURRENT_TIMESTAMP";


            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            PersisterGetter persisterGetter = new PersisterGetter(ConnectionString);
            command.Parameters.AddWithValue("@IdStudent", persisterGetter.GetIdStudentByMatricola(matricola));
            using var command2 = new SqlCommand(sql2, connection);
            var result = 0;

            if (command2.ExecuteNonQuery() > 0)
            {

                command.Parameters.AddWithValue("@Voto", voto);
                result = command.ExecuteNonQuery();

            }

            return result > 0;
        }

        public bool AddLesson(Lezione lezione)
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
