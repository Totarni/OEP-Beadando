using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beadando_Tömegközlekedés
{
    public class NincsJarmuException : Exception { }
    public class NincsMegfeleloException : Exception { }
    public class Onkormanyzat
    {
        public List<Jarmu> Jarmuvek = new List<Jarmu>();
        public List<Ceg> Cegek = new List<Ceg>();

        public Onkormanyzat() { Jarmuvek = new List<Jarmu>(); Cegek = new List<Ceg>(); }
        public Jarmu JarmuKeres(string azon)
        {
            foreach (Jarmu jarmu in Jarmuvek)
            {
                if (jarmu.azon == azon) return jarmu;
            }
            throw new NincsJarmuException();
        }
        public string arany15EvesBuszpark()
        {
            int s = 0;
            int s2 = 0;
            foreach (Jarmu jarmu in Jarmuvek)
            {
                if (jarmu.tipus == "Autóbusz") { s++; }
                if (jarmu.tipus == "Autóbusz" && 2023 - jarmu.gyartasev > 15) { s2++; }
            }
            if(s <1)
                return "";
            return $"{s2} : {s}";
        }

        public Jarmu LegdragabbEvben(int ev)
        {
            Munkalap max = null!;
            foreach (Ceg ceg in Cegek)
            {
                try
                {
                    if (max == null)
                        max = ceg.LegdragabbEvben(ev);
                    else if (max.ar < ceg.LegdragabbEvben(ev).ar)
                        max = ceg.LegdragabbEvben(ev);
                }
                catch (NincsMegfeleloException)
                {
                    //skip
                }
            }
            if(max == null) throw new NincsMegfeleloException();
            return max.jarmu;
        }

        public Jarmu dragaJarmu()
        {
            if(Jarmuvek.Count != 0)
            {
                Jarmu maxjarm = Jarmuvek[0];
                double maxar =  maxjarm.jelar;
                for (int i = 1; i < Jarmuvek.Count; i++)
                {
                    if (Jarmuvek[i].jelar > maxar)
                    {
                        maxjarm= Jarmuvek[i];
                        maxar = maxjarm.jelar;
                    }
                }
                return maxjarm;
            }
            else { throw new NincsJarmuException(); }
        }
        public string JavitasArany()
        {
            int n =0;
            foreach (Ceg ceg in Cegek)
            {
                n += ceg.JavitasAlattDB();
            }
            if(n ==0) return "";
            else return $" {n} : {Jarmuvek.Count}";
        }
    }
}
