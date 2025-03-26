public class Amarok : Monster, Character
{
    public Amarok()
    {
        Health = 50;
        ArmorClass = 14;
        Strength = 12;
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
        throw new NotImplementedException();
    }
}