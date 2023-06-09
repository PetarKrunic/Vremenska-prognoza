using SR41_2020_POP2021.model;

using SR41_2020_POP2021.Windows;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SR41_2020_POP2021
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           // Util.Instance.CitanjeEntitete("korisnici.txt");
            //Util.Instance.CitanjeEntitete("instruktori.txt");

            Util.Instance.CitanjeEntitete("korisnici");
            Util.Instance.CitanjeEntitete("instruktori");
            //Util.Instance.CitanjeEntitete("ali");
        
            InitializeComponent();
            Util.Instance.emailPrijavljen = "";


        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
           


            if (username.Text == "" || password.Password.Length == 0)
            {
                MessageBox.Show("Niste uneli korisnicko ime ili lozinku");
                return;
            }
            

         



            foreach (RegistrovaniKorisnik k in Util.Instance.Korisnici)
            {
                if (k.Email == username.Text && k.Lozinka == password.Password && k.TipKorisnika == ETipKorisnika.ADMINISTRATOR)
                {
                      
                    Util.Instance.emailPrijavljen = k.Email;
                    AllInstructors allInstructorsWindow = new AllInstructors();
                    this.Hide();
                    allInstructorsWindow.Show();
                    this.Close();
               
                    break;
                }
                else if (k.Email == username.Text  && k.Lozinka == password.Password && k.TipKorisnika == ETipKorisnika.POLAZNIK)
                {
                    
                    Util.Instance.emailPrijavljen = k.Email;
                    registrovaniKorisnikProzor regKorisnikProzor = new registrovaniKorisnikProzor();
                    regKorisnikProzor.Show();
               
                    this.Close();
                    break;
                }
                else if (k.Email == username.Text  && k.Lozinka == password.Password && k.TipKorisnika == ETipKorisnika.INSTRUKTOR)
                {
                    Util.Instance.emailPrijavljen = k.Email;
                    InstruktorProzor instruktorProzor = new InstruktorProzor();
                    instruktorProzor.Show();
                
                    
                }
                else if (username.Text != k.Email && password.Password!= k.Lozinka)
                {
                    MessageBox.Show("Niste uneli ispravno korisnicko ime ili lozinku");
                    return;
                }
                this.Close();
            }
            //  Login();
        }

        public void Login()
        {
            //string query = "SELECT  TipKorisnika Ime,Prezime from Korisnici WHERE  Email = @Email and Lozinka=@Lozinka";
            //string returnValue = "";

            
            // RegistrovaniKorisnik p = new RegistrovaniKorisnik();
           
            //using (SqlConnection con = new SqlConnection(Util.CONNECTION_STRING))
            //{


            //    using (SqlCommand sqlcmd = new SqlCommand(query, con))
            //    {
            //        sqlcmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = username.Text;
            //        sqlcmd.Parameters.Add("@Lozinka", SqlDbType.VarChar).Value = password.Password;
            //        con.Open();
            //        returnValue = (string)sqlcmd.ExecuteScalar();
            //    }
            //}



            ////EDIT to avoid NRE 
            //if (String.IsNullOrEmpty(returnValue))
            //{
            //    MessageBox.Show("Incorrect username or password");
            //    return;
            //}
            //returnValue = returnValue.Trim();
            //if (returnValue == "ADMINISTRATOR")
            //{

            //    AllInstructors allInstructorsWindow = new AllInstructors();
            //    this.Hide();
            //    allInstructorsWindow.Show();
            //    this.Show();

            //}
            //else if (returnValue == "POLAZNIK")
            //{
            //    registrovaniKorisnikProzor regKorisnikProzor = new registrovaniKorisnikProzor();
            //    regKorisnikProzor.Show();
            //}
            //else if (returnValue == "INSTRUKTOR")
            //{
            //    MessageBox.Show("Instruktor");
            //}
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            Register RegWindow = new Register();
            RegWindow.Show();
            this.Close();
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fitnesBtn_Click(object sender, RoutedEventArgs e)
        {
            FitnessCentar fitnesCentarWindow = new FitnessCentar();
            this.Hide();
            fitnesCentarWindow.Show();
            this.Close();
            
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }
    }
}

