/*
 * Author: Leszek Lewandowski
 * File: Program.cs
 */

using Comarch20250217.Calculator;
using System;
using System.Net.Sockets;

namespace Comarch20250217;

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
        ConsoleKeyInfo znakKontynuowac;
        do
        {
            DisplayMenu();

            string? sWybor = Console.ReadLine();
            bool czyMoznaOdczytac = int.TryParse(sWybor, out int wybor);

            if (czyMoznaOdczytac)
            {
                int x, y;
                Calc kalkulator = new Calc();

                switch (wybor)
                {
                    case 1:
                        OdczytajXY(out x, out y);
                        int suma = kalkulator.Add(x, y);
                        Console.WriteLine($"Wynik dodawania {x} oraz {y} to {suma}");
                        break;
                    case 2:
                        OdczytajXY(out x, out y);
                        Console.WriteLine($"Wynik odejmowawania {x} oraz {y} to {kalkulator.Substract(x, y)}");
                        break;
                    case 3:
                        OdczytajXY(out x, out y);
                        Console.WriteLine($"Wynik mnożenia {x} oraz {y} to {x * y}");
                        break;
                    case 4:
                        OdczytajXY(out x, out y);
                        try
                        {
                            Console.WriteLine($"Wynik dzielenia {x} oraz {y} to {kalkulator.Dividy(x, y)}");
                        }
                        catch (Exception ex)
                        {
                            ShowError("Pamiętaj cholero! Nie dziel przez 0!");
                        }
                        break;
                    case 5:
                        kalkulator.Sortowanie();
                        break;
                    default:
                        ShowError("Wybór jest nieprawidłowy!");
                        break;
                }
            }
            else
            {
                ShowError("Podana wartość jest nieprawidłowa!");
            }
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Czy chcesz wykonać kolejną operację? [T|n]");
            znakKontynuowac = Console.ReadKey();

        } while (znakKontynuowac.Key == ConsoleKey.T);

    }

    private static void OdczytajXY(out int x, out int y)
    {
        Console.Write("Podaj X: ");
        x = int.Parse(Console.ReadLine()!);
        Console.Write("Podaj Y: ");
        y = int.Parse(Console.ReadLine()!);
    }

    private static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("KALKULATOR 1.0");
        Console.WriteLine("1. Dodawanie");
        Console.WriteLine("2. Odejmowanie");
        Console.WriteLine("3. Mnożenie");
        Console.WriteLine("4. Dzielenie");
        Console.WriteLine("5. Sortowanie liczb");
        Console.Write("Wybierz pozycję: ");
    }

    private static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

}

