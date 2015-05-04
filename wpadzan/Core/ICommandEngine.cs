using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Core
{
    public interface ICommandEngine
    {
        void Start();

        void Stop();

        void Add(ICommandItem item);

        void CancelAll();
    }
}
