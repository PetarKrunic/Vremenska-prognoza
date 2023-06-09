using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    [Serializable]
    public class Polaznik
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private RegistrovaniKorisnik _korisnik;

        public RegistrovaniKorisnik Korisnik
        {
            get { return _korisnik; }
            set { _korisnik = value; }
        }

        public static List<Trening> zakazanTrening = new List<Trening>();

        public void dodajTrening(Trening t)
        {
            zakazanTrening.Add(t);
        }
        public override string ToString()
        {
            return Korisnik.Ime + " " + Korisnik.Prezime ;
        }


        public string PolaznikZaUpisUFajl()
        {
           // return Korisnik.Ime + ";" + Korisnik.Prezime + ";" + Korisnik.Email + ";" + Korisnik.Lozinka + ";" + Korisnik.JMBG + ";" + Korisnik.Adresa.ToString() + ";" + Korisnik.Pol + ";" + Korisnik.TipKorisnika + ";" + Korisnik.Aktivan;
            return Korisnik.Email;
        }
    }
}
