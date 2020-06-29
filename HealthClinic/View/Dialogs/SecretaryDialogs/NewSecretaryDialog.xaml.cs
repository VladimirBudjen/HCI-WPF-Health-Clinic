using HealthClinic.Backend.Controller.SuperintendentControllers;
using HealthClinic.View.ErrorCheck;
using Model.Accounts;
using Model.Util;
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

namespace HealthClinic.View.Dialogs.SecretaryDialogs
{
    /// <summary>
    /// Interaction logic for NewSecretaryDialog.xaml
    /// </summary>
    public partial class NewSecretaryDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Country[] countries;
        private String[] countriesStringArray;
        private String[] cities;
        private String[] specialities;
        private Secretary secretaryDTO;

        public string[] Cities
        {
            get { if (CountryCombo.SelectedItem != null) { return citiesStringFromCountry(findCountryWithName(countries, CountryCombo.SelectedItem.ToString())); } else return cities; }
            set
            {
                if (value != cities) cities = value;
                OnPropertyChanged("Cities");
            }
        }

        public string[] CountriesStringArray
        {
            get { return countriesStringArray; }
            set
            {
                if (value != countriesStringArray) countriesStringArray = value;
                OnPropertyChanged("CountriesStringArray");
            }
        }



        public string[] Specialities
        {
            get => specialities; set
            {
                if (value != specialities) specialities = value;
                OnPropertyChanged("Specialities");
            }
        }

        public Secretary SecretaryDTO { get => secretaryDTO; set => secretaryDTO = value; }

        public NewSecretaryDialog()
        {
            this.DataContext = this;
            InitializeComponent();


            countries = new Country[2];
            CountriesStringArray = new string[2];
            countries[0] = new Country("Srbija");
            countries[1] = new Country("Hrvatska");
            City zagreb = new City("Zagreb", "999899");
            countries[1].AddCity(zagreb);
            City Kamenica = new City("Sremska Kamenica", "20208");
            City NoviSad = new City("Novi Sad", "21200");
            City Beograd = new City("Beograd", "20000");
            countries[0].AddCity(NoviSad);
            countries[0].AddCity(Beograd);
            countries[0].AddCity(Kamenica);
            CountriesStringArray = new string[2];
            CountriesStringArray[0] = "Srbija";
            CountriesStringArray[1] = "Hrvatska";
    
            CountryCombo.SelectedIndex = 0;
            Cities = citiesStringFromCountry(findCountryWithName(countries, CountryCombo.SelectedItem.ToString()));

            CityCombo.SelectedIndex = 0;


        }

        private String[] citiesStringFromCountry(Country country)
        {
            String[] stringArray = new string[3];
            int i = 0;
            foreach (City city in country.City)
            {
                stringArray[i] = city.Name;
                i++;
            }
            List<String> nonBlank = new List<String>();
            foreach (String s in stringArray)
            {
                if (s != null)
                {
                    nonBlank.Add(s);
                }
            }
            // nonBlank will have all the elements which contain some characters.
            stringArray = nonBlank.ToArray();

            return stringArray;

        }

        private Country findCountryWithName(Country[] countrieArray, String name)
        {

            foreach (Country country in countrieArray)
            {
                if (country.Name.Equals(name))
                {
                    return country;
                }
            }
            return null;


        }

 
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void CountryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CountryCombo.SelectedItem != null)
            {
                Cities = citiesStringFromCountry(findCountryWithName(countries, CountryCombo.SelectedItem.ToString()));
                CityCombo.SelectedIndex = 0;
            }

        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            okButton.IsEnabled = !string.IsNullOrEmpty(nameTextInput.Text) &&
                !string.IsNullOrEmpty(surnameTextInput.Text) && !string.IsNullOrEmpty(jmbgTextInput.Text)
                && !string.IsNullOrEmpty(adressInput.Text) && isDateGood(dateTextInput.Text)
                && !string.IsNullOrEmpty(emailInput.Text) && !string.IsNullOrEmpty(contactInput.Text);

        }

        private bool isDateGood(string stringDate)
        {
            try
            {
                DateTime myDate = DateTime.ParseExact(stringDate, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return false;
            }
            return true;

        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            String name = nameTextInput.Text;
            if (!Checker.nameRegex.IsMatch(name))
            {
                MessageBox.Show("Neispravno uneto ime!");
                return;
            }
            String surname = surnameTextInput.Text;
            if (!Checker.nameRegex.IsMatch(surname))
            {
                MessageBox.Show("Neispravno uneto prezime!");
                return;
            }
            String jmbg = jmbgTextInput.Text;
            if (!Checker.jmbgRegex.IsMatch(jmbg))
            {
                MessageBox.Show("Neispravno unet jmbg!");
                return;
            }
            SuperIntendentSecretariesController controller = new SuperIntendentSecretariesController();
            if (controller.jmbgExists(jmbg))
            {
                System.Windows.Forms.MessageBox.Show("Takav jmbg već postoji!");
                return;
            }



            String address = adressInput.Text;
            String email = emailInput.Text;
            String conctact = contactInput.Text;
            String country = CountryCombo.Text;
            String city = CityCombo.Text;
            DateTime dateOfbirth =
            DateTime.ParseExact(dateTextInput.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (dateOfbirth > DateTime.Today)
            {
                MessageBox.Show("Neispravan datum!");
                return;
            }

            SecretaryDTO = new Secretary(name, surname, jmbg, dateOfbirth, email, conctact ,new Address(address));
  
            this.Close();

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

