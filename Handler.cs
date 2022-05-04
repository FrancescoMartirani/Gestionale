using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class Handler
    {

        private readonly string connectionString = "Server=ACADEMYNETPD01\\SQLEXPRESS;Database=Gestionale;Trusted_Connection=True;";

        public List<Persona> GetPersone()
        {
            var persister = new Persister(connectionString);
            var listPerson = persister.GetPeople();
            return listPerson;
        }

        public bool InserisciUnaPersona(DateTime birthday, string gender, string name, string surname, string address)
        {
            var person = new Persona
            {
                Birthday = birthday,
                Gender = gender,
                Name = name,
                Surname = surname,
                Address = address

            };

            var persister = new Persister(connectionString);
            return persister.AddPerson(person);

        }

        public bool InserisciUnoStudente(DateTime birthday, string gender, string name, string surname, string address, int matricola, DateTime dataiscrizione)
        {
            var person = new Persona
            {
                Birthday = birthday,
                Gender = gender,
                Name = name,
                Surname = surname,
                Address = address

            };



            var student = new Studente
            {
                Matricola = matricola,
                DataIscrizione = dataiscrizione,

            };

            var persister = new Persister(connectionString);
            return persister.AddPerson(person) && persister.AddStudent(student);

        }

        public bool InserisciUnInsegnante(DateTime birthday, string gender, string name, string surname, string address, int matricola, DateTime dataassunzione)
        {
            var person = new Persona
            {
                Birthday = birthday,
                Gender = gender,
                Name = name,
                Surname = surname,
                Address = address

            };



            var teacher = new Insegnante
            {
                Matricola = matricola,
                DataAssunzione = dataassunzione,

            };

            var persister = new Persister(connectionString);
            return persister.AddPerson(person) && persister.AddTeacher(teacher);

        }

    }
}
