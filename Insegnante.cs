using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionale
{
    public class Insegnante : Persona
    {

        public int IdTeacher { get; set; }
        public int IdPerson { get; set; }
        public int Matricola { get; set; }
        public DateTime DataAssunzione { get; set; }

    }
}
