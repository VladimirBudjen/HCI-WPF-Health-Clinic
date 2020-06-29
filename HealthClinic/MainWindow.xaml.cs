using HealthClinic.View.Commands;
using HealthClinic.View.TableViewModels;
using System.Windows;
using System.Windows.Input;
using MenuItem = System.Windows.Controls.MenuItem;
using System.Threading;
using HealthClinic.View.TableViews;

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
        public delegate void mainVoidDelegate();
        public delegate int mainIntDelegate();



        private int _selectedTabIndex;
        private int _selectedTableRowIndex;
        public int SelectedTabIndex { get => _selectedTabIndex; set => _selectedTabIndex = value; }
        public int SelectedTableRowIndex { get => _selectedTableRowIndex; set => _selectedTableRowIndex = value; }

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
            SelectedTableRowIndex = -1;
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

        public void setAllDelegatesToNull()
        {
            deleteSelectedRoom = null;
            deleteSelectedPhysician = null;
            deleteSelectedSecretary = null;
            deleteSelectedMedicine = null;
            deleteSelectedRenovation = null;
            editRoom = null;
            editPhysician = null;
            editSecretary = null;
            editMedicine = null;
            editRenovation = null;
            addRoom = null;
            addPhysician = null;
            addSecretary = null;
            addMedicine = null;
            addRenovation = null;
            roomRenovation = null;
            roomEquipment = null;
            workingHours = null;
            vacation = null;
            roomsSelected = null;
            physiciansSelected = null;
            secretariesSelected = null;
            medicineSelected = null;
            renovationsSelected = null;
            deleteSelectedRejection = null;
            rejectionSelected = null;
            editRejection = null;
            deleteApprovedMedicine = null;
            approvedMedicineSelected = null;
        }

    private void Rooms_Executed(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            CreateRoomDataContext();
            
        }

        private void Physicians_Executed(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            DataContext = _physicianTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.physiciansTabIndex;
            physiciansTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
            addPhysicianMenuItems();

        }

        private void Secretaries_Executed(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            DataContext = _secretaryTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.secretariesTabIndex;
            secretariesTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
        }

        private void WaitingMedicine_Executed(object sender, RoutedEventArgs e)
        {
            MedicineTableView.setAllDelegatesToNull += setAllDelegatesToNull;
            DataContext = _waitingMedicineTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.medicineTabIndex;
            medicineTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();

        }

        private void Renovation_Executed(object sender, RoutedEventArgs e)
        {
            setAllDelegatesToNull();
            DataContext = _renovationTableViewModel;
            SelectedTabIndex = (int)currentTabIndex.renovationsTabIndex;
            renovationTab.IsChecked = true;
            Tables.Focus();
            removeAllMenuItems();
            

        }


  
        public static event mainVoidDelegate deleteSelectedRoom;
        public static event mainVoidDelegate deleteSelectedPhysician;
        public static event mainVoidDelegate deleteSelectedSecretary;
        public static event mainVoidDelegate deleteSelectedMedicine;
        public static event mainVoidDelegate deleteSelectedRenovation;
        public static event mainVoidDelegate deleteSelectedRejection;
        public static event mainVoidDelegate deleteApprovedMedicine;

        private void DeletoRow_Executed(object sender, RoutedEventArgs e)
        {
            switch (SelectedTabIndex)
            {
                case (int)currentTabIndex.roomsTabIndex:
                    deleteSelectedRoom();
                    break;
                case (int)currentTabIndex.physiciansTabIndex:
                    deleteSelectedPhysician();
                    break;
                case (int)currentTabIndex.secretariesTabIndex:
                    deleteSelectedSecretary();
                    break;
                case (int)currentTabIndex.medicineTabIndex:
                    switch (MedicineTableView.selectedRadio)
                    {
                        case 0:
                            deleteSelectedMedicine();
                            break;
                        case 1:
                            deleteSelectedRejection();
                            break;
                        case 2:
                            deleteApprovedMedicine();
                            break;
                    }
                    
                    break;
                case (int)currentTabIndex.renovationsTabIndex:
                    deleteSelectedRenovation();
                    break;
                default:
                    break;
            }
            
        }


  
        public static event mainVoidDelegate editRoom;
        public static event mainVoidDelegate editPhysician;
        public static event mainVoidDelegate editSecretary;
        public static event mainVoidDelegate editMedicine;
        public static event mainVoidDelegate editRejection;
        public static event mainVoidDelegate editRenovation;


        private void EditRow_Executed(object sender, RoutedEventArgs e)
        {
            switch (SelectedTabIndex)
            {
                case (int)currentTabIndex.roomsTabIndex:
                    editRoom();
                    break;
                case (int)currentTabIndex.physiciansTabIndex:
                    editPhysician();
                    break;
                case (int)currentTabIndex.secretariesTabIndex:
                    editSecretary();
                    break;
                case (int)currentTabIndex.medicineTabIndex:
                    switch (MedicineTableView.selectedRadio)
                    {
                        case 0:
                            editMedicine();
                            break;
                        case 1:
                            editRejection();
                            break;
                        case 2:
                            break;
                    }

                    break;
                case (int)currentTabIndex.renovationsTabIndex:
                    editRenovation();
                    break;
                default:
                    break;


            }

        }


        public static event mainVoidDelegate addRoom;
        public static event mainVoidDelegate addPhysician;
        public static event mainVoidDelegate addSecretary;
        public static event mainVoidDelegate addMedicine;
        public static event mainVoidDelegate addRenovation;

        private void AddRow_Executed(object sender, RoutedEventArgs e)
        {
            switch (SelectedTabIndex)
            {
                case (int)currentTabIndex.roomsTabIndex:
                    addRoom();
                    break;
                case (int)currentTabIndex.physiciansTabIndex:
                    addPhysician();
                    break;
                case (int)currentTabIndex.secretariesTabIndex:
                    addSecretary();
                    break;
                case (int)currentTabIndex.medicineTabIndex:
                    addMedicine();
                    break;
                case (int)currentTabIndex.renovationsTabIndex:
                    addRenovation();
                    break;
                default:
                    break;


            }

        }


      

        private void FocusTable_Executed(object sender, RoutedEventArgs e)
        {
            Tables.Focus();
        }


        public static event mainVoidDelegate roomRenovation;
        public static bool isRoomRenovationNull()
        {
            return roomEquipment == null;
        }
        private void RoomRenovationDialog_Executed(object sender, RoutedEventArgs e)
        {
            roomRenovation();
        }


        public static event mainVoidDelegate roomEquipment;
   


        private void RoomEquipmentDialog_Executed(object sender, RoutedEventArgs e)
        {

            roomEquipment();
        }



        public static event mainVoidDelegate workingHours;

        private void PhysicianWorkingDialog_Executed(object sender, RoutedEventArgs e)
        {
            workingHours();
        }

      
        public static event mainVoidDelegate vacation;

        private void PhysicianVacationDialog_Executed(object sender, RoutedEventArgs e)
        {
            vacation();
          
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
            if (SelectedTabIndex==((int)currentTabIndex.roomsTabIndex) && getSelecteRow() != -1)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }


        private void RoomsEquipmentDialog_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (SelectedTabIndex == ((int)currentTabIndex.roomsTabIndex) && getSelecteRow() != -1)
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
            if (SelectedTabIndex == ((int)currentTabIndex.physiciansTabIndex) && getSelecteRow() != -1)
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
            if (SelectedTabIndex == ((int)currentTabIndex.physiciansTabIndex) && getSelecteRow() != -1)
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


        public static event mainIntDelegate roomsSelected;
        public static event mainIntDelegate physiciansSelected;
        public static event mainIntDelegate secretariesSelected;
        public static event mainIntDelegate medicineSelected;
        public static event mainIntDelegate rejectionSelected;
        public static event mainIntDelegate renovationsSelected;
        public static event mainIntDelegate approvedMedicineSelected;


        private int getSelecteRow()
        {
            
            switch (SelectedTabIndex)
            {
                case (int)currentTabIndex.roomsTabIndex:
                    SelectedTableRowIndex = roomsSelected();
                    break;
                case (int)currentTabIndex.physiciansTabIndex:
                    SelectedTableRowIndex = physiciansSelected();
                    break;
                case (int)currentTabIndex.secretariesTabIndex:
                    SelectedTableRowIndex = secretariesSelected();
                    break;
                case (int)currentTabIndex.medicineTabIndex:
                    switch (MedicineTableView.selectedRadio)
                    {
                        case 0:
                            SelectedTableRowIndex = medicineSelected();
                            break;
                        case 1:
                            SelectedTableRowIndex = rejectionSelected();
                            break;
                        case 2:
                            SelectedTableRowIndex = approvedMedicineSelected();
                            break;
                    }

                    break;
                case (int)currentTabIndex.renovationsTabIndex:
                    SelectedTableRowIndex = renovationsSelected();
                    break;
                default:
                    SelectedTableRowIndex = -1;
                    break;
            }
            return SelectedTableRowIndex;
        }


        private void Demo_Click(object sender, RoutedEventArgs e)
        {
            
            Thread.Sleep(500);
            Physicians_Executed(sender, e);
            
            Thread.Sleep(2000);
            AddRow_Executed(sender, e);
  
        }

        private void Help(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:\programi\c#\HCI\Projekat\HealthClinic\HealthClinic\Static\Help.pdf");
        }

        private void Edit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool medicineBool = true;
            if (SelectedTabIndex == (int)currentTabIndex.medicineTabIndex)
            {
                switch (MedicineTableView.selectedRadio)
                {
                    case 0:
                        medicineBool = true;
                        break;
                    case 1:
                        medicineBool = true;
                        break;
                    case 2:
                        medicineBool = false;
                        break;
                }

            }

            e.CanExecute = getSelecteRow() != -1 && medicineBool;
        }

        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = getSelecteRow() != -1;
        }

        private void Add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            bool medicineBool = true;
            if (SelectedTabIndex == (int)currentTabIndex.medicineTabIndex)
            {
                switch (MedicineTableView.selectedRadio)
                {
                    case 0:
                        medicineBool = true;
                        break;
                    case 1:
                        medicineBool = false;
                        break;
                    case 2:
                        medicineBool = false;
                        break;
                }

            }

            e.CanExecute = medicineBool;
        }
    }
}
