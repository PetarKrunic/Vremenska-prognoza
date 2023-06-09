using SR41_2020_POP2021.model;
using System;
using System.Collections;
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
    /// Interaction logic for AllInstructors.xaml
    /// </summary>
    public partial class AllInstructors : Window
    {

        ICollectionView view;
        ICollectionView view2;
        ICollectionView view3;
       

        public AllInstructors()
        {
            Util.Instance.CitanjeEntitete("trening2");
            InitializeComponent();
            PretragaBox.Items.Add("Pretraga po imenu");
            PretragaBox.Items.Add("Pretraga po prezimenu");
            PretragaBox.Items.Add("Pretraga po email adresi");
            PretragaBox.Items.Add("Pretraga po adresi");
            PretragaBox.Items.Add("Pretraga po tipu");



            updateView();
        
            updateViewAdmin();


        }




        //private bool CustomFilter1(object obj)
        //{
        //    RegistrovaniKorisnik registrovaniKorisnik = obj as RegistrovaniKorisnik;
        //    //  string sAdresa = registrovaniKorisnik.Adresa.Ulica + registrovaniKorisnik.Adresa.Broj + registrovaniKorisnik.Adresa.Grad + registrovaniKorisnik.Adresa.Drzava;

        //    if (registrovaniKorisnik.TipKorisnika.Equals(ETipKorisnika.INSTRUKTOR) && registrovaniKorisnik.Aktivan)
        //    {
        //        if (PretragaBox.SelectedIndex == 0)
        //        {
        //            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
        //            {
        //                conn.Open();
        //                string sql = "SELECT * FROM Korisnici WHERE Ime= @Ime";
        //                SqlCommand com = new SqlCommand(sql, conn);
        //                com.Parameters.AddWithValue("@Ime", pretraga.Text);

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
        //                {
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    DGInstruktori.ItemsSource = dt.DefaultView;
        //                }

        //            }
        //        }

        //        else if (PretragaBox.SelectedIndex == 1)
        //        {
        //            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
        //            {
        //                conn.Open();
        //                string sql = "SELECT * FROM Korisnici WHERE Prezime= @Prezime";
        //                SqlCommand com = new SqlCommand(sql, conn);
        //                com.Parameters.AddWithValue("@Prezime", pretraga.Text);

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
        //                {
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    DGInstruktori.ItemsSource = dt.DefaultView;
        //                }

        //            }
        //        }

        //        else if (PretragaBox.SelectedIndex == 2)
        //        {
        //            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
        //            {
        //                conn.Open();
        //                string sql = "SELECT * FROM Korisnici WHERE Email= @Email";
        //                SqlCommand com = new SqlCommand(sql, conn);
        //                com.Parameters.AddWithValue("@Email", pretraga.Text);

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
        //                {
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    DGInstruktori.ItemsSource = dt.DefaultView;
        //                }

        //            }
        //        }

        //        else if (PretragaBox.SelectedIndex == 3)
        //        {
        //            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
        //            {
        //                conn.Open();
        //                string sql = "SELECT * FROM Korisnici WHERE Adresa= @Adresa";
        //                SqlCommand com = new SqlCommand(sql, conn);
        //                com.Parameters.AddWithValue("@Adresa", pretraga.Text);

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
        //                {
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    DGInstruktori.ItemsSource = dt.DefaultView;
        //                }

        //            }
        //        }

        //        else if (PretragaBox.SelectedIndex == 4)
        //        {
        //            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
        //            {
        //                conn.Open();
        //                string sql = "SELECT * FROM Korisnici WHERE TipKorisnika= @TipKorisnika and Aktivan=@Aktivan";
        //                SqlCommand com = new SqlCommand(sql, conn);
        //                com.Parameters.AddWithValue("@TipKorisnika", pretraga.Text);

        //                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
        //                {
        //                    com.Parameters.AddWithValue("@Aktivan", registrovaniKorisnik.Aktivan);
        //                    DataTable dt = new DataTable();
        //                    adapter.Fill(dt);
        //                    DGInstruktori.ItemsSource = dt.DefaultView;
        //                }

        //            }
        //        }
        //    }
        //    return false;
        //}

    





        private bool CustomFilter(object obj)
        {
            RegistrovaniKorisnik instruktor= obj as RegistrovaniKorisnik;
          
            string sAdresa = instruktor.Adresa.Ulica + instruktor.Adresa.Broj + instruktor.Adresa.Grad + instruktor.Adresa.Drzava;

            if (!instruktor.TipKorisnika.Equals(ETipKorisnika.ADMINISTRATOR) && instruktor.Aktivan)
            {
                if (PretragaBox.SelectedIndex == 0)
                {
                    
                    return instruktor.Ime.ToLower().Contains(pretraga.Text.ToLower());

                }
                else if (PretragaBox.SelectedIndex == 1)
                {
                    return instruktor.Prezime.ToLower().Contains(pretraga.Text.ToLower());
                }
                else if (PretragaBox.SelectedIndex == 2)
                {
                    return instruktor.Email.ToLower().Contains(pretraga.Text.ToLower());
                }
                else if (PretragaBox.SelectedIndex == 3)
                {
                    if (instruktor.Adresa.Ulica.ToLower().Contains(pretraga.Text.ToLower())

                       || instruktor.Adresa.Grad.ToLower().Contains(pretraga.Text.ToLower())
                       || instruktor.Adresa.Drzava.ToLower().Contains(pretraga.Text.ToLower())
                       || instruktor.Adresa.Broj.ToLower().Contains(pretraga.Text.ToLower())
                       || sAdresa.Replace(" ", "").ToLower().Contains(pretraga.Text.Replace(" ", "").ToLower()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (PretragaBox.SelectedIndex == 4)
                {
                    return instruktor.TipKorisnika.ToString().ToLower().Contains(pretraga.Text.ToLower());
                }
                else
                    return true;
            }
            return false;
            
        }

        private void updateView()
        {
            DGInstruktori.ItemsSource = null;
            view = new CollectionViewSource { Source = Util.Instance.Korisnici }.View;
            DGInstruktori.ItemsSource = view;
            DGInstruktori.IsSynchronizedWithCurrentItem = true;
         
            DGInstruktori.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view.Filter = CustomFilter;
        }


        private void DodavanjeInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditInstructors addEditInstructors = new AddEditInstructors(noviKorisnik);
            this.Hide();
            if (!(bool)addEditInstructors.ShowDialog()) { }
            this.Show();
            view.Refresh();
        }

        private void IzmenaInstruktora_Click(object sender, RoutedEventArgs e)
        {
         

            RegistrovaniKorisnik selectedInstruktor = view.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariInstruktor = selectedInstruktor.Clone();

            AddEditInstructors addEditInstructors = new AddEditInstructors(selectedInstruktor, EStatus.IZMENI);
            this.Hide();

            if (!(bool)addEditInstructors.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariInstruktor.Email));
                Util.Instance.Korisnici[index] = stariInstruktor;
            }
            this.Show();
            view.Refresh();
        }

        private void BrisanjeInstruktora_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik instruktorZaBrisanje = (RegistrovaniKorisnik)DGInstruktori.SelectedItem;

            Util.Instance.DeleteUser(instruktorZaBrisanje.Email);

            

            int index = Util.Instance.Korisnici.ToList().FindIndex(korisnik => korisnik.Email.Equals(instruktorZaBrisanje.Email));

        
            Util.Instance.Korisnici[index].Aktivan = false;
           
            updateView();
            view.Refresh();

        }

        private void DGInstruktori_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
          

            if (e.PropertyName.Equals("Error"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            if (e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void DodavanjeKorisnika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik noviKorisnik = new RegistrovaniKorisnik();
            AddEditUsers addEditUsers = new AddEditUsers(noviKorisnik);
            this.Hide();
            if (!(bool)addEditUsers.ShowDialog()) { }
            this.Show();
            view2.Refresh();
        }

        private void IzmenaKorisnika_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedPolaznik = view2.CurrentItem as RegistrovaniKorisnik;
            RegistrovaniKorisnik stariPolaznik = selectedPolaznik.ClonePolaznik();

            AddEditUsers addEditUsers = new AddEditUsers(selectedPolaznik, EStatus.IZMENI);
            this.Hide();
            //??
            if (!(bool)addEditUsers.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariPolaznik.Email));
                Util.Instance.Korisnici[index] = stariPolaznik;
            }
            this.Show();
            view2.Refresh();
        }





        //private void okButton_Click(object sender, RoutedEventArgs e)
        //{
        //  //  view.Filter = CustomFilter1;
        // //   view.Refresh();
        //}

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                pretraga.Clear();
                view.Refresh();
                view2.Refresh();

            }
        }



        private void Logut_Button_Click(object sender, RoutedEventArgs e)
        {
            var mv = new MainWindow();
            mv.Show();
            this.Close();
        }

        private void ZakaziTrening_Click(object sender, RoutedEventArgs e)
        {
            Trening noviTrening = new Trening();
            DodajTrening dodajTrening = new DodajTrening(noviTrening);
            this.Hide();
            dodajTrening.Show();
      
        }

        private void DGAdminImfo_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Error") || e.PropertyName.Equals("ID"))
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
        }

        private void updateViewAdmin()
        {
            DGAdminImfo.ItemsSource = null;
            view3 = CollectionViewSource.GetDefaultView(Util.Instance.Korisnici);
            DGAdminImfo.ItemsSource = view3;
            DGAdminImfo.IsSynchronizedWithCurrentItem = true;

            DGAdminImfo.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            view3.Filter = FilterAdmin;
            view3.Refresh();
        }

        private bool FilterAdmin(object obj)
        {
            RegistrovaniKorisnik korisnik = obj as RegistrovaniKorisnik;

            if (korisnik.Email.Equals(Util.Instance.emailPrijavljen))
            {
                return true;
            }
            return false;
        }

        private void izmena_Click(object sender, RoutedEventArgs e)
        {
            RegistrovaniKorisnik selectedAdmin = view3.CurrentItem as RegistrovaniKorisnik;

            RegistrovaniKorisnik stariAdmin = selectedAdmin.Clone();

            IzmenaInfoAdmin izmenaInfoAdmin = new IzmenaInfoAdmin(selectedAdmin, EStatus.IZMENI);
            this.Hide();

            if (!(bool)izmenaInfoAdmin.ShowDialog())
            {
                int index = Util.Instance.Korisnici.ToList().FindIndex(k => k.Email.Equals(stariAdmin.Email));
                Util.Instance.Korisnici[index] = stariAdmin;
            }
            this.Show();
            view3.Refresh();
        }

        private void pretraga_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            view.Refresh();
        }

        private void PretragaBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
