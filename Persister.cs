﻿using System;
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

    }
}
