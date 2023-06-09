using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEditUsers.xaml
    /// </summary>
    public partial class AddEditUsers : Window
    {

        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniPolaznik;

        public AddEditUsers(RegistrovaniKorisnik polaznik, EStatus status = EStatus.DODAJ)
        {
            InitializeComponent();

            ComboTipPolaznika.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            ComboPolaznika.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();

            odabraniPolaznik = polaznik;
            odabraniStatus = status;

            this.DataContext = polaznik;

            if (status.Equals(EStatus.IZMENI) && polaznik != null)
            {
                this.Title = "Izmeni polaznika";

                txtLozinkaPolaznika.IsEnabled = false;
                ComboTipPolaznika.IsEnabled = false;
                txtJmbgPolaznika.IsEnabled = false;
                txtEmailPolaznika.IsEnabled = false;
            }
            else
            {
                this.Title = "Dodaj polaznika";
                ComboTipPolaznika.IsEnabled = false;
            }
        }

        private void btnCancelKorisnici_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOkKorisinici_Click(object sender, RoutedEventArgs e)
        {
            if (odabraniStatus.Equals(EStatus.DODAJ))
            {

                //Adresa editAdresa = new Adresa
                //{

                //    Ulica = txtUlicaPolaznika.Text.TrimEnd(),
                //    Broj = txtBrojPolaznika.Text.TrimEnd(),
                //    Grad = txtGradPolaznika.Text.TrimEnd(),
                //    Drzava = txtDrzavaPolaznika.Text.TrimEnd()

                //};


                //odabraniPolaznik.Aktivan = true;
                //odabraniPolaznik.Adresa = editAdresa;


                Polaznik polaznik = new Polaznik
                {


                    Korisnik = odabraniPolaznik

                };

                Util.Instance.Korisnici.Add(odabraniPolaznik);
                Util.Instance.Polaznici.Add(polaznik);

                //int id = Util.Instance.SacuvajEntitete(odabraniPolaznik);
                //polaznik.ID = id;
                //Util.Instance.SacuvajEntitete(polaznik);
            }
          
            this.DialogResult = true;
            this.Close();
        }
    }
}
