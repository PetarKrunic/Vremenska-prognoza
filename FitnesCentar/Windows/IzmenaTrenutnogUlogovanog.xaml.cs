﻿using SR41_2020_POP2021.model;
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
    /// Interaction logic for IzmenaTrenutnogUlogovanog.xaml
    /// </summary>
    public partial class IzmenaTrenutnogUlogovanog : Window
    {
        private EStatus odabraniStatus;
        private RegistrovaniKorisnik odabraniPolaznik;


        public IzmenaTrenutnogUlogovanog(RegistrovaniKorisnik polaznik, EStatus status = EStatus.IZMENI)
        {
            InitializeComponent();

            this.DataContext = polaznik;
            ComboTip.ItemsSource = Enum.GetValues(typeof(ETipKorisnika)).Cast<ETipKorisnika>();
            Combo.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();



            odabraniPolaznik = polaznik;
            odabraniStatus = status;

            if (status.Equals(EStatus.IZMENI) && polaznik != null)
            {
                this.Title = "Izmeni instruktora";

                //txtLozinka.IsEnabled = false;
                ComboTip.IsEnabled = false;
                // txtJmbg.IsEnabled = false;
                //  txtEmail.IsEnabled = false;



            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (odabraniStatus.Equals(EStatus.IZMENI))
            {
                izmenaInstruktora(odabraniPolaznik);
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
                command.CommandText = @"update dbo.Korisnici set Ime = '" + this.txtIme.Text + "' ,Prezime= '" + this.txtPrezime.Text + "',Lozinka= '" + this.txtLozinka.Text + "',Email= '" + this.txtEmail.Text + "',Pol= '" + this.Combo.Text + "',JMBG= '" + this.txtJmbg.Text + "',Adresa= '" + this.txtUlica.Text + ',' + this.txtBroj.Text + ',' + this.txtGrad.Text + ',' + this.txtDrzava.Text + "'  where ID=" + registrovaniKorisnik.ID + ";";
                return (int)command.ExecuteNonQuery();
            }
        }
    }
}
