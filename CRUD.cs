using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

public class CRUD
{
    private string filePath = @"C:\Users\wwwsu\source\repos\NewCSharp\NewCSharp\VehicleRentSystem\vehicles.txt";

    public CRUD()
    {
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    public void Create(string row)
    {
        File.AppendAllText(filePath, row + Environment.NewLine);
    }

    public void ReadAll()
    {
        var lines = File.ReadAllLines(filePath);
        foreach (var l in lines) Console.WriteLine(l);
    }

    public List<string> ReadLines()
    {
        return File.ReadAllLines(filePath).ToList();
    }

    public void UpdateByID(string idnumber, string newRow)
    {
        var lines = File.ReadAllLines(filePath).ToList();

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith(idnumber))
            {
                lines[i] = newRow;
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Record updated successfully.");
                return;
            }
        }

        Console.WriteLine("ID not found.");
    }

    public void DeleteByID(string idToDelete)
    {
        string[] lines = File.ReadAllLines(filePath);
        bool found = false;

        List<string> updatedLines = new List<string>();

        foreach (string line in lines)
        {
            if (line.StartsWith(idToDelete))
            {
                found = true; 
            }
            else
            {
                updatedLines.Add(line); 
            }
        }

        if (!found)
        {
            Console.WriteLine("ID not found.");
            return;
        }

        File.WriteAllLines(filePath, updatedLines);
        Console.WriteLine("Record deleted.");
    }


    public void RentVehicle(Validation val, FileLayout layout)
    {
        // Ask user for city
        string rentCity = val.ValidateCity();
        Console.WriteLine("\nAvailable Vehicles in " + rentCity + ":");
        Console.WriteLine(layout.Header());

        // Read all vehicles from file
        string[] allVehicles = File.ReadAllLines(filePath);
        bool anyAvailable = false;

        // Show available vehicles in selected city
        for (int i = 0; i < allVehicles.Length; i++)
        {
            string line = allVehicles[i];
            string[] parts = line.Split('|');
            for (int j = 0; j < parts.Length; j++)
                parts[j] = parts[j].Trim();

            string cityFromFile = parts[4];
            string statusFromFile = parts[5];

            if (cityFromFile == rentCity && statusFromFile == "Available")
            {
                Console.WriteLine(line);
                anyAvailable = true;
            }
        }

        if (!anyAvailable)
        {
            Console.WriteLine("No available vehicles in this city.");
            return;
        }

        string rentID = val.ValidateRentID();

        string selectedVehicle = null;

        for (int i = 0; i < allVehicles.Length; i++)
        {
            if (allVehicles[i].StartsWith(rentID))
            {
                string[] parts = allVehicles[i].Split('|');
                for (int j = 0; j < parts.Length; j++)
                    parts[j] = parts[j].Trim();

                if (parts[5] == "Available")
                {
                    selectedVehicle = allVehicles[i];
                    break;
                }
            }
        }

        if (selectedVehicle == null)
        {
            Console.WriteLine("Vehicle not found or not available.");
            return;
        }

        // Ask for hours
        string hours = val.ValidateHours();
        string[] vehicleParts = selectedVehicle.Split('|');
        for (int i = 0; i < vehicleParts.Length; i++)
            vehicleParts[i] = vehicleParts[i].Trim();

        int ratePerHour = int.Parse(vehicleParts[3]);
        int hourNum = int.Parse(hours);
        int bill = ratePerHour * hourNum;

        Console.WriteLine("Total Bill: " + bill);

        // Update vehicle status to Rented
        string newRow = layout.Row(
            vehicleParts[0],  // ID
            vehicleParts[1],  // Name
            vehicleParts[2],  // Type
            vehicleParts[3],  // Rate per hour
            vehicleParts[4],  // City
            "Rented"          // status
        );

        UpdateByID(rentID, newRow);
    }
    public void ReturnVehicle(Validation val, FileLayout layout)
    {
        string returnID = val.ValidateRentID(); 

        string[] allVehicles = File.ReadAllLines(filePath);
        string selectedVehicle = null;

        // Find the rented vehicle
        for (int i = 0; i < allVehicles.Length; i++)
        {
            if (allVehicles[i].StartsWith(returnID))
            {
                string[] parts = allVehicles[i].Split('|');
                for (int j = 0; j < parts.Length; j++)
                    parts[j] = parts[j].Trim();

                if (parts[5] == "Rented")
                {
                    selectedVehicle = allVehicles[i];
                    break;
                }
            }
        }

        if (selectedVehicle == null)
        {
            Console.WriteLine("Vehicle not found or not rented.");
            return;
        }

        // Update status back to Available
        string[] vehicleParts = selectedVehicle.Split('|');
        for (int i = 0; i < vehicleParts.Length; i++)
            vehicleParts[i] = vehicleParts[i].Trim();

        string newRow = layout.Row(
            vehicleParts[0],  // ID
            vehicleParts[1],  // Name
            vehicleParts[2],  // Type/Color
            vehicleParts[3],  // Rate per hour
            vehicleParts[4],  // City
            "Available"       // Updated status
        );

        UpdateByID(returnID, newRow);
        Console.WriteLine("Vehicle returned successfully.");
    }

}
