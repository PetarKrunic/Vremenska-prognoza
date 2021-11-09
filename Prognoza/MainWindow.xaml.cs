using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Net;
using System.IO;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Prognoza
{

    public partial class MainWindow : Window
    {

        public string Temperature;
        string Condition;
        string Humidity;
        string Windspeed;
        string Town;
        string Country;
        string woeid;
        string LastUpdate;
        string Code;

       
        

        private const string API_KEY = "1ac08587147e7001ad70dfd3760c6a76";
        private const string CurrentUrl =
            "http://api.openweathermap.org/data/2.5/weather?" +
            "q=@LOC@&mode=xml&units=metric&APPID=" + API_KEY;
        private const string ForecastUrl =
            "http://api.openweathermap.org/data/2.5/forecast?" +
            "q=@LOC@&mode=xml&units=metric&APPID=" + API_KEY;



        public MainWindow()
        {
            InitializeComponent();
            woeid = "Novi Sad";
            getData();
            temperature.Text = Temperature;
            town.Text = Town;
            country.Text = Country;
            condition.Text = Condition;
            humidity.Text = Humidity + " %";
            wndSpd.Text = Windspeed + " hPa";
            cel.Text = string.Format("\u00B0") + "C";

            Pic1.Source = new BitmapImage(new Uri("http://openweathermap.org/img/w/" + Code + ".png", UriKind.Absolute));





            cmb.Items.Add("Barcelona");
            cmb.Items.Add("Rome");
            cmb.Items.Add("Berlin");
            cmb.Items.Add("Moscow");
            cmb.Items.Add("Dubai");
            cmb.Items.Add("Belgrade");
            cmb.Items.Add("Atina");
            cmb.Items.Add("Podgorica");
            cmb.Items.Add("Los Angeles");
            cmb.Items.Add("London");
            cmb.Items.Add("Paris");
            cmb.Items.Add("Torino");
            cmb.Items.Add("Prijedor");
            cmb.Items.Add("Novi Sad");
            cmb.Items.Add("Mexico City");
            cmb.Items.Add("Melbourne");
            cmb.Items.Add("Tokyo");
            cmb.Items.Add("New Delhi");
            cmb.Items.Add("Oslo");
            cmb.Items.Add("Amsterdam");
            cmb.Items.Add("Milano");
            cmb.Items.Add("Madrid");
            cmb.Items.Add("Istanbul");
            cmb.Items.Add("Bern");
            cmb.Items.Add("Nice");
            cmb.Items.Add("Liverpool");
            cmb.Items.Add("Vienna");
            cmb.Items.Add("Wexford");
            cmb.Items.Add("Banja Luka");
            cmb.Items.Add("Nis");
            cmb.Items.Add("Ljubljana");
            cmb.Items.Add("Riga");
            cmb.Items.Add("Cairo");
            cmb.Items.Add("Hamburg");
            cmb.Items.Add("Tripoli");
            cmb.Items.Add("Genova");



            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }



     

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            woeid = cmb.Text;
            getData();
        }


        public void getData()
        {

            string url = ForecastUrl.Replace("@LOC@", woeid);

            using (WebClient client = new WebClient())
            {
                // Get the response string from the URL.
                try
                {
                    getWeather(client.DownloadString(url));
                }
                catch (WebException ex)
                {
                    DisplayError(ex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unknown error\n" + ex.Message);
                }
            }
        }

        private void DisplayError(WebException exception)
        {
            try
            {
                StreamReader reader = new StreamReader(exception.Response.GetResponseStream());
                XmlDocument response_doc = new XmlDocument();
                response_doc.LoadXml(reader.ReadToEnd());
                XmlNode message_node = response_doc.SelectSingleNode("//message");
                MessageBox.Show(message_node.InnerText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error\n" + ex.Message);
            }
        }



        private void getWeather(string xml)
        {
            XmlDocument xml_doc = new XmlDocument();
            xml_doc.LoadXml(xml);

            XmlNode loc_node = xml_doc.SelectSingleNode("weatherdata/location");
            Town = loc_node.SelectSingleNode("name").InnerText;
            Country = loc_node.SelectSingleNode("country").InnerText;



            foreach (XmlNode time_node in xml_doc.SelectNodes("//time"))
            {
                // Get the time in UTC.
                DateTime time =
                    DateTime.Parse(time_node.Attributes["from"].Value,
                        null, DateTimeStyles.AssumeUniversal);

                // Get the temperature.
                XmlNode temp_node = time_node.SelectSingleNode("temperature");
                string temp = temp_node.Attributes["value"].Value;
                Temperature = temp;
                XmlNode wind_node = time_node.SelectSingleNode("windSpeed");
                string wind = wind_node.Attributes["mps"].Value;
                Windspeed = wind;
                XmlNode hum_node = time_node.SelectSingleNode("humidity");
                string hum = hum_node.Attributes["value"].Value;
                Humidity = hum;
                XmlNode code_node = time_node.SelectSingleNode("symbol");
                string code = code_node.Attributes["var"].Value;
                Code = code;
                XmlNode cond_node = time_node.SelectSingleNode("symbol");
                string cond = code_node.Attributes["name"].Value;
                Condition = cond;

                break;
            }

            temperature.Text = Temperature;
            town.Text = Town;
            country.Text = Country;
            condition.Text = Condition;
            humidity.Text = Humidity + " %";
            wndSpd.Text = Windspeed + " hPa";
            cel.Text = string.Format("\u00B0") + "C";
            Pic1.Source = new BitmapImage(new Uri("http://openweathermap.org/img/w/" + Code + ".png", UriKind.Absolute));
        }


    }
}
