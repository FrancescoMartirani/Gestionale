using Gestionale;
using System.Data.SqlClient;

Handler handler = new Handler();
handler.InserisciUnaPersona(new DateTime(1970,3, 15) , "uomo", "luca", "rossi");