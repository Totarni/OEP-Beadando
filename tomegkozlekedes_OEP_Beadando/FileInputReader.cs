using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFile;

namespace tomegkozlekedes_OEP_Beadando
{
    public class NoZoneException : Exception { }
    public class WrongTypeException : Exception { }
    public class FileInputReader
    {
        private readonly TextFileReader reader;
        public FileInputReader(string path)
        {
            reader = new TextFileReader(path);
        }

        public bool ReadVehicle(out Government gov)
        {
            bool err;
            gov = null!;
            err = reader.ReadLine(out string line);
            if (err)
            {
                char seperator = ' ';
                string[] parts = line.Split(seperator);
                gov = new Government(parts[0]);
                for (int i = 1; i < parts.Length; i += 5)
                {
                    try
                    {
                        gov.AddVehicle(parts[i], parts[i + 1], GetZone(parts[i + 2]), DateOnly.Parse(parts[i + 3]), double.Parse(parts[i + 4]));
                    }
                    catch (NoZoneException)
                    {
                        Console.WriteLine($"Hibás övezet bemenet a {parts[0]} azonositóju járműnél");
                    }
                    catch(IncorrectVehicleException) 
                    {
                        Console.WriteLine($"Hibás Jármű tipus a {parts[0]} azonositóju járműnél");
                    }
                }
            }
            return err;
        }
        public bool ReadWorksheet(Government gov)
        {
            bool err;
            err = reader.ReadLine(out string line);
            if (err)
            {
                string[] parts = line.Split(';');
                for (int i = 0; i < parts.Length; i++)
                {
                    string[] parts2 = parts[i].Split();
                    if (parts2.Length == 7)
                    {
                        try
                        {
                            gov.GetVehicleById(parts2[0]).CreateSheet(DateOnly.Parse(parts2[1]), DateOnly.Parse(parts2[2]), DateOnly.Parse(parts2[3]), double.Parse(parts2[4]), GetType(parts2[5]), gov.GetCompanyByName(parts2[6]));
                        }
                        catch (NoVehicleException)
                        {
                            Console.WriteLine($"Nem található Jármű \"{parts2[0]}\" azonositóval");
                        }
                        catch (WrongTypeException)
                        {
                            Console.WriteLine($"Nem található \"{parts2[5]}\" szervizelés tipus");
                        }
                    }
                    else
                    {
                        try
                        {
                        gov.GetVehicleById(parts2[0]).CreateSheet(DateOnly.Parse(parts2[1]), DateOnly.Parse(parts2[2]), GetType(parts2[3]), gov.GetCompanyByName(parts2[4]));
                        }
                        catch (NoVehicleException)
                        {
                            Console.WriteLine($"Nem található Jármű \"{parts2[0]}\" azonositóval");
                        }
                        catch (WrongTypeException)
                        {
                            Console.WriteLine($"Nem található \"{parts2[3]}\" szervizelés tipus");
                        }
                        catch (ActiveWorksheetException)
                        {
                            Console.WriteLine($"Már létezik egy aktív munkalap \"{parts2[0]}\"-nak");
                        }
                    }
                }
            }
            return err;
        }

        private MyType GetType(string type)
        {
            if (type == "Javítás") return MyType.Javitás;
            else if (type == "Átvizsgálás") return MyType.Átvizsgálás;
            else throw new WrongTypeException();
        }

        private Zone GetZone(string zone)
        {
            switch (zone)
            {
                case "Belváros": return Belvaros.Instance();
                case "Külváros": return Kulvaros.Instance();
                case "Vegyes": return Vegyes.Instance();
                default: throw new NoZoneException();
            }
        }
    }
}
