using Backend.Controller.SuperintendentControllers;
using HealthClinic.View.Dialogs.MedicineDialogs;
using HealthClinic.ViewModels;
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
    /// Interaction logic for RejectedMedicineTable.xaml
    /// </summary>
    public partial class RejectedMedicineTablePage : Page
    {
 

        public static List<Rejection> _rejections;
        private SuperintendentMedicineController controller;
        public ObservableCollection<RejectionViewModel> Rejections
        {
            get;
            set;
        }

        private void refreshTable()
        {
            Rejections.Clear();
            _rejections = controller.getAllRejected();
            foreach (Rejection rejection in _rejections)
            {
                Rejections.Add(new RejectionViewModel(rejection));
            }
        }

        public RejectedMedicineTablePage()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new SuperintendentMedicineController();
            //addRejectionsToRepository();
            Rejections = new ObservableCollection<RejectionViewModel>();
            refreshTable();
            MainWindow.deleteSelectedRejection += deleteRow;
            MainWindow.editRejection += editRow;
            MainWindow.rejectionSelected += getSelectedRow;
        }

        private int getSelectedRow()
        {
            return dataGridWaitingMedicine.SelectedIndex;
        }

        private void addRejectionsToRepository()
        {
            controller.NewRejection(new Rejection("eeee", new Medicine("hoho", 
                "hihi", new MedicineManufacturer("ee"), new MedicineType("JOJO"))));
            controller.NewRejection(new Rejection("11", new Medicine("22",
                "33", new MedicineManufacturer("44"), new MedicineType("55"))));
            controller.NewRejection(new Rejection("x", new Medicine("xx",
                "xxx", new MedicineManufacturer("xxxx"), new MedicineType("xxxxxx"))));


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
                        controller.DeleteRejection(Rejections.ElementAt(index).Rejection);
                        refreshTable();
                        break;
                    default:
                        break;
                }
                focusCurent();
            }

        }

        private void editRow()
        {
            int selected = dataGridWaitingMedicine.SelectedIndex;
            if (selected != -1)
            {

                EditMedicineDialog editMedicineDialog = new EditMedicineDialog(Rejections.ElementAt(selected).Medicine);
                editMedicineDialog.ShowDialog();
                if (editMedicineDialog.MedicineDTO != null)
                {
                    controller.NewWaitinMedicine(editMedicineDialog.MedicineDTO);
                    controller.DeleteRejection(Rejections.ElementAt(selected).Rejection);
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
                statusBar.Text = "Lek: " + Rejections.ElementAt(dataGridWaitingMedicine.SelectedIndex).CopyrightName;
            }
            catch
            {
                statusBar.Text = "";
            }


        }



    }
}

