using System;
using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using Paint101.Desktop.ViewModels;

namespace Paint101.Desktop
{
    /// <summary>
    /// Caliburn bootstrapper for application
    /// </summary>
    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer _container;


        public AppBootstrapper()
        {
            Initialize();
        }


        protected override void Configure()
        {
            NlogHelper.Configure();

            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();

            _container.PerRequest<ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
