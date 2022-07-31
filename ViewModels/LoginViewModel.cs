using Caliburn.Micro;
using CaliburnPlayGround.Views;
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
        public void Login(string username, string password) //binds the 2 textboxes(Username, Password) automatically [case insensitive]
        {
            if (username.Length > 3 && !string.IsNullOrWhiteSpace(password))
                _eventAggregator.PublishOnUIThreadAsync(_dashboardvm);
        }
        //public void Login(object view)
        //{
        //    var v = view as LoginView;
        //    //use event agregator to raise an event and handle it in main view model.
        //    if (v.Username.Text.Length > 3 && !string.IsNullOrWhiteSpace(v.Password.Text))
        //        _eventAggregator.PublishOnUIThreadAsync(_dashboardvm);
        //}
        
    }
}
