using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal static class PrintField
    {
        public static void printField(Player player)
        {
            Console.Clear();
            Console.WriteLine("Sea Battle");
            Console.WriteLine("Exit - ESC or z");
            Console.WriteLine();
            Console.WriteLine("Your ships              Opponent ships");
            Console.WriteLine("  a b c d e f g h i j\t  a b c d e f g h i j");
            for (int i = 0; i < player.getSizeField(); i++)
            {
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < player.getSizeField(); j++)
                {
                    if (player.getFieldElement(i, j) == 0)
                        Console.Write("_ ");
                    else if(player.getFieldElement(i, j) == 1)
                        Console.Write("O ");
                    else
                        Console.Write("X ");
                }
                Console.Write("\t");
                Console.Write(i);
                Console.Write(" ");
                for (int j = 0; j < player.getSizeField(); j++)
                {
                    if (player.getMyMoveElement(i, j) == 0)
                        Console.Write("_ ");
                    else if (player.getMyMoveElement(i, j) == 1)
                        Console.Write("X ");
                    else
                        Console.Write("* ");
                }
                Console.WriteLine("\n");
            }           
        }//end printField
    }//end class PrintField
}
