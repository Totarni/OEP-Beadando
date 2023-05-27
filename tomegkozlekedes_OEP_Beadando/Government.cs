using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tomegkozlekedes_OEP_Beadando
{
    public class NoVehicleException : Exception { }
    public class IncorrectVehicleException : Exception { }
    public class Government
    {
        public string name;
        private List<Company> companies;
        private List<Vehicle> vehicles;

        public Government(string name)
        {
            companies = new List<Company>();
            vehicles = new List<Vehicle>();
            this.name = name;
        }

        public void AddVehicle(string id, string type, Zone zone, DateOnly creationDate, double originalPrice)
        {
            switch (type)
            {
                case "Villamos":
                    vehicles.Add(new Villamos(id, creationDate, originalPrice, zone));
                    break;
                case "Autóbusz":
                    vehicles.Add(new Autobusz(id, creationDate, originalPrice, zone));
                    break;
                case "Troli":
                    vehicles.Add(new Troli(id, creationDate, originalPrice, zone));
                    break;
                default:
                    throw new IncorrectVehicleException();
            }
        }
        public Company GetCompanyByName(string name)
        {
            foreach (Company company in companies)
            {
                if (company.name == name) return company;
            }
            return AddCompany(name);
        }
        private Company AddCompany(string company)
        {
            Company comp = new Company(company);
            companies.Add(comp);
            return comp;
        }
        public Vehicle GetVehicleById(string id)
        {
            foreach (Vehicle j in vehicles)
            {
                if (j.GetId() == id) return j;
            }
            throw new NoVehicleException();
        }

        public double OldBusesRate()
        {
            int cnt = 0;
            foreach (Vehicle j in vehicles)
            {
                if ((DateTime.Now.Year - j.GetCreationDate().Year) > 15 && j is Autobusz)
                {
                    cnt++;
                }
            }
            double cntbuses = 0;
            foreach (Vehicle j in vehicles)
            {
                if (j is Autobusz)
                {
                    cntbuses++;
                }
            }
            return cnt / cntbuses;
        }

        public Vehicle MostValuableVehicle()
        {
            if (vehicles.Count == 0) throw new NoVehicleException();
            Vehicle maxVehicle = vehicles[0];
            double maxPrice = maxVehicle.ActualPrice();
            for (int i = 1; i < vehicles.Count; i++)
            {
                if (vehicles[i].ActualPrice() > maxPrice)
                {
                    maxVehicle = vehicles[i];
                    maxPrice = maxVehicle.ActualPrice();
                }
            }
            return maxVehicle;
        }

        public double MaintenanceRate()
        {
            int cntMaintenance = 0;
            double cntNotReview = 0;
            foreach (Vehicle j in vehicles)
            {
                if (j.IsUnderMaintenance()) cntMaintenance++;
                if (!j.IsUnderReview()) cntNotReview++;
            }
            return cntMaintenance / cntNotReview;
        }

        //karbantartási díj
        public Vehicle MostExpensiveFeeVehicle()
        {
            if (vehicles.Count == 0) throw new NoVehicleException();
            Vehicle vehicleMax = null!;
            double maxFee = -1;//ugye negativ nem lehet
            for (int i = 0; i < vehicles.Count; i++)
            {
                try
                {
                    if (vehicles[i].GetMaxServiceFee2022() > maxFee)
                    {
                        vehicleMax = vehicles[i];
                        maxFee = vehicleMax.GetMaxServiceFee2022();
                    }
                }
                catch (NoWorksheetException) { continue; }//semmi baj,ki kell hagyni mert nem volt megfelelő munkalap
            }
            if (vehicleMax == null) throw new NoVehicleException();
            return vehicleMax;
        }
    }
}
