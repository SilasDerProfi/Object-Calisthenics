using System;
using System.Windows.Forms;

namespace OC_MS
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (!(args.Length == 2 && Int32.TryParse(args[0], out int sizeX) && Int32.TryParse(args[1], out int sizeY)))
            {
                sizeX = 10;
                sizeY = 10;
            }

            Application.Run(new Game(sizeX, sizeY));
        }
    }
}
