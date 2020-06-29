
using HealthClinic.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Grid;
using System.Data;
using Model.Util;
using Model.Accounts;
using Model.Hospital;
using Backend.Controller.SuperintendentControllers;
using System.Linq;
using HealthClinic.Backend.Controller.SuperintendentControllers;
using Backend.Service.SchedulingService.AppointmentGeneralitiesOptions;

namespace HealthClinic.View.Dialogs.PhysicianDialogs
{
    /// <summary>
    /// Interaction logic for VacationDialog.xaml
    /// </summary>
    public partial class VacationDialog : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<VacationViewModel> _vacationModels;
        public List<TimeInterval> _vacations;
        private Physitian _physitianDTO;
        private SuperiIntendentPhysiciansController controller;


        private void refreshTable()
        {
            _vacationModels.Clear();
            _vacations = controller.GetAllVacations(PhysitianDTO);
            VacationModels = createVacationsModels(_vacations);
        }
   
        public ObservableCollection<VacationViewModel> VacationModels
        {
            get => _vacationModels; set
            {
                if (value != _vacationModels) _vacationModels = value;
                OnPropertyChanged("VacationModels");
            }
        }

        public Physitian PhysitianDTO { get => _physitianDTO; set => _physitianDTO = value; }

        public VacationDialog(Physitian physitian)
        {
            InitializeComponent();
            this.DataContext = this;
            controller = new SuperiIntendentPhysiciansController();
            VacationModels = new ObservableCollection<VacationViewModel>();
            PhysitianDTO = physitian;
            refreshTable();
            
        }

        private ObservableCollection<VacationViewModel> createVacationsModels(List<TimeInterval> interval)
        {
            ObservableCollection< VacationViewModel > vacations= new ObservableCollection<VacationViewModel>();
            foreach (TimeInterval ti in interval)
            {
                vacations.Add(new VacationViewModel(ti));
            }
            return vacations;
        }

        private void TextInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            AddButton.IsEnabled = isDateGood(endTextInput.Text) && isDateGood(startTextInput.Text);
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


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.ParseExact(startTextInput.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(endTextInput.Text, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            if (startDate > endDate)
            {
                System.Windows.Forms.MessageBox.Show("Datum kraja odmora ne može biti pre datuma početka!");
                return;
            }
            if (startDate < DateTime.Today)
            {
                System.Windows.Forms.MessageBox.Show("Morate zakazati odmor nakon današnjeg dana!");
                return;
            }

            TimeInterval interval = new TimeInterval(startDate, endDate);
            PhysitianAvailabilityService availibilityService = new PhysitianAvailabilityService();
            if (!availibilityService.canGoOnVacation(PhysitianDTO,interval))
            {
                System.Windows.Forms.MessageBox.Show("Lekar ima preglede u datom periodu ili dati period sadrži odmor!");
                return;
            }
            controller.AddVacation(interval, PhysitianDTO);
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

                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Da li ste sigurni da želite da izbrišete izabrani odmor?",
                "Brisanje reda", MessageBoxButtons.YesNo);
                switch (dialogResult)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        controller.RemoveVacation(PhysitianDTO.VacationTime.ElementAt(selecteIndex), PhysitianDTO);
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
        }

        private void deleteKeyPressed(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key.Equals(Key.Delete))
            {
                deleteRow();
            }
        }

        private void statisticsButton_Click(object sender, RoutedEventArgs e)
        {
            using (PdfDocument document = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = document.Pages.Add();

                //Create PDF graphics for a page
                PdfGraphics graphics = page.Graphics;

                //Set the standard font
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont font2 = new PdfStandardFont(PdfFontFamily.Helvetica, 14);

                String radnoVreme;
                if (PhysitianDTO.WorkSchedule != null)
                {
                    radnoVreme = "\nRadnik " + PhysitianDTO.Name + " " + PhysitianDTO.Surname + " radi od" + PhysitianDTO.WorkSchedule.Start.ToString("HH:mm")
                    + " do " + PhysitianDTO.WorkSchedule.End.ToString("HH:mm") + ". ";
                }
                else
                {
                    radnoVreme = "\nRadnik " + PhysitianDTO.Name + " " + PhysitianDTO.Surname + " trenutno nema fiksno radno vreme.";
                }
                //Draw the text
                graphics.DrawString("Statistika", font, PdfBrushes.Black, new PointF(0, 0));
                graphics.DrawString(radnoVreme, font2, PdfBrushes.Black, new PointF(10, 60));


                //Create a PdfGrid.
                PdfGrid pdfGrid = new PdfGrid();
                //Create a DataTable.
                DataTable dataTable = new DataTable();
                //Add columns to the DataTable
                dataTable.Columns.Add("Početak odmora");
                dataTable.Columns.Add("Kraj odmora");
                //Add rows to the DataTable.
                foreach (TimeInterval vacation in PhysitianDTO.VacationTime)
                {
                    dataTable.Rows.Add(new object[] { vacation.Start.ToString("dd-MM-yyyy"), vacation.End.ToString("dd-MM-yyyy") });
                }
                //Assign data source.
                pdfGrid.DataSource = dataTable;
                //Draw grid to the page of PDF document.
                pdfGrid.Draw(page, new PointF(80, 200));


                //Save the document
                document.Save("Output.pdf");
            }
            System.Diagnostics.Process.Start(@"E:\programi\c#\HCI\Projekat\HealthClinic\HealthClinic\HealthClinic\bin\Debug\Output.pdf");
        }
    }
}
