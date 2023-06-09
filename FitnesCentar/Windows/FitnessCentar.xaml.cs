using SR41_2020_POP2021.model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for FitnessCentar.xaml
    /// </summary>
    public partial class FitnessCentar : Window
    {

        ICollectionView view;

        public FitnessCentar()
        {
            InitializeComponent();

            Pretraga.Items.Add("Pretraga po imenu");
            Pretraga.Items.Add("Pretraga po prezimenu");
            Pretraga.Items.Add("Pretraga po email adresi");
            Pretraga.Items.Add("Pretraga po adresi");


            updateView();
            view.Filter = CustomFilter;



            if (Util.Instance.emailPrijavljen == "")
            {
                ZakaziTrening.IsEnabled = false;
                ZakaziTrening.ToolTip = "Morate se registrovati da zakazete trening";
            }

            else { ZakaziTrening.IsEnabled = true; }




        }
        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;
            string sAdresa = korisnik.Adresa.Ulica + korisnik.Adresa.Broj + korisnik.Adresa.Grad + korisnik.Adresa.Drzava;

            if (korisnik.TipKorisnika.Equals(ETipKorisnika.INSTRUKTOR) && korisnik.Aktivan)
            {
                if (Pretraga.SelectedIndex == 0)
                {
                
                    return korisnik.Ime.ToLower().Contains(pretraga.Text.ToLower());
                    
                }
                else if (Pretraga.SelectedIndex == 1)
                {
                    return korisnik.Prezime.ToLower().Contains(pretraga.Text.ToLower());
                }
                else if (Pretraga.SelectedIndex == 2)
                {
                    return korisnik.Email.ToLower().Contains(pretraga.Text.ToLower());
                }
                else if (Pretraga.SelectedIndex == 3)
                {
                    if (korisnik.Adresa.Ulica.ToLower().Contains(pretraga.Text.ToLower())

                       || korisnik.Adresa.Grad.ToLower().Contains(pretraga.Text.ToLower())
                       || korisnik.Adresa.Drzava.ToLower().Contains(pretraga.Text.ToLower())
                       || korisnik.Adresa.Broj.ToLower().Contains(pretraga.Text.ToLower())
                       || sAdresa.Replace(" ", string.Empty).ToLower().Contains(pretraga.Text.Replace(" ", string.Empty).ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            else
                return true;
               
            }
           
            return false;

        }

        private void updateView()
        {
            DGInformacije.ItemsSource = null;
            view = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGInformacije.ItemsSource = view;
            DGInformacije.IsSynchronizedWithCurrentItem = true;

            DGInformacije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            DGInformacije.SelectedItems.Clear();
        }

        private void DGInformacije_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("JMBG"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("Lozinka"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }
        //private void btnSearch_Click_1(object sender, RoutedEventArgs e)
        //{
        // //   view.Filter = CustomFilter1;
        //  //  view.Refresh();
        //}

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                pretraga.Clear();
                view.Refresh();

            }
        }

        private void ZakaziTrening_Click(object sender, RoutedEventArgs e)
        {
            Trening noviTrening = new Trening();
            DodajTrening dodajTrening = new DodajTrening(noviTrening);
            this.Hide();
            dodajTrening.Show();
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }

        private void pretraga_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }
    }
}
