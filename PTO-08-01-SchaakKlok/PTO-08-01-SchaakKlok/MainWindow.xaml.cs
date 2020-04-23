using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Schaakklok.CB;


namespace PTO_08_01_SchaakKlok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        Timer RechterKlok = new Timer();
        Timer LinkerKlok = new Timer();
        private DispatcherTimer cronoLinks;
        private DispatcherTimer cronoRechts;
        
        public MainWindow()
        {
            InitializeComponent();
            lblKlokLinks.Content = LinkerKlok.ResterendeTijd;
            lblKlokRechts.Content = RechterKlok.ResterendeTijd;
        }
        
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            RechterKlok.IngegevenTijdOpvangen(txtTijdIngeven.Text);
            LinkerKlok.IngegevenTijdOpvangen(txtTijdIngeven.Text);
            lblKlokLinks.Content = LinkerKlok.ResterendeTijd;
            lblKlokRechts.Content = RechterKlok.ResterendeTijd;
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            cronoLinks = new DispatcherTimer();
            cronoLinks.Interval = new TimeSpan(0,0,1);
            cronoRechts = new DispatcherTimer();
            cronoRechts.Interval = new TimeSpan(0,0,1);
            cronoLinks.Start();
            cronoRechts.Stop();
            cronoLinks.Tick += new EventHandler(timerTickLinks);
        }
        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (cronoLinks.IsEnabled == true)
            {
                cronoLinks.Stop();
                cronoRechts.Start();
                cronoRechts.Tick += new EventHandler(timerTickRechts);
            }
            else
            {
                cronoLinks.Start();
                cronoRechts.Stop();
                cronoLinks.Tick += new EventHandler(timerTickLinks);
            }
        }

        private void timerTickLinks(object sender, EventArgs e)
        {
        
            LinkerKlok.SecondenAftellen();
            lblKlokLinks.Content = LinkerKlok.ResterendeTijd;
            lblKlokRechts.Content = RechterKlok.ResterendeTijd;
        }

        private void timerTickRechts(object sender, EventArgs e)
        {
            
            RechterKlok.SecondenAftellen();
            lblKlokLinks.Content = LinkerKlok.ResterendeTijd;
            lblKlokRechts.Content = RechterKlok.ResterendeTijd;
        }
    }
}
