using LibreHardwareMonitorConsoleDemo;
using LibreHardwareMonitorConsoleDemo.Helpers;

Console.Clear();

try
{
    if (CheckPrivileges.IsAdministrator() == false)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("To properly work, this program must with admin privileges.");
        Console.ResetColor();
        Thread.Sleep(1200);
        Environment.Exit(0);
    }

    else
    {
        Console.WriteLine("### Libre Hardware Monitor CLI - September/2022 dll ###");
        HardwareInfo.Monitor();
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
}