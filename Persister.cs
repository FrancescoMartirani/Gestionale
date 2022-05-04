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

        public List<Studente> GetStudents()
        {

            var sql = @"
                    SELECT [IdStudente]
                          ,[IdPerson]
                          ,[Matricola]
                          ,[DataIscrizione]
                      FROM [dbo].[Student]";

            var listResult = new List<Studente>();

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {


                Studente student = new Studente
                {

       

                };

                listResult.Add(student);
            }

            return listResult;
        }

        public bool Add(Persona person)
        {
            var sql = @"
                        INSERT INTO [dbo].[Person]
                                   ([Name]
                                   ,[Surname]
                                   ,[BirthDay]
                                   ,[Gender])
                             VALUES
                                   (@Name
                                   ,@Surname
                                   ,@BirthDay
                                   ,@Gender)";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Name", person.Name);
            command.Parameters.AddWithValue("@Surname", person.Surname);
            command.Parameters.AddWithValue("@BirthDay", person.Birthday);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            return command.ExecuteNonQuery() > 0;
        }

    }
}
