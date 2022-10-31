using LibreHardwareMonitor.Hardware;

namespace LibreHardwareMonitorConsoleDemo;

public static class HardwareInfo
{
    public static void Monitor()
    {
        var computer = new Computer
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true
        };

        computer.Open();
        computer.Accept(new UpdateVisitor());

        foreach (var hardware in computer.Hardware)
        {
            Console.WriteLine("Hardware: {0}", hardware.Name); // Display CPU and GPU name/model

            // Display CPU and GPU sensors
            foreach (var sensor in hardware.Sensors)
            {
                // TODO - Obtain Intel Core temperatures as well
                if (sensor.Name.Contains("Core (Tctl/Tdie)")) // Only working with Ryzen SoC
                    Console.WriteLine("\tSensor: {0}, value: {1} C", sensor.Name, Math.Round((float)sensor.Value, 2));

                // Only working with Ryzen SoC
                if (sensor.Name.Contains("GPU VR SoC")) // (GPU Core)
                    Console.WriteLine("\tSensor: {0}, value: {1} C", sensor.Name.Replace("VR SoC", "Core"),
                        Math.Round((float)sensor.Value, 2));

                // TODO - Get GPU Core temperature on desktop, not only Radeon iGpu
                /*
                if (sensor.Name.Contains("GPU Core")) // (GPU Core)
                    Console.WriteLine("\tSensor: {0}, value: {1} C", sensor.Name, Math.Round((float)sensor.Value, 2));
                */
            }
        }

        computer.Close();
    }
}