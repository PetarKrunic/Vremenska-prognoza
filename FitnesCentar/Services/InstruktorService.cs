using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.Services
{
    public class InstruktorService : IInstruktorService
    {
        public  void CitajKorisnike()
        {
            Util.Instance.Instruktori = new ObservableCollection<Instruktor>();
            Util.Instance.Korisnici = new ObservableCollection<RegistrovaniKorisnik>();


            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
             
                command.CommandText = @"SELECT * from Korisnici ";
               

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] adress = reader.GetString(7).Split(',');

                    Util.Instance.Korisnici.Add(new RegistrovaniKorisnik
                    {
                        ID = reader.GetInt32(0),
                        Ime = reader.GetString(1),
                        Prezime = reader.GetString(2),
                        TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), reader.GetString(3)),
                        Email = reader.GetString(4),
                        Aktivan = reader.GetBoolean(5),
                        Lozinka = reader.GetString(8),
                        Pol = (EPol)Enum.Parse(typeof(EPol), reader.GetString(6)),
                        JMBG = reader.GetString(9),
                        Adresa = new Adresa(){ 
                            Ulica = adress[0],
                            Broj =adress[1],
                            Grad=adress[2],
                            Drzava=adress[3]
                        }
                 



                    }) ;
                }
                reader.Close();
            }
        }


       


        public int SacuvajKorisnike(Object obj)
        {
            Instruktor instruktor = obj as Instruktor;
           
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                SqlCommand command1 = conn.CreateCommand();
                command.CommandText = @"insert into dbo.Instruktori (Id)
                                  output inserted.id VALUES (@Id)";
                command.Parameters.Add(new SqlParameter("Id", instruktor.ID));
                return (int)command.ExecuteScalar();
            }

        }
    }
}
