using tomegkozlekedes_OEP_Beadando;

namespace Tomegkozlekedes_Tester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBusesRate()
        {
            Government gov = new Government("Szolnok Városi Közlekedés");

            gov.AddVehicle("azon - 201", "Autóbusz", Belvaros.Instance(), DateOnly.Parse("2014 - 02 - 28"), 7500000);
            gov.AddVehicle("azon - 202", "Villamos", Kulvaros.Instance(), DateOnly.Parse("2017 - 09 - 12"), 6200000);
            gov.AddVehicle("azon - 203", "Troli", Belvaros.Instance(), DateOnly.Parse("2015 - 06 - 19"), 6800000);
            gov.AddVehicle("azon - 204", "Autóbusz", Vegyes.Instance(), DateOnly.Parse("2000 - 02 - 28"), 7100000);
            gov.AddVehicle("azon - 205", "Villamos", Belvaros.Instance(), DateOnly.Parse("2009 - 04 - 08"), 5900000);
            gov.AddVehicle("azon - 206", "Troli", Belvaros.Instance(), DateOnly.Parse("2016 - 08 - 07"), 6600000);

            gov.GetVehicleById("azon - 201").CreateSheet(DateOnly.Parse("2015 - 03 - 10"), DateOnly.Parse("2015 - 03 - 15"), DateOnly.Parse("2021 - 08 - 20"), 180000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2018 - 06 - 15"), DateOnly.Parse("2018 - 06 - 30"), MyType.Átvizsgálás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2019 - 02 - 05"), DateOnly.Parse("2019 - 02 - 10"), DateOnly.Parse("2023 - 02 - 28"), 230000, MyType.Javitás, gov.GetCompanyByName("DebreceniJárműcég"));
            gov.GetVehicleById("azon - 203").CreateSheet(DateOnly.Parse("2016 - 09 - 18"), DateOnly.Parse("2016 - 09 - 25"), DateOnly.Parse("2022 - 11 - 12"), 150000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2009 - 08 - 20"), DateOnly.Parse("2009 - 08 - 30"), DateOnly.Parse("2010 - 06 - 10"), 140000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2010 - 05 - 10"), DateOnly.Parse("2010 - 05 - 20"), DateOnly.Parse("2011 - 09 - 15"), 180000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2014 - 11 - 05"), DateOnly.Parse("2014 - 11 - 15"), DateOnly.Parse("2018 - 01 - 30"), 250000, MyType.Javitás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2015 - 04 - 20"), DateOnly.Parse("2015 - 04 - 25"), MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2018 - 01 - 10"), DateOnly.Parse("2018 - 01 - 15"), DateOnly.Parse("2018 - 05 - 25"), 90000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 206").CreateSheet(DateOnly.Parse("2017 - 03 - 25"), DateOnly.Parse("2017 - 04 - 05"), DateOnly.Parse("2022 - 08 - 15"), 160000, MyType.Átvizsgálás, gov.GetCompanyByName("DebreceniJárműcég"));

            // van 2 db busz és ebből az egyik 15 évestél több tehát 1/2 kell hogy kapjak
            Assert.AreEqual(0.5, gov.OldBusesRate());
        }
        [TestMethod]
        public void TestMostValuableVehicle()
        {
            Government gov = new Government("Szolnok Városi Közlekedés");

            gov.AddVehicle("azon - 201", "Autóbusz", Belvaros.Instance(), DateOnly.Parse("2014 - 02 - 28"), 7500000); //fact  2.0   //7500000*(100 - (2023 - 2014))/(100.0*2.0) = 5250000.0
            gov.AddVehicle("azon - 202", "Villamos", Kulvaros.Instance(), DateOnly.Parse("2017 - 09 - 12"), 6200000);//fact 0.9     //6200000*(100 - (2023 - 2017))/(100.0*0.9) = 5777777.777777778
            gov.AddVehicle("azon - 203", "Troli", Belvaros.Instance(), DateOnly.Parse("2015 - 06 - 19"), 6800000);//fact 3.0        //6800000*(100 - (2023 - 2015))/(100.0*3.0) = 5200000.0
            gov.AddVehicle("azon - 204", "Autóbusz", Vegyes.Instance(), DateOnly.Parse("2000 - 02 - 28"), 7100000);// fact 2.5      //7100000*(100 - (2023 - 2000))/(100.0*2.5) = 3590000.0
            gov.AddVehicle("azon - 205", "Villamos", Belvaros.Instance(), DateOnly.Parse("2009 - 04 - 08"), 5900000);// fact 1.0    //5900000*(100 - (2023 - 2009))/(100.0*1.0) = 5312500.0
            gov.AddVehicle("azon - 206", "Troli", Belvaros.Instance(), DateOnly.Parse("2016 - 08 - 07"), 6600000);// 3.0            //6600000*(100 - (2023 - 2016))/(100.0*3.0) = 5066666.666666667

            gov.GetVehicleById("azon - 201").CreateSheet(DateOnly.Parse("2015 - 03 - 10"), DateOnly.Parse("2015 - 03 - 15"), DateOnly.Parse("2021 - 08 - 20"), 180000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2018 - 06 - 15"), DateOnly.Parse("2018 - 06 - 30"), MyType.Átvizsgálás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2019 - 02 - 05"), DateOnly.Parse("2019 - 02 - 10"), DateOnly.Parse("2023 - 02 - 28"), 230000, MyType.Javitás, gov.GetCompanyByName("DebreceniJárműcég"));
            gov.GetVehicleById("azon - 203").CreateSheet(DateOnly.Parse("2016 - 09 - 18"), DateOnly.Parse("2016 - 09 - 25"), DateOnly.Parse("2022 - 11 - 12"), 150000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2009 - 08 - 20"), DateOnly.Parse("2009 - 08 - 30"), DateOnly.Parse("2010 - 06 - 10"), 140000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2010 - 05 - 10"), DateOnly.Parse("2010 - 05 - 20"), DateOnly.Parse("2011 - 09 - 15"), 180000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2014 - 11 - 05"), DateOnly.Parse("2014 - 11 - 15"), DateOnly.Parse("2018 - 01 - 30"), 250000, MyType.Javitás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2015 - 04 - 20"), DateOnly.Parse("2015 - 04 - 25"), MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2018 - 01 - 10"), DateOnly.Parse("2018 - 01 - 15"), DateOnly.Parse("2018 - 05 - 25"), 90000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 206").CreateSheet(DateOnly.Parse("2017 - 03 - 25"), DateOnly.Parse("2017 - 04 - 05"), DateOnly.Parse("2022 - 08 - 15"), 160000, MyType.Átvizsgálás, gov.GetCompanyByName("DebreceniJárműcég"));

            // elvileg az azon 202
            Assert.AreEqual("azon - 202", gov.MostValuableVehicle().GetId());
        }
        [TestMethod]
        public void TestMaintenanceRate()
        {
            Government gov = new Government("Szolnok Városi Közlekedés");

            gov.AddVehicle("azon - 201", "Autóbusz", Belvaros.Instance(), DateOnly.Parse("2014 - 02 - 28"), 7500000);
            gov.AddVehicle("azon - 202", "Villamos", Kulvaros.Instance(), DateOnly.Parse("2017 - 09 - 12"), 6200000);
            gov.AddVehicle("azon - 203", "Troli", Belvaros.Instance(), DateOnly.Parse("2015 - 06 - 19"), 6800000);
            gov.AddVehicle("azon - 204", "Autóbusz", Vegyes.Instance(), DateOnly.Parse("2000 - 02 - 28"), 7100000);
            gov.AddVehicle("azon - 205", "Villamos", Belvaros.Instance(), DateOnly.Parse("2009 - 04 - 08"), 5900000);
            gov.AddVehicle("azon - 206", "Troli", Belvaros.Instance(), DateOnly.Parse("2016 - 08 - 07"), 6600000);
            gov.AddVehicle("azon - 207", "Troli", Belvaros.Instance(), DateOnly.Parse("2023 - 05 - 27"), 6900420);

            gov.GetVehicleById("azon - 201").CreateSheet(DateOnly.Parse("2015 - 03 - 10"), DateOnly.Parse("2015 - 03 - 15"), DateOnly.Parse("2021 - 08 - 20"), 180000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2018 - 06 - 15"), DateOnly.Parse("2018 - 06 - 30"), MyType.Átvizsgálás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2019 - 02 - 05"), DateOnly.Parse("2019 - 02 - 10"), DateOnly.Parse("2023 - 02 - 28"), 230000, MyType.Javitás, gov.GetCompanyByName("DebreceniJárműcég"));
            gov.GetVehicleById("azon - 203").CreateSheet(DateOnly.Parse("2016 - 09 - 18"), DateOnly.Parse("2016 - 09 - 25"), DateOnly.Parse("2022 - 11 - 12"), 150000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2009 - 08 - 20"), DateOnly.Parse("2009 - 08 - 30"), DateOnly.Parse("2010 - 06 - 10"), 140000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2010 - 05 - 10"), DateOnly.Parse("2010 - 05 - 20"), DateOnly.Parse("2011 - 09 - 15"), 180000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2014 - 11 - 05"), DateOnly.Parse("2014 - 11 - 15"), DateOnly.Parse("2018 - 01 - 30"), 250000, MyType.Javitás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2015 - 04 - 20"), DateOnly.Parse("2015 - 04 - 25"), MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2018 - 01 - 10"), DateOnly.Parse("2018 - 01 - 15"), DateOnly.Parse("2018 - 05 - 25"), 90000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 206").CreateSheet(DateOnly.Parse("2017 - 03 - 25"), DateOnly.Parse("2017 - 04 - 05"), DateOnly.Parse("2022 - 08 - 15"), 160000, MyType.Átvizsgálás, gov.GetCompanyByName("DebreceniJárműcég"));

            // javitás alattra direkt az előzőkhöz képest 1-et be raktam,illetve hozzá adtam egy új járművet aminek nincs még munka lapja, az össze ami pedig nem atvizsgálás, tehát => van 7 db jármű, 1 db javitás alatt, 1 átvizsgálás, a maradék 5 pedig üzembe. ez alapján 6 db nem átvizsgálás alatt álló járművan. tehát az azárny 1/6 lesz
            Assert.AreEqual(1/(double)6,gov.MaintenanceRate());
        }
        [TestMethod]
        public void TestMostExpensiveFeeVehicle()
        {
            Government gov = new Government("Szolnok Városi Közlekedés");

            gov.AddVehicle("azon - 201", "Autóbusz", Belvaros.Instance(), DateOnly.Parse("2014 - 02 - 28"), 7500000);
            gov.AddVehicle("azon - 202", "Villamos", Kulvaros.Instance(), DateOnly.Parse("2017 - 09 - 12"), 6200000);
            gov.AddVehicle("azon - 203", "Troli", Belvaros.Instance(), DateOnly.Parse("2015 - 06 - 19"), 6800000);
            gov.AddVehicle("azon - 204", "Autóbusz", Vegyes.Instance(), DateOnly.Parse("2000 - 02 - 28"), 7100000);
            gov.AddVehicle("azon - 205", "Villamos", Belvaros.Instance(), DateOnly.Parse("2009 - 04 - 08"), 5900000);
            gov.AddVehicle("azon - 206", "Troli", Belvaros.Instance(), DateOnly.Parse("2016 - 08 - 07"), 6600000);

            gov.GetVehicleById("azon - 201").CreateSheet(DateOnly.Parse("2015 - 03 - 10"), DateOnly.Parse("2015 - 03 - 15"), DateOnly.Parse("2021 - 08 - 20"), 180000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2018 - 06 - 15"), DateOnly.Parse("2018 - 06 - 30"), MyType.Átvizsgálás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2019 - 02 - 05"), DateOnly.Parse("2019 - 02 - 10"), DateOnly.Parse("2023 - 02 - 28"), 230000, MyType.Javitás, gov.GetCompanyByName("DebreceniJárműcég"));
            gov.GetVehicleById("azon - 203").CreateSheet(DateOnly.Parse("2016 - 09 - 18"), DateOnly.Parse("2016 - 09 - 25"), DateOnly.Parse("2022 - 11 - 12"), 150000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2009 - 08 - 20"), DateOnly.Parse("2009 - 08 - 30"), DateOnly.Parse("2010 - 06 - 10"), 140000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 204").CreateSheet(DateOnly.Parse("2010 - 05 - 10"), DateOnly.Parse("2010 - 05 - 20"), DateOnly.Parse("2011 - 09 - 15"), 180000, MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2014 - 11 - 05"), DateOnly.Parse("2014 - 11 - 15"), DateOnly.Parse("2018 - 01 - 30"), 250000, MyType.Javitás, gov.GetCompanyByName("ElektroBuszTech"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2015 - 04 - 20"), DateOnly.Parse("2015 - 04 - 25"), MyType.Átvizsgálás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 205").CreateSheet(DateOnly.Parse("2018 - 01 - 10"), DateOnly.Parse("2018 - 01 - 15"), DateOnly.Parse("2018 - 05 - 25"), 90000, MyType.Javitás, gov.GetCompanyByName("SzolnokiMűhely"));
            gov.GetVehicleById("azon - 206").CreateSheet(DateOnly.Parse("2017 - 03 - 25"), DateOnly.Parse("2017 - 04 - 05"), DateOnly.Parse("2022 - 08 - 15"), 160000, MyType.Átvizsgálás, gov.GetCompanyByName("DebreceniJárműcég"));
            gov.GetVehicleById("azon - 202").CreateSheet(DateOnly.Parse("2022 - 02 - 05"), DateOnly.Parse("2022 - 02 - 10"), DateOnly.Parse("2022 - 02 - 28"), 230000, MyType.Javitás, gov.GetCompanyByName("DebreceniJárműcég"));

            // hozzá adtam még egy 22-ben történő munkát hogy a max vizsgálat tényleg megy e. igy elvileg a azon 202-es lesz a drágább
            Assert.AreEqual("azon - 202", gov.MostExpensiveFeeVehicle().GetId());
        }
    }
}