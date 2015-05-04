using MicroIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Core
{
    public class ServiceMain
    {
        public static void Init(MicroIocContainer container)
        {
            RegisterService(container);
            ActivateQueryEngine(container);
        }

        private static void RegisterService(MicroIoc.MicroIocContainer container)
        {
            // Register Service
            // container.Register<Infrastructure.Services.IAgodaService, Services.AgodaServices>();
            container.Register<ICommandEngine, CommandEngine>(null, true);
        }

        public static void ActivateQueryEngine(MicroIoc.MicroIocContainer container)
        {
            container.Resolve<ICommandEngine>().Start();
        }

        public static void DeActivateQueryEngine(MicroIoc.MicroIocContainer container)
        {
            container.Resolve<ICommandEngine>().Stop();
        }
    }
}
