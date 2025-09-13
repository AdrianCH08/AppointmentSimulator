using AppointmentSimulator.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AppointmentSimulator.ViewModels
{
    public partial class AppointmentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;
        [ObservableProperty]
        private string _subject = string.Empty;
        [ObservableProperty]
        private DateTime _appointmentDate = DateTime.Now; //se inicia con la fecha actual
        [ObservableProperty]
        private TimeSpan _startingTime;
        [ObservableProperty]
        private TimeSpan _endingTime;

        [RelayCommand]
        public async Task AddAppointment()
        {
            DateTime today = DateTime.Now;// fecha actual
            if(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Subject)) // verifica que no esten vacios los campos
            {
                await Shell.Current.DisplayAlert("Error", "Completa todos los campos", "OK");
                return;
            }
            if(AppointmentDate <= today)
            {
                await Shell.Current.DisplayAlert("Error", "Tiene que ser una fecha actual o futura","OK");
                return;
            }

            if(StartingTime > EndingTime)
            {
                await Shell.Current.DisplayAlert("Error", "La fecha de inicio no puede ser despues de la fecha de termino", "OK");
                return;
            }

            // Registro
            Appointment appointment = new() //Objeto appo
            {
                Name = Name,
                Subject = Subject,
                AppointmentDate = AppointmentDate,
                StartingTime = StartingTime,
                EndingTime = EndingTime
            };

            // Agregamos registro
            GlobalData.Appointments.Add(appointment);

            await Shell.Current.DisplayAlert("Correcto", "Nueva cita creada", "OK");
            await Shell.Current.GoToAsync("..");
        }

    }
        
}
