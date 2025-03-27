using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public class RoomMap
{
    Random rand = new Random();
    public Room[,] Rooms {get; set;}
    public int MapSize {get;}

    public RoomMap()
    {

    }
    
    public RoomMap(Room[,] rooms)
    {
        Rooms = rooms;
    }
    public RoomMap(int gridDimensions)
    {
        MapSize = gridDimensions;
        Rooms = new Room[MapSize,MapSize];
    }

    public void MakeMap()
    {
        int FountainRoom = rand.Next((MapSize * MapSize)/2, MapSize * MapSize);
        int count = 0;
        for(int i = 0; i < MapSize; i++)
        {
            for(int j = 0; j < MapSize; j++)
            {
                Rooms[i,j] = new Room();
                if(PickMonsterRoom() && i != 0 && j != 0)
                {
                    Rooms[i,j].monster = PickMonsterType();
                    Rooms[i,j].HasMonster = true;
                    Rooms[i,j].monster.potions.Add(new Potion());
                }
                else if(count == FountainRoom)
                {
                    Rooms[i,j].HasFountain = true;
                }
                else
                {
                    Rooms[i,j].HasMonster = false;
                }
            }
        }
    }

//PickMonsterRoom() will be the method deciding if a room has a monster, there is a 1/4 chance that a room has a monster
    public bool PickMonsterRoom()
    {
        int num = rand.Next(4);
        int num2 = 1;
        if(num == num2)
        {
            return true;
        }
        return false;
    }

//PickMonsterType() picks what kind of monster will be in the monster room, equal chance of any monster
    public Monster PickMonsterType()
    {
        int num = rand.Next(4);
        switch (num)
        {
            case 1:
            case 3:
                return new Amarok();
            default:
                return new Maelstrom();
        }
    }

    public void DisplayMap(int xIndex, int yIndex)
    {
        for(int i = 0; i < MapSize; i++)
        {
            for(int j = 0; j < MapSize; j++)
            {
                if(i == xIndex && j == yIndex)
                {
                    Rooms[i,j].PrintRoom(i, j, "*  $  *");
                }
                else
                {

                    Rooms[i,j].PrintRoom(i, j, "*     *");
                }
            }
        }
    }
}