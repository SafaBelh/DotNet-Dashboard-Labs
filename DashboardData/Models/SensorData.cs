using System.ComponentModel.DataAnnotations;

namespace DashboardData.Models;

public class SensorData
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom est obligatoire")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom doit contenir entre 3 et 50 caractères")]
    public string Name { get; set; } = "";

    public string Type { get; set; } = "Temperature";

    [Range(-50, 150, ErrorMessage = "La valeur doit être comprise entre -50 et 150")]
    public double Value { get; set; }

    public DateTime LastUpdate { get; set; } = DateTime.Now;

    [Range(1, int.MaxValue, ErrorMessage = "Veuillez sélectionner un emplacement valide")]
    public int LocationId { get; set; }
    public Location Location { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}

public class LocationStat
{
    public string LocationName { get; set; } = "";
    public double AverageValue { get; set; }
}

public class LocationCountStat
{
    public string LocationName { get; set; } = "";
    public int Count { get; set; }
}