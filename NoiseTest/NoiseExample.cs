// Simplex Noise for C#
// Copyright © Benjamin Ward 2019
// See LICENSE
// Simplex Noise implementation offering 1D, 2D, and 3D forms w/ values in the range of 0 to 255.
// Based on work by Heikki Törmälä (2012) and Stefan Gustavson (2006).
// Contribution by Draco Rat 2013 (Improved GUI with gridsize, random seed, faster drawing and time taken to draw.)

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
