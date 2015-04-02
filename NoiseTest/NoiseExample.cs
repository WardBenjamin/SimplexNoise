// Simplex noise example.
// Author: Benjamin Ward
// Original version by Heikki Törmälä 2012
// Improved by Draco Rat 2013 (Improved GUI with gridsize, random seed, faster drawing and time taken to draw.)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NoiseTest
{
    static class NoiseExample
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
