# TP2 – LINQ (Language Integrated Query)

**Author:** safabelhouche  
**Branch:** `tp2`  
**Date:** April 2025  


## 📌 Objectives

- Manipulate collections with declarative LINQ queries instead of manual loops.
- **Filtering** (`Where`), **sorting** (`OrderByDescending`), **projection** (`Select`).
- **Aggregations** (`Sum`, `Average`, `Max`, `FirstOrDefault`).
- **Grouping** by a key and aggregating within groups (`GroupBy`).
- **Pipeline**: split a CSV string, parse, filter, sort, take top 3.



## 📂 Files in this branch

| File | Description |
|------|-------------|
| `DataLab2/Program.cs` | Complete code with all activities and the final exercise. |
| `DataLab2/tp2-output.png` | Screenshot of the terminal output (with emojis). |


## ▶️ How to run

```bash
cd DataLab2
dotnet run
```

## 📸 Execution output

![Terminal output](DataLab2/tp2-output.png)

## 🧠 What I learned
✅ LINQ method syntax is similar to JavaScript array methods (Where = filter, Select map, OrderBy = sort).

✅ GroupBy groups elements by a key and allows per‑group aggregations.

✅ Aggregations (Sum, Average, Max) are computed directly on the collection – no manual loops.

✅ FirstOrDefault safely returns the first match or null.

✅ The CSV pipeline shows how to chain operations: Split → Select → Where → OrderBy → Take.

✅ Anonymous types (new { ... }) are useful for temporary projections.

## 🔗 Branch information

This code is stored in the `tp2` branch of the repository.  
The `main` branch contains only this README.md (project overview).

---
💻 Copyright © 2025 safabelhouche – All rights reserved.
This work is part of the .NET C# Programming course at Ecole Polytechnique de Sousse.