using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohariFenster
{
    public class Adjektiv
    {
        // Private Felder, die ID und den Namen des Adjektivs speichern
        private int _adjektivID;
        private string _adjektiv;

        // Öffentlicher Getter für die AdjektivID, keine Set-Methode, da ID nicht verändert werden sollte
        public int AdjektivID
        {
            get { return _adjektivID; }
        }

        // Öffentlicher Getter und Setter für den Adjektivnamen
        public string Adjektive
        {
            get { return _adjektiv; }
            set { _adjektiv = value; }
        }
    }
}
