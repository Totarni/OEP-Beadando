using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Tömegközlekedés
{
    public class Ceg
    {
        public string cegnev;
        public List<Munkalap> munkalapok;
        public Ceg(string nev)
        {
            cegnev = nev;
            munkalapok = new List<Munkalap>();
        }
        public void MunkalapLetreJon(int mikor, string mettol, Jarmu jarmu, string tipus)
        {
            munkalapok.Add(new Munkalap(mikor, mettol, jarmu, this, tipus));
        }
        public void MunkalapLetreJon(int mikor, string mettol, Jarmu jarmu, string tipus,string meddig,int ar)
        {
            munkalapok.Add(new Munkalap(mikor, mettol, jarmu, this, tipus,meddig,ar));
        }

        public Munkalap LegdragabbEvben(int ev)
        {
            bool l = false;
            Munkalap max= null!;
            foreach (Munkalap munkalap in munkalapok)
            {
                if(!l && munkalap.mikor == ev)
                {
                    l = true;
                    max = munkalap;
                }else if (l && munkalap.mikor == ev)
                {
                    if(munkalap.ar > max.ar)
                    {
                        max = munkalap;
                    }
                }
            }
            if(max == null) throw new NincsMegfeleloException();
            return max;
        }

        public int JavitasAlattDB()
        {
            int n = 0;
            foreach (Munkalap lapok in munkalapok)
            {
                if (lapok.befejezett == false && lapok.tipus == "javítás")
                {
                    n++;
                }
            }
            return n;
        }
    }
}
