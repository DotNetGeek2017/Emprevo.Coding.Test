using System;
using System.Linq;

namespace Emprevo.Coding.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args==null || !args.Any() || args.Count()!=2)
            {
                Console.WriteLine("Please provide the patron Entry & Exit DateTime as parameters. \r\nExample:Emprevo.Coding.Test.exe  \"2018-02-16 11:59:00.000\"  \"2018-02-16 19:19:00.000\"");
                return;
            }

            DateTime? entryDateTime=DateTime.TryParse(args[0], out var date1)? date1:(DateTime?) null;
            DateTime? exitDateTime = DateTime.TryParse(args[1], out var date2) ? date2 : (DateTime?)null;

            if((entryDateTime==null || exitDateTime == null) || (exitDateTime <= entryDateTime))
            {
                Console.WriteLine("Please provide the patron Entry & Exit DateTime as parameters. \r\n Example:Emprevo.Coding.Test.exe  \"2018-02-16 11:59:00.000\"  \"2018-02-16 9:19:00.000\"");
                return;
            }

            var carParkingCalculator = new CarParkCalculateEngine();
            var carparkingDetaills=carParkingCalculator.GetCarParkingPriceDetails(entryDateTime.Value, exitDateTime.Value);

            Console.WriteLine(carparkingDetaills.Rate.Name);
            Console.WriteLine(carparkingDetaills.TotalParkingFee);
        }
    }
}
