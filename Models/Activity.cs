using Caliburn.Micro;

namespace CaliburnPlayGround.Models
{
    public class Activity : PropertyChangedBase
    {
        private string _name;
        private double _hoursConsumed;
        private bool _isCompleted;

        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyOfPropertyChange(nameof(Name)); }
        }

        public double HoursConsumed
        {
            get { return _hoursConsumed; }
            set { _hoursConsumed = value; NotifyOfPropertyChange(nameof(HoursConsumed)); }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }



    }
}
