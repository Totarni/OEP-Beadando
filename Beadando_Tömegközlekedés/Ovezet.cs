using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando_Tömegközlekedés
{
    public interface Ovezet
    {
        public double faktor(Villamos f);
        public double faktor(Autobusz f);
        public double faktor(Troli f);
    }

    public class Belvaros : Ovezet
    {
        private static Belvaros pelda = null!;
        public static Belvaros Peldany()
        {
            if (pelda == null) pelda = new Belvaros();
            return pelda;
        }

        public double faktor(Villamos f) { return 1.0; }
        public double faktor(Autobusz f) { return 2.0; }
        public double faktor(Troli f) { return 3.0; }
    }
    public class Kulvaros : Ovezet
    {
        private static Kulvaros pelda = null!;
        public static Kulvaros Peldany()
        {
            if (pelda == null) pelda = new Kulvaros();
            return pelda;
        }

        public double faktor(Villamos f) { return 0.9; }
        public double faktor(Autobusz f) { return 2.0; }
        public double faktor(Troli f) { return 3.1; }
    }
    public class Vegyes : Ovezet
    {
        private static Vegyes pelda = null!;
        public static Vegyes Peldany()
        {
            if (pelda == null) pelda = new Vegyes();
            return pelda;
        }

        public double faktor(Villamos f) { return 1.2; }
        public double faktor(Autobusz f) { return 2.5; }
        public double faktor(Troli f) { return 3.8; }
    }
}
