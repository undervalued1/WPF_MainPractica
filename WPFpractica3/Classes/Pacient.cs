using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFpractica3.Classes
{
    public class Pacient : INotifyPropertyChanged
    {

        private string _idPacient;
        public string IdPacient
        {
            get => _idPacient;
            set
            {
                if (value != _idPacient)
                {
                    _idPacient = value;
                    OnPropertyChanged("IdPacient");
                }
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string _lastName;
        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        private string _middleName;
        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        private DateTime? _dateBirthday = null;
        public DateTime? DateBirthday
        {
            get => _dateBirthday;
            set
            {
                if (_dateBirthday != value)
                {
                    _dateBirthday = value;
                    OnPropertyChanged("DateBirthday");
                }
            }
        }


        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (value != _phoneNumber)
                {
                    _phoneNumber = value;
                    OnPropertyChanged("PhoneNumber");
                }
            }
        }

        private List<AppointmentStory> _appointmentStories = new();
        public List<AppointmentStory> AppointmentStories
        {
            get => _appointmentStories;
            set
            {
                if (_appointmentStories != value)
                {
                    _appointmentStories = value;
                    OnPropertyChanged(nameof(AppointmentStories));
                }
            }
        }

        public string DaysSinceLastAppointment
        {
            get
            {
                if (AppointmentStories == null || !AppointmentStories.Any())
                    return "Первый прием в клинике";

                var lastAppointment = AppointmentStories
                    .OrderByDescending(a => a.Date)
                    .FirstOrDefault();

                if (lastAppointment == null)
                    return "Первый прием в клинике";

                var lastDate = lastAppointment.Date;
                var days = (DateTime.Now - lastDate).Days;

                return days == 0 ? "Последний прием: Сегодня" : $"Последний прием: {days} дней назад";
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propName = null)

        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
