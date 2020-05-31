using HealthClinic.View.Commands;
using HealthClinic.View.Dialogs.MedicineDialogs;
using HealthClinic.View.Dialogs.PhysicianDialogs;
using HealthClinic.View.Dialogs.RenovationDialogs;
using HealthClinic.View.Dialogs.RoomDialogs;
using HealthClinic.View.Dialogs.SecretaryDialogs;
using HealthClinic.View.TableViewModels;
using HealthClinic.View.TableViews;
using System;
using System.Collections.Generic;
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
using MenuItem = System.Windows.Controls.MenuItem;
using MessageBox = System.Windows.Forms.MessageBox;

namespace HealthClinic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public enum currentTabIndex : int {
        roomsTabIndex= 0,
        physiciansTabIndex = 1,
        secretariesTabIndex = 2,
        medicineTabIndex = 3,
        renovationsTabIndex = 4

    }
    public partial class MainWindow : Window
    {
        private RoomsTableViewModel _roomsTableViewModel;
        private PhysicianTableViewModel _physicianTableViewModel;
        private SecretaryTableViewModel _secretaryTableViewModel;
        private WaitingMedicineTableViewModel _waitingMedicineTableViewModel;
        private RenovationTableViewModel _renovationTableViewModel;
        private MenuItem _renovationItem;
        private MenuItem _roomEquipmentItem;
        private MenuItem _physicianVacationItem;
        private MenuItem _physicianWorkingItem;
        private int _selectedTabIndex;
        public int SelectedTabIndex { get => _selectedTabIndex; set => _selectedTabIndex = value; }

        public MainWindow()
        {
            InitializeComponent();
            CreateAllMenuItems();
            CreateAllViewModels();
            CreateRoomDataContext();
        }

        private void CreateRoomDataContext()
        {
            DataContext = _roomsTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.roomsTabIndex;
            roomsTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
            addRoomsMenuItems();
        }

        private void CreateAllViewModels()
        {
            _roomsTableViewModel = new RoomsTableViewModel();
            _physicianTableViewModel = new PhysicianTableViewModel();
            _secretaryTableViewModel = new SecretaryTableViewModel();
            _waitingMedicineTableViewModel = new WaitingMedicineTableViewModel();
            _renovationTableViewModel = new RenovationTableViewModel();
        }

        private void CreateAllMenuItems()
        {
            _renovationItem = new MenuItem();
            _renovationItem.Header = "Renoviranja od prostorije";
            _renovationItem.Command = RoutedCommands.RoomRenovationDialog_Command;
            _roomEquipmentItem = new MenuItem();
            _roomEquipmentItem.Header = "Oprema od prostorije";
            _roomEquipmentItem.Command = RoutedCommands.RoomEquipmentDialog_Command;
            _physicianVacationItem = new MenuItem();
            _physicianVacationItem.Header = "Godišnji odmori";
            _physicianVacationItem.Command = RoutedCommands.PhysicianVacationDialog_Command;
            _physicianWorkingItem = new MenuItem();
            _physicianWorkingItem.Header = "Satnica rada";
            _physicianWorkingItem.Command = RoutedCommands.PhysicianWorkingDialog_Command;


        }

        private void Rooms_Executed(object sender, RoutedEventArgs e)
        {
            CreateRoomDataContext();
        }

        private void Physicians_Executed(object sender, RoutedEventArgs e)
        {
            DataContext = _physicianTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.physiciansTabIndex;
            physiciansTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
            addPhysicianMenuItems();

        }

        private void Secretaries_Executed(object sender, RoutedEventArgs e)
        {
            DataContext = _secretaryTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.secretariesTabIndex;
            secretariesTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
        }

        private void WaitingMedicine_Executed(object sender, RoutedEventArgs e)
        {
            DataContext = _waitingMedicineTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.medicineTabIndex;
            medicineTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();

        }

        private void Renovation_Executed(object sender, RoutedEventArgs e)
        {
            DataContext = _renovationTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.renovationsTabIndex;
            renovationTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
            

        }


        private void DeletoRow_Executed(object sender, RoutedEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet?",
                "Brisanje red", MessageBoxButtons.YesNo);
        }
        private void EditRow_Executed(object sender, RoutedEventArgs e)
        {
            switch (SelectedTabIndex)
            {
                case (int)currentTabIndex.roomsTabIndex:
                    NewRoomDialog newRoomDialog = new NewRoomDialog();
                    newRoomDialog.ShowDialog();
                    break;
                case (int)currentTabIndex.physiciansTabIndex:
                    NewPhysicianDialog newPhysicianDialog = new NewPhysicianDialog();
                    newPhysicianDialog.ShowDialog();
                    break;
                case (int)currentTabIndex.secretariesTabIndex:
                    NewSecretaryDialog newSecretaryDialog = new NewSecretaryDialog();
                    newSecretaryDialog.ShowDialog();
                    break;
                case (int)currentTabIndex.medicineTabIndex:
                    NewMedicineDialog newMedicineDialog = new NewMedicineDialog();
                    newMedicineDialog.ShowDialog();
                    break;
                case (int)currentTabIndex.renovationsTabIndex:
                    NewRenovationDialog newRenovationDialog = new NewRenovationDialog();
                    newRenovationDialog.ShowDialog();
                    break;
                default:
                    break;


            }

        }


        private void FocusTable_Executed(object sender, RoutedEventArgs e)
        {
            Tables.Focus();
        }

        private void Search_Executed(object sender, RoutedEventArgs e)
        {
            searchTextBox.Focus();
        }

        private void RoomRenovationDialog_Executed(object sender, RoutedEventArgs e)
        {
            RoomRenovationDialog newRoomRenovationDialog = new RoomRenovationDialog();
            newRoomRenovationDialog.ShowDialog();
        }

        private void RoomEquipmentDialog_Executed(object sender, RoutedEventArgs e)
        {
            RoomEquipmentDialog newRoomsEquipmentDialog = new RoomEquipmentDialog();
            newRoomsEquipmentDialog.ShowDialog();
        }

        private void PhysicianWorkingDialog_Executed(object sender, RoutedEventArgs e)
        {
            WorkingDialog newWorkingDialog = new WorkingDialog();
            newWorkingDialog.ShowDialog();
        }
        private void PhysicianVacationDialog_Executed(object sender, RoutedEventArgs e)
        {
           VacationDialog newVacationDialog = new VacationDialog();
            newVacationDialog.ShowDialog();
        }

        private void Rooms_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkExecutionavAilability(currentTabIndex.roomsTabIndex);
        }

        private void Secretaries_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkExecutionavAilability(currentTabIndex.secretariesTabIndex);
        }

        private void Physicians_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkExecutionavAilability(currentTabIndex.physiciansTabIndex);
        }

        private void WaitingMedicine_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkExecutionavAilability(currentTabIndex.medicineTabIndex);
        }

        private void Renovation_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = checkExecutionavAilability(currentTabIndex.renovationsTabIndex);
        }

        private void RoomRenovationDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SelectedTabIndex==((int)currentTabIndex.roomsTabIndex))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
            //OVDE CE BITI PROVERA DA LI JE SELEKTOVANO U TABELI
        }


        private void RoomsEquipmentDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SelectedTabIndex == ((int)currentTabIndex.roomsTabIndex))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }
        private void PhysicianVacationDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SelectedTabIndex == ((int)currentTabIndex.physiciansTabIndex))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }


        private void PhysicianWorkingDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SelectedTabIndex == ((int)currentTabIndex.physiciansTabIndex))
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }



        private bool checkExecutionavAilability(currentTabIndex tab)
        {
            if (SelectedTabIndex == (int)tab)
            {
                return false;
            }
            else
            {
                return true;
            };
        }

        private void removeAllMenuItems()
        {
            EditSeparator.Visibility = Visibility.Collapsed;
            EditHeader.Items.Remove(_renovationItem);
            EditHeader.Items.Remove(_roomEquipmentItem);
            EditHeader.Items.Remove(_physicianVacationItem);
            EditHeader.Items.Remove(_physicianWorkingItem);

        }

        private void addRoomsMenuItems()
        {
            EditSeparator.Visibility = Visibility.Visible;
            EditHeader.Items.Add(_renovationItem);
            EditHeader.Items.Add(_roomEquipmentItem);
        }

        private void addPhysicianMenuItems()
        {
            EditSeparator.Visibility = Visibility.Visible;
            EditHeader.Items.Add(_physicianVacationItem);
            EditHeader.Items.Add(_physicianWorkingItem);
        }


    }
}
