using System;
using System.Collections.Generic;

namespace DataLab1;

public class Exercice1
{
    public List<Sensor> Run()
    {
        Console.WriteLine("\n🟣🟣🟣🟣🟣🟣🟣🟣 EXERCICE 1 : Génération de 100 capteurs 🟣🟣🟣🟣🟣🟣🟣🟣\n");

        List<Sensor> sensors = new List<Sensor>();
        Random random = new Random();
        string[] types = { "Temperature", "Humidity", "CO2" };

        for (int i = 1; i <= 100; i++)
        {
            string randomType = types[random.Next(types.Length)];
            Sensor sensor = new Sensor(i, $"Sensor_{i}", randomType);
            double randomValue = random.Next(0, 101);
            sensor.UpdateValue(randomValue);
            sensors.Add(sensor);
        }

        Console.WriteLine($"Génération terminée : {sensors.Count} capteurs.\n");

        Console.WriteLine("Aperçu des 10 premiers capteurs :");
        for (int i = 0; i < 10; i++)
        {
            Sensor s = sensors[i];
            Console.WriteLine($"ID: {s.Id}, Nom: {s.Name}, Type: {s.Type}, Valeur: {s.Value}");
        }

        Console.WriteLine("\n( ✅ Exercice 1 terminé )\n");

        return sensors;
    }
}