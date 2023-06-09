using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    /// Interaction logic for registrovaniKorisnikProzor.xaml
    /// </summary>
    public partial class registrovaniKorisnikProzor : Window
    {

        private ICollectionView view;
        private ICollectionView view1;
       
        public registrovaniKorisnikProzor()
        {
            InitializeComponent();
     
            updateView();
            updateViewInstruktori();

            

        }

        public bool IsOpened()
        {
            if (Application.Current.MainWindow.IsActive)
            {
                return true;
            }

            else { return false; }
        }
        private void updateView()
        {
            DGRegKorisnik.ItemsSource = null;
            view =new  CollectionViewSource{ Source = Util.Instance.Korisnici}.View;
            DGRegKorisnik.ItemsSource = view;
            DGRegKorisnik.IsSynchronizedWithCurrentItem = true;
            DGRegKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        
            view.Filter = CustomFilter;
            view.Refresh();
        }

        private void updateViewInstruktori()
        {
            DGTreninzi.ItemsSource = null;
            view1 = new CollectionViewSource { Source = Util.Instance.Korisnici }.View;
            DGTreninzi.ItemsSource = view1;
            DGTreninzi.IsSynchronizedWithCurrentItem = true;
            DGTreninzi.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            view1.Filter = CustomFilterInstruktori;
            view1.Refresh();
        }

        private bool CustomFilterInstruktori(Object obj)
        {
            RegistrovaniKorisnik instruktor = obj as RegistrovaniKorisnik;
            if (instruktor.TipKorisnika.Equals(ETipKorisnika.INSTRUKTOR) && instruktor.Aktivan)
            {
                return true;
            }
            return false;
        }

        private bool CustomFilter(Object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;
            if (korisnik.Email.Equals(Util.Instance.emailPrijavljen))
            {
                return true;
            }
            return false;
        }
        private void DGTreninzi_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void dodajTrening_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedInstruktor = view1.CurrentItem as RegistrovaniKorisnik;
            PrikazSlobTrenPolaznik prikazSlobTrenPolaznik = new PrikazSlobTrenPolaznik(selectedInstruktor);


            if (!(bool)prikazSlobTrenPolaznik.ShowDialog() && selectedInstruktor != null)
            {


                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(selectedInstruktor.Email));
                Util.Instance.Korisnici[index] = selectedInstruktor;

            }   
                this.Show();
                view1.Refresh();
            
        }

       

        private void DGRegKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("Aktivan") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void izmenaBtn_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedPolaznik = view.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariPolaznik = selectedPolaznik.ClonePolaznik();

            IzmenaTrenutnogUlogovanog izmenaTrenutnogUlogovanog = new IzmenaTrenutnogUlogovanog(selectedPolaznik, EStatus.IZMENI);
            this.Hide();

            if (!(bool)izmenaTrenutnogUlogovanog.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariPolaznik.Email));
                Util.Instance.Korisnici[index] = stariPolaznik;
            }
            this.Show();
            view.Refresh();
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }
    }
}