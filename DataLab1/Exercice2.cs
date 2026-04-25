using System;
using System.Collections.Generic;

namespace DataLab1;

public class Exercice2
{
    public void Run(List<Sensor> sensors)
    {
        Console.WriteLine("\n🟣🟣🟣🟣🟣🟣🟣🟣 EXERCICE 2 : Statistiques des capteurs 🟣🟣🟣🟣🟣🟣🟣🟣\n");

        if (sensors == null || sensors.Count == 0)
        {
            Console.WriteLine("Aucun capteur à analyser.");
            return;
        }

        double sum = 0;
        double maxVal = -1000;
        string maxSensorName = "";
        int co2AlertCount = 0;

        foreach (Sensor s in sensors)
        {
            sum += s.Value;

            if (s.Value > maxVal)
            {
                maxVal = s.Value;
                maxSensorName = s.Name;
            }

            if (s.Type == "CO2" && s.Value > 80)
            {
                co2AlertCount++;
            }
        }

        double average = sum / sensors.Count;

        Console.WriteLine($"📊 Nombre total de capteurs : {sensors.Count}");
        Console.WriteLine($"📈 Moyenne globale : {average:F2}");
        Console.WriteLine($"🔥 Valeur maximale : {maxVal} (capteur : {maxSensorName})");
        Console.WriteLine($"💨 Capteurs CO₂ avec valeur > 80 : {co2AlertCount}");

        Console.WriteLine("\n( ✅ Exercice 2 terminé)\n");
    }
}