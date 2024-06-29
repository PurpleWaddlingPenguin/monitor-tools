using System.Runtime.InteropServices;


namespace MonitorTools
{
    public class Program
    {
        // import SendMessage extension
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
                      IntPtr wParam, IntPtr lParam);

        // Constants
        const int HWND_BROADCAST = 0xFFFF;      // broadcast to all devices
        const int WM_SYSCOMMAND = 0x0112;       // flag for system command
        const int SC_MONITORPOWER = 0xF170;     // flag for Monitor power
        const int OPT_MONITOR_ON = -1;          // flag to turn Monitor on           
        const int OPT_MONITOR_OFF = 2;          // flag to turn Monitor off
        const int OPT_MONITOR_STANDBY = 1;      // flag to turn Monitor to standby


        public static void Main(string[] args)
        {
            if(args == null || args.Length != 1)
            {
                OutputDefaultOptions();
                return;
            }

            switch(args[0].ToUpper())
            {
                case "ON":
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, OPT_MONITOR_ON);
                    Console.WriteLine("Monitor Turned On");
                    break;

                case "OFF":
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, OPT_MONITOR_OFF);
                    Console.WriteLine("Monitor Turned Off");
                    break;

                case "STANDBY":
                    SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, OPT_MONITOR_STANDBY);
                    Console.WriteLine("Monitor In Standby");
                    break;

                default:
                    Console.WriteLine("Invalid Option.");
                    Console.WriteLine("");
                    OutputDefaultOptions();
                    break;

            }
        }

        static void OutputDefaultOptions()
        {
            Console.WriteLine("Usage: MonitorTools.exe <option>");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine("  On: Turns Monitor On");
            Console.WriteLine("  Off: Turns Monitor Off");
            Console.WriteLine("  Standby: Sets Monitor to Standby");
        }


    }
}

