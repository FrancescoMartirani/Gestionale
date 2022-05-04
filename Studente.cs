using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Gestionale
{
    public class Studente : Persona
    {

        public int IdStudent { get; set; }
        public int Matricola { get; set; }
        public DateTime DataIscrizione { get; set; }

    }
}
