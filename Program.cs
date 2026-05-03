using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitTracker
{
    internal class Program
    {
        static List<WorkOut> workouts = new List<WorkOut>();
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("=================================");
                Console.WriteLine("          FIT TRACKER");
                Console.WriteLine("=================================");
                Console.WriteLine("Treningi w maju: " + workouts.Count);
                Console.WriteLine();
                PrintMenu();
                Console.WriteLine();
                Console.Write("Twój wybór: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddWorkout();
                        break;
                    case "2":
                        ViewWorkouts();
                        break;
                    case "3":
                        ShowStats();
                        break;
                    case "0":
                        Console.WriteLine("Do widzenia!");
                        return;
                    default:
                        Console.WriteLine("Nieznana opcja.");
                        Console.ReadKey();
                        break;
                }
            }
            while (true);
        }

        static void PrintMenu()
        {
            Console.WriteLine("1. Dodaj trening");
            Console.WriteLine("2. Historia treningów");
            Console.WriteLine("3. Statystyki");
            Console.WriteLine("0. Wyjdź");
        }

        static void AddWorkout()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("       Dodaj nowy trening");
            Console.WriteLine("==================================");
            Console.WriteLine();

            WorkOut w = new WorkOut();
            w.Type = GetWorkoutType("Wybierz typ treningu: ");
            w.DurationMinutes = GetIntInput("Podaj czas trwania (minuty): ");
            w.Calories = GetIntInput("Podaj spalone kalorie: ");
            w.Date = DateTime.Now.ToString("yyyy-MM-dd");

            workouts.Add(w);
            Console.WriteLine("Trening dodany!");
            Console.ReadKey();
        }
        static void ViewWorkouts()
        {
            Console.Clear();
            Console.WriteLine("==================================");
            Console.WriteLine("      Ostatnie treningi:");
            Console.WriteLine("==================================");
            Console.WriteLine();

            if (workouts.Count == 0)
            {
                Console.WriteLine("Brak treningów do wyświetlenia.");
            }
            else
            {
                foreach (var w in workouts)
                {
                    Console.WriteLine($"{w.Date} - {w.Type} - {w.DurationMinutes} min - {w.Calories} kcal");
                }
            }

            Console.ReadKey();


        }
        static void ShowStats()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("            Statystyki");
            Console.WriteLine("===================================");
            Console.WriteLine();

            if (workouts.Count == 0)
            {
                Console.WriteLine("Brak danych do wyświetlenia.");
                Console.ReadKey();
                return;
            }

            int totalMinutes = 0;
            int totalCalories = 0;
            int maxMinutes = 0;

            foreach (WorkOut w in workouts)
            {
                totalMinutes += w.DurationMinutes;
                totalCalories += w.Calories;
                if (w.DurationMinutes > maxMinutes)
                {
                    maxMinutes = w.DurationMinutes;
                }
            }
            double avgMinutes = (double)totalMinutes / workouts.Count;
            // -- Favourite
            int[] counts = new int[6];

            foreach (WorkOut w in workouts)
            {
                counts[(int)w.Type]++;
            }

            int maxCount = 0;
            WorkOutType favourite = WorkOutType.Bieganie;

            for (int i = 1; i < 5; i++)
            {
                if (counts[i] > maxCount)
                {
                    maxCount = counts[i];
                    favourite = (WorkOutType)i;
                }
            }
            // -- Najdłuższy

            int[] minutesByType = new int[6];

            foreach (WorkOut w in workouts)
            {
                minutesByType[(int)w.Type] += w.DurationMinutes;
            }

            int maxTypeMinutes = 0;
            WorkOutType longest = WorkOutType.Bieganie;

            for (int i = 1;i <= 5; i++)
            {
                if (minutesByType[i] > maxTypeMinutes)
                {
                    maxTypeMinutes = minutesByType[i];
                    longest = (WorkOutType)i;
                }
            }

            Console.WriteLine($"Liczba treningów: {workouts.Count}");
            Console.WriteLine($"Łączny czas: {totalMinutes}");
            Console.WriteLine($"Średni czas: {avgMinutes:F1}");
            Console.WriteLine($"Najdłuższy trening: {maxMinutes}");
            Console.WriteLine($"Łączne kalorie: {totalCalories} kcal");
            Console.WriteLine($"Ulubiony trening: {favourite} ({maxCount} razy)");
            Console.WriteLine($"Najbardziej czasochłonny typ ćwiczeń: {longest} ({maxTypeMinutes} minut)");

            Console.ReadKey();
        }
            static WorkOutType GetWorkoutType(string label)
        {
            Console.WriteLine("Rodzaj treningu: ");
            Console.WriteLine("1. Bieganie");
            Console.WriteLine("2. Jazda na rowerze");
            Console.WriteLine("3. Pływanie");
            Console.WriteLine("4. Siłownia");
            Console.WriteLine("5. Joga");
            Console.Write(label);

            string input = Console.ReadLine();
            int choice;

            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1: return WorkOutType.Bieganie;
                    case 2: return WorkOutType.Rower;
                    case 3: return WorkOutType.Pływanie;
                    case 4: return WorkOutType.Silownia;
                    case 5: return WorkOutType.Yoga;
                }
            }
            Console.WriteLine("Nieprawidłowy wybór. Domyślnie ustawiono Bieganie.");
            return WorkOutType.Bieganie;
        }

        static int GetIntInput(string label)
        {
            Console.Write(label);
            string input = Console.ReadLine();
            int result;

            if (int.TryParse(input, out result) && result >= 0)
            {
                return result;
            }

            Console.WriteLine("Błędna wartość. Ustawiono: 0");
            return 0;
        }
        enum WorkOutType
        {
            Bieganie = 1,
            Rower = 2,
            Pływanie = 3,
            Silownia = 4,
            Yoga = 5
        }

        struct WorkOut
        {
            public WorkOutType Type;
            public int DurationMinutes;
            public int Calories;
            public string Date;
        }
    }

}
