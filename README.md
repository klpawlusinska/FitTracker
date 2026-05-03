# 🏋️ FitTracker

A C# console application for logging and tracking workouts. Users can add completed workouts, view their history, and see detailed statistics.

## About

This project was built as part of my Applied Computer Science studies to practice object-oriented programming concepts in C#, including enums, structs, lists, methods, and input validation.

## Features

- Log completed workouts with type, duration and calories burned
- View full workout history
- Statistics dashboard:
  - Total number of workouts
  - Total and average workout time
  - Longest workout
  - Total calories burned
  - Most frequent workout type
  - Most time-consuming workout type

## Supported Workout Types

- 🏃 Bieganie (Running)
- 🚴 Rower (Cycling)
- 🏊 Pływanie (Swimming)
- 🏋️ Siłownia (Gym)
- 🧘 Joga (Yoga)

## Technologies

- **Language:** C#
- **Platform:** .NET Console Application
- **Concepts used:** enum, struct, `List<T>`, switch, do-while, foreach, TryParse, string interpolation

## How to Run

1. Clone the repository:
   ```
   git clone https://github.com/klpawlusinska/FitTracker.git
   ```
2. Open `FitTracker.sln` in Visual Studio
3. Run the project (`F5`)

## Example Output

```
=================================
          FIT TRACKER
=================================
Treningi: 3

1. Dodaj trening
2. Historia treningów
3. Statystyki
0. Wyjdź

===================================
            Statystyki
===================================
Liczba treningów:      3
Łączny czas:           135 min
Średni czas:           45,0 min
Najdłuższy trening:    60 min
Łączne kalorie:        980 kcal
Ulubiony trening:      Bieganie (2 razy)
Najbardziej czasochłonny: Bieganie (90 minut)
```

## Author

**Klaudia Pawlusińska** — 1st year Computer Science student, building skills in C#, SQL and data analytics.
