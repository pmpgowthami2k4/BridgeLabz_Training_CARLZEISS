

//8.The RPG Character Evolution 
//Scenario: In a game, a Warrior can "Level Up" to a Paladin. A Paladin inherits all 
//Warrior skills but adds a heal() ability. However, the attack() method must be 20% 
//stronger than the base Warrior. 
//● Concepts:aMethod Overriding and super(). 
//● Hint: Call super().attack() * 1.2 in the child class.

//using System;

//// ================= BASE CLASS =================
//class Warrior
//{
//    protected int attackPower;

//    public Warrior()
//    {
//        attackPower = 100;
//    }

//    public virtual int Attack()
//    {
//        Console.WriteLine($"Warrior attacks with power {attackPower}");
//        return attackPower;
//    }
//}

//// ================= DERIVED CLASS =================
//class Paladin : Warrior
//{
//    public Paladin() : base()
//    {
//    }

//    // Method overriding + base call
//    public override int Attack()
//    {
//        int enhancedAttack = (int)(base.Attack() * 1.2);
//        Console.WriteLine($"Paladin attacks with enhanced power {enhancedAttack}");
//        return enhancedAttack;
//    }

//    public void Heal()
//    {
//        Console.WriteLine("Paladin uses Heal ✨");
//    }
//}

//// ================= MAIN =================
//class Program
//{
//    static void Main()
//    {
//        Console.WriteLine("=== Warrior ===");
//        Warrior warrior = new Warrior();
//        warrior.Attack();

//        Console.WriteLine("\n=== Paladin (Evolved Warrior) ===");
//        Paladin paladin = new Paladin();
//        paladin.Attack();
//        paladin.Heal();
//    }
//}
