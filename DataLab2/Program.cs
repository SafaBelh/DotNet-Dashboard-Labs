using System.Linq;

// ========== 🟣🟣🟣 CREATING LOCAL FUNCTION THAT RETURNS FAKE TRANSACTIONS 🟣🟣🟣 ==========

Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 GENERTAING FAKE DATA 🟣🟣🟣🟣🟣🟣");
List<Transaction> GetFakeData()
{
    return new List<Transaction>
    {
        new(1, "Hardware", 1200.50, new DateTime(2023, 1, 10), "France"),
        new(2, "Software", 300.00, new DateTime(2023, 1, 12), "USA"),
        new(3, "Service", 150.00, new DateTime(2023, 1, 15), "France"),
        new(4, "Hardware", 80.00, new DateTime(2023, 2, 1), "Allemagne"),
        new(5, "Hardware", 2500.00, new DateTime(2023, 2, 5), "USA"),
        new(6, "Software", 50.00, new DateTime(2023, 2, 7), "France"),
        new(7, "Service", 450.00, new DateTime(2023, 2, 11), "Espagne"),
    };
}

// 🟣 LOADING FAKE DATA INTO VARIABLE //
var transactions = GetFakeData();
Console.WriteLine($"\n✅ Chargement terminé : {transactions.Count} transactions.\n");

// ========== 🟣🟣🟣 ACTIVITÉ 2 : FILTRAGE (WHERE) 🟣🟣🟣 ==========

Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 FILTRAGE 🟣🟣🟣🟣🟣🟣");
Console.WriteLine("\n🔍 Filtrage (France > 100€) 🔍\n");
var resultatsFrance = transactions.Where(t => t.Pays == "France" && t.Montant > 100);
foreach (var t in resultatsFrance)
    Console.WriteLine($"🇫🇷 {t}");

// ========== 🟣🟣🟣 ACTIVITÉ 3 : PROJECTION ET TRI 🟣🟣🟣 ==========

Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 PROJECTION ET TRI 🟣🟣🟣🟣🟣🟣");
Console.WriteLine("\n📊 Tri et Projection (du plus cher au moins cher) 📊\n");
var topVentes = transactions
    .OrderByDescending(t => t.Montant)
    .Select(t => new { t.Categorie, Prix = t.Montant + " €" });
foreach (var item in topVentes)
    Console.WriteLine($"💰 Vente : {item.Categorie} → {item.Prix}");

// ========== 🟣🟣🟣 ACTIVITÉ 4 : AGRÉGATIONS 🟣🟣🟣 ==========
Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 AGRÉGATIONS 🟣🟣🟣🟣🟣🟣");
Console.WriteLine("\n📈 KPIs Globaux 📈\n");
double totalCA = transactions.Sum(t => t.Montant);
double moyenne = transactions.Average(t => t.Montant);
double maxVente = transactions.Max(t => t.Montant);
var plusGrosseVente = transactions.FirstOrDefault(t => t.Montant == maxVente);
Console.WriteLine($"💶 Total CA : {totalCA} €");
Console.WriteLine($"📊 Panier moyen : {moyenne:F2} €");
Console.WriteLine($"🔥 Record détenu par : {plusGrosseVente?.Pays} ({plusGrosseVente?.Categorie}) – {maxVente} €");



// ========== 🟣🟣🟣 ACTIVITÉ 5 : GROUP BY 🟣🟣🟣 ==========
Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 GROUPING BY 🟣🟣🟣🟣🟣🟣");

Console.WriteLine("\n🌍 CA par Pays (GroupBy) 🌍\n");
var analysePays = transactions
    .GroupBy(t => t.Pays)
    .Select(g => new
    {
        Pays = g.Key,
        Total = g.Sum(t => t.Montant),
        Nombre = g.Count()
    })
    .OrderByDescending(x => x.Total);
foreach (var stat in analysePays)
    Console.WriteLine($"🏷️  '{stat.Pays}' : {stat.Total} € ({stat.Nombre} ventes)");





// ========== 🟣🟣🟣 EXERCICE D'APPLICATION : PIPELINE CSV 🟣🟣🟣 ==========
Console.WriteLine("\n\n🟣🟣🟣🟣🟣🟣 EXERCICE D'APPLICATION : PIPELINE CSV  🟣🟣🟣🟣🟣🟣");
Console.WriteLine("\n🎯 Top 3 produits High-Tech (prix < 1000) 🎯\n");
string rawCsv = "Laptop,900;Souris,25;Clavier,45;Ecran,150;CleUSB,10;Webcam,3000;Cable,5";

var top3 = rawCsv
    .Split(';')
    .Select(part =>
    {
        var elements = part.Split(',');
        return new { Nom = elements[0], Prix = int.Parse(elements[1]) };
    })
    .Where(p => p.Prix <= 1000)
    .OrderBy(p => p.Prix)
    .Take(3);

foreach (var p in top3)
    Console.WriteLine($"🏆 {p.Nom} : {p.Prix} €");

// ========== 🟣🟣🟣 RECORD DEFINITION 🟣🟣🟣 ==========
public record Transaction(int Id, string Categorie, double Montant, DateTime Date, string Pays);