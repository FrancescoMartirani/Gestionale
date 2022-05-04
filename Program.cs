using Gestionale;
using System.Data.SqlClient;

Handler handler = new Handler();
/* handler.InserisciUnaPersona(new DateTime(1970, 3, 15), "uomo", "luca", "rossi", "via x 13");
handler.InserisciUnoStudente(new DateTime(1997, 4, 12), "uomo", "riccardo", "viola", "via x 11",102932, new DateTime(2021, 9, 15));
handler.InserisciUnInsegnante(new DateTime(1980, 6, 19), "donna", "sara", "rossi", "via x 45", 540321, new DateTime(2008, 3, 16));
handler.InserisciUnoStudente(new DateTime(1997, 4, 12), "uomo", "andrea", "rossi", "via x 21", 332451, new DateTime(2021, 2, 12));
handler.InserisciUnaMateria("Matematica","Matematica",12,48); 
handler.InserisciUnEsame(new DateTime(2022, 5, 1), 540321, "Matematica");  

handler.InserisciDettagliEsame(102932, handler.GetIdEsameConDataENome(new DateTime(2022, 5, 1), "Matematica")); 
handler.InserisciUnoStudente(new DateTime(1997, 4, 12), "uomo", "andrea", "rossi", "via x 21", 332451, new DateTime(2021, 2, 12));
handler.InserisciDettagliEsame(332451, handler.GetIdEsameConDataENome(new DateTime(2022, 5, 1), "Matematica")); 

handler.InserisciUnaMateria("Fisica", "Fisica", 12, 48); 
handler.InserisciUnEsame(new DateTime(2022, 1, 10), 540321, "Fisica"); */

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