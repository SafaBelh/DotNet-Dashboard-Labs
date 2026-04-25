namespace DataLab1;

public class Sensor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Value { get; set; }

    public Sensor(int id, string name, string type)
    {
        Id = id;
        Name = name;
        Type = type;
        Value = 0.0;
    }

    public void UpdateValue(double newValue)
    {
        if (newValue < -50 || newValue > 100)
        {
            Console.WriteLine($"[ALERTE] Valeur aberrante pour {Name} : {newValue}");
            return;
        }
        Value = newValue;
    }
}