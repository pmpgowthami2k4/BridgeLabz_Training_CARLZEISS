//// Question
//// Design a Ride Booking System where:
//// 1) A Ride is an abstract entity.
//// 2) Each ride has:
//// - BaseFare
//// - Distance

//// 3) Ride types:
//// - BikeRide
//// - CarRide
//// 4) Each ride calculates fare differently.
//// 5) Fare calculation logic must be hidden from outside classes.
//// 6) The system should:
//// - Accept any ride type
//// - Calculate fare using runtime polymorphism
//// Create objects and show output.

////  Use all OOPS concepts in ONE program.
//using System;

//abstract class Ride
//{
//    // ENCAP
//    private double baseFare;
//    private double distance;

//    protected double BaseFare
//    {
//        get { return baseFare; }
//    }

//    protected double Distance
//    {
//        get { return distance; }
//    }

//    // CONSTR
//    protected Ride(double baseFare, double distance)
//    {
//        this.baseFare = baseFare;
//        this.distance = distance;
//    }


//    public abstract double CalculateFare();
//}



//class BikeRide : Ride
//{
//    public BikeRide(double distance)
//        : base(20, distance)
//    {
//    }


//    public override double CalculateFare()
//    {
//        return BaseFare + (Distance * 5);
//    }
//}

//class CarRide : Ride
//{
//    public CarRide(double distance) : base(50, distance)
//    {

//    }

//    public override double CalculateFare()
//    {
//        return BaseFare + (Distance * 10);
//    }
//}


//class RideBookingSystem
//{
//    public void PrintFare(Ride ride)
//    {
//        Console.WriteLine($"Total Fare for 10km: Rs.{ride.CalculateFare()}");
//    }
//}


//class Program
//{
//    static void Main()
//    {
//        Ride bikeRide = new BikeRide(10); // 10 km
//        Ride carRide = new CarRide(10);

//        RideBookingSystem system = new RideBookingSystem();

//        Console.WriteLine("Bike Ride Fare:");
//        system.PrintFare(bikeRide);

//        Console.WriteLine("\nCar Ride Fare:");
//        system.PrintFare(carRide);
//    }
//}

