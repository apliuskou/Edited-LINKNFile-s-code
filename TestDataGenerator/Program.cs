using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDataGenerator
{
    class Program
    {

        static void Main(string[] args)
        {

            DateTime dateOfTransaction = RandomDayGen.RandomDay();
            string _dateOfTransaction = Convert.ToString(dateOfTransaction);

            string homeFolder = @"c:\GitHub\tabgen\";
            Random randomCustomer = new Random();
            Random moneyRandom = new Random();
            string nextRecord = "";
            string[] allPossibleCustomers = Enum.GetNames(typeof(Customers));
            int maxCustomers = allPossibleCustomers.Length;




            try
            {
                using (StreamWriter target = File.CreateText(homeFolder + @"\sample2.csv"))
                {

                    for (int i = 0; i < 10000; i++)
                    {
                        nextRecord = nextRecord + i + ", " + (Customers)randomCustomer.Next(0, maxCustomers) + ", ";
                        nextRecord = nextRecord + moneyRandom.Next(100, 10000) + ", ";
                        nextRecord = nextRecord + _dateOfTransaction;
                        ;
                        Console.WriteLine(" Line{0}: {1}", i, nextRecord);
                        target.WriteLine(nextRecord);

                        nextRecord = "";
                    }
                }
            }
            catch (IOException)
            {

                Console.WriteLine("Error! File already exist or path not found!");
                throw;
            }

            Console.WriteLine("Saved successfully! Sample file built!");
            Console.ReadKey();

        }
    }
}
