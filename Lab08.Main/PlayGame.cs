using System.Collections;
using System.Net.Quic;

public class PlayGame
{
    Random rand = new Random();
    RoomMap Map { get; set; }
    (int X, int Y) Index;

    Player player;
    public bool Win;
    public bool Lose;
    public bool quit;
    public PlayGame(int size)
    {
        Map = new RoomMap(size);
        Index = (0, size - 1);
        player = new Player();
    }

    public void Run()
    {
        Map.MakeMap();
        quit = false;
        while (!quit)
        {
            Console.Clear();
            Map.DisplayMap(Index.X, Index.Y);
            Move();
            CheckforEndCondition();
            if (Win == true || Lose == true)
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
                if (Index.Y - 1 >= 0)
                {
                    Index.Y--;
                }
                break;
            case ConsoleKey.DownArrow:
                if (Index.Y + 1 < Map.MapSize)
                {
                    Index.Y++;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (Index.X - 1 >= 0)
                {
                    Index.X--;
                }
                break;
            case ConsoleKey.RightArrow:
                if (Index.X + 1 < Map.MapSize)
                {
                    Index.X++;
                }
                break;
        }


    }

    public void CheckforEndCondition()
    {
        if (Map.Rooms[Index.X, Index.Y].HasFountain)
        {
            Win = true;
        }
        if (player.Health <= 0)
        {
            Lose = true;
        }
        if (Map.Rooms[Index.X, Index.Y].HasMonster)
        {
            if (Map.Rooms[Index.X, Index.Y].monster is Maelstrom)
            {
                MaelstromCombat();
            }
            else
            {
                Combat();
            }
        }
    }
    public void Surroundings()
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        if (Index.Y == Map.MapSize - 1 && Index.X == 0)
        {
            Console.WriteLine("You see light in this room coming from outside the cavern. This is the entrance.");
        }
        else if (CheckForMaelstrom())
        {
            Console.WriteLine("You hear the growling and groaning of a maelstrom nearby.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.White;
            if (Map.Rooms[Index.X, Index.Y].HasMonster)
            {
                Console.WriteLine($"This room has a {Map.Rooms[Index.X, Index.Y].monster.Name}");
            }
            else if (Map.Rooms[Index.X, Index.Y].HasFountain)
            {
                Console.WriteLine("This room has the Fountain of Objects");
            }
            else
            {
                Console.WriteLine("There is nothing in this room");
            }
        }
    }

    public bool CheckForMaelstrom()
    {
        int[,] directions = { { 1, 0 }, { -1, 0 }, { 0, 1 }, { 0, -1 } };
        for (int i = 0; i < directions.Length / 2; i++)
        {
            int newX = Index.X + directions[i, 0];
            int newY = Index.Y + directions[i, 1];
            if (newX > 0 && newX < Map.MapSize - 1 && newY > 0 && newY < Map.MapSize - 1 && Map.Rooms[newX, newY].monster is Maelstrom)
            {
                return true;
            }
        }
        return false;
    }
    public void Combat()
    {

        while (player.Health > 0 && Map.Rooms[Index.X, Index.Y].monster.Health > 0)
        {
            Console.Clear();
            Map.DisplayMap(Index.X, Index.Y);
            Console.WriteLine($"Player HP: {player.Health}");
            Console.WriteLine($"{Map.Rooms[Index.X, Index.Y].monster.Name} HP: {Map.Rooms[Index.X, Index.Y].monster.Health}");
            switch(PlayerOptions())
            {
                case 1:
                    if(player.weapon.StrengthEnhance + rand.Next(20) >= Map.Rooms[Index.X, Index.Y].monster.ArmorClass)
                    {
                        player.Health = player.Health - Map.Rooms[Index.X, Index.Y].monster.weapon.Damage;
                    }
                    if(rand.Next(20) + Map.Rooms[Index.X, Index.Y].monster.weapon.StrengthEnhance >= player.ArmorClass)
                    {
                        Map.Rooms[Index.X, Index.Y].monster.Health = Map.Rooms[Index.X, Index.Y].monster.Health - player.weapon.Damage;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    player.DisplayPotionList();
                    break;
            }
        }
        if (Map.Rooms[Index.X, Index.Y].monster.Health <= 0)
        {
            Map.Rooms[Index.X, Index.Y].HasMonster = false;
            Console.WriteLine($"You killed the {Map.Rooms[Index.X, Index.Y].monster.Name}");
            Loot();
        }

    }



    public int PlayerOptions()
    {
        Console.WriteLine("What would you like to do? 1: Attack 2: Dodge 3: Drink Potion");
        return player.ValidateAnswer(3);
    }

    

    public void Loot()
    {
        //player automatically get the monsters potion
        player.potions.Add(new Potion());
        Map.Rooms[Index.X, Index.Y].monster.potions.Remove( Map.Rooms[Index.X, Index.Y].monster.potions[0]);
        Console.WriteLine($"Would you like a { Map.Rooms[Index.X, Index.Y].monster.weapon.Name}? 1: Yes 2: No");
        Console.WriteLine($"It does { Map.Rooms[Index.X, Index.Y].monster.weapon.Damage} damage, and enhances your strength by { Map.Rooms[Index.X, Index.Y].monster.weapon.Damage}.");
        if(player.ValidateAnswer(2) == 1)
        {
            player.weapon = Map.Rooms[Index.X, Index.Y].monster.weapon;
            Map.Rooms[Index.X, Index.Y].monster.weapon = new NoWeapon();
        }
    }

    
    public void MaelstromCombat()
    {
        int chanceItFlees = rand.Next(3);
        if (chanceItFlees == 1)
        {
            MoveMaelstrom();
            if (Index.X + 2 < Map.MapSize)
            {
                Index.X += 2;
            }
            else
            {
                Index.X = Index.X - Map.MapSize + 2;
            }

            if (Index.Y - 1 >= 0)
            {
                Index.Y--;
            }
            else
            {
                Index.Y = 0 + Index.Y + 1;
            }
        }
        else
        {
            Combat();
        }
    }
    public void MoveMaelstrom()
    {
        Map.Rooms[Index.X, Index.Y].HasMonster = false;
        if (Index.X - 2 >= 0)
        {
            Index.X -= 2;
        }
        else
        {
            Index.X = 0 + Index.X + 2;
        }

        if (Index.Y + 1 < Map.MapSize)
        {
            Index.Y++;
        }
        else
        {
            Index.Y = Index.Y - Map.MapSize + 1;
        }
        Map.Rooms[Index.X, Index.Y].monster = new Maelstrom();
        Map.Rooms[Index.X, Index.Y].HasMonster = true;


    }

    public void DisplayEndGame()
    {
        Map.DisplayMap(Index.X, Index.Y);
        if (Win)
        {
            Console.WriteLine("Congratulations! You found the Fountain of Objects");
        }
        if (Lose)
        {
            Console.WriteLine("GAME OVER");
        }
    }
}