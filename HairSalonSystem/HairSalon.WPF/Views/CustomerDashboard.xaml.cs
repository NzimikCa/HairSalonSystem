using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HairSalonSystem.HairSalon.WPF.Views;

namespace HairSalon.WPF
{
    public partial class CustomerDashboard : Window
    {
        private int currentUserId;

        public CustomerDashboard(int userId, string customerName)
        {
            InitializeComponent();
            currentUserId = userId;
            lblWelcome.Text = $"Welcome, {customerName}!";
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            // Will connect to database later
            // For now, create sample data to test UI
            DataTable dt = new DataTable();
            dt.Columns.Add("AppointmentDate", typeof(string));
            dt.Columns.Add("TimeSlot", typeof(string));
            dt.Columns.Add("StylistName", typeof(string));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("TotalPrice", typeof(string));
            dt.Columns.Add("Status", typeof(string));

            // Sample data
            dt.Rows.Add("12/05/2025", "10 AM", "Bob Smith", "Haircut", "$30", "Scheduled");
            dt.Rows.Add("11/28/2025", "2 PM", "Sara Lee", "Coloring", "$80", "Completed");

            dgAppointments.ItemsSource = dt.DefaultView;
        }

        private void btnBookAppointment_Click(object sender, RoutedEventArgs e)
        {
            BookAppointmentWindow bookWindow = new BookAppointmentWindow(currentUserId);
            bookWindow.ShowDialog();
            LoadAppointments(); // Refresh after booking
        }

        private void btnCancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment to cancel");
                return;
            }

            MessageBox.Show("Cancel functionality - will add database code later");
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow loginWindow = new MainWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
