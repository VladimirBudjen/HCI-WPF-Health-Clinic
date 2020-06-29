using Backend.Controller.SuperintendentControllers;
using HealthClinic.Backend.Controller.SuperintendentControllers;
using HealthClinic.View.ErrorCheck;
using Model.Accounts;
using Model.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HealthClinic.View.Dialogs.PhysicianDialogs
{
    /// <summary>
    /// Interaction logic for NewPhysicianDialog.xaml
    /// </summary>
    public partial class NewPhysicianDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Country[] countries;
        private String[] countriesStringArray;
        private String[] cities;
        private String[] specialities;
        private Physitian physicianDTO;

        public string[] Cities { get { if (CountryCombo.SelectedItem != null) { return citiesStringFromCountry(findCountryWithName(countries, CountryCombo.SelectedItem.ToString())); } else return cities; }
            set
            {
                if (value != cities) cities = value;
                OnPropertyChanged("Cities");
            }
        }

        public string[] CountriesStringArray { get { return countriesStringArray; } set
            {
                if (value != countriesStringArray) countriesStringArray = value;
                OnPropertyChanged("CountriesStringArray");
            }
        }



        public string[] Specialities { get => specialities; set
            {
                if (value != specialities) specialities = value;
                OnPropertyChanged("Specialities");
            }
        }

        public Physitian PhysicianDTO { get => physicianDTO; set => physicianDTO = value; }

        public NewPhysicianDialog()
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
            Specialities = new string[3];
            Specialities[0] = "Oftamolog";
            Specialities[1] = "Pedijatar";
            Specialities[2] = "Hirurg";

            CountryCombo.SelectedIndex = 0;
            Cities = citiesStringFromCountry(findCountryWithName(countries,CountryCombo.SelectedItem.ToString()));
       
            CityCombo.SelectedIndex = 0;
            
            specialityCombo.SelectedIndex = 0;

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
            foreach(String s in stringArray)
            {
                if (s!=null)
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
            
            foreach(Country country in countrieArray)
            {
                if (country.Name.Equals(name))
                {
                    return country;
                }
            }
            return null;

            
        }

        private City stringToCity(Country country,string name)
        {
            foreach(City city in country.City)
            {
                if (city.Name.Equals(name))
                {
                    return city;
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
                && !string.IsNullOrEmpty(addressInput.Text) && isDateGood(dateTextInput.Text)
                && !string.IsNullOrEmpty(emailInput.Text)
                && !string.IsNullOrEmpty(contactInput.Text)
                && isHoursDateGood(workStartInput.Text)
                && isHoursDateGood(workEndInput.Text);
                                
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
        private bool isHoursDateGood(string stringDate)
        {
            try
            {
                DateTime myDate = DateTime.ParseExact(stringDate, "HH:mm",
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
            SuperiIntendentPhysiciansController controller = new SuperiIntendentPhysiciansController();
            if (controller.jmbgExists(jmbg))
            {
                System.Windows.Forms.MessageBox.Show("Takav id već postoji!");
                return;
            }

            DateTime workStart = DateTime.ParseExact(workStartInput.Text, "HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime workEnd = DateTime.ParseExact(workEndInput.Text, "HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            TimeInterval workInterval = new TimeInterval(workStart, workEnd);
            Address address = new Address(addressInput.Text);
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
            List<Specialization> speciality = new List<Specialization>();
            speciality.Add(new Specialization(specialityCombo.Text));
            
            PhysicianDTO = new Physitian(Guid.NewGuid().ToString(),name, surname, jmbg ,dateOfbirth, contactInput.Text, emailInput.Text, address, workInterval ,speciality);
            this.Close();

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
