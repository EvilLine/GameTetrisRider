using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drivers
{
    internal class MoveControl
    {
        public string? Command { get; set; } = null;
        private Car _car;
        public MoveControl(Car car)
        {
            _car = car;
            ServiceRun();
        }
        private void ServiceRun()
        {
            Task.Run(() =>
            {
                while (true)
                {

                }
            });
        }
        
    }
}
