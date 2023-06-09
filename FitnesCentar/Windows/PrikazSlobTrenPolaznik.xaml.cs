using SR41_2020_POP2021.model;
using SR41_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PrikazSlobTrenPolaznik.xaml
    /// </summary>
    public partial class PrikazSlobTrenPolaznik : Window
    {
       
        private EStatusTreniga odabraniStatus;

        private ICollectionView view;
        public RegistrovaniKorisnik odabraniInstruktor;

        public PrikazSlobTrenPolaznik(RegistrovaniKorisnik inst)
        {
            InitializeComponent();

            this.DataContext = inst;
            this.odabraniInstruktor = inst;

            updateView();
        }

        private void updateView()
        {
            PrikazSlobTreninga.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Treninzi);
            PrikazSlobTreninga.ItemsSource = view;
            PrikazSlobTreninga.IsSynchronizedWithCurrentItem = true;

            PrikazSlobTreninga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {

            Trening trening = obj as Trening;
            if (trening.Aktivan && trening.instruktorZakazanTrening.Korisnik.Email.Equals(odabraniInstruktor.Email.ToString()))
            {
                return true;
            }
            return false;

        }

        private void PrikazSlobTreninga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RezervisiTrening_Click(object sender, RoutedEventArgs e)
        {
            if (odabraniStatus.Equals(EStatusTreniga.SLOBODAN))
            {
                Trening selectedTrening = view.CurrentItem as Trening;



                RegistrovaniKorisnik Rniko = new RegistrovaniKorisnik
                {
                  //  Email = 
                };
                Polaznik niko = new Polaznik
                {
                    Korisnik = Rniko
                };

                Trening trening = new Trening()
                {
                    Status = EStatusTreniga.REZERVISAN,
                    Aktivan = true,
                    polaznikZakazanTrening = niko

                };
                //RegistrovaniKorisnik Rniko = new RegistrovaniKorisnik
                //{
                //    JMBG = "N/N"
                //};
                //Polaznik niko = new Polaznik
                //{
                //    Korisnik = Rniko
                //};
             //   Trening trening = new Trening(DatumTreninga.SelectedDate.Value.Date, VremeTreninga.Text, TrajanjeTreninga.Text, instruktor, niko, true);
                Util.Instance.Treninzi.Add(trening);
            //    TreningService.rezervisiTrening();
                MessageBox.Show("Uspesno ste rezervisali trening");
            }
        }
    }
}
