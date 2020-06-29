
using Model.Accounts;
using Model.Util;
using System;
using System.Collections.Generic;
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

namespace HealthClinic.View.Dialogs.PhysicianDialogs
{
    /// <summary>
    /// Interaction logic for WorkingDialog.xaml
    /// </summary>
    public partial class WorkingDialog : Window
    {
        private Physitian physitianDTO;

        public Physitian PhysitianDTO { get => physitianDTO; set => physitianDTO = value; }

        public WorkingDialog(Physitian physitian)
        {
            this.PhysitianDTO = physitian;
            InitializeComponent();
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.ParseExact(startTextInput.Text, "HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(endTextInput.Text, "HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            TimeInterval interval = new TimeInterval(start, end);
            PhysitianDTO.WorkSchedule = interval;
            
            this.Close();
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            okButton.IsEnabled = isDateGood(startTextInput.Text) && isDateGood(endTextInput.Text);

        }

        private bool isDateGood(string stringDate)
        {
            try
            {
                DateTime myDate = DateTime.ParseExact(stringDate, "HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                return false;
            }
            return true;

        }
    }
}
