/*
 * Author: Leszek Lewandowski
 * File: Program.cs
 */

using System;
using System.Net.Sockets;

/// <summary>
/// Jest to klasa startowa aplikacji. 
/// </summary>
internal class Program
{
    /// <summary>
    /// Punkt startowy aplikacji
    /// </summary>
    /// <param name="args">Parametry startowe aplikacji</param>
    /// <seealso cref=""/>
    private static void Main(string[] args)
    {
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine("1. Dodawanie");
        Console.WriteLine("2. Odejmowanie");
        Console.WriteLine("3. Mnożenie");
        Console.WriteLine("4. Dzielenie");
        Console.Write("Wybierz pozycję: ");

        string? sWybor = Console.ReadLine();
        bool czyMoznaOdczytac = int.TryParse(sWybor, out int wybor);

        if (czyMoznaOdczytac)
        {
            Console.Write("Podaj X: ");
            int x = int.Parse(Console.ReadLine()!);

            Console.Write("Podaj Y: ");
            int y = int.Parse(Console.ReadLine()!);

            switch (wybor)
            {
                case 1:
                    Console.WriteLine($"Wynik dodawania {x} oraz {y} to {x + y}");
                    break;
                case 2:
                    Console.WriteLine($"Wynik odejmowawania {x} oraz {y} to {x - y}");
                    break;
                case 3:
                    Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {x * y}");
                    break;
                case 4:
                    Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {x / (float)y}");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wybór jest nieprawidłowy!");
                    Console.ResetColor();
                    break;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Podana wartość jest nieprawidłowa!");
            Console.ResetColor();
        }

    }
}