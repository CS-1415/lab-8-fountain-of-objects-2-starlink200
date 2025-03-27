using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class Player : ICharacter
{
    public string Name {get; set;}
    public int Health {get; set;}
    public Weapon weapon {get; set;}
    public List<Potion> potions {get; set;}
    public int ArmorClass {get; set;}
    public Player()
    {
        Name = "player";
        Health = 100;
        ArmorClass = 9;
        potions = new List<Potion>();
        weapon = new Sword();
        
    }
    
    public void Strengthen()
    {
        if(potions.Contains(new StrengthPotion()))
        {
            weapon.StrengthEnhance += new StrengthPotion().Potency;
        }
    }

    public void Heal()
    {
        if(potions.Contains(new HealPotion()))
        {
            Health += new HealPotion().Potency;
            potions.Remove(new HealPotion());
        }
        else if(potions.Contains(new HighHealPotion()))
        {
            Health += new HighHealPotion().Potency;
            potions.Remove(new HighHealPotion());
        }
        else
        {
            Console.WriteLine("You are out of healing potions");
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
        }
    }

    public void DisplayPotionList()
    {
        int strengthCount = 0;
        int healCount = 0;
        int highHealCount = 0;
        foreach(Potion potion in potions)
        {
            switch(potion)
            {
                case HealPotion:
                    healCount++;
                    break;
                case HighHealPotion:
                    highHealCount++;
                    break;
                case StrengthPotion:
                    strengthCount++;
                    break;
            }
        }
        Console.WriteLine("Current potions:");
        Console.WriteLine($"{strengthCount}x Strength Potion(s)");
        Console.WriteLine($"{healCount}x Heal Potion(s)");
        Console.WriteLine($"{highHealCount}x High Heal Potions");
    }

    public void ChoosePotion()
    {
        Console.WriteLine("Which potion would you like to drink? 1: Strength Potion 2: Heal Potion 3: High Heal Potion");
        switch (ValidateAnswer(3))
        {
            case 3:
            case 2:
                Heal();
                break;
            case 1:
                Strengthen();
                break;
        }
    }

    public int ValidateAnswer(int max)
    {
        int num;
        bool isValid;
        do
        {
            isValid = int.TryParse(Console.ReadLine(), out num);
            if(num < 1 || num > max)
            {
                isValid = false;
            }
        }
        while(!isValid);
        return num;
    }

    
}