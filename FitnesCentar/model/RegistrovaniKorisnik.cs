using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    
    public class RegistrovaniKorisnik :IDataErrorInfo
    {

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        private string _ime;

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        private string _prezime;

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        private string _jmbg;

        public string JMBG
        {
            get { return _jmbg; }
            set { _jmbg = value; }
        }

        private EPol ePol;

        public EPol Pol
        {
            get { return ePol; }
            set { ePol = value; }
        }

        private Adresa adresa;
        public Adresa Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

     
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _lozinka;

        public string Lozinka
        {
            get { return _lozinka; }
            set { _lozinka = value; }
        }

        private ETipKorisnika _tipKorisnika;

        public ETipKorisnika TipKorisnika
        {
            get { return _tipKorisnika; }
            set { _tipKorisnika = value; }
        }

        private bool _aktivan;
     //   internal RegistrovaniKorisnik Korisnik;

        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        public string Error 
        {
            get 
            {
                return "Poruka";
            }
        }

        public string this[string columnName] 
        {
            get 
            {
                switch (columnName) 
                {
                    case "Ime":
                        if (string.IsNullOrEmpty(Ime)) 
                        {
                            return "Polje mora biti popunjeno!";
                        }
                        break;

                    case "Prezime":
                        if (string.IsNullOrEmpty(Prezime))
                        {
                            return "Polje mora biti popunjeno!";
                        }
                        break;

                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                        {
                             return "Polje mora biti popunjeno!";
                        }
                        break;
                    case "Lozinka":
                        if (string.IsNullOrEmpty(Lozinka))
                        {
                             return "Polje mora biti popunjeno!";
                        }
                        break;
                    
                }
                return String.Empty;
            }
        }

        public override string ToString()
        {
            return Ime + " " + Prezime + " " + JMBG + "" + Pol + "" + Email + TipKorisnika;
        }

        public string KorisnikZaUpisUFajl()
        {
            return Ime + ";" + Prezime + ";" + Email + ";" + Lozinka + ";" + JMBG +";"+ Adresa.ToString() +  ";" + Pol + ";" + TipKorisnika + ";" + Aktivan;
            
        }

        public RegistrovaniKorisnik Clone()
        {
            RegistrovaniKorisnik kopija = new RegistrovaniKorisnik();

            kopija.Ime = Ime;
            kopija.Prezime = Prezime;
            kopija.Aktivan = Aktivan;
            kopija.Adresa = Adresa;
            kopija.Adresa.Ulica = Adresa.Ulica;
            kopija.Adresa.Broj = Adresa.Broj;
            kopija.Adresa.Grad = Adresa.Grad;
            kopija.Adresa.Drzava = Adresa.Drzava;
            kopija.Email = Email;
            kopija.Pol = Pol;
            kopija.Lozinka = Lozinka;
            kopija.JMBG = JMBG;
            kopija.TipKorisnika = TipKorisnika;

            return kopija;
        }

        public RegistrovaniKorisnik ClonePolaznik()
        {
            RegistrovaniKorisnik kopijaPolaznik = new RegistrovaniKorisnik();

            kopijaPolaznik.Ime = Ime;
            kopijaPolaznik.Prezime = Prezime;
            kopijaPolaznik.Aktivan = Aktivan;
            kopijaPolaznik.Adresa = Adresa;
            kopijaPolaznik.Adresa.Ulica = Adresa.Ulica;
            kopijaPolaznik.Adresa.Broj = Adresa.Broj;
            kopijaPolaznik.Adresa.Grad = Adresa.Grad;
            kopijaPolaznik.Adresa.Drzava = Adresa.Drzava;
            kopijaPolaznik.Email = Email;
            kopijaPolaznik.Pol = Pol;
            kopijaPolaznik.Lozinka = Lozinka;
            kopijaPolaznik.JMBG = JMBG;
            kopijaPolaznik.TipKorisnika = TipKorisnika;

            return kopijaPolaznik;
        }

        public RegistrovaniKorisnik CloneInstruktor()
        {
            RegistrovaniKorisnik kopijaInstruktor = new RegistrovaniKorisnik();

            kopijaInstruktor.Ime = Ime;
            kopijaInstruktor.Prezime = Prezime;
            kopijaInstruktor.Aktivan = Aktivan;
            kopijaInstruktor.Adresa = Adresa;
            kopijaInstruktor.Adresa.Ulica = Adresa.Ulica;
            kopijaInstruktor.Adresa.Broj = Adresa.Broj;
            kopijaInstruktor.Adresa.Grad = Adresa.Grad;
            kopijaInstruktor.Adresa.Drzava = Adresa.Drzava;
            kopijaInstruktor.Email = Email;
            kopijaInstruktor.Pol = Pol;
            kopijaInstruktor.Lozinka = Lozinka;
            kopijaInstruktor.JMBG = JMBG;
            kopijaInstruktor.TipKorisnika = TipKorisnika;

            return kopijaInstruktor;
        }
    }
}
