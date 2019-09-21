/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;

using System.Threading;


namespace SensorNamespace {
    class Sensor {
        private ISensorInterface sensorInterface;
       
        public Sensor(ISensorInterface sensorInterface) {
            this.sensorInterface = sensorInterface;
        }

        private void ThreadStart() {
            while (true) {
                // The sensor reads a value from the real world and converts it to a double. 
                // We would need the unit of measure from the sensor manufacturer.
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
