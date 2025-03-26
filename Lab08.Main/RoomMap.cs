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
        int count = 0;
        int MaelStromRoom = PickRandNum();
        int AmarokRoom = PickRandNum();
        int PitRoom = PickRandNum();
        int FountainRoom = PickRandNum();

        for(int i = 0; i < MapSize; i++)
        {
            for(int j = 0; j < MapSize; j++)
            {
                if(count == MaelStromRoom)
                {
                    Rooms[i,j] = new MonsterRoom<Maelstrom>(new Maelstrom());
                }
                else if(count == AmarokRoom)
                {
                    Rooms[i,j] = new MonsterRoom<Amarok>(new Amarok());
                }
                else if(count == FountainRoom)
                {
                    Rooms[i,j] = new FountainRoom();
                }
                else if(count == PitRoom)
                {
                    Rooms[i,j] = new PitRoom();
                }
                else
                {
                    Rooms[i,j] = new Room();
                }
                count++;
            }
        }
    }

    public void MoveMaelstrom(int xIndex, int yIndex)
    {
        Rooms[xIndex,yIndex] = new Room();
        if(xIndex - 2 >= 0 )
        {
            xIndex -= 2;
        }
        else
        {
            xIndex = 0 + xIndex + 2;
        }

        // if(yIndex + 1 < MapSize)
        // {
        //     yIndex ++;
        // }
        // else
        // {
        //     yIndex = yIndex -MapSize + 1;
        // }
        Rooms[xIndex,yIndex] = new MonsterRoom<Maelstrom>();
        

    }

    int PickRandNum()
    {
        
        return rand.Next(MapSize*MapSize/2, MapSize * MapSize);
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