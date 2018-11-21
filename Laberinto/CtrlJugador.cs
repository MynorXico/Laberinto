using System;
using System.Collections.Generic;
using System.Linq;

namespace JuegoVs
{
    class Jugador : Punto
    {
        List<Celdas> muros;
        List<Celdas> libres;
        public int puntosVida;
        string Nombre;
        String log;
        //Los muros se creeran por el valor de las coodernadas de base 
        public Jugador(char value, List<Celdas> muros, List<Celdas> libres, string nombre) : base(value, 2, 1)
        {
            this.muros = muros;
            this.libres = libres;
            this.puntosVida = 5;
            this.Nombre = nombre;
            
        }
        public void MostrarStatus()
        {
            Console.ResetColor();
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("STATUS DEL PERSONAJE: ");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine("Nombre: " + Nombre);
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("Puntos de vida actuales: " + this.puntosVida);
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Ubicación actual: " + "(" + this.X + "," + this.Y + ")");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine(log);
            if (this.puntosVida == 0) {
                BucleJuego.conVida = false;
            }
        }
        // Al presionar las teclas actuara el objeto, al igual que con las letra asignadas
        public void HandleKey(ConsoleKeyInfo click)
        {
            log = "                                         ";
            switch (click.Key)
            {
                case ConsoleKey.D:
                    Y += 1;
                    if (IsCollidingMuros()) {
                        Y -= 1;
                        log = "Hay un obstáculo, no se puede mover. ";
                    }
                    else if (ItsAnEnemy())
                    {
                        Y -= 1;
                        log = "Hay un enemigo, no se puede mover.   ";
                        puntosVida--;
                    }
                    break;
                case ConsoleKey.L:
                    Y += 1;
                    if (ItsAnEnemy())
                    {
                        libres.Find(c => (c.X == X && c.Y == Y)).IsEnemy = false;
                    }
                    else
                    {
                        Y -= 1;
                    }
                    break;

                case ConsoleKey.A:
                    Y -= 1;
                    if (IsCollidingMuros()) {
                        log = "Hay un obstáculo, no se puede mover. ";
                        Y += 1;
                    }
                    else if (ItsAnEnemy())
                    {
                        Y += 1;
                        log = "Hay un enemigo, no se puede mover.   ";
                        puntosVida--;
                    }
                    break;
                case ConsoleKey.J:
                    Y -= 1;
                    if (ItsAnEnemy())
                    {
                        libres.Find(c => (c.X == X && c.Y == Y)).IsEnemy = false;
                    }
                    else
                    {
                        Y += 1;
                    }
                    break;

                case ConsoleKey.S:
                    X += 1;
                    if (IsCollidingMuros())
                    {
                        log = "Hay un obstáculo, no se puede mover. ";
                        X -= 1;
                    }
                    else if (ItsAnEnemy())
                    {
                        X -= 1;
                        log = "Hay un enemigo, no se puede mover.   ";
                        puntosVida--;
                    }
                    break;
                case ConsoleKey.K:
                    X += 1;
                    if (ItsAnEnemy())
                    {
                        libres.Find(c => (c.X == X && c.Y == Y)).IsEnemy = false;
                    }
                    else
                    {
                        X -= 1;
                    }
                    break;

                case ConsoleKey.W:
                    X -= 1;
                    if (IsCollidingMuros())
                    {
                        log = "Hay un obstáculo, no se puede mover. ";
                        X += 1;
                    }
                    else if (ItsAnEnemy())
                    {
                        X += 1;
                        log = "Hay un enemigo, no se puede mover.   ";
                        puntosVida--;
                    }
                    break;
                case ConsoleKey.I:
                    X -= 1;
                    if (ItsAnEnemy())
                    {
                        libres.Find(c => (c.X == X && c.Y == Y)).IsEnemy = false;
                    }
                    else
                    {
                        X += 1;
                    }
                    break;
                    
            }
            MostrarStatus();
        }

       
        //Revisa si los muros de la lista contienen las coordenadas del jugador
        bool IsCollidingMuros()
        {
            return muros.Any(c => c.IsCollidingWith(this));
        }

        // Revisa si hay un enemigo en el lugar
        bool ItsAnEnemy() {
            return libres.Any(c => c.IsAnEnemy(this));
        }

        bool ItsAStar() {
            return libres.Any(c => c.IsAStar(this));
        }
    }
}