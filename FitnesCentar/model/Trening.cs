using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SR41_2020_POP2021.model
{
    [Serializable]
    public class Trening
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _datum;

        public DateTime Datum
        {
            get { return _datum; }
            set { _datum = value; }
        }

        private string _vremeTreninga;

        public string VremeTreninga
        {
            get { return _vremeTreninga; }
            set { _vremeTreninga = value; }
        }

        private int _trajanjeTreninga;

        public int TrajanjeTreninga
        {
            get { return _trajanjeTreninga; }
            set { _trajanjeTreninga = value; }
        }



        private EStatusTreniga  eStatusTreniga;

        public EStatusTreniga Status
        {
            get { return eStatusTreniga; }
            set { eStatusTreniga = value; }
        }

        private Instruktor _instrukotorZakazanTrening;

        public Instruktor instruktorZakazanTrening
        {
            get { return _instrukotorZakazanTrening; }
            set { _instrukotorZakazanTrening = value; }
        }

        private bool _aktivan;
        public bool Aktivan
        {
            get { return _aktivan; }
            set { _aktivan = value; }
        }

        private Polaznik _polaznikZakazanTrening;

        public Trening(DateTime date, string vreme, string trajanje, Instruktor selectedInstruktor, Polaznik selectedPolaznik, bool tAktivan)
        {
            _datum = date;
            _vremeTreninga = vreme;
            _trajanjeTreninga = int.Parse(trajanje);
            _instrukotorZakazanTrening = selectedInstruktor;
            polaznikZakazanTrening = selectedPolaznik;
            _aktivan = tAktivan;
        }

        public Trening() { }

        public Polaznik polaznikZakazanTrening
        {
            get { return _polaznikZakazanTrening; }
            set { _polaznikZakazanTrening = value; }
        }



       

        
        public string treningZaUspisUFajl()
        {
            return ID + " " + Datum.Date.ToLongDateString() + " " + VremeTreninga
                + " " + TrajanjeTreninga.ToString() + " " + eStatusTreniga.ToString()
                + " " + instruktorZakazanTrening.Korisnik.Ime + " " + instruktorZakazanTrening.Korisnik.Prezime + " " + instruktorZakazanTrening.Korisnik.JMBG
                + " " + polaznikZakazanTrening.Korisnik.Ime + " " + polaznikZakazanTrening.Korisnik.Prezime + " " + polaznikZakazanTrening.Korisnik.JMBG;
        }       
  

    }
}
