using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneySaved
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        System.Windows.Threading.DispatcherTimer dispatcherTimer;
        DateTime timeBegin = new DateTime(2019, 10, 26, 14, 0, 0);
        double cigarettesPerSecond = 20f / 24f / 60f / 60f;
        double dollarsPerCigarette = 3.75f / 20f;
       
        string lastCount;

        public MainWindow()
        {
            InitializeComponent();

            
            Update();

            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Update();
        }

        private void  Update() { 
            
            double secs = DateTime.Now.Subtract(timeBegin).TotalSeconds;

            double cigarettes = secs * cigarettesPerSecond;
            double dollars = cigarettes * dollarsPerCigarette;

            Count.Text = cigarettes.ToString("F0");
            Money.Text = dollars.ToString("C");

            if( Count.Text != lastCount )
            {
                using (SoundPlayer playSound = new SoundPlayer(Properties.Resources.Got500))
                {
                    playSound.Play();
                }
                    
            }

            lastCount = Count.Text;

            double days = DateTime.Now.Subtract(timeBegin).TotalDays;

            Days.Text = days.ToString("F0");




        }

    }
}
