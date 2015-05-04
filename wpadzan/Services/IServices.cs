using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wpadzan.Models;

namespace wpadzan.Services
{
    public interface IServices
    {
        void getData(string id, Action<AdzanModel, Exception> callback);
    }
}
