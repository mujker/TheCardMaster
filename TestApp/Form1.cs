using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TestApp
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
            List<Color> colors = new List<Color>();
            colors.Add(Color.Yellow);
            colors.Add(Color.Blue);
            colors.Add(Color.Red);
            Task.Factory.StartNew(delegate
            {
                while (true)
                {
                    foreach (Color color in colors)
                    {
                        pictureBox1.Invoke((Action) delegate { pictureBox1.BackColor = color; });
                        Thread.Sleep(2500);
                    }
                }
            });
        }
    }
}
