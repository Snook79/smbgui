using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace SMBGUI
{
    static class Program
    {
        // Definizione del mutex
        static Mutex _mutex = new Mutex(true, "SMBGui_Unique");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Verifica se il mutex è già acquisito
            if (!_mutex.WaitOne(TimeSpan.Zero))
            {
                MessageBox.Show("L'applicazione è già in esecuzione.");
                return;
            }

            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmGui());
            }
            finally
            {
                // Rilascio del mutex al termine dell'esecuzione dell'applicazione
                _mutex.ReleaseMutex();
            }
        }
    }
}
