namespace TicTacToe
{
    public class Program
    {
        private static char[] field = { 'o', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static char[] temp = { 'o', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        
        static void Main(string[] args)
        {
            int player = 1;
            int playerInput;
            char mark = 'X';
            int gameControl = -1;
            DrawBoard();
            while (gameControl == -1)
            {
                if (player % 2 != 0)
                {
                    mark = 'X';
                    player = 1;
                }
                else
                {
                    mark = 'O';
                    player = 2;
                }

                Console.Write($"Player {player}, enter a number from 1-9: ");

                try
                {
                    playerInput = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong move!");
                    continue;
                }
                
                try
                {
                    if (field[playerInput] == (char)(playerInput + '0'))
                    {
                        temp[playerInput] = mark;
                        field[playerInput] = mark;
                    }
                    else
                    {
                        Console.WriteLine("Wrong move!");
                        player--;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Wrong move!");
                    player--;
                }

                player++;
                
                DrawBoard();
                
                gameControl = CheckWin();
            }

            DrawBoard();
            
            if (gameControl == 1)
            {
                Console.WriteLine($"Game over, player {--player} won.");
            }
            else
            {
                Console.WriteLine("The game is tied.");
            }
            
        }
        
        public static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t Tic Tac Toe");
            Console.WriteLine("\t 1st player (X) - 2nd player(O)");
            Console.WriteLine();
            Console.WriteLine($"     |     |               |     |     ");
            Console.WriteLine($"  {temp[7]}  |  {temp[8]}  |  {temp[9]}         7  |  8  |  9  ");
            Console.WriteLine($"_____|_____|_____     _____|_____|_____");
            Console.WriteLine($"     |     |               |     |     ");
            Console.WriteLine($"  {temp[4]}  |  {temp[5]}  |  {temp[6]}         4  |  5  |  6  ");
            Console.WriteLine($"_____|_____|_____     _____|_____|_____");
            Console.WriteLine($"     |     |               |     |     ");
            Console.WriteLine($"  {temp[1]}  |  {temp[2]}  |  {temp[3]}         1  |  2  |  3  ");
            Console.WriteLine($"     |     |               |     |     ");
            Console.WriteLine();
        }

        public static int CheckWin()
        {
            if ((field[1] == field[2]) && (field[2] == field[3]))
                return 1;
            else if ((field[4] == field[5]) && (field[5] == field[6]))
                return 1;
            else if ((field[7] == field[8]) && (field[8] == field[9]))
                return 1;
            else if ((field[1] == field[4]) && (field[4] == field[7]))
                return 1;
            else if ((field[2] == field[5]) && (field[5] == field[8]))
                return 1;
            else if ((field[3] == field[6]) && (field[6] == field[9]))
                return 1;
            else if ((field[1] == field[5]) && (field[5] == field[9]))
                return 1;
            else if ((field[3] == field[5]) && (field[5] == field[7]))
                return 1;
            else if (field[1] != '1' && field[2] != '2' && field[3] != '3' && field[4] != '4' && field[5] != '5' &&
                     field[6] != '6' && field[7] != '7' && field[8] != '8' && field[9] != '9')
                return 0;
            else
                return -1;
        }
        
        
    }

}