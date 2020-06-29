using HealthClinic.Backend.Controller.SuperintendentControllers;
using HealthClinic.Model;
using HealthClinic.View.Dialogs.SecretaryDialogs;
using Model.Accounts;
using Model.Util;
using Syncfusion.XPS;
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
    /// Interaction logic for SecretaryTableView.xaml
    /// </summary>
    public partial class SecretaryTableView : System.Windows.Controls.UserControl
    {
        public static List<Secretary> _secretaries;
        private SuperIntendentSecretariesController controller;

        public ObservableCollection<SecretaryViewModel> Secretaries
        {
            get;
            set;
        }

        private void refreshTable()
        {
            Secretaries.Clear();
            _secretaries = controller.GetAllSecretaries();
            foreach (Secretary secretary in _secretaries)
            {
                Secretaries.Add(new SecretaryViewModel(secretary));
            }
        }
        public SecretaryTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new SuperIntendentSecretariesController();
            Secretaries = new ObservableCollection<SecretaryViewModel>();
            refreshTable();
            MainWindow.deleteSelectedSecretary += deleteRow;
            MainWindow.addSecretary += addRow;
            MainWindow.editSecretary += editRow;
            MainWindow.secretariesSelected += getSelectedRow;
        }
        private int getSelectedRow()
        {
            return dataGridSecretaries.SelectedIndex;
        }

        private void deleteRow()
        {
            int index = dataGridSecretaries.SelectedIndex;
            if (index != -1)
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        controller.DeleteSecretary(Secretaries.ElementAt(index).Secretary);
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

            NewSecretaryDialog newSecretaryDialog = new NewSecretaryDialog();
            newSecretaryDialog.ShowDialog();

            if (newSecretaryDialog.SecretaryDTO != null)
            {
                controller.NewSecretary(newSecretaryDialog.SecretaryDTO);
                refreshTable();
                focusOnLast();
            }
            focusOnLast();
        }



        private void editRow()
        {
            int selected = dataGridSecretaries.SelectedIndex;
            if (selected != -1)
            {

                EditSecretaryDialog editSecretariesDialog = new EditSecretaryDialog(Secretaries.ElementAt(selected).Secretary);
                editSecretariesDialog.ShowDialog();
                if (editSecretariesDialog.SecretaryDTO != null)
                {
                    controller.EditSecretary(editSecretariesDialog.SecretaryDTO);
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
                dataGridSecretaries.Focus();
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
            if (dataGridSecretaries.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dataGridSecretaries, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void focusOnLast()
        {

            int index = dataGridSecretaries.Items.Count - 2;
            try
            {
                scroll();
                var selectedRow = (DataGridRow)dataGridSecretaries.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridSecretaries.Focus();
            }

        }

        private void focusCurent()
        {
            int index = dataGridSecretaries.SelectedIndex;
            try
            {

                var selectedRow = (DataGridRow)dataGridSecretaries.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridSecretaries.Focus();
            }

        }

        private void checkIfSelected()
        {
            if (dataGridSecretaries.SelectedIndex == -1)
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
                statusBar.Text = "JMBG: " + Secretaries.ElementAt(dataGridSecretaries.SelectedIndex).Jmbg;
            }
            catch
            {
                statusBar.Text = "";
            }


        }


    }
}
