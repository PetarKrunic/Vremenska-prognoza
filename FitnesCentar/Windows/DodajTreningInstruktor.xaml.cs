using SR41_2020_POP2021.model;
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
    /// Interaction logic for DodajTreningInstruktor.xaml
    /// </summary>
    public partial class DodajTreningInstruktor : Window
    {
     
        ICollectionView view;
        public DodajTreningInstruktor()
        {
            InitializeComponent();
            dodajInstruktoreUListBox();

           
            ComboTrening.ItemsSource = Enum.GetValues(typeof(EStatusTreniga)).Cast<EStatusTreniga>();
        }

        public void dodajInstruktoreUListBox()
        {

            DGInstruktoriZaTrening.ItemsSource = null;
          
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGInstruktoriZaTrening.ItemsSource = view;
            DGInstruktoriZaTrening.IsSynchronizedWithCurrentItem = true;

            DGInstruktoriZaTrening.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilter;
        }

        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;

            if (korisnik.Email.Equals(Util.Instance.emailPrijavljen))
            {
                return true;
            }
            return false;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (VremeTreninga.Text == "" || TrajanjeTreninga.Text == "")

            {
                MessageBox.Show("Niste uneli sve podatke!");
                return;
            }
            if (!VremeTreninga.Text.Contains(":"))
            {
                MessageBox.Show("Morate uneti validano vreme!");
                return;
            }

            RegistrovaniKorisnik selectedInstruktor = view.CurrentItem as RegistrovaniKorisnik;
                Instruktor instruktor = new Instruktor
                {


                    Korisnik = selectedInstruktor

                };
                RegistrovaniKorisnik Rniko = new RegistrovaniKorisnik
                {
                    JMBG = "N/N"
                };
                Polaznik niko = new Polaznik
                {
                    Korisnik = Rniko
                };

                Trening trening = new Trening(DatumTreninga.SelectedDate.Value.Date, VremeTreninga.Text, TrajanjeTreninga.Text, instruktor, niko, true);
                Util.Instance.Treninzi.Add(trening);
                Util.Instance.SacuvajEntitete(trening);
                MessageBox.Show("Uspesno ste dodali trening");

                VremeTreninga.Clear();
                TrajanjeTreninga.Clear();

            
        }

        private void DGInstruktoriZaTrening_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
        private void OtkaziTrening_Click(object sender, RoutedEventArgs e)
        {
            var ip = new InstruktorProzor();
            ip.Show();
            this.Close();
        }
    }
}
