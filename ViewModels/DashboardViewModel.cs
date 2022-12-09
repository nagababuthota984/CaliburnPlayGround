using Caliburn.Micro;
using CaliburnPlayGround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnPlayGround.ViewModels
{
    public class DashboardViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                selectedIndex = value;
                NotifyOfPropertyChange(() => SelectedIndex);
            }
        }

        public List<Activity> Activities
        {
            get
            {
                return new(){
                    new(){
                        Name="Database tuning",
                        HoursConsumed=20,
                        IsCompleted=true
                    },
                    new(){
                        Name="System Check",
                        HoursConsumed=20,
                        IsCompleted=false
                    },new(){
                        Name="Reverse engineering",
                        HoursConsumed=12,
                        IsCompleted=false
                    },new(){
                        Name="Gui testing",
                        HoursConsumed=2,
                        IsCompleted=true
                    },new(){
                        Name="Unit testing",
                        HoursConsumed=30,
                        IsCompleted=false
                    },new(){
                        Name="Requirement analysis",
                        HoursConsumed=2,
                        IsCompleted=true
                    },
                };
            }

        }

        public DashboardViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            SelectedIndex = 0;
        }
        public void LogOut()
        {
            _eventAggregator.PublishOnUIThreadAsync("Logout");
        }

        public void ChangeTab()
        {
            SelectedIndex = 1;
        }
    }

}
