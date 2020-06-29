using Backend.Controller.SuperintendentControllers;
using HealthClinic.Model;
using HealthClinic.View.Dialogs.MedicineDialogs;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for WaitingMedicinePage.xaml
    /// </summary>
    public partial class WaitingMedicinePage : Page
    {

        public static List<Medicine> _medicines;
        private SuperintendentMedicineController controller;
        public ObservableCollection<MedicineViewModel> WaitingMedicine
        {
            get;
            set;
        }

        private void refreshTable()
        {
            WaitingMedicine.Clear();
            _medicines = controller.getAllWaiting();
            foreach (Medicine medicine in _medicines)
            {
                WaitingMedicine.Add(new MedicineViewModel(medicine));
            }
        }

        public WaitingMedicinePage()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new SuperintendentMedicineController();
            WaitingMedicine = new ObservableCollection<MedicineViewModel>();
            refreshTable();
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
            int index = dataGridWaitingMedicine.SelectedIndex;
            if (index != -1)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje red", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        controller.DeleteWaitingMedicine(WaitingMedicine.ElementAt(index).Medicine);
                        refreshTable();
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
                controller.NewWaitinMedicine(newMedicineDialog.MedicineDTO);
                refreshTable();
                focusOnLast();

            }

            focusOnLast();
        }

        private void editRow()
        {
            int selected = dataGridWaitingMedicine.SelectedIndex;
            if (selected != -1)
            {

                EditMedicineDialog editMedicineDialog = new EditMedicineDialog(WaitingMedicine.ElementAt(selected).Medicine);
                editMedicineDialog.ShowDialog();
                if (editMedicineDialog.MedicineDTO != null)
                {
                    controller.EditWaitingMedicine(editMedicineDialog.MedicineDTO);
                    refreshTable();

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

