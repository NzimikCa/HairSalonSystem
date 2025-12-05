using HairSalonSystem.HairSalon.WPF.Views;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace HairSalon.WPF
{
    public partial class StylistDashboard : Window
    {
        private int currentUserId;

        public StylistDashboard(int userId, string stylistName)
        {
            InitializeComponent();
            currentUserId = userId;
            lblWelcome.Text = $"Welcome, {stylistName}!";
            dpScheduleDate.SelectedDate = DateTime.Today;
            LoadAppointments(DateTime.Today);
        }

        private void LoadAppointments(DateTime date)
        {
            // Sample data - will connect to database later
            DataTable dt = new DataTable();
            dt.Columns.Add("TimeSlot", typeof(string));
            dt.Columns.Add("CustomerName", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            // Sample data for today
            if (date.Date == DateTime.Today)
            {
                dt.Rows.Add("10 AM", "Alice Johnson", "Haircut", "$30", "Scheduled");
                dt.Rows.Add("2 PM", "John Doe", "Coloring", "$80", "Scheduled");
            }

            dgAppointments.ItemsSource = dt.DefaultView;
            lblScheduleTitle.Text = date.Date == DateTime.Today ?
                "Today's Appointments:" :
                $"Appointments for {date:MM/dd/yyyy}:";
        }

        private void dpScheduleDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dpScheduleDate.SelectedDate.HasValue)
            {
                LoadAppointments(dpScheduleDate.SelectedDate.Value);
            }
        }

        private void btnMarkCompleted_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment");
                return;
            }

            MessageBox.Show("Mark completed - will add database code later");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
