using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{    
    internal class InputClassPlayer
    {
        int i = -1;
        int j = -1;               

        public int getI() { return i; }
        public int getJ() { return j; }
        public bool readKeyPlayer(Player player, Handler handler)
        {
            char letter = ' ';
            while (j == -1)
            {                
                PrintField.printField(player);
                Console.Write("Letter >");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                letter = inputKey.KeyChar;
                if (inputKey.Key == ConsoleKey.Escape || inputKey.KeyChar == 'z') return true;     
              
                switch (inputKey.KeyChar)
                {
                    case 'a': j = 0; break;
                    case 'b': j = 1; break;
                    case 'c': j = 2; break;
                    case 'd': j = 3; break;
                    case 'e': j = 4; break;
                    case 'f': j = 5; break;
                    case 'g': j = 6; break;
                    case 'h': j = 7; break;
                    case 'i': j = 8; break;
                    case 'j': j = 9; break;
                    default: continue;
                }                
            }
            Console.WriteLine();
            while(i == -1)
            {                
                PrintField.printField(player);
                Console.WriteLine("Letter >" + letter);
                Console.Write("Number >");
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape || inputKey.KeyChar == 'z' || inputKey.KeyChar == 'Z') return true;
                               
                switch (inputKey.KeyChar)
                {
                    case '0': i = 0; break;
                    case '1': i = 1; break;
                    case '2': i = 2; break;
                    case '3': i = 3; break;
                    case '4': i = 4; break;
                    case '5': i = 5; break;
                    case '6': i = 6; break;
                    case '7': i = 7; break;
                    case '8': i = 8; break;
                    case '9': i = 9; break;
                    default: continue;
                }                
            }
            handler.iPlayer = i;
            handler.jPlayer = j;

            i = -1;
            j = -1;
            return false;
        }//end readKey               
    }//end InputClass
}
