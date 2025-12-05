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
    public partial class BookAppointmentWindow : Window
    {
        private int currentUserId;

        public BookAppointmentWindow(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            dpAppointmentDate.DisplayDateStart = DateTime.Today;
            LoadStylists();
            LoadServices();
        }

        private void LoadStylists()
        {
            // Sample data - will connect to database later
            DataTable dt = new DataTable();
            dt.Columns.Add("StylistId", typeof(int));
            dt.Columns.Add("FullName", typeof(string));

            dt.Rows.Add(1, "Bob Smith");
            dt.Rows.Add(2, "Sara Lee");

            cmbStylist.ItemsSource = dt.DefaultView;
            cmbStylist.DisplayMemberPath = "FullName";
            cmbStylist.SelectedValuePath = "StylistId";
        }

        private void LoadServices()
        {
            // Sample data - will connect to database later
            DataTable dt = new DataTable();
            dt.Columns.Add("ServiceId", typeof(int));
            dt.Columns.Add("ServiceName", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));

            dt.Rows.Add(1, "Haircut - Short", 30.00);
            dt.Rows.Add(2, "Haircut - Long", 45.00);
            dt.Rows.Add(3, "Single Color", 80.00);
            dt.Rows.Add(4, "Highlights", 100.00);

            cmbService.ItemsSource = dt.DefaultView;
            cmbService.DisplayMemberPath = "ServiceName";
            cmbService.SelectedValuePath = "ServiceId";
        }

        private void cmbService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbService.SelectedItem != null)
            {
                DataRowView row = (DataRowView)cmbService.SelectedItem;
                decimal price = Convert.ToDecimal(row["Price"]);
                lblTotalPrice.Text = $"${price:F2}";
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            // Validation
            if (dpAppointmentDate.SelectedDate == null ||
                cmbTimeSlot.SelectedItem == null ||
                cmbStylist.SelectedItem == null ||
                cmbService.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields");
                return;
            }

            MessageBox.Show("Appointment booked!\n(Will save to database later)");
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}