using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Core
{
    public interface ICommandItem : IDisposable
    {
        string Name { get; set; }

        CommandType Type { get; set; }

        CommandStatus Status { get; set; }

        void PerformAsync();

        void Cancel();
    }
}
