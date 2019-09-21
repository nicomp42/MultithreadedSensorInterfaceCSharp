using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SensorNamespace {
    class Sensor {
        private ISensorInterface sensorInterface;
       
        public Sensor(ISensorInterface sensorInterface) {
            this.sensorInterface = sensorInterface;
        }

        private void ThreadStart() {
            while (true) {
                float value = (float)(new Random()).NextDouble();
                sensorInterface.Update(value);
                Thread.Sleep(500);  // A nice pause because analog sensors are slow.
            }
        }
        public void Start() {
            Thread thread = new Thread(new ThreadStart(this.ThreadStart));
            thread.Start();
        }
    }
}
