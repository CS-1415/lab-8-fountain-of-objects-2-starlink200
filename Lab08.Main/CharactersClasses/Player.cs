using System.Security.Cryptography.X509Certificates;

public class Player : ICharacter
{
    public string Name {get; set;}
    public int Health {get; set;}
    public Weapon weapon {get; set;}
    public List<Potion> potions {get; set;}
    public int ArmorClass {get; set;}
    public int Strength {get; set;}
    public Player()
    {
        Name = "player";
        Health = 100;
        ArmorClass = 9;
        Strength = 10;
        potions = new List<Potion>();
        weapon = new Sword();
        
    }


    public void Heal()
    {
        if(potions.Count >= 1)
        {
            Health += potions[0].Heal;
            potions.Remove(potions[0]);
        }
        else
        {
            Console.WriteLine("You are out of potions");
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
        }
    }

    
}