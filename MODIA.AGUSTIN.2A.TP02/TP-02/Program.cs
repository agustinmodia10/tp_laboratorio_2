using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2018;

namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            Console.Title = "MODIA.AGUSTIN.2A.TP02";

            Changuito changoDeCompras = new Changuito(6);

            Dulce c1 = new Dulce(Producto.EMarca.Sancor, "ASE012", ConsoleColor.Blue);
            Dulce c2 = new Dulce(Producto.EMarca.Ilolay, "ESD913", ConsoleColor.Cyan);
            Leche m1 = new Leche(Producto.EMarca.Pepsico, "HEK789", ConsoleColor.DarkCyan);
            Leche m2 = new Leche(Producto.EMarca.Serenisima, "IOE852", ConsoleColor.DarkMagenta, Leche.ETipo.Entera);
            Snacks a1 = new Snacks(Producto.EMarca.Campagnola, "AWE968", ConsoleColor.Magenta);
            Snacks a2 = new Snacks(Producto.EMarca.Arcor, "TQU426", ConsoleColor.Blue);
            Snacks a3 = new Snacks(Producto.EMarca.Sancor, "IOA852", ConsoleColor.White);
            Snacks a4 = new Snacks(Producto.EMarca.Sancor, "TRA321", ConsoleColor.DarkYellow);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el m1 repetido) y muestro
            changoDeCompras += c1;
            changoDeCompras += c2;
            changoDeCompras += m1;
            changoDeCompras += m1;
            changoDeCompras += m2;
            changoDeCompras += a1;
            changoDeCompras += a2;
            changoDeCompras += a3;
            changoDeCompras += a4;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= c1;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Dulce));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Leches
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Leche));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Snacks));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
        }
    }
}
