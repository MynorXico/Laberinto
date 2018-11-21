using System;

namespace JuegoVs
{ 
    //opcion de interfaz de usuario
    class InterfaceDeUsuario : IInterfaceUsuario
    {
        
        public void ComenzarJuego(IBucleJuego buclejuego)
        {
            Console.SetWindowSize(80, 20);//Tamaño de pantalla de windows 
            Console.CursorVisible = false;
            string nom;

            do
            {
                string key;
                do
                { //Presentacion
                    Console.Clear();
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine(" STRADOVARIOUS STUDIOs PRESENT ");
                    Console.WriteLine("");
                    Console.WriteLine("     MAZE LABERINTO ESCAPE    ");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                    Console.WriteLine("");
                    Console.WriteLine("Ingrese su nombre de jugador:");
                    nom = (Console.ReadLine());
                
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("    COMANDOS DEL JUEGO  ");
                    Console.WriteLine("");
                    Console.WriteLine(" *-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("");
                    Console.WriteLine(" DESPlAZAR ARRIBA ----->  Letra W ");    
                    Console.WriteLine(" DESPlAZAR ABAJO ------>  Letra S ");
                    Console.WriteLine(" DESPlAZAR IZQUIERDA -->  Letra A ");
                    Console.WriteLine(" DESPlAZAR DERECHA ---->  Letra D ");
                    Console.WriteLine(" ATACAR ARRIBA ----->     Letra I ");
                    Console.WriteLine(" ATACAR ABAJO ------>     Letra K ");
                    Console.WriteLine(" ATACAR IZQUIERDA -->     Letra J ");
                    Console.WriteLine(" ATACAR DERECHA ---->     Letra L ");
                    Console.WriteLine("");
                    Console.WriteLine(" *-*-*-*-*-*-*-*-*-*-*-*-*-*-*");

                    Console.WriteLine("Presione cualquier tecla para continuar:");
                    Console.ReadLine();
                    //Menu de seleccion
                    Console.Clear();
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("     MAZE LABERINTO ESCAPE       ");
                    Console.WriteLine("*-*-*-*-*-*-*-*-*-*-*-*-*-*-*");
                    Console.WriteLine("Iniciar juego");
                    Console.WriteLine("1. Tablero 1");
                    Console.WriteLine("2. Tablero 2");
                    Console.WriteLine("3. Tablero 3");
                    Console.WriteLine("4. Salir");
   
                    key = Console.ReadLine();
                    Console.Clear();
                } while (key != "1" && key != "2" && key != "3" && key != "4");
                switch (key)
                {
                    case "1":
                        IJuego juego1 = new Juego(9, 9, '@', 6, 10, nom); //Cambiando valores se incrementa el tamaño del mapa x,y
                        juego1.Initialize();
                        buclejuego.correr(juego1);
                        break;
                    case "2":
                        IJuego juego2 = new Juego(11, 10, '@', 6, 15, nom); //Cambiando valores se incrementa el tamaño del mapa x,y
                        juego2.Initialize();
                        buclejuego.correr(juego2);
                        break;
                    case "3":
                        IJuego juego3 = new Juego(13, 13, '@', 6, 40, nom); //Cambiando valores se incrementa el tamaño del mapa x,y
                        juego3.Initialize();
                        buclejuego.correr(juego3);
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                        

                }
                Console.Clear();
            } while (true);
        }

      
    }
}

