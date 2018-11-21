using System;

namespace JuegoVs
{
    abstract class Color
    {
       
        //Heredeara la clase si se usa la funcion de mostrar el color tipo string
        protected void ColorDisplay(string str, ConsoleColor fgColor, ConsoleColor bgColor)
        {
            ConsoleColor defaultFg = Console.ForegroundColor;
            ConsoleColor defaultBg = Console.BackgroundColor;

            Console.ForegroundColor = fgColor;
            Console.BackgroundColor = bgColor;

            Console.Write(str);

            Console.ForegroundColor = defaultFg;
            Console.BackgroundColor = defaultBg;
        }
    }
}