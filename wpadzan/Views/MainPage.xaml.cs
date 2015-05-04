using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using wpadzan.ViewModels;
using MicroIoc;
using Microsoft.Practices.Prism.Events;
using wpadzan.Core;

namespace wpadzan.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        private BaseEvent baseEvent;

        private MainPageViewModel viewModel
        {
            get { return (this.DataContext as MainPageViewModel); }
        }

        public MainPage()
        {
            InitializeComponent();
            //IMicroIocContainer container =
            //   (IMicroIocContainer)Application.Current.Resources["Container"];
            //this.DataContext = container.TryResolve<MainPageViewModel>(null);

            //IEventAggregator eventAggregator = container.Resolve<IEventAggregator>();
            //baseEvent = eventAggregator.GetEvent<BaseEvent>();

            //this.Loaded += MainPage_Loaded;
            this.DataContext = new MainPageViewModel();
        }

        //private void MainPage_Loaded(object sender, RoutedEventArgs e)
        //{
        //    viewModel.OnLoadedCommand.Execute(e);
        //}
    }
}