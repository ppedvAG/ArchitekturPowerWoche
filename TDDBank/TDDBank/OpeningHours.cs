using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank
{
    public class OpeningHours
    {
        public bool IsOpen(DateTime dt)
        {
            var start = new TimeSpan(10, 30, 0);
            var ende = new TimeSpan(19, 00, 0);
            var endeSa = new TimeSpan(14, 00, 0);

            //häßlich aber geht
            if (dt.DayOfWeek == DayOfWeek.Sunday) return false;
            else if (dt.DayOfWeek == DayOfWeek.Saturday && dt.TimeOfDay >= start && dt.TimeOfDay < endeSa)
                return true;
            else if (dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday && dt.TimeOfDay >= start && dt.TimeOfDay < ende)
                return true;

            return false;
        }

        public bool IsNowOpen()
        {
            return IsOpen(DateTime.Now);
        }

        public void ReadOpeningHours()
        {
            using var sr = new StreamReader(@"m:\BLA\BLA\OH.txt");
            var line = sr.ReadLine();
            while (!sr.EndOfStream)
                Debug.WriteLine(line);

        }
    }
}
