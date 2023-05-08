using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Tömegközlekedés
{
    public class OvezetException : Exception { }
    public class Jarmu
    {
        public string azon;
        public int gyartasev;
        public double ujar;
        public string tipus;
        public Ovezet ovezet;
        public double jelar;
        //public List<Munkalap> munkalapok;

        public Jarmu(string azon,int gyartasev,double ujar,string tipus,string ovezet) 
        {
            this.azon= azon;
            this.gyartasev= gyartasev;
            this.ujar= ujar;
            this.tipus= tipus;
            if (ovezet == "Belváros") { this.ovezet = Belvaros.Peldany(); }
            else if (ovezet == "Külváros") { this.ovezet = Kulvaros.Peldany(); }
            else if (ovezet == "Vegyes") { this.ovezet = Vegyes.Peldany(); }
            else throw new OvezetException();
            jelar = -1;
        }
    }

    public class Villamos : Jarmu
    {
        public Villamos(string azon, int gyartasev, double ujar, string ovezet) : base(azon, gyartasev, ujar, "Villamos", ovezet) { jelar = ujar *(100 - (2023 - gyartasev))/(100.0 / this.ovezet.faktor(this)); }
    }
    public class Autobusz : Jarmu
    {
        public Autobusz(string azon, int gyartasev, double ujar, string ovezet) : base(azon, gyartasev, ujar, "Autóbusz", ovezet) { jelar = ujar * (100 - (2023 - gyartasev)) / (100.0 / this.ovezet.faktor(this)); }
    }
    public class Troli : Jarmu
    {
        public Troli(string azon, int gyartasev, double ujar, string ovezet) : base(azon, gyartasev, ujar, "Troli", ovezet) { jelar = ujar * (100 - (2023 - gyartasev)) / (100.0 / this.ovezet.faktor(this)); }
    }
}
