using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Would you like a 1: small, 2: medium, or 3: large maze");
        bool isValid;
        int num;
        do
        {
            isValid = int.TryParse(Console.ReadLine(), out num);
            if(num < 1 || num > 3)
            {
                isValid = false;
            }
        }
        while(!isValid);
        switch (num)
        {
            case 1:
                PlayGame newGame = new PlayGame(4);
                newGame.Run();
                break;
            case 2:
                newGame = new PlayGame(6);
                newGame.Run();
                break;
            case 3:
                newGame = new PlayGame(8);
                newGame.Run();
                break;
        }
        

    }
}