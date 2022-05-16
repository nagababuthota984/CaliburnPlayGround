using Caliburn.Micro;
using System.Windows;

namespace CaliburnPlayGround.ViewModels
{
    public class LoginViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly DashboardViewModel _dashboardvm;

        public LoginViewModel(IEventAggregator eventAggregator,DashboardViewModel dashboardvm)
        {
            _eventAggregator = eventAggregator;
            _dashboardvm = dashboardvm;
        }
        public bool CanLogin(string username,string password)
        {
            return !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password);   
        }
        public void Login(string username,string password)
        {
            //use event agregator to raise an event and handle it in main view model.
            if(username.Length>3 && !string.IsNullOrWhiteSpace(password))
                _eventAggregator.PublishOnUIThreadAsync(_dashboardvm);
        }
    }
}
