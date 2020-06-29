
using Model.Hospital;
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

namespace HealthClinic.View.Dialogs.MedicineDialogs
{
    /// <summary>
    /// Interaction logic for NewMedicineDialog.xaml
    /// </summary>
    public partial class NewMedicineDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Medicine medicineDTO;

        public Medicine MedicineDTO { get => medicineDTO; set => medicineDTO = value; }

        public NewMedicineDialog()
        {
            this.DataContext = this;
            InitializeComponent();

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
            medicineDTO = new Medicine(copyrightName, genericName, new MedicineManufacturer(manufacturer), new MedicineType(description));
            this.Close();
        }

      
    }

}
