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
   // public class PolazniciService : IPolazniciService
   // {
    //    public void CitajKorisnike()
    //    {
    //        Util.Instance.Polaznici = new ObservableCollection<Polaznik>();
    //        Util.Instance.Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
    //        using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
    //        {
    //            conn.Open();
    //            SqlCommand command = conn.CreateCommand();
    //            command.CommandText = @"select * from Korisnici where TipKorisnika = 'POLAZNIK'";

    //            SqlDataReader reader = command.ExecuteReader();
    //            while (reader.Read())
    //            {
    //                Util.Instance.Korisnici.Add(new RegistrovaniKorisnik

    //                {
    //                    ID = reader.GetInt32(0),
    //                    Ime = reader.GetString(1),
    //                    Prezime = reader.GetString(2),
    //                    TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), reader.GetString(3)),
    //                    Email = reader.GetString(4),
    //                    Aktivan = reader.GetBoolean(5),
    //                    Lozinka = reader.GetString(6),
    //                    Pol = (EPol)Enum.Parse(typeof(EPol), reader.GetString(7)),
    //                    JMBG = reader.GetString(8),
    //                });
    //            }
    //            reader.Close();
    //        }
    //    }

    //    public int SacuvajKorisnike(Object obj)
    //    {
    //        Polaznik polaznik = obj as Polaznik;
    //        using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
    //        {
    //            conn.Open();
    //            SqlCommand command = conn.CreateCommand();
    //            command.CommandText = @"insert into dbo.Polaznici (Id)
    //                               output.INSERTED.id VALUES (@Id)";
    //            command.Parameters.Add(new SqlParameter("Id", polaznik.ID));

    //            return (int)command.ExecuteScalar();
    //        }

    //    }
    //}
}
