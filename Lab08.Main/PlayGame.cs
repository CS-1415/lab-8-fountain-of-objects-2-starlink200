using System.Collections;
using System.Net.Quic;

public class PlayGame
{
    RoomMap Map {get; set;}
    (int X, int Y) Index;
    public bool Win;
    public bool Lose;
    public bool quit;
    public PlayGame(int size)
    {
        Map = new RoomMap(size);
        Index = (0, size - 1);
    }

    public void Run()
    {
        Map.MakeMap();
        quit = false;
        while(!quit)
        {
            Console.Clear();
            Map.DisplayMap(Index.X, Index.Y);
            Move();
            CheckforEndCondition();
            if(Win == true || Lose == true)
            {
                quit = true;
            }
        }
        DisplayEndGame();
    }

    public void Move()
    {

        Surroundings();
        Map.Rooms[Index.X, Index.Y].Entered = true;
        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.UpArrow:
                if(Index.Y - 1 >= 0)
                {
                    Index.Y--;
                }
                break;
            case ConsoleKey.DownArrow:
                if(Index.Y + 1 < Map.MapSize)
                {
                    Index.Y++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if(Index.X - 1 >= 0)
                {
                    Index.X--;
                }
                break;
            case ConsoleKey.RightArrow:
                if(Index.X + 1 < Map.MapSize)
                {
                    Index.X++;
                }
                break;
        }
        
        
    }

    public void CheckforEndCondition()
    {
        if(Map.Rooms[Index.X, Index.Y] is FountainRoom)
        {
            Win = true;
        }
        if(Map.Rooms[Index.X, Index.Y] is PitRoom)
        {
            Lose = true;
        }
        if(Map.Rooms[Index.X, Index.Y] is MonsterRoom<Maelstrom> || Map.Rooms[Index.X, Index.Y] is MonsterRoom<Amarok>)
        {
            Combat();
        }
    }
    public void Surroundings()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        if(Index.Y == Map.MapSize - 1 && Index.X == 0)
        {
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
        }
        else if(CheckForPit())
        {
            Console.WriteLine("You feel a draft coming from a close room. A pit is nearby");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            if(Map.Rooms[Index.X, Index.Y] is MonsterRoom<Maelstrom> || Map.Rooms[Index.X, Index.Y] is MonsterRoom<Amarok>)
            {
                Console.WriteLine("This room has a monster");
            }
            else if(Map.Rooms[Index.X, Index.Y] is FountainRoom)
            {
                Console.WriteLine("This room has the Fountain of Objects");
            }
            else
            {
                Console.WriteLine("There is nothing in this room");
            }
        }
    }

    public bool CheckForPit()
    {
        int[,] directions = {{ 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 }};
        for(int i = 0; i < directions.Length/2; i++)
        {
            int newX = Index.X + directions[i,0];
            int newY = Index.Y + directions[i,1];
            if (newX > 0 && newX < Map.MapSize - 1 && newY > 0 && newY < Map.MapSize - 1 && Map.Rooms[newX, newY] is PitRoom)
            {
                return true;
            }
        }
        return false;
    }
    public void Combat()
    {
        if(Map.Rooms[Index.X, Index.Y] is MonsterRoom<Maelstrom>)
        {
            if(Index.X + 2 < Map.MapSize)
            {
                Index.X += 2;
            }
            else
            {
                Index.X = Index.X - Map.MapSize + 2;
            }

            if(Index.Y - 1 >= 0)
            {
                Index.Y --;
            }
            else
            {
                Index.Y = 0 + Index.Y + 1;
            }
            Map.MoveMaelstrom(Index.X, Index.Y);
        }
        else if(Map.Rooms[Index.X, Index.Y] is MonsterRoom<Amarok>)
        {

        }
    }

    public void DisplayEndGame()
    {
        if(Win)
        {
            Console.WriteLine("Congratulations! You found the Fountain of Objects");
        }
        if(Lose)
        {
            Console.WriteLine("GAME OVER");
        }
    }
}