/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorNamespace;
using System.Threading;

namespace MultithreadedSensorInterfaceCSharp {
    class Demo : SensorNamespace.ISensorInterface {
        private static float sensorValue;
        private static Sensor temperatureSensor;
        static void Main(string[] args) {
            Demo demo = new MultithreadedSensorInterfaceCSharp.Demo();
            SensorNamespace.Sensor sensor = new SensorNamespace.Sensor(demo);
            temperatureSensor = new SensorNamespace.Sensor(demo);
            temperatureSensor.Start();
            while (true) {
                Console.WriteLine(sensorValue);
                Thread.Sleep(5000);
            }
        }

        void ISensorInterface.Update(float value) {
            sensorValue = value;
        }
    }
}
