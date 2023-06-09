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

namespace SR41_2020_POP2021.Services
{
    public class UserService : IUserService
    {
        public void CitajKorisnike()
        {
                 
        }

        public void DeleteUser(string email)
        {
            RegistrovaniKorisnik registrovaniKorisnik =Util.Instance.Korisnici.ToList().Find(korisnik => korisnik.Email.Equals(email));
            if (registrovaniKorisnik == null)
            {
                throw new UserNotFoundException($"Ne postoji korisnik sa emailom: {email}");
            }
            registrovaniKorisnik.Aktivan = false;

            updateUSer(registrovaniKorisnik);
           // Util.Instance.SacuvajEntitete("korisnici.txt");
        }

        public int SacuvajKorisnike(Object obj)
        {
            {
                RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;

                using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"insert into dbo.Korisnici (Ime, Prezime,TipKorisnika, Email,Aktivan,Lozinka,Pol,JMBG,Adresa)
                                        output inserted.id VALUES (@Ime, @Prezime, @Type, @Email, @Aktivan,@Lozinka,@Pol,@JMBG,@Adresa)";
                    command.Parameters.Add(new SqlParameter("Ime", korisnik.Ime));
                    command.Parameters.Add(new SqlParameter("Prezime", korisnik.Prezime));
                    command.Parameters.Add(new SqlParameter("Type", korisnik.TipKorisnika.ToString()));
                    command.Parameters.Add(new SqlParameter("Email", korisnik.Email));
                    command.Parameters.Add(new SqlParameter("Aktivan", korisnik.Aktivan));
                    command.Parameters.Add(new SqlParameter("Lozinka", korisnik.Lozinka));
                    command.Parameters.Add(new SqlParameter("Pol", korisnik.Pol.ToString()));
                    command.Parameters.Add(new SqlParameter("JMBG", korisnik.JMBG));
                    command.Parameters.Add(new SqlParameter("Adresa", korisnik.Adresa.ToString()));
                    return (int)command.ExecuteScalar();
                }
            }

        }

        public void updateUSer(object obj)
        {
            RegistrovaniKorisnik registrovaniKorisnik = obj as RegistrovaniKorisnik;

            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Korisnici SET Aktivan=@Aktivan where Email=@Email";

                command.Parameters.Add(new SqlParameter("Aktivan", registrovaniKorisnik.Aktivan));

                command.Parameters.Add(new SqlParameter("Email", registrovaniKorisnik.Email));

                command.ExecuteNonQuery();

            }
        }

        
    }
}
