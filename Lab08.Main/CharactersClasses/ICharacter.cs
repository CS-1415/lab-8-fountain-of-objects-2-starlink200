using System.Dynamic;

public interface ICharacter
{
    public string Name {get; set;}
    public int ArmorClass {get; set;}
    public int Health {get; set;}
    public int Strength {get; set;}
    public Weapon weapon {get; set;}
    public List<Potion> potions {get; set;}



}