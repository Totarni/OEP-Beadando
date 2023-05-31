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
            //ez csak azokra lesz meg híva ami még nincs be fejezve.
            this.to = to;
            this.cost = cost;
        }

        public double GetCost()
        {
            return cost;
        }

        public new MyType GetType()
        {
            return type;
        }
        public DateOnly GetSheetEnd()
        {
            if (to == default(DateOnly)) //ezt interneten találtam, elvileg megnézi hogy létezik e a to.
            {
                throw new NotFinishedException();
            }
            return to;
        }

    }


}
