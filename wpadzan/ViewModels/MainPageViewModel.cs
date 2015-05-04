using MicroIoc;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using wpadzan.Core;
using wpadzan.Models;
using wpadzan.Services;

namespace wpadzan.ViewModels
{
    public class MainPageViewModel : NotificationObject
    {
        //private IServices services;
        //private BaseEvent baseEvent;

        private List<string> time;
        public List<string> Time
        {
            get { return time; }
            set 
            {
                if (value != time)
                {
                    time = value;
                    RaisePropertyChanged(() => Time);
                }
            }
        }

        public MainPageViewModel()
        {
            //this.services = services;

            // Instance List
            this.Time = new List<string>();

            //this.OnLoadedCommand = new DelegateCommand<RoutedEventArgs>(OnLoaded);
            #region Register Container
            //IMicroIocContainer container =
            //    (IMicroIocContainer)Application.Current.Resources["Container"];
            //IEventAggregator eventAggregator =
            //    container.Resolve<IEventAggregator>();
            //baseEvent = eventAggregator.GetEvent<BaseEvent>();
            #endregion Register Container

            OnLoaded();
        }

        //public DelegateCommand<RoutedEventArgs> OnLoadedCommand { get; private set; }
        private void OnLoaded()
        {
            List<string> str = new List<string>();

            PrayTime p = new PrayTime();
            double lo = -6.217234;
            double la = 106.813144;
            int y = 0, m = 0, d = 0, tz = 0;

            DateTime cc = DateTime.Now;
            y = cc.Year;
            m = cc.Month;
            d = cc.Day;
            tz = TimeZoneInfo.Local.GetUtcOffset(new DateTime(y, m, d)).Hours;
            String[] s;

            p.setCalcMethod(4);
            p.setAsrMethod(0);
            s = p.getDatePrayerTimes(y, m, d, lo, la, tz);
            for (int i = 0; i < s.Length; ++i)
            {
                str.Add(s[i]);
                Debug.WriteLine("RADITYA GUMAY ==>" + s[i]);
            }

            Time = str.ToList();

            // TODO GET LOCAL TIME
            //TimeZoneInfo localZone = TimeZoneInfo.Local;
            //string text = String.Format("{0}{1}:{2:00} ({3})", (localZone.BaseUtcOffset >= TimeSpan.Zero) ? "" : "-", Math.Abs(localZone.BaseUtcOffset.Hours),
            //                          Math.Abs(localZone.BaseUtcOffset.Minutes), TimeZoneInfo.Local.DisplayName);

            //TODO HIT SERVICE
            //await TaskEx.Run(() =>
            //    {
            //        Deployment.Current.Dispatcher.BeginInvoke(() =>
            //        {
            //            //baseEvent.Publish(new BaseArgs("StartLoading"));
            //            services.getData("1", (result, ex) =>
            //                {
            //                    if (ex != null) 
            //                    {
            //                        var res = result.Adzan.ToList();
            //                    }
            //                });
            //        });
            //    });
        }
    }
}
