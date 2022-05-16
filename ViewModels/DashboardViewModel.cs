using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayGround.ViewModels
{
    public class DashboardViewModel:Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public DashboardViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }
        public void LogOut()
        {
            _eventAggregator.PublishOnUIThreadAsync("Logout");
        }
    }

}
