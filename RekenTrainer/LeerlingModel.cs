using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace RekenTrainer
{
    class LeerlingModel
    {
		Random randomGenerator = new Random();

		//fields
		private int _randomGetal;
		public int RandomGetal
		{
			get { return _randomGetal; }
			set { _randomGetal = value; }
		}

		
		private int _getal1;

		public int Getal1
		{
			get { return  _getal1; }
			set {  _getal1 = value; }
		}

		private int _getal2;

		public int Getal2
		{
			get { return _getal2; }
			set { _getal2 = value; }
		}

		private int _plusOfMin;

		public int PlusOfMin
		{
			get { return _plusOfMin; }
			set { _plusOfMin = value; }
		}

		private string _PlusOfMinTekst;

		public  string PlusOfMinTekst
		{
			get { return _PlusOfMinTekst; }
			set { _PlusOfMinTekst = value; }
		}


		private string _achternaam;

		public string Achternaam
		{
			get { return _achternaam; }
			set { _achternaam = value; }
		}

		private string _voornaam;

		public  string Voornaam
		{
			get { return _voornaam; }
			set { _voornaam = value; }
		}

		private string _klas;

		public string Klas
		{
			get { return _klas; }
			set { _klas = value; }
		}

		private int _uitkomst;

		public int Uitkomst
		{
			get { return _uitkomst; }
			set { _uitkomst = value; }
		}

		private int? _antwoord;

		public int? Antwoord
		{
			get { return _antwoord; }
			set { _antwoord = value; }
		}

		private int _aantalOpgaven;

		public int AantalOpgaven
		{
			get { return _aantalOpgaven; }
			set { _aantalOpgaven = value; }
		}

		private List<LeerlingModel> _OpgavesOpslaanLijst = new List<LeerlingModel>();

		private int _stappenTeller;

		public int StappenTeller
		{
			get { return _stappenTeller; }
			set { _stappenTeller = value; }
		}

		private List<LeerlingModel> _antwoordEnUitkomstLijst = new List<LeerlingModel>();

		public List<LeerlingModel> AntwoordEnUitkomstLijst
		{
			get { return _antwoordEnUitkomstLijst; }
			set { _antwoordEnUitkomstLijst = value; }
		}

		private List<LeerlingModel> _randomLijst = new List<LeerlingModel>();

		public List<LeerlingModel> RandomLijst
		{
			get { return _randomLijst; }
			set { _randomLijst = value; }
		}

		// Constructors

		public LeerlingModel(int getal1, int getal2, int plusOfMin)
		{
			Getal1 = getal1;
			Getal2 = getal2;
			PlusOfMin = plusOfMin;
		}

		public LeerlingModel(int uitkomst, int? antwoord)
		{
			Uitkomst = uitkomst;
			Antwoord = antwoord;
		}

		private int _behaaldePunten;

		public int BehaaldePunten
		{
			get { return _behaaldePunten; }
			set { _behaaldePunten = value; }
		}


		// Methodes

		public void AantalOpgavenNaarInt (string aantalOefenigen)
		{
			bool Succes;
			int s;
			Succes = int.TryParse(aantalOefenigen, out s); // manier om een string om te zetten naar een int ALLEEN als de inhoud in een INT kan worden gestoken.
			if (Succes) //True
			{
				AantalOpgaven = s;
			}

			
		}
		
		private void RandomGetallenGeneren(int Maxgetal)
		{
			for (int i = 0; i < AantalOpgaven; i++)
			{
				Getal1 = randomGenerator.Next(0, Maxgetal + 1);
				Getal2 = randomGenerator.Next(0, Maxgetal + 1);
				if (Klas == "1ste Leerjaar" || Klas == "2de Leerjaar")
				{
					while (Getal1 < Getal2)
					{
						Getal1 = randomGenerator.Next(0, Maxgetal + 1);
					}
				}
				PlusOfMin = randomGenerator.Next(0, 2);
				RandomLijst.Add(new LeerlingModel(Getal1, Getal2, PlusOfMin));
			}
			
		}

		public void PlusOfMinGenereren(int plusOfMin)
		{
			if (PlusOfMin == 1)
			{
				PlusOfMinTekst = "-";
			}
			else
			{
				PlusOfMinTekst = "+";
			}
		}

		public void ControlerenUitkomsten()
		{
			BehaaldePunten = 0;
			foreach (LeerlingModel ingaveLeerling in AntwoordEnUitkomstLijst)
			{
				if ( ingaveLeerling.Antwoord == ingaveLeerling.Uitkomst)
				{
					BehaaldePunten = ++BehaaldePunten;
				}
			}
		}
		public void SommenGenereren ()
		{
			if (Klas == "1ste Leerjaar")
			{
				RandomGetallenGeneren(10);
			}

			else if (Klas == "2de Leerjaar")
			{
				RandomGetallenGeneren(20);
			}
			
			else if (Klas == "3de Leerjaar" || Klas == "4de Leerjaar")
			{
				RandomGetallenGeneren(20);
			}
			else 
			{
				RandomGetallenGeneren(100);
			}
			AntwoordBerekenen();
		}

		public void AntwoordBerekenen()
		{
			{
				foreach (LeerlingModel UitkomstBerekenen in RandomLijst)
				{
					if (PlusOfMin == 1)
					{
						UitkomstBerekenen.Uitkomst = UitkomstBerekenen.Getal1 - UitkomstBerekenen.Getal2;
					}
					else
					{
						UitkomstBerekenen.Uitkomst = UitkomstBerekenen.Getal1 + UitkomstBerekenen.Getal2;
					}
					AntwoordEnUitkomstLijst.Add(new LeerlingModel(Uitkomst, null));

				}
				
				
			}
			
		}
		
		public void VerderZettenLoop(string antwoord)
		{
			bool Succes;
			int s;
			Succes = int.TryParse(antwoord, out s); // manier om een string om te zetten naar een int ALLEEN als de inhoud in een INT kan worden gestoken.
			if (Succes) //True
			{
				Antwoord = s;
			}
			else
			{
				Antwoord = null;
			}
			
			++StappenTeller;
		}
		
		
		
			
		
	}
}
