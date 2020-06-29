
using Backend.Controller.SuperintendentControllers;
using HealthClinic.Model;
using HealthClinic.View.Dialogs.RoomDialogs;
using Model.Hospital;
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
    /// Interaction logic for RoomsTableView.xaml
    /// </summary>
    public partial class RoomsTableView : System.Windows.Controls.UserControl
    {

       
       
        private DataGridView myDataGridView;
        public static List<Room> _rooms;
        private RoomController roomController;
        private RenovationController renovationController;

        public ObservableCollection<RoomViewModel> Rooms
        {
            get;
            set;
        }

        private void refreshTable()
        {
            Rooms.Clear();
            _rooms = roomController.GetAll();
            foreach (Room room in _rooms)
            {
                Rooms.Add(new RoomViewModel(room));
            }
        }

        public RoomsTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            roomController = new RoomController();
            renovationController = new RenovationController();
            Rooms = new ObservableCollection<RoomViewModel>();
            
            refreshTable();

            dataGridRooms.SelectedIndex = 0;
            MainWindow.deleteSelectedRoom += deleteRow;
            MainWindow.addRoom += addRow;
            MainWindow.editRoom += editRow;
            MainWindow.roomRenovation += renovateSelectedRoom;
            MainWindow.roomEquipment += equipmentOfSelectedRoom;
            MainWindow.roomsSelected += getSelectedRow;
            myDataGridView = new DataGridView();
            myDataGridView.DataSource = dataGridRooms;
        }
        private int getSelectedRow()
        {
            return dataGridRooms.SelectedIndex;
        }

        
        private void deleteRow()
        {
            if (dataGridRooms.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da želite da izbrišete entitet? Sva renoviranja date prostorije će biti obrisana.",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        RenovationController equipmentController = new RenovationController();
                        equipmentController.DeleteRenovationsWithRoom(Rooms.ElementAt(dataGridRooms.SelectedIndex).Room);
                        roomController.DeleteRoom(Rooms.ElementAt(dataGridRooms.SelectedIndex).Room);
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
            NewRoomDialog newRoomDialog = new NewRoomDialog();
            newRoomDialog.ShowDialog();
            if (newRoomDialog.RoomDTO != null)
            {
                RoomViewModel roomModel = new RoomViewModel(newRoomDialog.RoomDTO);
                roomController.NewRoom(roomModel.Room);
                refreshTable();
            }
            focusOnLast();
          
        }

        private void editRow()
        {
            int selected = dataGridRooms.SelectedIndex;
            if (selected != -1)
            {
           
                EditRoomDialog editRoomDialog = new EditRoomDialog(Rooms.ElementAt(selected).Room);
                editRoomDialog.ShowDialog();
                if (editRoomDialog.RoomDTO != null)
                {

                    
                    roomController.EditRoom(editRoomDialog.RoomDTO);
                    refreshTable();
     
                }

                focusOnLast();
            }


        }
        private void renovateSelectedRoom()
        {
            int selected = dataGridRooms.SelectedIndex;
            if (selected != -1)
            {
                Console.WriteLine(selected + "JE SELEKTOVAN");
                RoomRenovationDialog renovateSelectedDialog = new RoomRenovationDialog(Rooms.ElementAt(selected).Room);
                renovateSelectedDialog.ShowDialog();
                if (renovateSelectedDialog.RenovationDTO != null)
                {
                    renovationController.NewRenovation(renovateSelectedDialog.RenovationDTO);
                }
                renovateSelectedDialog.Close();

            }
         

        }


        private void equipmentOfSelectedRoom()
        {
            int selected = dataGridRooms.SelectedIndex;
            if (selected != -1)
            {

                RoomEquipmentDialog equipmentDialog = new RoomEquipmentDialog(Rooms.ElementAt(selected).Room);
                equipmentDialog.ShowDialog();
                if (equipmentDialog.RoomDTO != null)
                {

                    roomController.EditRoom(equipmentDialog.RoomDTO);
                    refreshTable();

                }
                focusOnLast();
            }
        }

        public static Room findRoomWithID(string id)
        {
            Room room = null;
            foreach (Room roomModel in RoomsTableView._rooms)
            {
                if (roomModel.Id.ToString().Equals(id))
                {
                    room = roomModel;
                }
            }
            return room;
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
                dataGridRooms.Focus();
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
            int index = dataGridRooms.SelectedIndex;
            deleteRow();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void equipmentOptionClick(object sender, System.Windows.RoutedEventArgs e)
        {
            equipmentOfSelectedRoom();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;


        }

        private void renovationOptionClick(object sender, System.Windows.RoutedEventArgs e)
        {
            renovateSelectedRoom();
            menu.Visibility = System.Windows.Visibility.Collapsed;
            menu.IsEnabled = false;

        }

        private void scroll()
        {
                

            if (dataGridRooms.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(dataGridRooms, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll != null) scroll.ScrollToEnd();
                }
            }
        }

        private void focusOnLast()
        {

            int index = dataGridRooms.Items.Count - 2;
            try
            {
                scroll();
                var selectedRow = (DataGridRow)dataGridRooms.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridRooms.Focus();
            }

        }

        private void focusCurent()
        {
            int index = dataGridRooms.SelectedIndex;
            try
            {

                var selectedRow = (DataGridRow)dataGridRooms.ItemContainerGenerator.ContainerFromIndex(index);
                FocusManager.SetIsFocusScope(selectedRow, true);
                FocusManager.SetFocusedElement(selectedRow, selectedRow);
            }
            catch
            {
                dataGridRooms.Focus();
            }

        }


        private void checkIfSelected()
        {
            if (dataGridRooms.SelectedIndex == -1)
            {
                editOption.IsEnabled = false;
                deleteOption.IsEnabled = false;
                renovationOption.IsEnabled = false;
                equipmentOption.IsEnabled = false;


            }
            else
            {
                editOption.IsEnabled = true;
                deleteOption.IsEnabled = true;
                renovationOption.IsEnabled = true;
                equipmentOption.IsEnabled = true;
            }
        }

        private void selectionChanged_Event(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                statusBar.Text = "ID: " + Rooms.ElementAt(dataGridRooms.SelectedIndex).Id;
            }
            catch
            {
                statusBar.Text = "";
            }
        }
    }
}


