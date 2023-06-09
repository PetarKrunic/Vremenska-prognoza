using SR41_2020_POP2021.Izuzeci;
using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SR41_2020_POP2021.Services
{
    public class TreningService : ITrening
    {
        public void CitajTrening()
        {
            Util.Instance.Treninzi = new ObservableCollection<Trening>();


            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"SELECT t.*, k.Email
                    FROM Trening AS t
                    JOIN Korisnici AS k
                    on t.Instruktor like concat('%',k.ime,'%') and t.Instruktor like concat('%',k.prezime,'%')";


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] imeInst = reader.GetString(5).Split(' ');
                    RegistrovaniKorisnik polaznikInstruktor = new RegistrovaniKorisnik
                    {
                        Ime = imeInst[0],
                        Prezime = imeInst[1],
                        Email = reader.GetString(8)
                    };

                    Util.Instance.Treninzi.Add(new Trening
                    {
                        ID = reader.GetInt32(0),
                        Datum = reader.GetDateTime(1),
                        VremeTreninga = reader.GetString(2),
                        TrajanjeTreninga = reader.GetInt32(3),
                        Status = (EStatusTreniga)Enum.Parse(typeof(EStatusTreniga), reader.GetString(4)),
                        instruktorZakazanTrening = new Instruktor
                        {
                            Korisnik = polaznikInstruktor
                        },
                        polaznikZakazanTrening = new Polaznik
                        {

                            Korisnik = new RegistrovaniKorisnik
                            {
                                JMBG = reader.GetString(6)
                            }



                        },
                        Aktivan = reader.GetBoolean(7)




                    });
                }
                reader.Close();
            }
        }

        public void CitajTreningAdmin()
        {
            Util.Instance.Treninzi = new ObservableCollection<Trening>();


            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();

                command.CommandText = @"SELECT * From Trening";


                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string[] imeInst = reader.GetString(5).Split(' ');
                    RegistrovaniKorisnik polaznikInstruktor = new RegistrovaniKorisnik
                    {
                        Ime = imeInst[0],
                        Prezime = imeInst[1],
                       // Email = reader.GetString(8)
                    };

                    Util.Instance.Treninzi.Add(new Trening
                    {
                        ID = reader.GetInt32(0),
                        Datum = reader.GetDateTime(1),
                        VremeTreninga = reader.GetString(2),
                        TrajanjeTreninga = reader.GetInt32(3),
                        Status = (EStatusTreniga)Enum.Parse(typeof(EStatusTreniga), reader.GetString(4)),
                        instruktorZakazanTrening = new Instruktor
                        {
                            Korisnik = polaznikInstruktor
                        },
                        polaznikZakazanTrening = new Polaznik
                        {

                            Korisnik = new RegistrovaniKorisnik
                            {
                                JMBG = reader.GetString(6)
                            }



                        },
                        Aktivan = reader.GetBoolean(7)




                    });
                }
                reader.Close();
            }
        }




        public void ObrisiTrening(int id)
        {
            Trening trening = Util.Instance.Treninzi.ToList().Find(tr => tr.ID.Equals(id));
            if(trening == null)
            {
                throw new UserNotFoundException($"Ne postoji trening sa datim id!");
            }
            trening.Aktivan = false;

            updateTrening(trening);
        }

        public void rezervisiTrening(int id)
        {
            Trening trening = Util.Instance.Treninzi.ToList().Find(tr => tr.ID.Equals(id));
            if (trening.Status.Equals(EStatusTreniga.REZERVISAN))
            {
                throw new UserNotFoundException($"Trening je zauzet!");
            }
            trening.Status = EStatusTreniga.SLOBODAN;
            updateRezervacija(trening);
           // throw new NotImplementedException();
        }

        public void updateRezervacija(object obj)
        {
            Trening trening = obj as Trening;

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update SET Status=@Status where ID=@ID" ;

                command.Parameters.Add(new SqlParameter("Status",trening.Status));
                command.Parameters.Add(new SqlParameter("ID", trening.ID));
                command.ExecuteNonQuery();
            }
        }
      
        public void updateTrening(object obj)
        {
            Trening trening = obj as Trening;

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Trening SET Aktivan=@Aktivan where ID=@ID";

                command.Parameters.Add(new SqlParameter("Aktivan", trening.Aktivan));

                command.Parameters.Add(new SqlParameter("ID", trening.ID));

                command.ExecuteNonQuery();

            }
        }

        public int SacuvajTrening(Object obj)
        {
            {
                Trening trening = obj as Trening;

                using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"insert into dbo.Trening (DatumTreninga, VremeTreninga,TrajanjeTreninga,Instruktor,Polaznik, StatusTreninga,Aktivan)
                                        output inserted.id VALUES (@DatumTreninga, @VremePocetkaTreninga, @TrajanjeTreninga, @Instruktor, @Polaznik, @StatusTreninga, @Aktivan)";
                    //,Instruktor,Polaznik
                    command.Parameters.Add(new SqlParameter("DatumTreninga", trening.Datum));
                    command.Parameters.Add(new SqlParameter("VremePocetkaTreninga", trening.VremeTreninga.ToString()));
                    command.Parameters.Add(new SqlParameter("TrajanjeTreninga", trening.TrajanjeTreninga));
                    command.Parameters.Add(new SqlParameter("StatusTreninga", trening.Status.ToString()));
                    command.Parameters.Add(new SqlParameter("Instruktor",trening.instruktorZakazanTrening.ToString()));
                    command.Parameters.Add(new SqlParameter("Aktivan", trening.Aktivan));
                    command.Parameters.Add(new SqlParameter("Polaznik", trening.polaznikZakazanTrening.ToString()));
                    return (int)command.ExecuteScalar();
                    
                }
            }

        }

        
    }
}
