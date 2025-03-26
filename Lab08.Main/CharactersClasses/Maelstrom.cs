public class Maelstrom : Monster, Character
{
    public Maelstrom()
    {
        Health = 20;
        ArmorClass = 10;
        Strength = 10;

    }

    public int Health
    {
        get {return Health;}

        set {Health = value;}
    }

    public int ArmorClass
    {
        get {return ArmorClass;}
        
        set {ArmorClass = value;}
    }

    public int Strength
    {
        get {return Strength;}

        set {Strength = value;}
    }

    public override void Attack()
    {
        
    }
}