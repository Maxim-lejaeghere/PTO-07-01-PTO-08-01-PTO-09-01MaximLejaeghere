﻿using System;
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

        private void btnStarten_Click(object sender, RoutedEventArgs e)
        {
            leerlingIngave.Klas = comboLeerjaar.Text;
            leerlingIngave.AantalOpgavenNaarInt(txtUitkomst.Text);
            if (comboLeerjaar.SelectedItem != null && txtVoornaam.Text != string.Empty && txtAchternaam.Text != string.Empty && leerlingIngave.AantalOpgaven != 0)
            {
                btnIngeven.IsEnabled = true;
                btnStarten.IsEnabled = false;
                leerlingIngave.StappenTeller = 0;
                leerlingIngave.SommenGenereren();
                leerlingIngave.PlusOfMin = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].PlusOfMin;
                leerlingIngave.Getal1 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal1;
                leerlingIngave.Getal2 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller].Getal2;
                leerlingIngave.PlusOfMinGenereren();
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

        private void btnIngeven_Click(object sender, RoutedEventArgs e)
        {
            leerlingIngave.VerderZettenLoop(txtUitkomst.Text);
            leerlingIngave.AntwoordBerekenen();

            if (leerlingIngave.StappenTeller - 1 < leerlingIngave.RandomLijst.Count)
            {
                leerlingIngave.PlusOfMin = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller - 1].PlusOfMin;
                leerlingIngave.Getal1 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller - 1].Getal1;
                leerlingIngave.Getal2 = leerlingIngave.RandomLijst[leerlingIngave.StappenTeller - 1].Getal2;
                leerlingIngave.PlusOfMinGenereren();
                lblOpgave.Content = $"{leerlingIngave.Getal1} {leerlingIngave.PlusOfMinTekst} {leerlingIngave.Getal2} = ?";
                
            }
            if (leerlingIngave.StappenTeller - 1 == leerlingIngave.RandomLijst.Count)
            {
                btnIngeven.IsEnabled = false;
                btnResultaat.IsEnabled = true;
            }
            txtUitkomst.Text = "";
        }

        private void btnResultaat_Click(object sender, RoutedEventArgs e)
        {
            leerlingIngave.ControlerenUitkomsten();
            lblOpgave.Content = $"Je hebt {leerlingIngave.BehaaldePunten} op {leerlingIngave.AntwoordEnUitkomstLijst.Count}";
            txtAchternaam.Text = string.Empty;
            txtUitkomst.Text = string.Empty;
            txtVoornaam.Text = string.Empty;
            comboLeerjaar.SelectedItem = false;
            lblStart.Content = "Druk op starten om te beginnen!";
            leerlingIngave.RandomLijst.Clear();
            leerlingIngave.AntwoordEnUitkomstLijst.Clear();
            leerlingIngave.StappenTeller = 0;
            btnResultaat.IsEnabled = false;
            btnStarten.IsEnabled = true;
        }
    }
}
