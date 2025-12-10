using System;
using System.Linq;
using System.Collections.Generic;

class VehicleRentSystem
{
    static void Main()
    {
        Validation val = new Validation();
        FileLayout layout = new FileLayout();
        CRUD crud = new CRUD();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Vehicle Rent System ---");
            Console.WriteLine("1. Add Vehicle");
            Console.WriteLine("2. Show Vehicles by City");
            Console.WriteLine("3. Update Vehicle");
            Console.WriteLine("4. Delete Vehicle");
            Console.WriteLine("5. Rent Vehicle");
            Console.WriteLine("6. Exit");
            Console.WriteLine("7. Return Vehicle");

            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string id = val.ValidateID("ID");
                    string name = val.ValidateString("Vehicle Name");
                    string type = val.ValidateVName();
                    Console.WriteLine($"Vehicle Type Selected:{type}");
                    string rate = val.ValidatePrice();
                    string city = val.ValidateCity();
                    Console.WriteLine($"City Selected:{city}");
                    string status = "Available";

                    string row = layout.Row(id, name, type, rate, city, status);
                    crud.Create(row);
                    Console.WriteLine("Vehicle added successfully.");
                    break;

                case "2":
                    string selectedCity = val.ValidateCity();
                    Console.WriteLine("\n" + layout.Header());

                    var lines = crud.ReadLines();

                    foreach (var l in lines)
                    {
                        string[] parts = l.Split('|');       
                        for (int i = 0; i < parts.Length; i++)
                        {
                            parts[i] = parts[i].Trim();      
                        }

                        string cityInRecord = parts[4];      

                        if (cityInRecord == selectedCity)    
                        {
                            Console.WriteLine(l);
                        }
                    }
                    break;


                case "3":
                    Console.Write("Enter ID to Update: ");
                    string oldID = Console.ReadLine().Trim();

                    string newID = val.ValidateID("ID");
                    string newName = val.ValidateString("Vehicle Name");
                    string newType = val.ValidateString("Vehicle Type");
                    string newRate = val.ValidatePrice();
                    string newCity = val.ValidateCity();
                    string newStatus = "Available";

                    string updatedRow = layout.Row(newID, newName, newType, newRate, newCity, newStatus);
                    crud.UpdateByID(oldID, updatedRow);
                    break;

                case "4":
                    Console.Write("Enter ID to Delete: ");
                    string deleteID = Console.ReadLine().Trim();
                    crud.DeleteByID(deleteID);
                    break;

                case "5":
                    Console.WriteLine("Enter City for Vehcile");
                    crud.RentVehicle(val,layout);
                    break;

                case "6":
                    exit = true;
                    Console.WriteLine("Exiting...");
                    break;

                case "7":
                    crud.ReturnVehicle(val, layout);
                    break;


                default:
                    Console.WriteLine("Invalid option, try again.");
                    break;
            }
        }
    }
}
