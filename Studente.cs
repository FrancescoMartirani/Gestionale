using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gestionale
{
    public class Studente
    {

        public int IdStudent;
        public int IdPerson;
        public int Matricola;
        public DateTime DataIscrizione;

        public Studente(int idstudent, int idperson, int matricola, DateTime dataiscrizione)
        {

            IdStudent = idstudent;
            IdPerson = idperson;
            Matricola = matricola;
            DataIscrizione = dataiscrizione;

        }

    }
}
