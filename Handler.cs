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

        public bool InserisciUnaPersona(Persona persona)
        {

            var persister = new Persister(connectionString);
            return persister.AddPerson(persona);

        }

        public bool InserisciUnoStudente(Studente studente)
        {
            

            var persister = new Persister(connectionString);
            return persister.AddPerson(studente) && persister.AddStudent(studente);

        }

        public bool InserisciUnInsegnante(Insegnante insegnante)
        {

            var persister = new Persister(connectionString);
            return persister.AddPerson(insegnante) && persister.AddTeacher(insegnante);

        }

        public bool InserisciUnaMateria(Materia materia)
        {
            

            var persister = new Persister(connectionString);
            return persister.AddSubject(materia);

        }

        public bool InserisciUnEsame(Esame esame, Insegnante insegnante, Materia materia)
        {

            var persister = new Persister(connectionString);
            var idinsegnante = persister.GetIdTeachersByMatricola(insegnante.Matricola);
            var idmateria = persister.GetIdSubjectsBySubjectsName(materia.NomeMateria);

            var esamedainserire = new Esame
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria,
                Data = esame.Data

            };

            
            return persister.AddExam(esamedainserire);

        }

        public bool InserisciDettagliEsame(Studente studente, int idesame)
        {

            var persister = new Persister(connectionString);
            var idstudente= persister.GetIdStudentByMatricola(studente.Matricola);

            var esamedettaglio = new EsameDettaglio
            {

                IdStudente = idstudente,
                IdEsame = idesame

            };


            return persister.AddExamDetails(esamedettaglio);

        }

        public bool InserisciUnaLezione(Insegnante insegnante, Materia materia)
        {

            var persister = new Persister(connectionString);
            var idinsegnante = persister.GetIdTeachersByMatricola(insegnante.Matricola);
            var idmateria = persister.GetIdSubjectsBySubjectsName(materia.NomeMateria);

            var lezione = new Lezione
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria

            };


            return persister.AddLesson(lezione);

        }

        public bool AggiungiVoto(int matricolastudente, int voto)
        {

            var persister = new Persister(connectionString);


            return persister.AddVoto(matricolastudente, voto);

        }
    }
}
