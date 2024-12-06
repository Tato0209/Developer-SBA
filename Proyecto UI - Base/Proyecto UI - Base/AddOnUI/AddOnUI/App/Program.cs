using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AddOnUI.App; // Add this line to include the App namespace

namespace AddOnUI
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Main oMain = new Main(); // Create an instance of the Main class

            System.Windows.Forms.Application.Run(); // Run the application //what is the purpose of this line? //This line is used to start the application and keep it running until the user closes it.
        }
    }
}
