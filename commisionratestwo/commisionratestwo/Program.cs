using System;
using System.IO;

namespace commisionratestwo
{
    struct employees
    {
        public string name;
        public int idnumber;
        public int propertiessold;
        public float commission;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Calculator");
            const int numberofemployees = 5;
            //Variable for structure
            employees[] staff = new employees[numberofemployees];
            int totalpropertiessold = 0;
            float commissionates = 500;

            //Temp staff member for testing ***REMOVE AT THE END***
            staff[0].name = "Eliot";
            staff[0].idnumber = 1234;
            staff[0].propertiessold = 5;

            //For loop which repeats the question 5 times and adds 1
            for (int i = 0; i < numberofemployees; i++)
            {
                Console.WriteLine("Please enter employee {0} name", i + 1);
                staff[i].name = Console.ReadLine();

                Console.WriteLine("Please enter employee {0} ID number", i + 1);
                int.TryParse(Console.ReadLine(), out staff[i].idnumber);

                Console.WriteLine("Please enter employee {0} houses sold", i + 1);
                int.TryParse(Console.ReadLine(), out staff[i].propertiessold);

                staff[i].commission = commissionates * staff[i].propertiessold;

                //Adds total properties sold to variable
                totalpropertiessold = totalpropertiessold + staff[i].propertiessold;


            }

            //Outputs the overall amount of properties sold
            Console.WriteLine("The most number of properties sold was {0}", totalpropertiessold);

            //Sorts array
            Array.Sort(staff, (x, y) => y.propertiessold.CompareTo(x.propertiessold));

            staff[0].commission = staff[0].commission * 1.15f;

            for (int i = 0; i < numberofemployees; i++)
            {

                

                //Outputs the top employees
                Console.WriteLine("The top {0} is {1} with {2} properties sold and commission rate is £{3}", i + i, staff[i].name, staff[i].propertiessold, staff[i].commission);

            }

            using (StreamWriter fileOutput = File.CreateText("data.txt"))
            {
                fileOutput.WriteLine("Name, ID No., Properties Sold");
                for (int i = 0; i < numberofemployees; i++)
                {
                    fileOutput.WriteLine("{0}, {1}, {2}, {3}", staff[i].name, staff[i].idnumber, staff[i].propertiessold, staff[i].commission);
                }
            }
        }
    }
}
