using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoMovie
{
    class Program
    {
        static void Main(string[] args)
        {
            string titleScreen = @" 

                                          888dP88dP     dP  .d888888  888888ba  
                                              88 88     88 d8'    88  88    `8b 
                                              88 88     88 88aaaaa88a 88     88 
                                              88 88     88 88     88  88     88 
                                       88.  .d8P Y8.   .8P 88     88  88     88 
                                        `Y8888'  `Y88888P' 88     88  dP     dP 
            ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
           _________________________________________________________________________________________________
          |                                                                                                 |
          |              888888ba                                                 dP                        |
          |              88    `8b                                                88                        |
          | ■■■■■■■■■■  a88aaaa8P' 88d888b. .d8888b. .d8888b. .d8888b. 88d888b. d8888P .d8888b.  ■■■■■■■■■■ |
          | ■■■■■■■■■■   88        88'  `88 88ooood8 Y8ooooo. 88ooood8 88'  `88   88   Y8ooooo.  ■■■■■■■■■■ |
          | ■■■■■■■■■■   88        88       88.  ...       88 88.  ... 88    88   88         88  ■■■■■■■■■■ |
          |              dP        dP       `88888P' `88888P' `88888P' dP    dP   dP   `88888P'             |
          |_________________________________________________________________________________________________|
          |                                                                                                 |
          | ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■ |
          | ■■  888888ba                          dP          8888ba.88ba                    oo          ■■ |
          | ■■  88    `8b                         88          88  `8b  `8b                               ■■ |
          | ■■ a88aaaa8P' .d8888b. 88d888b. .d888b88 .d8888b. 88   88   88 .d8888b. dP   .dP dP .d8888b. ■■ |
          | ■■  88   `8b. 88'  `88 88'  `88 88'  `88 88'  `88 88   88   88 88'  `88 88   d8' 88 88ooood8 ■■ |
          | ■■  88     88 88.  .88 88    88 88.  .88 88.  .88 88   88   88 88.  .88 88 .88'  88 88.  ... ■■ |
          | ■■  dP     dP `88888P8 dP    dP `88888P8 `88888P' dP   dP   dP `88888P' 8888P'   dP `88888P' ■■ |
          | ■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■ |
          |_________________________________________________________________________________________________|
                                                                                (c) 2021 DefinitelySotfware
                                                                                     All Rights Reserved";
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (titleScreen.Length / 2)) + "}", titleScreen));
            Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Press any key to continue...".Length / 2)) + "}", "Press any key to continue..."));
            Console.ReadKey();
            Console.Clear();
            menu();
        }
        static void RandomMovie()
        {
            String movie, directory, txt, ans, vistas, sepBar = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■";
            List<string> yesList = new List<string>()
            {
                "yes",
                "si",
                "y"
            };
            Random randomMovie = new Random();

            //obtengo la ubicacion de donde se ejecuta el exe
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            directory = System.IO.Path.GetDirectoryName(path);
            //concateno la ubicacion con el nombre del txt
            txt = directory + "\\Movies.txt";
            vistas = directory + "\\Watched.txt";

            Console.Title = "RandoMovie";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(CenterText("Pelicula Random"));
            Console.WriteLine(CenterText(sepBar)+"\n");
            Console.WriteLine(CenterText("Presiona ENTER para obtener la pelicula que verás hoy!")+"\n");
            Console.ReadKey();

            //Lee todas las lineas del archivo y las mete en un array de strings
            string[] Movies = System.IO.File.ReadAllLines(@txt);
            //Obtiene la pelicula de la lista
            movie = Movies[randomMovie.Next(Movies.Length)];

            Console.CursorVisible = true;
            Console.WriteLine(CenterText(movie)+"\n");
            Console.Write(String.Format("{0," + ((Console.WindowWidth / 2) + ("Verás la pelicula? (Y/N): ".Length / 2)-11) + "}", "Verás la pelicula ? (Y / N): "));
            ans = (Console.ReadLine()).ToLower();
            Console.WriteLine("");

            if (yesList.Contains(ans))
            {
                System.IO.File.WriteAllText(@txt, String.Empty);
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@txt))
                {
                    foreach (string s in Movies)
                    {
                        if (!s.Equals(movie))
                        {
                            writer.WriteLine(s);
                        }
                    }
                }
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@vistas, append: true))
                {
                    foreach (string s in Movies)
                    {
                        if (s.Equals(movie))
                        {
                            writer.WriteLine(s);
                        }
                    }
                }

                Console.CursorVisible = false;

                Console.WriteLine(CenterText(sepBar));
                Console.WriteLine(CenterText("Disfruta la pelicula!"));
                Console.WriteLine(CenterText("Presiona ENTER para volver al menu..."));
                Console.ReadKey();
                menu();
            }
            else
            {
                Console.CursorVisible = false;
                Console.WriteLine(CenterText(sepBar));
                Console.WriteLine(CenterText("Presiona ENTER para volver al menu..."));
                Console.ReadKey();
                menu();
            }
        }

        static void menu()
        {
            Console.Clear();
            int index = 0;
            string sepBar = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■";
            List<string> menuItem = new List<string>
            {
                "Pelicula Random",
                "Agregar Pelicula",
                "Formatear Lista",
                "Creditos",
                "Salir"
            };
            Console.Title = "RandoMovie";
            Console.CursorVisible = false;
            while (true)
            {        
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth/2) +("Menu Principal".Length/2)) + "}","Menu Principal"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (sepBar.Length / 2)) + "}", sepBar));
                for (int i =0; i< menuItem.Count(); i++)
                {
                    if (i == index)
                    {
                        
                        Console.Write(String.Format("{0," + (((Console.WindowWidth - menuItem[i].Length)/2)) + "}", ""));
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.WriteLine(menuItem[i]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (menuItem[i].Length / 2)) + "}", menuItem[i]));
                    }
                    Console.ResetColor();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (sepBar.Length / 2)) + "}", sepBar));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Usa ↑↓ para navegar".Length / 2)) + "}", "Usa ↑↓ para navegar"));
                Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Presiona ENTER para seleccionar una opción".Length / 2)) + "}", "Presiona ENTER para seleccionar una opción"));

                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.DownArrow)
                {
                    if (index==menuItem.Count()-1) { index = 0; }
                    else { index += 1; }
                }
                else if (ckey.Key == ConsoleKey.UpArrow)
                {
                    if (index <=0) { index = menuItem.Count()-1; }
                    else { index -= 1; }
                }
                // Selecciones del menú (quiza convertir a un switch case?)
                if (ckey.Key == ConsoleKey.Enter && index == 0)
                {
                    Console.Clear();
                    RandomMovie();
                } 
                else if (ckey.Key == ConsoleKey.Enter && index == 1)
                {
                    Console.Clear();
                    AddMovie();
                } 
                else if (ckey.Key == ConsoleKey.Enter && index == 2)
                {
                    Console.Clear();
                    FormatList();
                }
                else if (ckey.Key == ConsoleKey.Enter && index == 3)
                {
                    Console.Clear();
                    Credits();
                }
                else if (ckey.Key == ConsoleKey.Enter && index == 4)
                {
                    Environment.Exit(1);
                }
                Console.Clear();                
            }
        }

        static void AddMovie()
        {
            List<string> yesList = new List<string>()
            {
                "yes",
                "si",
                "y"
            };
            string sepBar = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■", movieName, directory, moviesTxt,confirm;
            Console.WriteLine(CenterText("Agregar Pelicula"));
            Console.WriteLine(CenterText(sepBar));
            Console.WriteLine("");

            Console.CursorVisible = true;

            Console.Write(String.Format("{0," + ((Console.WindowWidth / 3) + ("Nombre de la pelicula : ".Length / 2)) + "}", "Nombre de la pelicula: ")); 
            movieName = Console.ReadLine();

            Console.Write(String.Format("{0," + ((Console.WindowWidth / 3) + ("Seguro que quieres agregar esta película ? (Y / N) : ".Length / 2)+12) + "}", "Seguro que quieres agregar esta película? (Y/N): "));
            confirm = Console.ReadLine();

            Console.CursorVisible = false;


            Console.WriteLine("");
            Console.WriteLine(CenterText(sepBar));
            
            if (yesList.Contains(confirm.ToLower()))
            {
                string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
                directory = System.IO.Path.GetDirectoryName(path);
                moviesTxt = directory + "\\Movies.txt";

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@moviesTxt, append: true))
                {
                    writer.Write(movieName);
                }

                Console.WriteLine(CenterText("Pelicula agregada con éxito, presiona Enter para salir..."));
                Console.ReadKey();
                menu();
            }
            else
            {
                Console.WriteLine(CenterText("Pelicula no agregada, presiona Enter para salir..."));
                Console.ReadKey();
                menu();
            }
        }

        static void FormatList()
        {
            string directory, moviesTxt, vistasTxt, cleanedString;
            char[] junkChars = {'-', '*', ' '};

            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            directory = System.IO.Path.GetDirectoryName(path);
            moviesTxt = directory + "\\Movies.txt";
            vistasTxt = directory + "\\Watched.txt";
            string[] Movies = System.IO.File.ReadAllLines(@moviesTxt);
            string[] Vistas = System.IO.File.ReadAllLines(vistasTxt);

            System.IO.File.WriteAllText(@moviesTxt, String.Empty);
            System.IO.File.WriteAllText(@vistasTxt, String.Empty);
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@moviesTxt))
            {
                foreach (string s in Movies)
                {
                    cleanedString = s.TrimStart(junkChars);
                    writer.WriteLine(cleanedString);
                }
            }
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@vistasTxt))
            {
                foreach (string s in Vistas)
                {
                    cleanedString = s.TrimStart(junkChars);
                    writer.WriteLine(cleanedString);
                }
            }
        }
        static void Credits()
        {
            string creditos = @"



                 ███▄ ▄███▓▄▄▄     ▓█████▄▓█████     ▄▄▄▄▓██   ██▓    ▄▄▄██▀▀█    ██ ▄▄▄      ███▄    █ 
                ▓██▒▀█▀ ██▒████▄   ▒██▀ ██▓█   ▀    ▓█████▒██  ██▒      ▒██  ██  ▓██▒████▄    ██ ▀█   █ 
                ▓██    ▓██▒██  ▀█▄ ░██   █▒███      ▒██▒ ▄█▒██ ██░      ░██ ▓██  ▒██▒██  ▀█▄ ▓██  ▀█ ██▒
                ▒██    ▒██░██▄▄▄▄██░▓█▄   ▒▓█  ▄    ▒██░█▀ ░ ▐██▓░   ▓██▄██▓▓▓█  ░██░██▄▄▄▄██▓██▒  ▐▌██▒
                ▒██▒   ░██▒▓█   ▓██░▒████▓░▒████▒   ░▓█  ▀█░ ██▒▓░    ▓███▒ ▒▒█████▓ ▓█   ▓██▒██░   ▓██░
                ░ ▒░   ░  ░▒▒   ▓▒█░▒▒▓  ▒░░ ▒░ ░   ░▒▓███▀▒██▒▒▒     ▒▓▒▒░ ░▒▓▒ ▒ ▒ ▒▒   ▓▒█░ ▒░   ▒ ▒ 
                ░  ░      ░ ▒   ▒▒ ░░ ▒  ▒ ░ ░  ░   ▒░▒   ▓██ ░▒░     ▒ ░▒░ ░░▒░ ░ ░  ▒   ▒▒ ░ ░░   ░ ▒░
                ░      ░    ░   ▒   ░ ░  ░   ░       ░    ▒ ▒ ░░      ░ ░ ░  ░░░ ░ ░  ░   ▒     ░   ░ ░ 
                       ░        ░  ░  ░      ░  ░    ░    ░ ░         ░   ░    ░          ░  ░        ░ 
                                    ░                     ░ ░                                          

(c) 2021 DefinitelySotfware                                                                         All Rights Reserved";

            Console.WriteLine(CenterText(creditos));
            Console.ReadKey();
        }

        static string CenterText(string text)
        {
            text = String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text);
            return text;
        }
    }
}
