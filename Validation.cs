using System;
using System.Linq;

public class Validation
{
    public string ValidateID(string fieldName)
    {
        while (true)
        {
            Console.Write("Enter Vehicle ID(format: MH29AP5026) : ");
            string id = Console.ReadLine().Trim();

            if (id.Length == 10 &&
                char.IsLetter(id[0]) &&
                char.IsLetter(id[1]) &&
                char.IsDigit(id[2]) &&
                char.IsDigit(id[3]) &&
                char.IsLetter(id[4]) &&
                char.IsLetter(id[5]) &&
                char.IsDigit(id[6]) &&
                char.IsDigit(id[7]) &&
                char.IsDigit(id[8]) &&
                char.IsDigit(id[9]))
            {
                return id;
            }
            else
            {
                Console.WriteLine("Invalid Vehicle ID.");
            }
        }
    }

    public string ValidateString(string vehiclename)
    {
        while (true)
        {
            Console.Write($"Enter {vehiclename}: ");
            string vn = Console.ReadLine().Trim();

            bool onlyLetters = true;

            foreach (char c in vn)
            {
                if (!char.IsLetter(c))
                {
                    onlyLetters = false;
                    break;
                }
            }

            if (onlyLetters && !vn.Contains(" "))
            {
                return vn;
            }
            else
            {
                Console.WriteLine("Invalid Vehicle Name");
            }
        }
    }

    public string ValidateVName()
    {
        while (true)
        {
            Console.WriteLine("Select Vehicle Type:");
            Console.WriteLine("1. Sedan");
            Console.WriteLine("2. SUV");
            Console.WriteLine("3. Coupe");
            Console.WriteLine("4. Sports");
            Console.WriteLine("5. Limousine");
            Console.Write("Choose: ");
            string choice1 = Console.ReadLine();

            switch (choice1)
            {
                case "1": return "Sedan";
                case "2": return "SUV";
                case "3": return "Coupe";
                case "4": return "Sports";
                case "5": return "Limousine";
                default:
                    Console.WriteLine("Invalid vehicle type option.");
                    break;
            }
        }
    }

    public string ValidatePrice()
    {
        while (true)
        {
            Console.Write("Enter Rate per Hour: ");
            string val = Console.ReadLine().Trim();
            if (val.All(char.IsDigit))
                return val;
            Console.WriteLine("Rate must be numeric.");
        }
    }
    public string ValidateHours()
    {
        while (true)
        {
            Console.Write("Enter Number of Hours: ");
            string val = Console.ReadLine().Trim();

            if (val.All(char.IsDigit))
                return val;

            Console.WriteLine("Hours must be numeric.");
        }
    }

    public string ValidateCity()
    {
        while (true)
        {
            Console.WriteLine("Select City:");
            Console.WriteLine("1. Pune");
            Console.WriteLine("2. Nagpur");
            Console.WriteLine("3. Mumbai");
            Console.WriteLine("4. Delhi");
            Console.WriteLine("5. Nashik");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": return "Pune";
                case "2": return "Nagpur";
                case "3": return "Mumbai";
                case "4": return "Delhi";
                case "5": return "Nashik";
                default:
                    Console.WriteLine("Invalid city option.");
                    break;
            }
        }
    }
    public string ValidateRentID()
    {
        while (true)
        {
            Console.Write("Enter Vehicle ID to Rent (format: MH29AP5026): ");
            string rentID = Console.ReadLine().Trim();

            // Check length first
            if (rentID.Length != 10)
            {
                Console.WriteLine("Vehicle ID must be 10 characters long.");
                continue;
            }

            // Check specific positions for letters/digits
            if (char.IsLetter(rentID[0]) &&
                char.IsLetter(rentID[1]) &&
                char.IsDigit(rentID[2]) &&
                char.IsDigit(rentID[3]) &&
                char.IsLetter(rentID[4]) &&
                char.IsLetter(rentID[5]) &&
                char.IsDigit(rentID[6]) &&
                char.IsDigit(rentID[7]) &&
                char.IsDigit(rentID[8]) &&
                char.IsDigit(rentID[9]))
            {
                return rentID; // Valid ID
            }
            else
            {
                Console.WriteLine("Invalid Vehicle ID format. Please enter again.");
            }
        }
    }

}
