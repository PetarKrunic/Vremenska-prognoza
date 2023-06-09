using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    public  class Adresa
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string ulica;

        public string Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }

        private  string broj;

        public  string Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        private string grad;

        public string Grad
        {
            get { return grad; }
            set { grad = value; }
        }

        private string drzava;
        

        public string Drzava
        {
            get { return drzava; }
            set { drzava = value; }
        }

      

        public override string ToString()
        {
            return Ulica + "," + Broj + "," + Grad + "," + Drzava;
        }

        
    }
}
