using Backend.Dto;
using HealthClinic.Backend.Model.Hospital;
using HealthClinic.Model;
using HealthClinic.View.TableViews;
using Model.Hospital;
using Model.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthClinic.View.Dialogs.RenovationDialogs
{
    /// <summary>
    /// Interaction logic for EditRenovationDialog.xaml
    /// </summary>
    public partial class EditRenovationDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string[] ids;
        private Renovation renovationDTO;
        private Renovation startRenovation;
        private Room roomDTO;
        public string[] Ids
        {
            get => ids; set
            {
                if (value != ids) ids = value;
                OnPropertyChanged("Ids");
            }
        }

        public Renovation RenovationDTO { get => renovationDTO; set => renovationDTO = value; }
        public Room RoomDTO { get => roomDTO; set => roomDTO = value; }

        public EditRenovationDialog(RenovationViewModel renovationModel)
        {
            startRenovation = renovationModel.Renovation;
            this.DataContext = this;
            InitializeComponent();
            startTextInput.Text = renovationModel.StartMoment;
            endTextInput.Text = renovationModel.EndMoment;
            Ids = new string[RoomsTableView._rooms.Count];
            int i = 0;
            int j = 0;
            foreach (Room roomModel in RoomsTableView._rooms)
            {
                if (roomModel.Id.Equals(renovationModel.Renovation.Room.Id))
                {
                    j= i; 
                }
                Ids[i++] = roomModel.Id.ToString();
               
            }

            thisRoomCombo.SelectedIndex = j;

        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            okButton.IsEnabled = isDateGood(startTextInput.Text) && isDateGood(endTextInput.Text);

        }

        private bool isDateGood(string stringDate)
        {
            try
            {
                DateTime myDate = DateTime.ParseExact(stringDate, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return false;
            }
            return true;

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.ParseExact(startTextInput.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endTextInput.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (start > end)
            {
                System.Windows.Forms.MessageBox.Show("Datum kraja renoviranja ne može biti pre datuma početka!");
                return;
            }
            if (start < DateTime.Today)
            {
                System.Windows.Forms.MessageBox.Show("Morate zakazati renoviranje nakon današnjeg dana!");
                return;
            }

            TimeInterval interval = new TimeInterval(start, end);

            Room room = findRumWithID(thisRoomCombo.Text);

            RoomDTO = room;
            RenovationDTO = startRenovation;
            RenovationDTO.Room = RoomDTO;
            RenovationDTO.TimeInterval = interval;

            if (renovationDTO == null)
            {
                Console.WriteLine("NULL RENOVATION");
            }
         
            this.Close();
        }

        private Room findRumWithID(string id)
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

    
    }
}
