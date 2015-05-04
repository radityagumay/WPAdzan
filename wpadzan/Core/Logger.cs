using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Core
{
    public static class Logger
    {
        public static string BaseLog
        {
            get { return DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"); }
        }

        public static void Delimiter()
        {
            System.Diagnostics.Debug.WriteLine("---------------------------------------------");
        }

        public static void Log(string log)
        {
            System.Diagnostics.Debug.WriteLine(BaseLog + " : " + log);
        }
    }
}
