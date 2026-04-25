# TP4 – Dependency Injection & Asynchronous Services

**Author:** safabelhouche  
**Branch:** `tp4`  
**Date:** April 2025  


## 🧭 TP4 – Dependency Injection (Overview)

### 🎯 General Objective
Separate the **data logic** from the **UI** by moving the sensor list into a dedicated **service**.  
Learn how to **register** and **inject** services using the built‑in Dependency Injection (DI) container.  
Make the service **asynchronous** to simulate real‑world delays and add a **loading indicator** to the dashboard.

### 🧠 Why Dependency Injection?
- **Separation of concerns** – UI (Blazor) and business logic (services) are independent.
- **Reusability** – the same service can be used in many pages.
- **Testability** – you can replace the real service with a mock for unit tests.
- **Flexibility** – swap implementations (e.g., from in‑memory list to a real database) without changing the page.


## 🔁 Core Concepts (MERN comparison)

| DI concept | React / Node equivalent |
|------------|-------------------------|
| Service class | A JavaScript module that fetches data (e.g., `sensorService.js`) |
| Interface (`ISensorService`) | TypeScript interface / contract |
| `AddScoped` | Registering a provider with a specific lifetime (per user circuit) |
| `@inject` | `import` + using a hook / context (e.g., `useContext`) |


## 📋 TP4 Activities (Teacher's Lab)

| Activity | What I did | What I learned |
|----------|------------|----------------|
| **1** | Created `SensorService` with an in‑memory list | Writing a plain C# data service |
| **2** | Defined `ISensorService` interface | Interface = contract; allows multiple implementations |
| **3** | Registered the service in `Program.cs` with `AddScoped` | DI container configuration |
| **4** | Injected `ISensorService` into `MyDashboard.razor` using `@inject` | Using a service inside a component |
| **5** | Made the service asynchronous (`GetSensorsAsync`) with `Task.Delay(2000)` | Simulate network latency |
| **6** | Updated the dashboard to use `OnInitializedAsync` and added a loading spinner | Async UI patterns |


## 🗺️ Flow Diagram (Without vs With DI)

### Before (TP3)
```
MyDashboard.razor
   └── hardcoded list of sensors (inside @code)
```

### After (TP4)
```
Program.cs (registers service)
       ↓
MyDashboard.razor → @inject ISensorService
       ↓
SensorService (provides data)
       ↓
MyDashboard.razor displays the data + loading spinner
```


## 📁 Project Structure (after TP4)

```
DashboardData/
├── Components/
│   ├── Layout/
│   │   ├── MainLayout.razor
│   │   └── NavMenu.razor
│   └── Pages/
│       ├── MyDashboard.razor      ← modified to use service
│       ├── Converter.razor
│       └── Logs.razor
├── Models/
│   └── SensorData.cs
├── Services/                       ← new folder
│   ├── ISensorService.cs           ← interface
│   └── SensorService.cs            ← implementation
├── Program.cs                      ← registration added
├── appsettings.json
└── wwwroot/
```


## 📂 Files in this branch

| File | Description |
|------|-------------|
| `DashboardData/Services/ISensorService.cs` | Interface declaring `GetSensorsAsync()`. |
| `DashboardData/Services/SensorService.cs` | Service with in‑memory list and `Task.Delay` simulation. |
| `DashboardData/Components/Pages/MyDashboard.razor` | Injected service, async loading, loading spinner. |
| `DashboardData/Program.cs` | Service registration (`AddScoped<ISensorService, SensorService>()`). |
| *(other files from TP3 are unchanged)* | Converter, Logs, models, etc. |


## ▶️ How to run

```bash
cd DashboardData
dotnet watch
```
Then open `https://localhost:5056/dashboard`


## 📸 Execution output

*I dont have Screenshots here – The dashboard looks the same as TP3, but now with a loading spinner and data from the service.*


## 🧠 What I learned

- ✅ How to create a **service** (plain C# class) and an **interface**.
- ✅ How to **register** the service in `Program.cs` (`AddScoped`).
- ✅ How to **inject** the service into a component using `@inject`.
- ✅ The difference between **synchronous** and **asynchronous** service methods.
- ✅ How to simulate a delay with `Task.Delay`.
- ✅ How to use `OnInitializedAsync` and add a **loading spinner** (`@if (isLoading)`).
- ✅ That the UI is now **decoupled** from the data source – we can later change the service to use a real database without touching the page.


## 🔗 Branch information

This code is stored in the **`tp4` branch** of the repository.  
It builds on the work from the `tp3` branch (the dashboard, converter, and logs are still there, but the main dashboard now uses DI and async).

---

**Copyright © 2025 safabelhouche – All rights reserved.**  
*This work is part of the .NET C# Programming course at Ecole Polytechnique de Sousse.*