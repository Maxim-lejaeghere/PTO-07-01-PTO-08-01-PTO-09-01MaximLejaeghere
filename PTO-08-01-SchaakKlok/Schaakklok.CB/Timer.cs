using System;


namespace Schaakklok.CB
{
	

	public class Timer
    {
		
		private string _IngegevenTekst;

		public string IngegevenTekst
		{
			get { return _IngegevenTekst; }
			set { _IngegevenTekst = value; }
		}


		private int _ingegevenTijd;

		public int IngegevenTijd
		{
			get { return _ingegevenTijd; }
			set { _ingegevenTijd = value; }
		}

		private int _resterendeTijd;

		public int ResterendeTijd
		{
			get { return  _resterendeTijd; }
			set {  _resterendeTijd = value; }
		}

		public Timer()
		{

		}

		public int SecondenAftellen()
		{
			ResterendeTijd--;

			return ResterendeTijd;
		}
		
		public void IngegevenTijdOpvangen(string ingegevenTekst)
		{
			bool Succes;
			int s;
			Succes = int.TryParse(ingegevenTekst, out s); // manier om een string om te zetten naar een int ALLEEN als de inhoud in een INT kan worden gestoken.
			if (Succes) //True
			{
				IngegevenTijd = s;
			}
			else
			{
				IngegevenTijd = 0;
			}
			ResterendeTijd = IngegevenTijd;
			
		}



	}
}
