using Gestionale;
using System.Data.SqlClient;

Handler handler = new Handler();
/* handler.InserisciUnaPersona(new DateTime(1970, 3, 15), "uomo", "luca", "rossi", "via x 13");
handler.InserisciUnoStudente(new DateTime(1997, 4, 12), "uomo", "riccardo", "viola", "via x 11",102932, new DateTime(2021, 9, 15));
handler.InserisciUnInsegnante(new DateTime(1980, 6, 19), "donna", "sara", "rossi", "via x 45", 540321, new DateTime(2008, 3, 16));
 */

handler.InserisciUnaMateria("Matematica","Matematica",12,48);

String nomestudente = handler.GetNomeStudenteConMatricola(102932);
String nomeinsegnante= handler.GetNomeInsegnanteConMatricola(540321);
List<Persona> nomipersone = handler.GetPersone();

Console.WriteLine(nomeinsegnante);
Console.WriteLine(nomestudente);

for (int i = 0; i < nomipersone.Count; i++)
{

    var nomecognome = nomipersone[i].Name + nomipersone[i].Surname;

    Console.WriteLine(nomecognome);

}