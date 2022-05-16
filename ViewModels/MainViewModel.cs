using Caliburn.Micro;
using System.Threading;
using System.Threading.Tasks;

namespace CaliburnPlayGround.ViewModels
{
    public class MainViewModel : Conductor<Screen>,IHandle<Screen>,IHandle<string>
    {
        private readonly IEventAggregator _eventAggregator;
        private LoginViewModel _loginvm;

        public MainViewModel(IEventAggregator eventAggregator,LoginViewModel loginvm)
        {
            _loginvm = loginvm;
            ActivateItemAsync(_loginvm);
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }
        
        public Task HandleAsync(Screen VMtoShow, CancellationToken cancellationToken)
        {
            return ActivateItemAsync(VMtoShow, cancellationToken);
        }
        public Task HandleAsync(string message, CancellationToken cancellationToken)
        {
            if (message.Equals("logout", System.StringComparison.OrdinalIgnoreCase))
                return ActivateItemAsync(_loginvm, cancellationToken);
            return null;
        }
    }
}
