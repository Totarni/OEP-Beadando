namespace Beadando_Tömegközlekedés
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Onkormanyzat Magyar = new Onkormanyzat();

            Villamos negyes;
            Troli hetvenötös;
            Autobusz ötös;
            Autobusz hetes;
            Autobusz Nyolce;
            try
            {
                negyes = new Villamos("4es", 2003, 52000000,"Belváros"); // az hogy 4es 6os stb az nem megfelelő azon mert ezek vonal tipusok. csak hogy ne zavarodj bele
                hetvenötös = new Troli("75ös", 1995, 2000000, "Vegyes");
                ötös = new Autobusz("5ös", 1990, 7500000, "Belváros");
                hetes = new Autobusz("7es", 1980, 8500000, "Belváros");
                Nyolce = new Autobusz("8Es", 2009, 9500000, "Belváros");

                Magyar.Jarmuvek.Add(negyes);
                Magyar.Jarmuvek.Add(hetvenötös);
                Magyar.Jarmuvek.Add(ötös);
                Magyar.Jarmuvek.Add(hetes);
                Magyar.Jarmuvek.Add(Nyolce);
            
                Ceg ceg1 = new Ceg("javito kft.");
                Ceg ceg2 = new Ceg("javito2 kft.");


                Magyar.Cegek.Add(ceg1);
                Magyar.Cegek.Add(ceg2);

                try
                {
                    ceg1.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("4es"), "javítás");
                    ceg1.MunkalapLetreJon(2012, "2012.06.15", Magyar.JarmuKeres("4es"), "javítás", "2013.01.10",450000);
                    ceg1.MunkalapLetreJon(2022, "2022.06.15", Magyar.JarmuKeres("4es"), "javítás", "2023.01.10",450000);
                    ceg1.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("5ös"), "javítás");
                    ceg1.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("8Es"), "átvizsgálás");

                    ceg2.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("7es"), "javítás");
                    ceg2.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("75ös"), "átvizsgálás");
                    ceg2.MunkalapLetreJon(2022, "2022.06.25", Magyar.JarmuKeres("75ös"), "javítás", "2022.09.28", 521000);
                    ceg2.MunkalapLetreJon(2015, "2015.06.25", Magyar.JarmuKeres("75ös"), "javítás", "2015.09.28", 521000);

                }
                catch (NincsJarmuException) { Console.Error.WriteLine("Nem létező jármű!"); }
                //negyes.MunkalapLetreJon(2015, "2015.06.25", ceg1, "Átvizsgálás");
            }
            catch (OvezetException)
            {
                Console.Error.WriteLine("Hibás Övezet bemenet");
            }

            //feladatok
            //a
            if (Magyar.arany15EvesBuszpark() != "") Console.WriteLine($"Az autóbusz park {Magyar.arany15EvesBuszpark()} arányban előregedett( 15évnél idősebb buszok : összes busz száma)");
            else Console.WriteLine("Nincs tulajdonban busz!");
            //b
            try
            {
                Jarmu draga = Magyar.dragaJarmu();
                Console.WriteLine($"A legnagyobb jelenértékű jármű a(z) {draga.azon} {draga.tipus}, {draga.jelar} Ft");
            }
            catch (NincsJarmuException)
            {
                Console.Error.WriteLine("Nincs egyetlen jármű se a rendszerben!");
            }
            //c
            if (Magyar.JavitasArany() != "") Console.WriteLine($"A javitás alatt álló járművek aránya: {Magyar.JavitasArany()} (javítás alatt állójármüvek száma : összes jármű száma)");
            else Console.WriteLine("Nincs Javitás alatt egyetlen jármű se!");
            //d
            int ev = 2022;
            try
            {
                Console.WriteLine($"A legtöbbet a(z) \"{Magyar.LegdragabbEvben(ev).azon}\" azonositójú járműre költöttek {ev} -ben/-ban");
            }
            catch (NincsMegfeleloException)
            {
                Console.WriteLine($"Egyetlen jármű se volt ebben az évben ({ev}) szervizben!");
            }
        }
    }
}