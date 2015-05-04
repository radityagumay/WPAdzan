using MicroIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wpadzan.Services;
using wpadzan.ViewModels;

namespace wpadzan
{

    public static class BootStrapper
    {
        public static void Init(IMicroIocContainer container)
        {
            LoadDebug(container);
        }

        private static void LoadDebug(IMicroIocContainer container)
        {
            // Load service first
            container.Register<IServices, wpadzan.Services.Services>(null, true);

            // Then Load all View Model
            container.Register<MainPageViewModel, MainPageViewModel>(null, false);
        }
    }
}
