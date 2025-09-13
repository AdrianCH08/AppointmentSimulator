using AppointmentSimulator.Models;
using AppointmentSimulator.ViewModels;

namespace AppointmentSimulator.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AppointmentsCollectionView.ItemsSource = GlobalData.Appointments;
            BindingContext = new AppointmentViewModel();
        }

        private async void OnClickedAdd(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AddNewAppointmentPage");
        }

    }
}
