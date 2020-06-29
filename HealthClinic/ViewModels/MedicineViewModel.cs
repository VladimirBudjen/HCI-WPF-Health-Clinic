
using Model.Hospital;
using System.ComponentModel;


namespace HealthClinic.Model
{
    public class MedicineViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Medicine _medicine;



        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public string CopyrightName
        {
            get => Medicine.CopyrightName; set
            {
                if (value != Medicine.CopyrightName)
                    Medicine = new Medicine(Medicine.SerialNumber ,value, Medicine.GenericName, Medicine.MedicineManufacturer, Medicine.MedicineType);
                   
                OnPropertyChanged("CopyrightName");
            }
        }
        public string GenericName
        {
            get => Medicine.GenericName; set
            {
                if (value != Medicine.GenericName)
                    Medicine = new Medicine(Medicine.SerialNumber ,Medicine.CopyrightName, value, Medicine.MedicineManufacturer, Medicine.MedicineType);
                ;
                OnPropertyChanged("GenericName");
            }
        }

        public string Manufacturer
        {
            get => Medicine.MedicineManufacturer.ToString(); set
            {
                if (value != Medicine.MedicineManufacturer.ToString())
                    Medicine = new Medicine(Medicine.SerialNumber ,Medicine.CopyrightName, 
                        Medicine.GenericName, new MedicineManufacturer(Medicine.MedicineManufacturer.SerialNumber,value), Medicine.MedicineType);
                  
                OnPropertyChanged("Manufacturer");
            }
        }


        public string Type
        {
            get => Medicine.MedicineType.ToString(); set
            {
                if (value != Medicine.MedicineType.ToString())
                    Medicine = new Medicine(Medicine.SerialNumber,Medicine.CopyrightName, 
                        Medicine.GenericName, Medicine.MedicineManufacturer, new MedicineType(Medicine.MedicineType.SerialNumber,value));

            
                OnPropertyChanged("Manufacturer");
            }
        }

        public Medicine Medicine { get => _medicine; set => _medicine = value; }

        public MedicineViewModel(Medicine medicine)
        {
            Medicine = medicine;
        }
    }
}
