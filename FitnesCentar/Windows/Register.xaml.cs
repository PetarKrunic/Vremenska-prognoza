using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SR41_2020_POP2021.Windows
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
       
        public Register()
        {


          //  Util.Instance.CitanjeEntitete("polaznici.txt");

            InitializeComponent();



            Pol.Items.Add(EPol.MUSKI);
            Pol.Items.Add(EPol.ZENSKI);
            Pol.Items.Add(EPol.DRUGO);


        }

        private void register_Click(object sender,EventArgs e)
        {

            if (Ime.Text == "" || Prezime.Text == "" || Jmbg.Text == "" || Email.Text == ""
                || Ulica.Text == "" || Broj.Text == "" || Grad.Text == "" || Drzava.Text == ""
                || Pol.SelectedIndex == -1 || Lozinka.Password.ToString() == "" || PLozinka.Password.ToString() == "")
            {
                MessageBox.Show("Niste uneli sve podatke!");
                return;
            }

            if (!Email.ToString().Contains("@") && !Email.ToString().EndsWith(".com"))
            {
                MessageBox.Show("Morate uneti validan email!");
            }

            else if (Lozinka.Password.ToString() != PLozinka.Password.ToString())
            {
                MessageBox.Show("Niste uneli iste lozinke!");
                return;
            }

            else if (ValidacijaRegistracijePolaznika(Email.Text.Trim()) is false)
            {
                MessageBox.Show("Korisnicko ime je zauzeto!");
                Email.Focus();
                return;
            }

            else
            {
                Adresa adresa = new Adresa();
                adresa.Ulica = Ulica.Text.TrimEnd();
                adresa.Broj = Broj.Text.TrimEnd();
                adresa.Grad = Grad.Text.TrimEnd();
                adresa.Drzava = Drzava.Text.TrimEnd();


                RegistrovaniKorisnik korisnik = new RegistrovaniKorisnik
                {
                    Email = Email.Text.Trim(),
                    Ime = Ime.Text.Trim(),
                    Prezime = Prezime.Text.Trim(),
                    Adresa = adresa,
                    JMBG = Jmbg.Text.Trim(),
                    Lozinka = Lozinka.Password.ToString(),
                    Pol = (EPol)Pol.SelectedItem,
                    TipKorisnika = ETipKorisnika.POLAZNIK,
                    Aktivan = true
                };

                Polaznik polaznik = new Polaznik
                {
                    Korisnik = korisnik
                };

                Util.Instance.Korisnici.Add(korisnik);

                // Util.Instance.SacuvajEntitete("polaznici.txt");
                // Util.Instance.SacuvajEntitete("korisnici.txt");
                Util.Instance.SacuvajEntitete(korisnik);

                MessageBox.Show("Uspesna registracija");
                this.Close();
            }
        }
        public bool ValidacijaRegistracijePolaznika(string vEmail)
        {
            using (StreamReader file = new StreamReader(@"../../Resources/korisnici.txt"))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] korisnikIzFajla = line.Split(';');
                    string proveraImena = korisnikIzFajla[2];

                    if (vEmail == proveraImena)
                    {
                        return false;
                    }
                }
            }

            return true;

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }
    }

    
}
