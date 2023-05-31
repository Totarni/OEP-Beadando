namespace tomegkozlekedes_OEP_Beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileInputReader inputreader = new FileInputReader("input_jarmu.txt");
            //FileInputReader inputreader = new FileInputReader("input_jarmu2chatgpt.txt");
            inputreader.ReadVehicle(out Government gov);
            inputreader.ReadWorksheet(gov);
            Console.WriteLine($"A 15 évnél idősebb és az összes buszok aránya: {gov.OldBusesRate()}");
            try
            {
                Console.WriteLine($"A legnagyobb értékű jármű jelenlegi érték szerint: {gov.MostValuableVehicle().GetId()} azonositójú");
            }
            catch (NoVehicleException)
            {
                Console.WriteLine("Nem volt egyetlen jármű se a rendszerben");
            }
            Console.WriteLine($"A javítás alatt álló járművek aránya az összes járműhöz kivéve az időszakos átvizsgálásokat: {gov.MaintenanceRate()}");
            try
            {
                Console.WriteLine($"A legtöbb pénzt amit egy járműre költöttek 2022-ben: {gov.MostExpensiveFeeVehicle().GetId()} azonositójú járműnél történt");
            }
            catch (NoVehicleException)
            {
                Console.WriteLine("Nem volt egyetlen jármű se a rendszerben ami megfelelt volna a feltételnek");

            }
        }
    }
}