using Model.Hospital;
using System;
using System.ComponentModel;
using System.Windows;

namespace HealthClinic.View.Dialogs.MedicineDialogs
{
    /// <summary>
    /// Interaction logic for EditMedicineDialog.xaml
    /// </summary>
    public partial class EditMedicineDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Medicine medicineDTO;

        public Medicine MedicineDTO { get => medicineDTO; set => medicineDTO = value; }

        public EditMedicineDialog(Medicine medicine)
        {
            
            this.DataContext = this;
            InitializeComponent();
            medicineDTO = medicine;
            copyrightNameInput.Text = medicine.CopyrightName;
            genericNameInput.Text = medicine.GenericName;
            manufacturerInput.Text = medicine.MedicineManufacturer.ToString();
            descriptionInput.Text = medicine.MedicineType.ToString();


        }


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            String genericName = genericNameInput.Text;
            String copyrightName = copyrightNameInput.Text;
            String manufacturer = manufacturerInput.Text;
            String description = descriptionInput.Text;
            medicineDTO = new Medicine(medicineDTO.SerialNumber,copyrightName, 
                genericName, new MedicineManufacturer(medicineDTO.MedicineManufacturer.SerialNumber,manufacturer),
                new MedicineType(medicineDTO.MedicineType.SerialNumber, description));
            this.Close();
        }


    }

}
