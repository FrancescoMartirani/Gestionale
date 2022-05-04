using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Gestionale
{
    public class Persona
    {

         public int Id { get; set; }
         public string Name { get; set; }
         public string Surname { get; set; }
         public string Gender { get; set; }
         public DateTime Birthday { get; set; }
         public string Address { get; set; }

    }
}
