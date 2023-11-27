
class Program
{
    static char[,] playerBoard = new char[10, 10];
    static char[,] computerBoard = new char[10, 10];

    static void Main(string[] args)
    {
        InitializeBoards();
        PlaceShips();

        while (true)
        {
            Console.Clear();
            PrintBoards();

            Console.WriteLine("Ваш ход:");
            Console.Write("Введите координату x: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Введите координату y: ");
            int y = int.Parse(Console.ReadLine());

            PlayerMove(x, y);

            if (CheckGameOver())
            {
                Console.WriteLine("Вы победили!");
                break;
            }

            ComputerMove();

            if (CheckGameOver())
            {
                Console.WriteLine("Компьютер победил!");
                break;
            }
        }

        Console.ReadLine();
    }

    static void InitializeBoards()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                playerBoard[i, j] = ' ';
                computerBoard[i, j] = ' ';
            }
        }
    }

    static void PrintBoards()
    {
        Console.WriteLine("Ваше поле:");
        PrintBoard(playerBoard);

        Console.WriteLine("\nПоле компьютера:");
        PrintBoard(computerBoard);
    }

    static void PrintBoard(char[,] board)
    {
        Console.WriteLine("   1 2 3 4 5 6 7 8 9 10");
        for (int i = 0; i < 10; i++)
        {
            Console.Write(i + " ");
            for (int j = 0; j < 10; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    static void PlaceShips()
    {
        Console.WriteLine("Расположите ваши корабли:");
        Console.WriteLine("Вводите координаты так, чтобы между кораблями была минимум одна пустая клетка!!!");

        for (int i = 1; i <= 4; i++)
        {
            Console.WriteLine($"Расположение корабля длиной {i}:");
            for (int j = 0; j < i; j++)
            {
                Console.Write($"Введите координату x для корабля {j + 1}: ");
                int x = int.Parse(Console.ReadLine());

                Console.Write($"Введите координату y для корабля {j + 1}: ");
                int y = int.Parse(Console.ReadLine());

                playerBoard[x, y] = 'O';
            }
        }

        Console.Clear();
    }

    static void PlayerMove(int x, int y)
    {
        if (computerBoard[x, y] == 'O')
        {
            Console.WriteLine("Вы попали!");
            playerBoard[x, y] = 'X';
        }
        else
        {
            Console.WriteLine("Вы промахнулись!");
            playerBoard[x, y] = '*';
        }
    }

    static void ComputerMove()
    {
        Random random = new Random();
        int x, y;

        do
        {
            x = random.Next(10);
            y = random.Next(10);
        } while (playerBoard[x, y] == 'X' || playerBoard[x, y] == '*');

        if (playerBoard[x, y] == 'O')
        {
            Console.WriteLine("Компьютер попал!");
            playerBoard[x, y] = 'X';
        }
        else
        {
            Console.WriteLine("Компьютер промахнулся!");
            playerBoard[x, y] = '*';
        }
    }

    static bool CheckGameOver()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if (playerBoard[i, j] == 'O')
                    return false;
                if (computerBoard[i, j] == 'O')
                    return false;
            }
        }

        return true;
    }
}