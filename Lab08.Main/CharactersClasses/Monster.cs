public class Monster : ICharacter
{
    public string Name {get; set;}
    public int Health {get; set;}
    public Weapon weapon {get; set;}
    public List<Potion> potions {get; set;}
    public int ArmorClass {get; set;}
    public int Strength {get; set;}
    public Monster()
    {
        Name = "";
        weapon = new NoWeapon();
        potions = new List<Potion>();
    }


}