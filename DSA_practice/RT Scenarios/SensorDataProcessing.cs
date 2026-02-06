using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace RealTimeSensorProcessing
{
    // Model for sensor reading
    class SensorReading
    {
        public string SensorId;
        public DateTime Timestamp;
        public double Value;
    }

    // Processor class
    class SensorProcessor
    {
        // Stores last 60 seconds data per sensor
        private Dictionary<string, Queue<SensorReading>> sensorWindows =
            new Dictionary<string, Queue<SensorReading>>();

        // Stores running sum per sensor
        private Dictionary<string, double> runningSum =
            new Dictionary<string, double>();

        private TimeSpan windowSize = TimeSpan.FromSeconds(60);

        public void ProcessReading(SensorReading reading)
        {
            // Initialize structures for new sensor
            if (!sensorWindows.ContainsKey(reading.SensorId))
            {
                sensorWindows[reading.SensorId] = new Queue<SensorReading>();
                runningSum[reading.SensorId] = 0;
            }

            Queue<SensorReading> queue = sensorWindows[reading.SensorId];

            // Add new reading
            queue.Enqueue(reading);
            runningSum[reading.SensorId] += reading.Value;

            // Remove expired readings
            while (queue.Count > 0 &&
                   queue.Peek().Timestamp < reading.Timestamp - windowSize)
            {
                SensorReading expired = queue.Dequeue();
                runningSum[reading.SensorId] -= expired.Value;
            }

            // Compute rolling average
            double average = runningSum[reading.SensorId] / queue.Count;

            // Detect spike
            if (reading.Value > 3 * average)
            {
                Console.WriteLine(
                    $"SPIKE Sensor={reading.SensorId}, Value={reading.Value:F2}, Avg={average:F2}");
            }
            else
            {
                Console.WriteLine(
                    $"Sensor={reading.SensorId}, Value={reading.Value:F2}, Avg={average:F2}");
            }
        }
    }

    class SensorDataProcessing    {
        static void Main(string[] args)
        {
            SensorProcessor processor = new SensorProcessor();
            DateTime now = DateTime.UtcNow;

            // Dummy sensor data
            List<SensorReading> readings = new List<SensorReading>
            {
                new SensorReading { SensorId="S1", Timestamp=now.AddSeconds(-55), Value=10 },
                new SensorReading { SensorId="S1", Timestamp=now.AddSeconds(-45), Value=12 },
                new SensorReading { SensorId="S1", Timestamp=now.AddSeconds(-35), Value=11 },
                new SensorReading { SensorId="S1", Timestamp=now.AddSeconds(-25), Value=10 },
                new SensorReading { SensorId="S1", Timestamp=now.AddSeconds(-15), Value=40 }, 

                new SensorReading { SensorId="S2", Timestamp=now.AddSeconds(-50), Value=20 },
                new SensorReading { SensorId="S2", Timestamp=now.AddSeconds(-30), Value=22 },
                new SensorReading { SensorId="S2", Timestamp=now.AddSeconds(-10), Value=21 }
            };

            // Process stream
            foreach (var reading in readings)
            {
                processor.ProcessReading(reading);
            }

            Console.WriteLine("\nProcessing complete.");
        }
    }
}


//==========OUTPUT==========
//Sensor = S1, Value = 10.00, Avg = 10.00
//Sensor = S1, Value = 12.00, Avg = 11.00
//Sensor = S1, Value = 11.00, Avg = 11.00
//Sensor = S1, Value = 10.00, Avg = 10.75
//SPIKE Sensor = S1, Value = 40.00, Avg = 16.60
//Sensor = S2, Value = 20.00, Avg = 20.00
//Sensor = S2, Value = 22.00, Avg = 21.00
//Sensor = S2, Value = 21.00, Avg = 21.00

//Processing complete.

