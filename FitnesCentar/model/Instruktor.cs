using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    [Serializable]
    public class Instruktor 
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

        //public Instruktor(Instruktor instr)
        //{
        //    this.RegistrovaniKorisnik = new RegistrovaniKorisnik();

        //    this.RegistrovaniKorisnik.email = instr.RegistrovaniKorisnik.email;

        //}




        public override string ToString()
        {
            return  _korisnik.Ime + " " + _korisnik.Prezime ;
        }

        public static List<Trening> ListaTreninga = new List<Trening>();
      

        public string InstruktorZaUpisUFajl()
        {
            return Korisnik.Email;
        }




       
    }
}
