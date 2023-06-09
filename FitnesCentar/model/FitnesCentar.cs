using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    public class FitnesCentar
    {
        private string sifra;

        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        private string nazivCentra;

        public string NazivCentra
        {
            get { return nazivCentra; }
            set { nazivCentra = value; }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }


        public override string ToString()
        {
            return "Naziv i adresa fitnes centra je i sifra je: " + NazivCentra + " " + Adresa + " " + Sifra;
        }

    }
}
