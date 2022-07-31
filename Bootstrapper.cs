using Caliburn.Micro;
using CaliburnPlayGround.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace CaliburnPlayGround
{
    /// <summary>
    /// bootstrapper gets instantiated when the resources are parsed and loaded(app.xaml)
    /// </summary>
    public class Bootstrapper : BootstrapperBase
    {
        private readonly SimpleContainer container = new();
        //order of exec - 1
        public Bootstrapper()
        {
            //calls configure 
            Initialize();
        }
        //order of exec - 2
        protected override void Configure()
        {
            container.Instance(container);
            container.Singleton<IEventAggregator, EventAggregator>();
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

        //called when Startup Event raised in the app.xaml/ app.xaml.cs
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
