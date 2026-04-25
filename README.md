# TP1 – C# Console Basics (Sensor Data Simulation)

**Author:** safabelhouche  
**Branch:** `tp1`  
**Date:** April 2025  

## 📌 Objectives
- Create a `Sensor` class with properties (`Id`, `Name`, `Type`, `Value`), a constructor, and a validation method `UpdateValue()`.
- Generate **100 random sensors** with:
  - Random type: `"Temperature"`, `"Humidity"`, or `"CO2"`.
  - Random value: integer between **0 and 100** (inclusive).
- Compute statistics on the generated data:
  - Total number of sensors.
  - Global average value.
  - Maximum value and the name of the sensor that holds it.
  - Number of CO₂ sensors with a value greater than 80 (alerts).

## 📂 Files in this branch
| File | Description |
|------|-------------|
| `Sensor.cs` | Sensor class definition (provided by teacher). |
| `Exercice1.cs` | Generates 100 sensors, displays the first 10 as a preview. |
| `Exercice2.cs` | Computes statistics (average, max, CO₂ alerts) from the sensor list. |
| `Program.cs` | Coordinates the two exercises: calls `Exercice1` to get the list, then passes it to `Exercice2`. |
| `tp1-output.png` | Screenshot of the terminal output (both exercises). |

## ▶️ How to run
```bash
dotnet run

## 📸 Execution output
https://tp1-output.png

## 🧠 What I learned
✅ Creating and using classes in C#. 

✅ Using List<T> to store collections of objects.

✅ Generating random numbers with Random.Next().

✅ Loops: for and foreach.

✅ Accumulating sums, tracking maximum values, counting with conditions.

✅ Formatting numbers with two decimal places ({average:F2}).

✅ Separating logic into multiple files for clarity and reusability.

## 🔗 Branch information
This code is stored in the tp1 branch of the repository.
The main branch contains only this README.md (project overview).

Copyright © 2025 safabelhouche – All rights reserved.
This work is part of the .NET C# Programming course at Ecole Polytechnique de Sousse.