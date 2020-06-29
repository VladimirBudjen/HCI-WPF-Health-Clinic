
using Backend.Controller.SuperintendentControllers;
using HealthClinic.Model;
using HealthClinic.View.TableViews;
using Model.Hospital;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthClinic.View.Dialogs.RoomDialogs
{
    /// <summary>
    /// Interaction logic for RoomEquipmentDialog.xaml
    /// </summary>
  
    public partial class RoomEquipmentDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<EquipmentViewModel> _equipmentModels { get; set; }
        public List<Equipment> _equipment;
        private Room _roomDTO;
        private string[] _ids;
        private RoomController roomController;
        private string[] combosEquipment;
        private EquipmentController equipmentController;

        private void refreshTable()
        {
            _equipmentModels.Clear();
            _equipment = roomController.GetAllEquipment(RoomDTO);
            EquipmentModels = createEquipmentModels(_equipment);
        }

        public ObservableCollection<EquipmentViewModel> EquipmentModels
        {
            get => _equipmentModels; set
            {
                if (value != _equipmentModels) _equipmentModels = value;
                OnPropertyChanged("EquipmentModels");
            }
        }



        public string[] Ids
        {
            get => _ids; set
            {
                if (value != _ids) _ids = value;
                OnPropertyChanged("Ids");
            }
        }

        public Room RoomDTO { get => _roomDTO; set => _roomDTO = value; }
        public string[] CombosEquipment { get => combosEquipment; set
            {
                if (value != combosEquipment) combosEquipment = value;
                OnPropertyChanged("CombosEquipment");
            }
        }

        public RoomEquipmentDialog(Room room)
        {
            InitializeComponent();
            this.DataContext = this;
            RoomDTO = room;
            roomController = new RoomController();
            equipmentController = new EquipmentController();
            //AddEquipmentToRepositorium();

            setComboString();
            nameInput.SelectedIndex = 0;

            _equipmentModels = new ObservableCollection<EquipmentViewModel>();


            Ids = new string[RoomsTableView._rooms.Count];
            int i = 0;
            foreach (Room roomModel in RoomsTableView._rooms)
            {
                Ids[i++] = roomModel.Id.ToString();
            }
            refreshTable();
        }

        private void AddEquipmentToRepositorium()
        {
            equipmentController.NewEquipment(new Equipment("Špric", "0"));
            equipmentController.NewEquipment(new Equipment("Ladica", "4"));
            equipmentController.NewEquipment(new Bed("Krevet sa sisaljkom", "3"));
        }

        private void setComboString()
        {
            List<Equipment> equipmentList = equipmentController.GetAll();
            CombosEquipment = new string[equipmentList.Count];
            int i = 0;
            foreach (Equipment eq in equipmentList)
            {
                CombosEquipment[i] = eq.Name;
                i++;
            }

        }

        private ObservableCollection<EquipmentViewModel> createEquipmentModels(List<Equipment> equipmentList)
        {
            ObservableCollection<EquipmentViewModel> equipmentModels = new ObservableCollection<EquipmentViewModel>();
            foreach (Equipment eq in equipmentList)
            {
                equipmentModels.Add(new EquipmentViewModel(eq));
            }
            return equipmentModels;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string serial = Guid.NewGuid().ToString();
            string id = serial.Substring(0, 5);
            roomController.AddEquipment(new Equipment(serial, nameInput.Text, id), RoomDTO);
            refreshTable();
        }


        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            deleteRow();
        }

        private void deleteRow()
        {
            int selecteIndex = dataGrid.SelectedIndex;
            if (selecteIndex != -1)
            {

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete izabranu opremu?",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        roomController.RemoveEquipmentById(RoomDTO.Equipment.ElementAt(selecteIndex).SerialNumber, RoomDTO);
                        refreshTable();
                        break;
                    default:
                        break;
                }

            }
        }

            

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DeleteButton.IsEnabled = dataGrid.SelectedIndex != -1;
            if (roomComboBox.SelectedIndex!=-1)
            {
                moveButton.IsEnabled = dataGrid.SelectedIndex != -1;
            }
        }

        private void deleteKeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Delete))
            {
                deleteRow();
            }
        }
 
        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            int selecteIndex = dataGrid.SelectedIndex;
            if (selecteIndex != -1)
            {

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da premestite izabranu opremu?",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        Equipment selectedEquipment = new Equipment(RoomDTO.Equipment.ElementAt(selecteIndex));
                        roomController.RemoveEquipmentById(RoomDTO.Equipment.ElementAt(selecteIndex).SerialNumber, RoomDTO);
                        Room r = RoomsTableView.findRoomWithID(roomComboBox.Text);
                        roomController.AddEquipment(selectedEquipment, r);
                        EquipmentModels = createEquipmentModels(RoomDTO.Equipment);
                        refreshTable();
                        break;
                    default:
                        break;
                }

            }
        }

    
    }
}
