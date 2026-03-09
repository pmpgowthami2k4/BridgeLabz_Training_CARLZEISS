using System;
using System.Collections.Generic;


// OBSERVER INTERFACE


// All observers must implement this interface
// so the subject can notify them
interface IObserver
{
    void Update(string productName);
}


// SUBJECT INTERFACE


// Subject manages observers
interface ISubject
{
    void Subscribe(IObserver observer);
    void Unsubscribe(IObserver observer);
    void Notify();
}


// CONCRETE SUBJECT


// Store acts as the publisher
class Store : ISubject
{
    // List of subscribed customers
    private List<IObserver> observers = new List<IObserver>();

    // Product that customers are waiting for
    private string product;

    // Add observer
    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    // Remove observer
    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    // Notify all observers about new product
    public void Notify()
    {
        foreach (var observer in observers)
        {
            observer.Update(product);
        }
    }

    // When product arrives
    public void SetProduct(string productName)
    {
        Console.WriteLine("\nStore: New product arrived -> " + productName);

        this.product = productName;

        // Notify all subscribed customers
        Notify();
    }
}


// CONCRETE OBSERVER


// Customer who subscribes to store updates
class Customer : IObserver
{
    private string name;

    public Customer(string name)
    {
        this.name = name;
    }

    // This method runs when the store notifies customers
    public void Update(string productName)
    {
        Console.WriteLine(name + " received notification: " + productName + " is available!");
    }
}


// CLIENT


class observer
{
    static void Main()
    {
        // Create store (subject)
        Store store = new Store();

        // Create customers (observers)
        Customer c1 = new Customer("Alice");
        Customer c2 = new Customer("Bob");
        Customer c3 = new Customer("Charlie");

        // Customers subscribe to store
        store.Subscribe(c1);
        store.Subscribe(c2);
        store.Subscribe(c3);

        // Product arrives -> store notifies customers
        store.SetProduct("iPhone 16");

        // One customer unsubscribes
        store.Unsubscribe(c2);

        // Another product arrives
        store.SetProduct("Samsung Galaxy S25");
    }
}
