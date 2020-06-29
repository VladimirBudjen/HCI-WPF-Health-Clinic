﻿
using Backend.Controller.SuperintendentControllers;
using Model.Hospital;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
    /// Interaction logic for NewRoomDialog.xaml
    /// </summary>
    public partial class NewRoomDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String[] types;
        private RoomType[] _types;
        private RoomController controler;
        private Room roomDTO;
      

        public string[] Types { get => types; set
            {
                if (value != types) types = value;
                OnPropertyChanged("Types");
            }
        }

        public Room RoomDTO { get => roomDTO; set => roomDTO = value; }

        public NewRoomDialog()
        {
            this.DataContext = this;
            controler = new RoomController();
            //AddRoomTypesInRepository();

            List<RoomType> typeList = controler.GetAllAutoRoomTypes();
            _types = typeList.ToArray();
            makeTypeComboStrings();
            InitializeComponent();
            
        }
        private void makeTypeComboStrings()
        {
            types = new string[_types.Length];
            int index = 0;
            foreach (RoomType rt in _types)
            {
                types[index] = rt.Name;
                index++;
            }
        }



        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void CanceButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            String type = typeCombo.Text;
            int id;
            try
            {
                id = int.Parse(ID.Text);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Morate uneti ceo broj u id sobe!");
                return;
            }
            if (controler.RoomNumberExists(id))
            {
                System.Windows.Forms.MessageBox.Show("Takav id već postoji!");
                return;
            }

            RoomDTO = new Room(id,new RoomType(type));
            this.Close();
        }

       

        


        
    }


}
