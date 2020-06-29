using Backend.Dto;
using Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;
using HealthClinic.Backend.Model.Hospital;
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

namespace HealthClinic.View.Dialogs.RoomDialogs
{
    /// <summary>
    /// Interaction logic for RoomRenovationDialog.xaml
    /// </summary>
    public partial class RoomRenovationDialog : Window, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private Renovation renovationDTO;
        private Room room;

        public Renovation RenovationDTO { get => renovationDTO; set => renovationDTO = value; }

        public RoomRenovationDialog(Room room)
        {
            this.DataContext = this;
            InitializeComponent();
            this.room = room;
            Console.WriteLine(room.Id);
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
                System.Windows.Forms.MessageBox.Show("Datum početka renoviranja ne moeže piti pre današnjeg dana!");
                return;
            }


            TimeInterval interval = new TimeInterval(start, end);
            RoomAvailabilityService availabilityService = new RoomAvailabilityService();
            if (!availabilityService.IsRoomAvailable(room, interval))
            {
                System.Windows.Forms.MessageBox.Show("Prostorija je zauzeta u datom periodu!");
                return;
            }
            RenovationDTO = new Renovation(room ,interval);
           
            this.Close();
        }

    }
}
