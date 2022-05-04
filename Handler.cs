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

        public String GetNomeStudenteConMatricola(int matricola)
        {
            var persister = new Persister(connectionString);
            var result = persister.GetStudentsNameByMatricola(matricola);
            return result;
        }

        public String GetNomeInsegnanteConMatricola(int matricola)
        {
            var persister = new Persister(connectionString);
            var result = persister.GetTeachersNameByMatricola(matricola);
            return result;
        }

        public int GetIdEsameConDataENome(DateTime data, string nomemateria)
        {
            var persister = new Persister(connectionString);
            var result = persister.GetIdExamByDateAndName(data, nomemateria);
            return result;
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

        public bool InserisciUnaMateria(string nomemateria, string descrizione, int crediti, int ore)
        {
            var materia = new Materia
            {
                NomeMateria = nomemateria,
                Descrizione = descrizione,
                Crediti = crediti,
                Ore = ore

            };

            var persister = new Persister(connectionString);
            return persister.AddSubject(materia);

        }

        public bool InserisciUnEsame(DateTime giornoesame, int matricolainsegnante, string nomemateria)
        {

            var persister = new Persister(connectionString);
            var idinsegnante = persister.GetIdTeachersByMatricola(matricolainsegnante);
            var idmateria = persister.GetIdSubjectsBySubjectsName(nomemateria);

            var esame = new Esame
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria,
                Data = giornoesame

            };

            
            return persister.AddExam(esame);

        }

        public bool InserisciDettagliEsame(int matricolastudente, int idesame)
        {

            var persister = new Persister(connectionString);
            var idstudente= persister.GetIdStudentByMatricola(matricolastudente);

            var esamedettaglio = new EsameDettaglio
            {

                IdStudente = idstudente,
                IdEsame = idesame

            };


            return persister.AddExamDetails(esamedettaglio);

        }

        public bool AggiungiVoto(int matricolastudente, int voto)
        {

            var persister = new Persister(connectionString);


            return persister.AddVoto(matricolastudente, voto);

        }
    }
}
