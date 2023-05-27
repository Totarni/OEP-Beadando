using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomegkozlekedes_OEP_Beadando
{
    public abstract class Zone
    {
        public abstract string zoneName { get; }
        public abstract double Factor(Villamos f);
        public abstract double Factor(Autobusz f);
        public abstract double Factor(Troli f);

        /*public double Factor(Vehicle vehicle)
        {
            throw new NotImplementedException();
            //a vehicle-t ugy se példáyositanak, de nem tudom/emlékszem hogy lehetne rá mondani valamit hogy ilyenkor ezt ne keljen létre hozni. esetleg majd megkérdezem ha nem felejtem el. :)
        }*/
    }

    public class Belvaros : Zone
    {
        private static Belvaros? instance;
        private Belvaros() { }
        public static Belvaros Instance()
        {
            instance ??= new Belvaros();
            return instance;
        }

        public override string zoneName { get { return "Belváros"; } }
        public override double Factor(Villamos f)
        {
            return 1.0;
        }
        public override double Factor(Autobusz f)
        {
            return 2.0;
        }
        public override double Factor(Troli f)
        {
            return 3.0;
        }
    }
    public class Kulvaros : Zone
    {
        private static Kulvaros? instance;
        private Kulvaros() { }
        public static Kulvaros Instance()
        {
            instance ??= new Kulvaros();
            return instance;
        }
        public override string zoneName { get { return "Külváros"; } }
        public override double Factor(Villamos f)
        {
            return 0.9;
        }
        public override double Factor(Autobusz f)
        {
            return 2.0;
        }
        public override double Factor(Troli f)
        {
            return 3.1;
        }
    }
    public class Vegyes : Zone
    {
        private static Vegyes? instance;
        private Vegyes() { }
        public static Vegyes Instance()
        {
            instance ??= new Vegyes();
            return instance;
        }
        public override string zoneName { get { return "Vegyes"; } }
        public override double Factor(Villamos f)
        {
            return 1.2;
        }
        public override double Factor(Autobusz f)
        {
            return 2.5;
        }
        public override double Factor(Troli f)
        {
            return 3.8;
        }
    }
}
