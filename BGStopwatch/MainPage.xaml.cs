using System;
using System.Diagnostics;
using Xamarin.Forms;
using BGStopwatch.Helpers;

namespace BGStopWatch
{
    public partial class MainPage : GradientContentPage
    {
        private readonly Stopwatch stopwatch;

        public MainPage()
        {
            InitializeComponent();
            stopwatch = new Stopwatch();

            labelStopwatch.Text = "00:00:00.00";
        }

        private void buttonStart_Clicked(object sender, EventArgs e)
        {
            if (!stopwatch.IsRunning)
            {
                stopwatch.Start();

                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                    {
                        labelStopwatch.Text = string.Format("{0:hh\\:mm\\:ss\\.ff}", stopwatch.Elapsed);

                        if (!stopwatch.IsRunning)
                            return false;
                        return true;
                    }
                );
            }
        }

        private void buttonStop_Clicked(object sender, EventArgs e)
        {
            stopwatch.Stop();
        }

        private void buttonReset_Clicked(object sender, EventArgs e)
        {
            labelStopwatch.Text = "00:00:00.00";
            stopwatch.Reset();
        }
    }
}