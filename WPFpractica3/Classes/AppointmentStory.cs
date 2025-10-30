using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFpractica3.Classes
{
    public class AppointmentStory : INotifyPropertyChanged
    {
        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }



        private string _doctorId = "";
        public string DoctorId
        {
            get => _doctorId;
            set
            {
                if (_doctorId != value)
                {
                    _doctorId = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _diagnosis = "";
        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                if (_diagnosis != value)
                {
                    _diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _recommendations = "";
        public string Recommendations
        {
            get => _recommendations;
            set
            {
                if (_recommendations != value)
                {
                    _recommendations = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _doctorFullName = "";
        public string DoctorFullName
        {
            get => _doctorFullName;
            set
            {
                if (_doctorFullName != value)
                {
                    _doctorFullName = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
