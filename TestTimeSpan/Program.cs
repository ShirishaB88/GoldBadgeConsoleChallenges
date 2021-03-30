using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTimeSpan
{
    class Program
    {
        static void Main(string[] args)
        {
            /*bool daysToClaim = */TestSpan(new DateTime(2021,5,15), new DateTime(2021, 2, 28));
            Console.ReadKey();
        }
        public static bool TestSpan(DateTime dateOfIncident,DateTime dateOfClaim)
        {
           
            TimeSpan timeSpan = dateOfIncident - dateOfClaim;
            int daysToClaim = Convert.ToInt32(timeSpan.TotalDays);

            if (daysToClaim <= 30)
            {
                Console.WriteLine($"{timeSpan.Days} and ItsValid");
                return true;
            }
            else
            {
                Console.WriteLine($"{timeSpan.Days} and Its not valid");
                return false;
            }
        }
    }

    
}
