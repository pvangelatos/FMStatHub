using FMStatHub.Analytics;
using FMStatHub.Exceptions;
using FMStatHub.Export;
using FMStatHub.Parsers;
using FMStatHub.Utilities;

namespace FMStatHub
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --- Header ---
            Console.WriteLine("=================================");
            Console.WriteLine("       FM StatHub v1.0          ");
            Console.WriteLine("=================================\n");

            try
            {
                // --- Input ---
                Console.Write("Δώσε το path του scouting report: ");
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    throw new AppException("Δεν δόθηκε path αρχείου.");

                // --- Parsing ---
                Logger.Info("Φόρτωση παικτών...");
                var parser = new HtmlScoutingParser();
                var players = parser.Parse(input);

                if (players.Count == 0)
                    throw new AppException("Δεν βρέθηκαν παίκτες στο αρχείο.");

                Logger.Success($"Φορτώθηκαν {players.Count} παίκτες.");

                // --- Analytics ---
                Logger.Info("Υπολογισμός composite scores...");
                var calculator = new CompositeScoreCalculator();
                calculator.CalculateAll(players);
                Logger.Success("Scores υπολογίστηκαν.");

                // --- Εμφάνιση ---
                Console.WriteLine();
                var roles = new[] { "AdvancedPlaymaker", "BallWinningMid", "Striker", "CentreBack", "Winger" };

                foreach (var role in roles)
                {
                    Console.WriteLine($"🏆 Top παίκτες για ρόλο: {role}");
                    Console.WriteLine(new string('-', 50));

                    var ranked = players
                        .OrderByDescending(p => p.CompositeScores.GetValueOrDefault(role))
                        .ToList();

                    foreach (var player in ranked)
                    {
                        double score = player.CompositeScores.GetValueOrDefault(role);
                        Console.WriteLine($"  {player.Name,-20} {player.Position,-5} {score,6:F1}");
                    }

                    Console.WriteLine();
                }

                // --- Export ---
                Console.Write("Εξαγωγή σε CSV; (y/n): ");
                string? exportChoice = Console.ReadLine();

                if (exportChoice?.ToLower() == "y")
                {
                    Console.Write("Path αποθήκευσης (π.χ. C:\\FMData\\results.csv): ");
                    string? exportPath = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(exportPath))
                        throw new AppException("Μη έγκυρο path εξαγωγής.");

                    var exporter = new CsvExporter();
                    exporter.Export(players, exportPath);
                    Logger.Success($"Αρχείο αποθηκεύτηκε: {exportPath}");
                }
            }
            catch (AppException ex)
            {
                Logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error($"Απροσδόκητο σφάλμα: {ex.Message}");
            }

            Console.WriteLine("\nΠάτα Enter για έξοδο...");
            Console.ReadLine();
        }
    }
}
