using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for InstruktorProzor.xaml
    /// </summary>
    public partial class InstruktorProzor : Window
    {
       
        ICollectionView view;
        ICollectionView view2;
        public InstruktorProzor()
        {
            InitializeComponent();


            updateView();
            updateViewKorisinici();
            
        }


        private void updateView()
        {
            DGInstruktorPrikaz.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Treninzi);
            DGInstruktorPrikaz.ItemsSource = view;
            DGInstruktorPrikaz.IsSynchronizedWithCurrentItem = true;

            DGInstruktorPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

          
            view.Filter = CustomFilter;
        }

        private void updateViewKorisinici()
        {
            DGInstruktoriInfo.ItemsSource = null;
            view2 = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGInstruktoriInfo.ItemsSource = view2;
            DGInstruktoriInfo.IsSynchronizedWithCurrentItem = true;

            DGInstruktoriInfo.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view2.Filter = FilterInstruktor;
            view2.Refresh();
        }

        private bool CustomFilter(object obj)
        {
        
            Trening trening = obj as Trening;

            if (trening.Aktivan && String.Equals(trening.instruktorZakazanTrening.Korisnik.Email, Util.Instance.emailPrijavljen))
            {
                if (p.Text != "")
                {
                    return trening.Datum.ToString().Contains(p.Text);
                }
                else
                    return true;
            }
            return false;

        }

        private bool CustomFilterTrening(object obj)
        {
            Trening trening = obj as Trening;

            if (!trening.Aktivan && String.Equals(trening.instruktorZakazanTrening.Korisnik.Email, Util.Instance.emailPrijavljen))
            {
                return true;
            }
            return false;

        }
        private bool FilterInstruktor(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;
      

            if (korisnik.Email.Equals(Util.Instance.emailPrijavljen))
            {
                return true;
            }
            return false;
        }



        private void DGInstruktor_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void ZakaziTreningInstruktor_Click(object sender, RoutedEventArgs e)
        {
            DodajTreningInstruktor dodajTreningInstruktor = new DodajTreningInstruktor();
            dodajTreningInstruktor.Show();
            this.Close();
        }

        private void ObrisiTreningInstruktor_Click(object sender, RoutedEventArgs e)
        {
            Trening treningZaBrisanje = (Trening)DGInstruktorPrikaz.SelectedItem;
            Util.Instance.ObrisiTrening(treningZaBrisanje.ID);

            int index = Util.Instance.Treninzi.ToList().FindIndex(trening => trening.ID.Equals(treningZaBrisanje.ID));

            Util.Instance.Treninzi[index].Aktivan = false;

            updateViewTrening();
            view.Refresh();
        }

        public void updateViewTrening()
        {

            DGInstruktorPrikaz.ItemsSource = null;
            view = new CollectionViewSource { Source = Util.Instance.Treninzi }.View;
            DGInstruktorPrikaz.ItemsSource = view;
            DGInstruktorPrikaz.IsSynchronizedWithCurrentItem = true;

            DGInstruktorPrikaz.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilterTrening;
        }



        private void InstruktorIzmena_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedInst = view2.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariInst = selectedInst.CloneInstruktor();

            IzmenaTrenRegiInstrukora editInstructors = new IzmenaTrenRegiInstrukora(selectedInst, EStatus.IZMENI);
            this.Hide();

            if (!(bool)editInstructors.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariInst.Email));
                Util.Instance.Korisnici[index] = stariInst;
            }
            this.Show();
            view2.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }

        private void TextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
