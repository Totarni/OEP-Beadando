using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomegkozlekedes_OEP_Beadando
{
    public class NotFinishedException : Exception { }
    public enum MyType
    {
        Javitás,
        Átvizsgálás
    }
    public class Worksheet
    {
        private Company company;
        private Vehicle vehicle;
        private DateOnly sheetCreation;
        private DateOnly from;
        private DateOnly to;
        private double cost;
        private MyType type;

        public Worksheet(Company company, Vehicle vehicle, DateOnly sheetCreation, DateOnly from, MyType type)
        {
            this.company = company;
            this.vehicle = vehicle;
            this.sheetCreation = sheetCreation;
            this.from = from;
            this.type = type;
        }

        public Worksheet(Company company, Vehicle vehicle, DateOnly sheetCreation, DateOnly from, DateOnly to, double cost, MyType type)
        {
            this.company = company;
            this.vehicle = vehicle;
            this.sheetCreation = sheetCreation;
            this.from = from;
            this.to = to;
            this.cost = cost;
            this.type = type;
        }

        public void WoorksheetComplete(double cost, DateOnly to)
        {
            //ez csak azokra lesz meg híva ami még nincs be fejezve. lesz feljebb rá megoldás
            this.to = to;
            this.cost = cost;
        }

        public double GetCost()
        {
            return cost;
        }

        public new MyType GetType() //itt a new szót a javasolta esetleg majd megkérdezem mit is jelent
        {
            return type;
        }
        //itt rájöttem hogy azt kell nézni hogy mikor van már ki fizetve egy jármű. nem azt hogy mikor kezdték
        /*public DateOnly GetSheetCreation()
        {
            return sheetCreation;
        }*/
        public DateOnly GetSheetEnd()
        {
            if (to == default(DateOnly)) //idk hogy ez müködik e
            {
                throw new NotFinishedException();
            }
            return to;
        }

    }


}
