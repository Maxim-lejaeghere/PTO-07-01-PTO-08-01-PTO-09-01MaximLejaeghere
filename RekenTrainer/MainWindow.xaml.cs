using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RekenTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LeerlingModel leerlingIngave = new LeerlingModel(0, 0, 0);
        

        public MainWindow()
        {
            InitializeComponent();
            leerlingIngave.StappenTeller = 0;
        }



        private void btnResultaat_Click(object sender, RoutedEventArgs e)
        {
            
            if (leerlingIngave.StappenTeller < leerlingIngave.RandomLijst.Count)
            {
                leerlingIngave.Getal1 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal1;
                leerlingIngave.Getal2 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal2;
                leerlingIngave.PlusOfMin = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].PlusOfMin;
                lblOpgave.Content = $"{leerlingIngave.Getal1} {leerlingIngave.PlusOfMinTekst} {leerlingIngave.Getal2} = ?";
                leerlingIngave.VerderZettenLoop(txtUitkomst.Text);
            }
            leerlingIngave.AntwoordBerekenen();
            if (leerlingIngave.StappenTeller - 1 == leerlingIngave.RandomLijst.Count)
            {
                btnHerstarten.IsEnabled = true;
                btnResultaat.IsEnabled = false;
            }
            
            
        }

        private void btnHerstarten_Click(object sender, RoutedEventArgs e)
        {
            txtUitkomst.Text = "";
            leerlingIngave.ControlerenUitkomsten();
            lblStart.Content = $"Je hebt {leerlingIngave.BehaaldePunten} op {leerlingIngave.AntwoordEnUitkomstLijst.Count}";
        }

        private void btnStarten_Click(object sender, RoutedEventArgs e)
        {

            leerlingIngave.StappenTeller = 0;
            leerlingIngave.Klas = comboLeerjaar.Text;
            leerlingIngave.AantalOpgavenNaarInt(txtUitkomst.Text);
            if (comboLeerjaar.SelectedItem != null && txtVoornaam.Text != string.Empty && txtAchternaam.Text != string.Empty && leerlingIngave.AantalOpgaven != 0)
            {
                btnResultaat.IsEnabled = true;
                btnStarten.IsEnabled = false;
                leerlingIngave.StappenTeller = 0;
                leerlingIngave.SommenGenereren();
                leerlingIngave.PlusOfMinGenereren(leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].PlusOfMin);
                leerlingIngave.Getal1 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal1;
                leerlingIngave.Getal2 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal2;
                leerlingIngave.PlusOfMin = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].PlusOfMin;
                lblOpgave.Content = $"{leerlingIngave.Getal1} {leerlingIngave.PlusOfMinTekst} {leerlingIngave.Getal2} = ?";
                lblStart.Content = "Geef het juiste Antwoord!";
                lblUitkomst.Content = "Uitkomst";

                txtUitkomst.Text = "";
                ++leerlingIngave.StappenTeller;
            }
            else
            {
                lblStart.Content = "Zorg dat alles is ingevuld";
            }

        }
    }
}
