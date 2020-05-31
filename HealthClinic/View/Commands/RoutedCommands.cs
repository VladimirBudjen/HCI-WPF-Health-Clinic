using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthClinic.View.Commands
{
    public static class RoutedCommands
    {
        public static readonly RoutedUICommand EditRow_Command = new RoutedUICommand(
            "Edit row",
            "EditRow",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control),
                new KeyGesture(Key.Enter, ModifierKeys.Control)
            }
        );


        public static readonly RoutedUICommand DeleteRow_Command = new RoutedUICommand(
            "Delete Cell",
            "DeleteCell",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control),
                new KeyGesture(Key.Delete),
                new KeyGesture(Key.Back, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand AddRow_Command = new RoutedUICommand(
            "Add row",
            "AddRow",
            typeof(RoutedCommands),
            new InputGestureCollection(){

                new KeyGesture(Key.N, ModifierKeys.Control),
                new KeyGesture(Key.Enter, ModifierKeys.Shift) 
            }

        );
        public static readonly RoutedUICommand Rooms_Command = new RoutedUICommand(
            "Rooms",
            "Rooms",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F1),

            }
        );

        public static readonly RoutedUICommand Physicians_Command = new RoutedUICommand(
            "Physicians",
            "Physicians",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.F2),

            }
        );
        public static readonly RoutedUICommand Secretaries_Command = new RoutedUICommand(
            "Secretaries",
            "Secretaries",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.F3),

            }
        );
        public static readonly RoutedUICommand WaitingMedicine_Command = new RoutedUICommand(
            "WaitingMedicine",
            "WaitingMedicine",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.F4),

            }
        );
        public static readonly RoutedUICommand Renovation_Command = new RoutedUICommand(
            "Renovations",
            "Renovations",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                        new KeyGesture(Key.F5),

            }
            );

        public static readonly RoutedUICommand FocusTable_Command = new RoutedUICommand(
            "FocusTable",
            "FocusTable",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.Space, ModifierKeys.Control)

            }
        );

        public static readonly RoutedUICommand Search_Command = new RoutedUICommand(
            "Search",
            "Search",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.S, ModifierKeys.Control)
            }
        );


        public static readonly RoutedUICommand RoomEquipmentDialog_Command = new RoutedUICommand(
            "EditRoomEquipment",
            "EditRoomEquipment",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.Q, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand RoomRenovationDialog_Command = new RoutedUICommand(
            "EditRoomRenovation",
            "EditRoomRenovation",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.R, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand PhysicianVacationDialog_Command = new RoutedUICommand(
            "EditPhysicianVacation",
            "EditPhysicianVacation",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.O, ModifierKeys.Control)
            }
        );

        public static readonly RoutedUICommand PhysicianWorkingDialog_Command = new RoutedUICommand(
            "EditPhysicianWorking",
            "EditPhysicianWorking",
            typeof(RoutedCommands),
            new InputGestureCollection()
            {
                    new KeyGesture(Key.W, ModifierKeys.Control)
            }
        );









    }
}
