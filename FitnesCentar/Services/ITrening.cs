using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.Services
{
   public interface ITrening
    {

        int SacuvajTrening(Object obj);

        void CitajTrening();

        void CitajTreningAdmin();

        void ObrisiTrening(int id);

        void rezervisiTrening(int id);
    }
}
