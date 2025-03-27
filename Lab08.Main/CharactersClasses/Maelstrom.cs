public class Maelstrom : Monster
{
    public Maelstrom()
    {
        Name = "Maelstrom";
        Health = 20;
        ArmorClass = 10;
        weapon = new NoWeapon();
        potions = new List<Potion>();
    }

}