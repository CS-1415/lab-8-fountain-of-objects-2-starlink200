public class MonsterRoom<T> : Room
{
    public T MonsterType;

    public MonsterRoom(){}
    public MonsterRoom(T monster_type)
    {
        MonsterType = monster_type;
    }
}