using Caliburn.Micro;
using CaliburnPlayGround.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CaliburnPlayGround
{
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container=new();
        public Bootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container.Instance(container);
            container.Singleton<IEventAggregator,EventAggregator>();
            container.Singleton<IWindowManager, WindowManager>();
            container.PerRequest<LoginViewModel>();
            container.PerRequest<MainViewModel>();
            container.PerRequest<DashboardViewModel>();
            
        }
        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }
        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
