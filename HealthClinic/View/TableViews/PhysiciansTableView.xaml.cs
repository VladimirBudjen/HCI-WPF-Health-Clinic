
using Backend.Controller.SuperintendentControllers;
using HealthClinic.Backend.Controller.SuperintendentControllers;
using HealthClinic.Model;
using HealthClinic.View.Dialogs.PhysicianDialogs;
using Model.Accounts;
using Model.Util;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for PhysiciansTableView.xaml
    /// </summary>
    public partial class PhysiciansTableView : System.Windows.Controls.UserControl
    {
        public static List<Physitian> _physitians;
        private SuperiIntendentPhysiciansController controller;

        public ObservableCollection<PhysicianViewModel> Physicians
        {
            get;
            set;
        }

        private void refreshTable()
        {
            Physicians.Clear();
            _physitians = controller.GetAllPhysitians();
            foreach (Physitian physitian in _physitians)
            {
                Physicians.Add(new PhysicianViewModel(physitian));
            }
        }


        public PhysiciansTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new SuperiIntendentPhysiciansController();
            Physicians = new ObservableCollection<PhysicianViewModel>();
            refreshTable();
            MainWindow.deleteSelectedPhysician += deleteRow;
            MainWindow.addPhysician += addRow;
            MainWindow.editPhysician += editRow;
            MainWindow.workingHours += setWorkingHours;
            MainWindow.vacation += setVacation;
            MainWindow.physiciansSelected += getSelectedRow;

        }

        public int getSelectedRow()
        {
            return dataGridPhysicians.SelectedIndex;
        }


        private void deleteRow()
        {
            int index = dataGridPhysicians.SelectedIndex;
            if (index != -1)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        controller.DeletePhysitian(Physicians.ElementAt(index).Physitian);
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
 
            NewPhysicianDialog newPhysicianDialog = new NewPhysicianDialog();
            newPhysicianDialog.ShowDialog();

            if (newPhysicianDialog.PhysicianDTO != null)
            {
                controller.NewPhysician(newPhysicianDialog.PhysicianDTO);
                refreshTable();
                focusOnLast();
            }

        }

        private void editRow()
        {
            int selected = dataGridPhysicians.SelectedIndex;
            if (selected != -1)
            {

                EditPhysicianDialog editPhysicianDialog = new EditPhysicianDialog(Physicians.ElementAt(selected).Physitian);
                editPhysicianDialog.ShowDialog();
                if (editPhysicianDialog.PhysicianDTO != null)
                {
                    controller.EditPhysitian(editPhysicianDialog.PhysicianDTO);
                    refreshTable();
                }
                focusOnLast();
            }
        }

        private void setWorkingHours()
        {
            int selected = dataGridPhysicians.SelectedIndex;
            if (selected != -1)
            {

                WorkingDialog workingDialog = new WorkingDialog(Physicians.ElementAt(selected).Physitian);
                workingDialog.ShowDialog();
                if (workingDialog.PhysitianDTO != null)
                {
                    PhysicianViewModel physicianModel = new PhysicianViewModel(workingDialog.PhysitianDTO);
                    Physicians.RemoveAt(selected);
                    Physicians.Add(physicianModel);

                }
                focusOnLast();

            }
        }

        private void setVacation()
        {
            int selected = dataGridPhysicians.SelectedIndex;
            if (selected != -1)
            {

                VacationDialog vacationDialog = new VacationDialog(Physicians.ElementAt(selected).Physitian);
                vacationDialog.ShowDialog();
                if (vacationDialog.PhysitianDTO != null)
                {
                    controller.EditPhysitian(vacationDialog.PhysitianDTO);
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
                dataGridPhysicians.Focus();
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


        private void vacation(object sender, System.Windows.RoutedEventArgs e)
        {
            setVacation();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void working(object sender, System.Windows.RoutedEventArgs e)
        {
            setWorkingHours();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }


        private void scroll()
        {


            if (dataGridPhysicians.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dataGridPhysicians, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void focusOnLast()
        {

            int index = dataGridPhysicians.Items.Count - 2;
            try
            {
                scroll();
                var selectedRow = (DataGridRow)dataGridPhysicians.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridPhysicians.Focus();
            }

        }

        private void focusCurent()
        {
            int index = dataGridPhysicians.SelectedIndex;
            try
            {

                var selectedRow = (DataGridRow)dataGridPhysicians.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridPhysicians.Focus();
            }

        }

        private void checkIfSelected()
        {
            if (dataGridPhysicians.SelectedIndex == -1)
            {
                editOption.IsEnabled = false;
                deleteOption.IsEnabled = false;
                vacationOption.IsEnabled = false;
                workOption.IsEnabled = false;

            }
            else
            {
                editOption.IsEnabled = true;
                deleteOption.IsEnabled = true;
                vacationOption.IsEnabled = true;
                workOption.IsEnabled = true;
            }
        }

        private void selectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                statusBar.Text = "JMBG: " + Physicians.ElementAt(dataGridPhysicians.SelectedIndex).Jmbg;
            }
            catch
            {
                statusBar.Text = "";
            }

        }
    }
}
