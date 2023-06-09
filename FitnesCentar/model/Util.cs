using SR41_2020_POP2021.Izuzeci;
using SR41_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR41_2020_POP2021.model
{
    public sealed class Util
    {

        public static string CONNECTION_STRING = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static readonly Util instance = new Util();
        private IUserService userService;
        private IInstruktorService instruktorService;
        private ITrening treningService;




        private Util()
        {
            userService = new UserService();
            instruktorService = new InstruktorService();
            treningService = new TreningService();

            initialize();
        }

        static Util() { }

        public static Util Instance
        {
            get
            {
                return instance;
            }
        }


        public ObservableCollection<RegistrovaniKorisnik> Korisnici { get; set; }
        public ObservableCollection<Instruktor> Instruktori { get; set; }
        public ObservableCollection<Polaznik> Polaznici { get; set; }
        public ObservableCollection<Trening> Treninzi { get; set; }

        public string emailPrijavljen = "";
        static string[] adress = @"SELECT Adresa from Korisnici where Email = emailPrijavljen".Split(',');



        /*public RegistrovaniKorisnik trenutniRegKor = new RegistrovaniKorisnik
        {

            ID = int.Parse(@"SELECT ID from Korisnici where Email = emailPrijavljen"),
            Ime = @"SELECT Ime from Korisnici where Email = emailPrijavljen",
            Prezime = @"SELECT Prezime from Korisnici where Email = emailPrijavljen",
            Email = @"SELECT Email from Korisnici where Email = emailPrijavljen",
            Lozinka = @"SELECT Lozinka from Korisnici where Email = emailPrijavljen",
            JMBG = @"SELECT JMBG from Korisnici where Email = emailPrijavljen",
            TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), @"SELECT TipKorisnika from Korisnici where Email = emailPrijavljen"),
            Pol = (EPol)Enum.Parse(typeof(EPol), @"SELECT Pol from Korisnici where Email = emailPrijavljen"),
            Adresa = new Adresa
            {
                Ulica = adress[0],
                Broj = adress[1],
                Grad = adress[2],
                Drzava = adress[3]
            }

        };*/

        public RegistrovaniKorisnik CitajTrenutnogKorisnika()
        {
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();

                RegistrovaniKorisnik trenutniRegKor = new RegistrovaniKorisnik
                {

                    ID = int.Parse(@"SELECT ID from Korisnici where Email = emailPrijavljen"),
                    Ime = @"SELECT Ime from Korisnici where Email = emailPrijavljen",
                    Prezime = @"SELECT Prezime from Korisnici where Email = emailPrijavljen",
                    Email = @"SELECT Email from Korisnici where Email = emailPrijavljen",
                    Lozinka = @"SELECT Lozinka from Korisnici where Email = emailPrijavljen",
                    JMBG = @"SELECT JMBG from Korisnici where Email = emailPrijavljen",
                    TipKorisnika = (ETipKorisnika)Enum.Parse(typeof(ETipKorisnika), @"SELECT TipKorisnika from Korisnici where Email = emailPrijavljen"),
                    Pol = (EPol)Enum.Parse(typeof(EPol), @"SELECT Pol from Korisnici where Email = emailPrijavljen"),
                    Adresa = new Adresa
                    {
                        Ulica = adress[0],
                        Broj = adress[1],
                        Grad = adress[2],
                        Drzava = adress[3]
                    }

                };

                return trenutniRegKor;
            }
        }
                
            
        


        public void initialize()
        {
            Korisnici = new ObservableCollection<RegistrovaniKorisnik>();
            Instruktori = new ObservableCollection<Instruktor>();
            Polaznici = new ObservableCollection<Polaznik>();
            Treninzi = new ObservableCollection<Trening>();
           
        }
        public void DeleteUser(string email)
        {

            userService.DeleteUser(email);
        }

        public void ObrisiTrening(int id)
        {

            treningService.ObrisiTrening(id);
        }

        public int SacuvajEntitete(Object obj)
        {

            if (obj is RegistrovaniKorisnik)
            {
                return userService.SacuvajKorisnike(obj);
            }
            else if (obj is Instruktor)
            {
                return instruktorService.SacuvajKorisnike(obj);
            }
            else if (obj is Trening)
            {
                return treningService.SacuvajTrening(obj);
            }

            return -1;
        }

        

        

        public void CitanjeEntitete(string filename)
        {

            if (filename.Contains("korisnici"))
            {
                userService.CitajKorisnike();
            }
            else if (filename.Contains("instruktori"))
            {
                instruktorService.CitajKorisnike();
            }
            else if (filename.Contains("ali"))
            {
                treningService.CitajTrening();
            }
            else if (filename.Contains("trening2"))
            {
                treningService.CitajTreningAdmin();
            }
        }

        




    }
}
