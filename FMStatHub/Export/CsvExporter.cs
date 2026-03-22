using FMStatHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Export
{
    internal class CsvExporter
    {
        public void Export(List<Player> players, string outputPath)
        {
            var lines = new List<string>();

            // --- Header ---
            var roles = players
                .SelectMany(p => p.CompositeScores.Keys)
                .Distinct()
                .OrderBy(r => r)
                .ToList();

            var header = new List<string>
            {
                "Name", "Age", "Club", "Nationality", "Position",
                "Value", "Wage"
            };
            header.AddRange(roles);
            lines.Add(string.Join(",", header));

            // --- Rows ---
            foreach (var player in players)
            {
                var row = new List<string>
                {
                    Escape(player.Name),
                    player.Age.ToString(),
                    Escape(player.Club),
                    Escape(player.Nationality),
                    Escape(player.Position),
                    player.Value.ToString(),
                    player.Wage.ToString()
                };

                foreach (var role in roles)
                {
                    double score = player.CompositeScores.GetValueOrDefault(role);
                    row.Add(score.ToString("F1"));
                }

                lines.Add(string.Join(",", row));
            }

            // --- Εγγραφή αρχείου ---
            File.WriteAllLines(outputPath, lines, System.Text.Encoding.UTF8);
            Console.WriteLine($"✓ Export ολοκληρώθηκε: {outputPath}");
        }

        // Αν η τιμή περιέχει κόμμα ή εισαγωγικά, τη βάζουμε σε quotes
        private string Escape(string value)
        {
            if (value.Contains(',') || value.Contains('"'))
                return $"\"{value.Replace("\"", "\"\"")}\"";
            return value;
        }
    }
}
