using HealthClinic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for WaitingMedicineTableView.xaml
    /// </summary>
    public partial class WaitingMedicineTableView : UserControl
    {

        public ObservableCollection<MedicineModel> WaitingMedicine
        {
            get;
            set;
        }
        public string RadioButtonFocus
        {
            get { return (string) GetValue(RadioButtonFocusProperty); }
            set { SetValue(RadioButtonFocusProperty, value); }
        }

        public static readonly DependencyProperty RadioButtonFocusProperty =
        DependencyProperty.Register("RadioButtonFocus", typeof(string), typeof(WaitingMedicineTableView), new UIPropertyMetadata(""));

        public WaitingMedicineTableView()
        {
            InitializeComponent();


   
            this.DataContext = this;
            WaitingMedicine = new ObservableCollection<MedicineModel>();
            for (int i = 0; i < 30; i++)
            {
                WaitingMedicine.Add(new MedicineModel("Panklav", "Panklav", "Hemofarm", "Antibiotik"));
                WaitingMedicine.Add(new MedicineModel("Conoor", "Bisaprolol", "Merck KGa", "Beta-biokator"));
                WaitingMedicine.Add(new MedicineModel("Bensedin", "Diazepam", "GALENIKA AD Beograd" , "Benzodiazepan"));
            }

            waitingRadioButton.IsChecked = true;


        }
        public void focusTable()
        {
            waitingRadioButton.Focus();
        }


    }
}
