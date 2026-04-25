# .NET Dashboard Labs (TP1 → TP9)

**Author:** safabelhouche  
**Repository:** [DotNet-Dashboard-Labs](https://github.com/SafaBelh/DotNet-Dashboard-Labs)  
**Year:** 2025



## 🧭 Overview

This repository contains my progressive work for **9 labs** (TP1 to TP9) from the .NET C# Programming module.  
Each lab builds on the previous one, starting from console basics and ending with a full‑stack interactive dashboard with data visualisation.

All code is stored in **separate Git branches** – one per TP.



## 🌿 Branches (TP1 → TP9)

| Branch | Description | Key topics |
|--------|-------------|-------------|
| [`tp1`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp1) | C# console basics | Classes, lists, loops, random data, statistics |
| [`tp2`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp2) | LINQ (declarative queries) | `Where`, `Select`, `OrderBy`, `GroupBy`, aggregations, CSV pipeline |
| [`tp3`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp3) | Blazor Web App (first interactive page) | Routing, events, conditional rendering, navigation |
| [`tp4`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp4) | Dependency Injection | Services, interfaces, DI container, async simulation |
| [`tp5`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp5) | Entity Framework Core + SQLite | Code‑First, migrations, relationships (1‑to‑N, N‑to‑N), seeding |
| [`tp6`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp6) | Async LINQ to SQL | KPIs (`CountAsync`, `AverageAsync`, `MaxAsync`), critical filter, loading spinner |
| [`tp7`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp7) | CRUD forms & validation | Unified add/edit form, `EditForm`, Data Annotations, delete confirmation |
| [`tp8`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp8) | Component architecture | Reusable components (`KpiCard`, `SensorTable`, `SensorCard`), `[Parameter]`, `EventCallback`, view toggle |
| [`tp9`](https://github.com/SafaBelh/DotNet-Dashboard-Labs/tree/tp9) | Data visualisation (Radzen) | Bar chart, radial gauge, donut chart, cross‑filtering, dashboard finalisation |

Each branch contains a **detailed README** explaining its objectives, activities, and screenshots.



## 💻 How to explore

1. **Clone the repository**  
   ```bash
   git clone https://github.com/SafaBelh/DotNet-Dashboard-Labs.git
   cd DotNet-Dashboard-Labs
   ```

2. **Switch to a specific TP branch**  
   ```bash
   git checkout tp3   # or tp4, tp5, …, tp9
   ```

3. **Open the project**  
   For console labs (TP1, TP2):  
   ```bash
   cd DataLabX
   dotnet run
   ```  
   For web labs (TP3 – TP9):  
   ```bash
   cd DashboardData
   dotnet watch
   ```

4. **Read the lab instructions** inside each branch's `README.md` (visible on GitHub).



## 🧠 What I learned (overall)

- ✅ C# syntax, object‑oriented programming, collections, LINQ.
- ✅ Building interactive web UIs with Blazor without JavaScript.
- ✅ Dependency Injection and separation of concerns.
- ✅ Database persistence with EF Core (SQLite), migrations, relationships.
- ✅ CRUD operations with automatic validation.
- ✅ Component‑based architecture and event communication.
- ✅ Data visualisation with Radzen (charts, gauges, cross‑filtering).

---

**Copyright © 2025 safabelhouche – All rights reserved.**  
*This work is part of the .NET C# Programming course at Ecole Polytechnique de Sousse.*
