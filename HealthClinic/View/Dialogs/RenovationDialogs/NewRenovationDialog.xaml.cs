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
    /// Interaction logic for NewRenovationDialog.xaml
    /// </summary>
    /// 
   

    public partial class NewRenovationDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string[] ids;
        private Renovation renovationDTO;
        private Room roomDTO;

        public string[] Ids { get => ids; set
            {
                if (value != ids) ids = value;
                OnPropertyChanged("Ids");
            }
        }

        public Renovation RenovationDTO { get => renovationDTO; set => renovationDTO = value; }
        public Room RoomDTO { get => roomDTO; set => roomDTO = value; }

        public NewRenovationDialog()
        {
            this.DataContext = this;
            InitializeComponent();
            Ids = new string[RoomsTableView._rooms.Count];
            int i = 0;
            foreach (Room room in RoomsTableView._rooms)
            {
                Ids[i++]= room.Id.ToString();
            }
            thisRoomCombo.SelectedIndex = 0;
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


            RenovationDTO = new Renovation(room,interval);
            RoomDTO = room;
  
            this.Close();
            
           
        }

        private Room findRumWithID(string id)
        {
            Room room = null;
            foreach (Room r in RoomsTableView._rooms)
            {
                if (r.Id.ToString().Equals(id))
                {
            
                    room = r;
                }
               

            }
            return room;
        }

    }
}
