using System;

namespace JuegoVs
{
    abstract class Punto : Color
    {
        // Valor de punto y sus coordenadas para llamarlas y recibirlas
        public virtual char Valor { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }
        public virtual bool IsEnemy { get; set; }
        public virtual bool IsStar { get; set; }

        public Punto(char valor, int x, int y)
        {
            Valor = valor;
            X = x;
            Y = y;
        }

        //Mostrara el punto con los colores
        public virtual void Display(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(Y, X);
            ColorDisplay(Valor.ToString(), fgColor, bgColor);
        }


        // Borrara el punto con los colores
        public virtual void Erase(ConsoleColor fgColor, ConsoleColor bgColor)
        {
            Console.SetCursorPosition(Y, X);
            ColorDisplay(" ", fgColor, bgColor);
        }


        //Veririficara si otro punto aparece
        public virtual bool IsCollidingWith(Punto p)
        {
            return X == p.X && Y == p.Y;
        }

        // Verificara si hay enemigo
        public virtual bool IsAnEnemy(Punto p) {
            return IsEnemy && X == p.X && Y == p.Y;
        }

        public virtual bool IsAStar(Punto p) {
            return IsStar && X == p.X && Y == p.Y;
        }
    }
}