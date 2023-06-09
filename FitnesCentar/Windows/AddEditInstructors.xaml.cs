using SR41_2020_POP2021.model;
using SR41_2020_POP2021.Services;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddEditInstructors.xaml
    /// </summary>
    public partial class AddEditInstructors : Window
    {
        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniInstruktor;
    
        public AddEditInstructors(RegistrovaniKorisnik instruktor , EStatus status = EStatus.DODAJ)
        {
           

            InitializeComponent();


            this.DataContext = instruktor;
            ComboTip.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            Combo.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();

          

            odabraniInstruktor = instruktor;
            odabraniStatus = status;



            if (status.Equals(EStatus.IZMENI) && instruktor != null)
            {
                this.Title = "Izmeni instruktora";

              //  txtLozinka.IsEnabled = false;
              //  ComboTip.IsEnabled = false;
               // txtJmbg.IsEnabled = false;
              //  txtEmail.IsEnabled = false;

               
       
            }
            else
            {
           

                this.Title = "Dodaj instruktora";
                //  ComboTip.IsEnabled = false;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {


            if (odabraniStatus.Equals(EStatus.DODAJ))
            {

                if (txtIme.Text == "" || txtPrezime.Text == "" || txtJmbg.Text == "" 
                || txtUlica.Text == "" || txtBroj.Text == "" || txtGrad.Text == "" || txtDrzava.Text == ""
                || txtLozinka.ToString() == "")
                {
                    MessageBox.Show("Niste uneli sve podatke!");
                    return;
                }
                if (!txtEmail.ToString().Contains("@") && !txtEmail.ToString().EndsWith(".com"))
                {
                    MessageBox.Show("Morate uneti validan email!");
                }

                Adresa editAdresa = new Adresa
                {

                    Ulica = txtUlica.Text.TrimEnd(),
                    Broj = txtBroj.Text.TrimEnd(),
                    Grad = txtGrad.Text.TrimEnd(),
                    Drzava = txtDrzava.Text.TrimEnd()

                };


                odabraniInstruktor.Aktivan = true;
                odabraniInstruktor.Adresa = editAdresa;


                Instruktor instruktor = new Instruktor
                {


                    Korisnik = odabraniInstruktor

                };

                Util.Instance.Korisnici.Add(odabraniInstruktor);
                Util.Instance.Instruktori.Add(instruktor);




                int id = Util.Instance.SacuvajEntitete(odabraniInstruktor);
                instruktor.ID = id;
                Util.Instance.SacuvajEntitete(instruktor);
            }
            else
            {
                izmenaInstruktora(odabraniInstruktor);
            }
   

            this.DialogResult = true;
            this.Close();
        }
        public int izmenaInstruktora(object obj)
        {
            RegistrovaniKorisnik registrovaniKorisnik = obj as RegistrovaniKorisnik;
     
            using (SqlConnection conn = new SqlConnection(Util.CONNECTION_STRING))
            {
                conn.Open();
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"update dbo.Korisnici set Ime = '" + this.txtIme.Text + "' ,Prezime= '" + this.txtPrezime.Text + "',Lozinka= '" + this.txtLozinka.Text + "',Email= '" + this.txtEmail.Text + "',Pol= '" + this.Combo.Text + "',JMBG= '" + this.txtJmbg.Text + "',Adresa= '" + this.txtUlica.Text + ',' + this.txtBroj.Text + ','+  this.txtGrad.Text + ','+ this.txtDrzava.Text + "'  where ID=" + registrovaniKorisnik.ID + ";";
                return (int)command.ExecuteNonQuery();
            }
        }
    }
}

