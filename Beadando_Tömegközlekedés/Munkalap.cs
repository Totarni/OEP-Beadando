using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Tömegközlekedés
{
    public class Munkalap
    {
        public int mikor;
        public string mettol;
        public Jarmu jarmu;
        public Ceg ceg;
        public string tipus;
        public bool befejezett;
        public string meddig;
        public double ar;
        public Munkalap(int mikor, string mettol, Jarmu jarmu, Ceg ceg, string tipus)
        {
            this.mikor = mikor;
            this.mettol = mettol;
            this.jarmu = jarmu;
            this.ceg = ceg;
            this.tipus = tipus;
            befejezett = false;
        }
        public Munkalap(int mikor, string mettol, Jarmu jarmu, Ceg ceg, string tipus, string meddig, double ar)
        {
            this.mikor = mikor;
            this.mettol = mettol;
            this.jarmu = jarmu;
            this.ceg = ceg;
            this.tipus = tipus;
            befejezett = true;
            this.meddig = meddig;
            this.ar = ar;
        }
        public void Befejez(string befDatum, double ar)
        {
            if(!befejezett) { 
            meddig = befDatum;
            this.ar = ar;
            befejezett = true;
            }
        }
    }
}
