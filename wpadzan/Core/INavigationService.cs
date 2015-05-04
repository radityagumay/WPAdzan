using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Navigation;

namespace wpadzan.Core
{
    public interface INavigationService
    {
        bool CanGoBack { get; }

        bool Navigate(Uri source);

        void GoBack();

        event NavigatedEventHandler Navigated;

        event NavigatingCancelEventHandler Navigating;

        event EventHandler<ObscuredEventArgs> Obscured;

        bool RecoveredFromTombstoning { get; set; }

        void UpdateTombstonedPageTracking(Uri pageUri);

        bool DoesPageNeedtoRecoverFromTombstoning(Uri pageUri);

        void RemoveBackEntry();
    }
}
