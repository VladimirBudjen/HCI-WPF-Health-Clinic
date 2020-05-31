using HealthClinic.Model;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for RenovationTableView.xaml
    /// </summary>
    public partial class RenovationTableView : UserControl
    {
        public ObservableCollection<RenovationModel> Renovations
        {
            get;
            set;
        }
        public RenovationTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            Renovations = new ObservableCollection<RenovationModel>();
            for (int i = 0; i < 30; i++)
            {
                Renovations.Add(new RenovationModel("123", "1.1.2021", "2.2.2021."));
                Renovations.Add(new RenovationModel("456", "4.5.2021", "3.3.2021."));
                Renovations.Add(new RenovationModel("789", "6.8.2021", "1.6.2021."));

            }

        }
    }
}
