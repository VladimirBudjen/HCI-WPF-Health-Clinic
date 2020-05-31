using System.ComponentModel;


namespace HealthClinic.Model
{
    public class MedicineModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _copyrightName;
        private string _genericName;
        private string _manufacturer;
        private string _description;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string CopyrightName
        {
            get => _copyrightName; set
            {
                if (value != _copyrightName) _copyrightName = value;
                OnPropertyChanged("CopyrightName");
            }
        }
        public string GenericName
        {
            get => _genericName; set
            {
                if (value != _genericName) _genericName = value;
                OnPropertyChanged("CopyrightName");
            }
        }

        public string Manufacturer
        {
            get => _genericName; set
            {
                if (value != _manufacturer) _manufacturer = value;
                OnPropertyChanged("Manufacturer");
            }
        }

        public string Description
        {
            get => _genericName; set
            {
                if (value != _description) _description = value;
                OnPropertyChanged("Description");
            }
        }

        public MedicineModel(string copyrightName, string genericName, string manufacturer, string description)
        {
            CopyrightName = copyrightName;
            GenericName = genericName;
            Manufacturer = manufacturer;
            Description = description;
        }
    }
}
