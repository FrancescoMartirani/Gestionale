using Gestionale;
using System.Data.SqlClient;

Handler handler = new Handler();

Persona persona = new Persona { Name = "Luca", Surname = "Rossi", Gender= "uomo", Birthday = new DateTime(1970, 3, 15), Address = "via x 13" };
Studente studente = new Studente { Name = "Riccardo", Surname = "Viola", Gender = "uomo", Birthday = new DateTime(1997, 4, 12), Address = "via x 11", DataIscrizione = new DateTime(2021, 9, 15), Matricola = 102932};
Studente studente2 = new Studente { Name = "Andrea", Surname = "Rossi", Gender = "uomo", Birthday = new DateTime(1997, 5, 9), Address = "via x 21", DataIscrizione = new DateTime(2021, 2, 12), Matricola = 332451};
Insegnante insegnante = new Insegnante { Name = "Sara", Surname = "Rossi", Gender = "donna", Birthday = new DateTime(1980, 6, 19), Address = "via x 45", DataAssunzione= new DateTime(2008, 3, 16), Matricola = 540321};
Materia materia = new Materia { NomeMateria = "Matematica", Descrizione = "Matematica", Crediti = 12, Ore = 48 };
Materia materia2 = new Materia { NomeMateria ="Fisica", Descrizione = "Fisica", Crediti = 12, Ore=48};
Esame esame = new Esame {Data = new DateTime(2022, 5, 1)};
Esame esame2 = new Esame {Data = new DateTime(2022, 1, 10)};

/* handler.InserisciUnaPersona(persona); 
handler.InserisciUnoStudente(studente); 
handler.InserisciUnoStudente(studente2); 
handler.InserisciUnInsegnante(insegnante); 
 handler.InserisciUnaMateria(materia); 
handler.InserisciUnEsame(esame, insegnante, materia); 

handler.InserisciUnaMateria(materia2);
handler.InserisciUnEsame(esame2, insegnante, materia2); 


handler.InserisciDettagliEsame(studente, handler.GetIdEsameConDataENome(esame.Data, materia.NomeMateria)); 
handler.InserisciDettagliEsame(studente2, handler.GetIdEsameConDataENome(esame2.Data, materia2.NomeMateria)); 

handler.InserisciUnaLezione(insegnante, materia); */

String nomestudente = handler.GetNomeStudenteConMatricola(studente.Matricola);
String nomeinsegnante= handler.GetNomeInsegnanteConMatricola(insegnante.Matricola);
List<Persona> nomipersone = handler.GetPersone(); 

Console.WriteLine(nomeinsegnante);
Console.WriteLine(nomestudente);

for (int i = 0; i < nomipersone.Count; i++)
{

    var nomecognome = nomipersone[i].Name + nomipersone[i].Surname;

    Console.WriteLine(nomecognome);

} 