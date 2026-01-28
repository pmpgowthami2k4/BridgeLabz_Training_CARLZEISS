using System;
using System.Globalization;
public class MedicalRecord {
    public string PatientName;
    public int PatientAge;

    public void showDetails()
    {
        Console.WriteLine($"Patient Name: {PatientName}");
        Console.WriteLine($"Patient Age: {PatientAge}");

    }

}

public class Prescription : MedicalRecord {

    public string MedicineName;
    public string Dosage;

    public void showPrescription()
    {
        Console.WriteLine($"Medicine Name: {MedicineName}");
        Console.WriteLine($"Dosage: {Dosage}");
    }


}

public class LabReport: Prescription 
{
    public string TestName;
    public string Result;

    public void showLabReport()
    {
        Console.WriteLine($"Test Name: {TestName}");
        Console.WriteLine($"Result: {Result}");
    }

}



class Program { 
    static void Main()
    {
        LabReport person1 = new LabReport();
        person1.PatientName = "Karthik";
        person1.PatientAge = 20;
        person1.MedicineName = "Paracetamol";
        person1.Dosage = "2 times a day";
        person1.TestName = "Jaundice Test";
        person1.Result = "Postive";

        person1.showDetails();
        person1.showPrescription();
        person1.showLabReport();

    }
}

