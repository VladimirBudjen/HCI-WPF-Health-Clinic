using Backend.Controller.SuperintendentControllers;
using Backend.Dto;
using HealthClinic.Backend.Model.Hospital;
using HealthClinic.Model;
using HealthClinic.View.Dialogs.RenovationDialogs;
using Model.Hospital;
using Model.Util;
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
using MessageBox = System.Windows.Forms.MessageBox;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for RenovationTableView.xaml
    /// </summary>
    public partial class RenovationTableView : System.Windows.Controls.UserControl
    {

        public static List<Renovation> _renovations;
        private RenovationController renovationController;

        public ObservableCollection<RenovationViewModel> Renovations
        {
            get;
            set;
        }

        private void refreshTable()
        {
            Renovations.Clear();
            _renovations = renovationController.GetAll();
            foreach (Renovation renovation in _renovations)
            {
                Renovations.Add(new RenovationViewModel(renovation));
            }
        }

        public RenovationTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            renovationController = new RenovationController();
            Renovations = new ObservableCollection<RenovationViewModel>();
            refreshTable();

            MainWindow.deleteSelectedRenovation += deleteRow;
            MainWindow.editRenovation += editRow;
            MainWindow.addRenovation += addRow;
            MainWindow.renovationsSelected += getSelectedRow;

        }
        private int getSelectedRow()
        {
            return dataGridRenovations.SelectedIndex;
        }


        private void deleteRow()
        {
            if (dataGridRenovations.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje red", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        renovationController.DeleteRenovation(Renovations.ElementAt(dataGridRenovations.SelectedIndex).Renovation);
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
            NewRenovationDialog newRenovationDialog = new NewRenovationDialog();
            newRenovationDialog.ShowDialog();
          
            if (newRenovationDialog.RenovationDTO != null)
            {
               
                renovationController.NewRenovation(newRenovationDialog.RenovationDTO);
                refreshTable();

            }
            focusOnLast();

        }

        private void editRow()
        {
            int selected = dataGridRenovations.SelectedIndex;
            if (selected != -1)
            {

                EditRenovationDialog editRenovationDialog = new EditRenovationDialog(Renovations.ElementAt(selected));
                editRenovationDialog.ShowDialog();
                if (editRenovationDialog.RenovationDTO != null)
                {
                    renovationController.EditRenovation(editRenovationDialog.RenovationDTO);
                    refreshTable();

                }

                focusOnLast();
            }

        }

        public static Renovation findRenovation(Room room)
        {

            foreach(Renovation r in _renovations)
            {
                if (r.Room.Id.Equals(room.Id))
                {
                    return r;
                }
            }
            return null;
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
                dataGridRenovations.Focus();
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


            if (dataGridRenovations.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dataGridRenovations, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void focusOnLast()
        {

            int index = dataGridRenovations.Items.Count - 2;
            try
            {
                scroll();
                var selectedRow = (DataGridRow)dataGridRenovations.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridRenovations.Focus();
            }

        }

        private void focusCurent()
        {
            int index = dataGridRenovations.SelectedIndex;
            try
            {

                var selectedRow = (DataGridRow)dataGridRenovations.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridRenovations.Focus();
            }

        }

      

        private void checkIfSelected()
        {
            if (dataGridRenovations.SelectedIndex == -1)
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
                statusBar.Text = "Renoviranje: Soba: " + Renovations.ElementAt(dataGridRenovations.SelectedIndex).Room + " / "
            + Renovations.ElementAt(dataGridRenovations.SelectedIndex).StartMoment + " / "
            + Renovations.ElementAt(dataGridRenovations.SelectedIndex).EndMoment;

            }
            catch
            {
                statusBar.Text = "";
            }


        }

    }
}
