using MSLM.ProcessExtensions;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;

namespace demo
{
    public partial class DemoService : ServiceBase
    {
        private Timer timer;
        public DemoService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            ProcessExtensions.StartProcessAsCurrentUser("C:\\TX\\TX.exe");

            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("TX");
            if (pname.Length == 0)
            {
                ProcessExtensions.StartProcessAsCurrentUser("C:\\TX\\TX.exe");
            }
            else
            {
                
            }
        }

        protected override void OnStop()
        {
        }
    }
}
