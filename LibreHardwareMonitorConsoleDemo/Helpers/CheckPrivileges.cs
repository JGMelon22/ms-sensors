using System.Security.Principal;

namespace LibreHardwareMonitorConsoleDemo.Helpers;

public static class CheckPrivileges
{
    public static bool IsAdministrator()
    {
        return new WindowsPrincipal(WindowsIdentity.GetCurrent())
            .IsInRole(WindowsBuiltInRole.Administrator);
    }
}