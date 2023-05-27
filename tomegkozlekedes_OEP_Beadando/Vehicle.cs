using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomegkozlekedes_OEP_Beadando
{
    public class ActiveWorksheetException : Exception { }
    public class NoActiveWorksheetException : Exception { }
    public class NoWorksheetException : Exception { }
    public class Vehicle
    {
        protected string id;
        //protected string type;
        protected DateOnly creationDate;
        protected double originalPrice;
        protected Worksheet actualWorksheet;
        protected List<Worksheet> worksheets;
        protected Zone zone;
        protected double factor;

        public Vehicle(string id, DateOnly creationDate, double originalPrice, Zone zone)
        {
            this.id = id;
            this.creationDate = creationDate;
            this.originalPrice = originalPrice;
            actualWorksheet = null!;
            worksheets = new List<Worksheet>();
            this.zone = zone;
            factor= -1.0;
        }

        /*public void CreateSheet(Company company, MyType type)//jelen pillanatba
        {
            if (actualWorksheet != null) throw new ActiveWorksheetException();
            actualWorksheet = new Worksheet(company, this, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now), type);
            worksheets.Add(actualWorksheet);
        }*/
        public void CreateSheet(DateOnly sheetCreation, DateOnly from, DateOnly to, double cost, MyType type, Company company) //befejezett lap hozzá adása
        {
            //if (actualWorksheet != null) throw new ActiveWorksheetException();
            //actualWorksheet = new Worksheet(company, this, sheetCreation, from, to, cost, type);
            worksheets.Add(new Worksheet(company, this, sheetCreation, from, to, cost, type));
        }
        public void CreateSheet(DateOnly sheetCreation, DateOnly from, MyType type, Company company)// nyitott lap hozzá adása
        {
            if (actualWorksheet != null) throw new ActiveWorksheetException();
            actualWorksheet = new Worksheet(company, this, sheetCreation, from, type);
            worksheets.Add(actualWorksheet);
        }
        public void CompleteSheet(double cost, DateOnly to)
        {
            if (actualWorksheet == null) throw new NoActiveWorksheetException();
            actualWorksheet.WoorksheetComplete(cost, to);
            actualWorksheet = null!;
        }

        public double ActualPrice()
        {
            return originalPrice * (100 - (DateOnly.FromDateTime(DateTime.Now).Year - creationDate.Year)) / (100.0 * factor);
        }

        public double GetMaxServiceFee2022()
        {
            if (worksheets.Count == 0) throw new NoWorksheetException();
            double maxfee = -1;
            bool l = false;
            foreach (Worksheet m in worksheets)
            {
                try
                {

                    if (!l && m.GetSheetEnd().Year == 2022)//lehet akkor fizetnek amikor befejezték a javitást
                    {
                        maxfee = m.GetCost();
                        l = true;
                    }
                    else if (l && m.GetSheetEnd().Year == 2022)
                    {
                        if (maxfee < m.GetCost())
                        {
                            maxfee = m.GetCost();
                        }
                    }
                }
                catch (NotFinishedException)
                {
                    continue; //szimplán skippeljük azt amikor egy befejeztlennel talizunk.
                }
            }
            if (maxfee == -1) throw new NoWorksheetException();
            return maxfee;
        }

        public DateOnly GetCreationDate()
        {
            return creationDate;
        }

        /*public String GetType()
        {
            return type;
        }*/

        public bool IsUnderReview()
        {
            if (actualWorksheet == null) return false;
            return actualWorksheet.GetType().Equals(MyType.Átvizsgálás);
        }
        public bool IsUnderMaintenance()
        {
            if (actualWorksheet == null) return false;
            return actualWorksheet.GetType().Equals(MyType.Javitás);
        }
        public bool GetWorking()
        {
            if (actualWorksheet == null) return true;
            else return false;
        }
        public string GetId()
        {
            return id;
        }

    }
    public class Villamos : Vehicle
    {
        public Villamos(string id, DateOnly creationDate, double originalPrice, Zone zone) : base(id, creationDate, originalPrice, zone) { factor = zone.Factor(this); }
    }
    public class Autobusz : Vehicle
    {
        public Autobusz(string id, DateOnly creationDate, double originalPrice, Zone zone) : base(id, creationDate, originalPrice, zone) { factor = zone.Factor(this); }
    }
    public class Troli : Vehicle
    {
        public Troli(string id, DateOnly creationDate, double originalPrice, Zone zone) : base(id, creationDate, originalPrice, zone) { factor = zone.Factor(this); }
    }
}
