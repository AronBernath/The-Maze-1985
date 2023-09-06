using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Timer
    {
        int timeCs, timeSec, timeMin;
        bool isActive;

        private void StartWatch()
        { 
            isActive = true;
        }

        private void StopWatch()
        {
            isActive = false;
        }
        public void Watch()
        {
            timeCs = 0;
            timeSec = 0;
            timeMin = 0;

            isActive = false;
        }
    }
}
