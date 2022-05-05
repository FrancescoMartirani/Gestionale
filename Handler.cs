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
            var persister = new PersisterGetter(connectionString);
            var listPerson = persister.GetPeople();
            return listPerson;
        }

        public String GetNomeStudenteConMatricola(string matricola)
        {
            var persister = new PersisterGetter(connectionString);
            var result = persister.GetStudentsNameByMatricola(matricola);
            return result;
        }

        public String GetNomeInsegnanteConMatricola(string matricola)
        {
            var persister = new PersisterGetter(connectionString);
            var result = persister.GetTeachersNameByMatricola(matricola);
            return result;
        }

        public int GetIdEsameConDataENome(DateTime data, string nomemateria)
        {
            var persister = new PersisterGetter(connectionString);
            var result = persister.GetIdExamByDateAndName(data, nomemateria);
            return result;
        }

        public bool InserisciUnaPersona(Persona persona)
        {

            var persister = new PersisterAdder(connectionString);
            return persister.AddPerson(persona);

        }

        public void CancellaUnaPersona(Persona persona)
        {

            var persister = new PersisterDelete(connectionString);
            persister.DeletePerson(persona);

        }

        public bool InserisciUnoStudente(Studente studente)
        {
            

            var persister = new PersisterAdder(connectionString);
            return persister.AddStudent(studente);

        }

        public void CancellaUnoStudente(Studente studente)
        {


            var persister = new PersisterDelete(connectionString);
             persister.DeleteStudent(studente);

        }

        public bool InserisciUnInsegnante(Insegnante insegnante)
        {

            var persister = new PersisterAdder(connectionString);
            return persister.AddTeacher(insegnante);

        }

        public bool InserisciUnaMateria(Materia materia)
        {
            

            var persister = new PersisterAdder(connectionString);
            return persister.AddSubject(materia);

        }

        public bool InserisciUnEsame(Esame esame, Insegnante insegnante, Materia materia)
        {

            var persisterGetter = new PersisterGetter(connectionString);
            var persisterAdder = new PersisterAdder(connectionString);
            var idinsegnante = persisterGetter.GetIdTeachersByMatricola(insegnante.Matricola);
            var idmateria = persisterGetter.GetIdSubjectsBySubjectsName(materia.NomeMateria);

            var esamedainserire = new Esame
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria,
                Data = esame.Data

            };

            
            return persisterAdder.AddExam(esamedainserire);

        }

        public bool InserisciDettagliEsame(Studente studente, int idesame)
        {

            var persisteradder = new PersisterAdder(connectionString);
            var persistergetter = new PersisterGetter(connectionString);
            var idstudente= persistergetter.GetIdStudentByMatricola(studente.Matricola);

            var esamedettaglio = new EsameDettaglio
            {

                IdStudente = idstudente,
                IdEsame = idesame

            };


            return persisteradder.AddExamDetails(esamedettaglio);

        }

        public bool InserisciUnaLezione(Insegnante insegnante, Materia materia)
        {

            var persisteradder = new PersisterAdder(connectionString);
            var persistergetter = new PersisterGetter(connectionString);
            var idinsegnante = persistergetter.GetIdTeachersByMatricola(insegnante.Matricola);
            var idmateria = persistergetter.GetIdSubjectsBySubjectsName(materia.NomeMateria);

            var lezione = new Lezione
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria

            };


            return persisteradder.AddLesson(lezione);

        }

        public bool InserisciUnaClasse(Insegnante insegnante, Materia materia)
        {

            var persisteradder = new PersisterAdder(connectionString);
            var persistergetter = new PersisterGetter(connectionString);
            var idinsegnante = persistergetter.GetIdTeachersByMatricola(insegnante.Matricola);
            var idmateria = persistergetter.GetIdSubjectsBySubjectsName(materia.NomeMateria);

            var lezione = new Lezione
            {

                IdInsegnante = idinsegnante,
                IdMateria = idmateria

            };


            return persisteradder.AddLesson(lezione);

        }

        public bool AggiungiVoto(string matricolastudente, int voto)
        {

            var persister = new PersisterAdder(connectionString);


            return persister.AddVoto(matricolastudente, voto);

        }
    }
}
