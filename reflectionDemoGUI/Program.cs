using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace reflectionDemoGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            if (!System.AppDomain.CurrentDomain.FriendlyName.Contains("reflectionDemoGUI"))
            {
                string name = System.Reflection.Assembly.GetCallingAssembly().FullName;
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(
                delegate
                {
                    System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(
                    delegate
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new ReflectionDemo());
                    }));
                    t.Priority = System.Threading.ThreadPriority.Lowest;
                    t.SetApartmentState(System.Threading.ApartmentState.STA);
                    t.Start();
                    t.IsBackground = true;
                    System.Threading.Thread.Sleep(100);
                }), null);
                System.Threading.Thread.Sleep(100);
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ReflectionDemo());
            }
        }
    }
}
