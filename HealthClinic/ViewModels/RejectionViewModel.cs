using Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.ViewModels
{
    public class RejectionViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Rejection _rejection;
        private Medicine _medicine;

        public string CopyrightName
        {
            get => Medicine.CopyrightName; set
            {
                if (value != Medicine.CopyrightName)
                {
                    Medicine = new Medicine(Medicine.SerialNumber, value, Medicine.GenericName, 
                    Medicine.MedicineManufacturer, Medicine.MedicineType);
                    Rejection = new Rejection(Rejection.SerialNumber, Rejection.Reason, Medicine);
                }

                OnPropertyChanged("CopyrightName");
            }
        }
        public string GenericName
        {
            get => Medicine.GenericName; set
            {
                if (value != Medicine.GenericName)
                {
                    Medicine = new Medicine(Medicine.SerialNumber, Medicine.CopyrightName, value,
                    Medicine.MedicineManufacturer, Medicine.MedicineType);
                    Rejection = new Rejection(Rejection.SerialNumber, Rejection.Reason, Medicine);
                }
                 
                OnPropertyChanged("GenericName");
            }
        }

        public string Manufacturer
        {
            get => Medicine.MedicineManufacturer.ToString(); set
            {
                if (value != Medicine.MedicineManufacturer.ToString()) { 
                    Medicine = new Medicine(Medicine.SerialNumber, Medicine.CopyrightName,
                    Medicine.GenericName, new MedicineManufacturer(Medicine.MedicineManufacturer.SerialNumber, value), Medicine.MedicineType);
                    Rejection = new Rejection(Rejection.SerialNumber, Rejection.Reason, Medicine);
                }

            OnPropertyChanged("Manufacturer");
            }
        }


        public string Type
        {
            get => Medicine.MedicineType.ToString(); set
            {
                if (value != Medicine.MedicineType.ToString())
                {
                    Medicine = new Medicine(Medicine.SerialNumber, Medicine.CopyrightName,
                    Medicine.GenericName, Medicine.MedicineManufacturer, new MedicineType(Medicine.MedicineType.SerialNumber, value));
                    Rejection = new Rejection(Rejection.SerialNumber,Rejection.Reason, Medicine);
                }


                OnPropertyChanged("Manufacturer");
            }
        }

        public string Reason
        {
            get => Rejection.Reason; set
            {
                if (value != Rejection.Reason)
                {
                    Rejection = new Rejection(Rejection.SerialNumber,value, Medicine);
                }
                OnPropertyChanged("Reason");
            }
        }

        public Medicine Medicine { get => _medicine; set => _medicine = value; }
        public Rejection Rejection { get => _rejection; set => _rejection = value; }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public RejectionViewModel(Rejection rejection)
        {
            this.Rejection = rejection;
            this.Medicine = Rejection.Medicine;
        }


    }
}
