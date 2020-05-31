using HealthClinic.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthClinic.View.TableViews
{
    /// <summary>
    /// Interaction logic for RoomsTableView.xaml
    /// </summary>
    public partial class RoomsTableView : UserControl
    {
    
        public ObservableCollection<RoomModel> Rooms
        {
            get;
            set;
        }

        public RoomsTableView()
        {
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<RoomModel>();
            for(int i=0; i<30; i++)
            {
                Rooms.Add(new RoomModel("123", "Soba za pregled"));
                Rooms.Add(new RoomModel("456", "Soba za previjanje", "1.1.2020."));
                Rooms.Add(new RoomModel("456", "Soba za operaciju"));
            }
            dataGridRooms.SelectedIndex = 0;
            

        }
    }
}


