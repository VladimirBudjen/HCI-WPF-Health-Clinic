using HealthClinic.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for PhysiciansTableView.xaml
    /// </summary>
    public partial class PhysiciansTableView : UserControl
    {
        public ObservableCollection<PhysicianModel> Physicians
        {
            get;
            set;
        }
        public PhysiciansTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            Physicians = new ObservableCollection<PhysicianModel>();
            for (int i = 0; i < 30; i++)
            {
                Physicians.Add(new PhysicianModel("Vladimir", "Budjen", "9988123123", "Gavrila Principa 39a", "1.1.1998.", "Stomatolog", "12:30-15:30"));
                Physicians.Add(new PhysicianModel("Pera", "Peric", "3333123123", "Cara Laze 32", "3.1.1991.", "Oftamolog", "20:30-15:30"));
                Physicians.Add(new PhysicianModel("Suzana", "Suzanic", "1231123123", "Zike Antica", "1.2.1990.", "Radiolog", "21:30-15:30"));
            }
     


        }
    }
}
