// Task 2:  Multilevel Transportation System
// Task: Create a system for managing various types of vehicles, including land, water, and air transportation.
// Each vehicle type should have specific movement logic and fuel consumption rates.
// Vehicles should share common attributes and behaviors but handle specific controls differently.
// Implement a system where the user can register, update, and retrieve vehicle details without knowing the exact type beforehand.
// Prevent unauthorized modifications to core vehicle attributes.


using System;

abstract class Vehicle {

    public string Model {get;}
    public double FuelLevel {get; set;}

    public Vehicle (string model, double fuelLevel) {
        Model = model;
        FuelLevel = fuelLevel;
    }
    public abstract void Move();
    public abstract void Refuel (double amount);     
}

class Car : Vehicle {

    public Car (string Model, double FuelLevel) : base (Model, FuelLevel) {}

    public override void Move () {

        if (FuelLevel < 5) {
            Console.WriteLine ("\nCar is out of fuel");
            return;
        }
        FuelLevel -= 5;

        Console.WriteLine ($"Car is moving. Fuel level:  {FuelLevel}");
    }

    public override void Refuel (double amount) {
        FuelLevel += amount;
        Console.WriteLine ($"Car refueled now Refuel fuel level: {FuelLevel}");
    }
    
}

class Motorcycle : Vehicle {

    public Motorcycle (string Model, double FuelLevel) : base (Model, FuelLevel) {}

    public override void  Move () {
        if (FuelLevel < 3) {
            Console.WriteLine ("Motorcycle is out of fuel");
            return;
        }
        FuelLevel -= 3;
        Console.WriteLine ($"Motorcycle is moving. Fuel level: {FuelLevel}");
    }

    public override void Refuel (double amount) {

        FuelLevel += amount;
        Console.WriteLine ($"Motorcycle refueled now Refuel fuel level: {FuelLevel}");
    }

}

class Program {
    static void Main (string[] args) {
        Car BMW = new Car ("BMW", 100);
        BMW.Move ();
        Console.WriteLine (BMW.FuelLevel);
        BMW.Refuel (10);
        Console.WriteLine (BMW.FuelLevel);
        Motorcycle Moto = new Motorcycle ("X",40);
        Moto.Move ();
        Console.WriteLine (Moto.FuelLevel);
        Moto.Refuel (10);
    }
}


