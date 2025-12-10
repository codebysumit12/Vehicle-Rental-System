Vehicle Rental Management System (C# Console App)

A simple and beginner-friendly Vehicle Rental System built using C#.
It allows storing vehicle details in a text file and provides full CRUD operations, renting, billing, and returning vehicles.

Features
✔ Add Vehicle

Store a new vehicle record in the text file.

✔ View All Vehicles

Display every vehicle in the system.

✔ Update Vehicle

Update the details of any vehicle using its ID.

✔ Delete Vehicle

Remove a vehicle from the list using its ID.

✔ Rent Vehicle

Select a city

Show all Available vehicles

Choose Vehicle ID

Enter hours

System generates the bill

Status changes to Rented

✔ Return Vehicle

Change the vehicle status back to Available.

Project Structure
VehicleRentSystem/
│
├── CRUD.cs           # Core CRUD and Rent/Return logic
├── Validation.cs     # Input validation (IDs, City, Hours)
├── FileLayout.cs     # Row and header formatting
├── Program.cs        # Menu + user interaction
└── vehicles.txt      # Data storage

How Data is Stored

Each line in vehicles.txt represents one vehicle:

ID | Name | Color/Type | RatePerHour | City | Status


Example:

101 | Activa | White | 50 | Pune | Available
102 | Splendor | Black | 70 | Nagpur | Rented

How to Run

Open the project in Visual Studio or .NET CLI.

Ensure your file path inside CRUD.cs is valid.

Run the program and use the menu to interact.

Requirements

.NET 6 / .NET Framework

Basic C# knowledge (loops, classes, file handling)

Why This Project?

Perfect for beginners learning:

File handling in C#

Basic CRUD operations

Validation methods

Console application structure

Simple project architecture

Future Improvements (Optional)

Replace text file with SQL database

Add login system

Add vehicle categories

Add rental history

Add GUI using WinForms/WPF
