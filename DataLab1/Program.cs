using DataLab1;


// 🟣🟣🟣🟣🟣🟣🟣🟣 LAB ACTIVITY 🟣🟣🟣🟣🟣🟣🟣🟣 //

Console.WriteLine("\n🟣🟣🟣🟣🟣🟣🟣🟣 LAB ACTIVITY 🟣🟣🟣🟣🟣🟣🟣🟣\n");

List<Sensor> fleet = new List<Sensor>();
fleet.Add(new Sensor(1, "Sonde_Nord", "Temp"));
fleet.Add(new Sensor(2, "Sonde_Sud", "Temp"));
fleet.Add(new Sensor(3, "Sonde_Ext", "Co2"));

Random rnd = new Random();

foreach (var s in fleet)
{
    double randomVal = rnd.Next(100, 400) / 10.0;

    s.UpdateValue(randomVal);

    Console.WriteLine($"→ ID: {s.Id}\t Nom: {s.Name}\t Val: {s.Value}");
}
Console.WriteLine("\n( ✅ Activité du Tp terminée )\n");

// 🟣🟣🟣🟣🟣🟣🟣🟣 LAB EXERCICE 1 🟣🟣🟣🟣🟣🟣🟣🟣 //
Exercice1 ex1 = new Exercice1();
List<Sensor> allSensors = ex1.Run();   

// 🟣🟣🟣🟣🟣🟣🟣🟣 LAB EXERCICE 2 🟣🟣🟣🟣🟣🟣🟣🟣 //
Exercice2 ex2 = new Exercice2();
ex2.Run(allSensors);  