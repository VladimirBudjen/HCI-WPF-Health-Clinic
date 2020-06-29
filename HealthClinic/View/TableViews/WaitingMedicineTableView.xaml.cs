using HealthClinic.Model;
using HealthClinic.View.Dialogs.MedicineDialogs;
using Model.Hospital;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;


namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for WaitingMedicineTableView.xaml
    /// </summary>
    public partial class WaitingMedicineTableView : System.Windows.Controls.UserControl
    {
        private static bool medicineIsInList = false;
        private static ObservableCollection<MedicineViewModel> staticMedicine = new ObservableCollection<MedicineViewModel>();

        public ObservableCollection<MedicineViewModel> WaitingMedicine
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
            WaitingMedicine = staticMedicine;
            if (!medicineIsInList)
            {
                    WaitingMedicine.Add(new MedicineViewModel(new Medicine("Panklav", "Panklav", new MedicineManufacturer("Hemofarm"), new MedicineType("Antibiotik"))));
                    WaitingMedicine.Add(new MedicineViewModel(new Medicine("Conoor", "Bisaprolol", new MedicineManufacturer("Merck KGa"), new MedicineType("Beta-biokator"))));
                    WaitingMedicine.Add(new MedicineViewModel(new Medicine("Bensedin", "Diazepam", new MedicineManufacturer("GALENIKA AD Beograd"), new MedicineType("Benzodiazepan"))));
            }

            medicineIsInList = true;

            MainWindow.deleteSelectedMedicine += deleteRow;
            MainWindow.addMedicine += addRow;
            MainWindow.editMedicine += editRow;
            MainWindow.medicineSelected += getSelectedRow;


        }

        private int getSelectedRow()
        {
            return dataGridWaitingMedicine.SelectedIndex;
        }
        private void deleteRow()
        {
            if (dataGridWaitingMedicine.SelectedIndex != -1)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje red", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        WaitingMedicine.RemoveAt(dataGridWaitingMedicine.SelectedIndex);
                        break;
                    default:
                        break;
                }
                focusCurent();
            }

        }

        private void addRow()
        {
            NewMedicineDialog newMedicineDialog = new NewMedicineDialog();
            newMedicineDialog.ShowDialog();
            if (newMedicineDialog.MedicineDTO != null)
            {
                MedicineViewModel medicineModel = new MedicineViewModel(newMedicineDialog.MedicineDTO);
                WaitingMedicine.Add(medicineModel);

            }

            focusOnLast();
        }

        private void editRow()
        {
            int selected = dataGridWaitingMedicine.SelectedIndex;
            if (selected != -1)
            {

                EditMedicineDialog editMedicineDialog = new EditMedicineDialog(WaitingMedicine.ElementAt(selected).CopyrightName, WaitingMedicine.ElementAt(selected).GenericName,
                    WaitingMedicine.ElementAt(selected).Manufacturer, WaitingMedicine.ElementAt(selected).Type);
                editMedicineDialog.ShowDialog();
                if (editMedicineDialog.MedicineDTO != null)
                {
                    MedicineViewModel medicineModel = new MedicineViewModel(editMedicineDialog.MedicineDTO);
                    WaitingMedicine.RemoveAt(selected);
                    WaitingMedicine.Add(medicineModel);

                }
                focusOnLast();

            }

        }

        private void shiftPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.LeftShift))
            {
                checkIfSelected();
                menu.Visibility = System.Windows.Visibility.Visible;
                menu.IsEnabled = true;
                //menu.Focus();
                backOption.Focus();
                dataGridWaitingMedicine.Focus();
                backOption.Focus();
            }
        }

        private void back(object sender, System.Windows.RoutedEventArgs e)
        {
            focusCurent();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;
        }

        private void addRowOption(object sender, System.Windows.RoutedEventArgs e)
        {
            addRow();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void editRowOption(object sender, System.Windows.RoutedEventArgs e)
        {
            editRow();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void deleteRowOtpion(object sender, System.Windows.RoutedEventArgs e)
        {
            deleteRow();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void scroll()
        {
            if (dataGridWaitingMedicine.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dataGridWaitingMedicine, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void focusOnLast()
        {

            int index = dataGridWaitingMedicine.Items.Count - 2;
            try
            {
                scroll();
                var selectedRow = (DataGridRow)dataGridWaitingMedicine.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridWaitingMedicine.Focus();
            }

        }

        private void focusCurent()
        {
            int index = dataGridWaitingMedicine.SelectedIndex;
            try
            {

                var selectedRow = (DataGridRow)dataGridWaitingMedicine.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridWaitingMedicine.Focus();
            }

        }

        private void checkIfSelected()
        {
            if (dataGridWaitingMedicine.SelectedIndex == -1)
            {
                editOption.IsEnabled = false;
                deleteOption.IsEnabled = false;


            }
            else
            {
                editOption.IsEnabled = true;
                deleteOption.IsEnabled = true;

            }
        }

        private void selectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                statusBar.Text = "Lek: " + WaitingMedicine.ElementAt(dataGridWaitingMedicine.SelectedIndex).CopyrightName;
            }
            catch
            {
                statusBar.Text = "";
            }
            

        }



    }
}
