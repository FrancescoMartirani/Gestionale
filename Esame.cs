using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionale
{
    public class Esame
    {

        public int IdEsame { get; set; }
        public int IdInsegnante { get; set; }
        public DateTime Data { get; set; }
        public int IdMateria { get; set; }

    }
}
