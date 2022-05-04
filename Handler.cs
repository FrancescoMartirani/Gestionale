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

        public bool InserisciUnaPersona(DateTime birthday, string gender, string name, string surname)
        {
            var person = new Persona
            {
                Birthday = birthday,
                Gender = gender,
                Name = name,
                Surname = surname
            };

            var persister = new Persister(connectionString);
            return persister.Add(person);
        }

    }
}
