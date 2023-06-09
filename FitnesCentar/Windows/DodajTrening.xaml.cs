using SR41_2020_POP2021.model;
using SR41_2020_POP2021.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for DodajTrening.xaml
    /// </summary>
    /// 
   
    public partial class DodajTrening : Window
    {
        private EStatusTreniga odabraniStatus;
       
       

        ICollectionView view;
        ICollectionView view1;
        public DodajTrening(Trening trening, EStatusTreniga status = EStatusTreniga.SLOBODAN)
        {

          
         
            InitializeComponent();

            this.DataContext = trening;
            ComboTrening.ItemsSource = Enum.GetValues(typeof(EStatusTreniga)).Cast<EStatusTreniga>();

            
            dodajInstruktoreUListBox();
            updateViewTrening();
         
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

        public void updateViewTrening()
        {

            DGBrisanjeTreninga.ItemsSource = null;
            view1 = new CollectionViewSource { Source = Util.Instance.Treninzi }.View;
            DGBrisanjeTreninga.ItemsSource = view1;
            DGBrisanjeTreninga.IsSynchronizedWithCurrentItem = true;

            DGBrisanjeTreninga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view1.Filter = CustomFilterTrening;
        }

        private bool CustomFilterTrening(object obj)
        {
            Trening trening = obj as Trening;

            if (trening.Status.Equals(EStatusTreniga.SLOBODAN) && trening.Aktivan is true)
            {
                return true;
            }
            return false;

        }

        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik instruktor = obj as RegistrovaniKorisnik;
           
            if (instruktor.TipKorisnika.Equals(ETipKorisnika.INSTRUKTOR) && instruktor.Aktivan)
            {
                return true;
            }
            return false;

        }


        private void DGInstruktoriZaTrening_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }



        private void ZakaziTrening_Click(object sender, RoutedEventArgs e)
        {
           

            if (odabraniStatus.Equals(EStatusTreniga.SLOBODAN))
            {

                if (VremeTreninga.Text == "" || TrajanjeTreninga.Text == "" )
                
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


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
           
            var al = new AllInstructors();
            al.Show();
            this.Close();
        }

        private void DGBrisanjeTreninga_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void BrisanjeTreninga_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaBrisanje = (Trening)DGBrisanjeTreninga.SelectedItem;
        
            Util.Instance.ObrisiTrening(treningZaBrisanje.ID);
         
            int index = Util.Instance.Treninzi.ToList().FindIndex(trening => trening.ID.Equals(treningZaBrisanje.ID));
            Util.Instance.Treninzi[index].Aktivan = false;

            updateViewTrening();
            view1.Refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mv =new  MainWindow();
            mv.Show();
            this.Close();
        }
    }
}


