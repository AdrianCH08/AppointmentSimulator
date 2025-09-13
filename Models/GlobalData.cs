using System.Collections.ObjectModel;

namespace AppointmentSimulator.Models
{
    public static class GlobalData
    {
        public static ObservableCollection<Appointment> Appointments { get; } =new();

        
    }
}
