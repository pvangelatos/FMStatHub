using FMStatHub.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Analytics
{
    internal class CompositeScoreCalculator
    {
        public void CalculateAll(List<Player> players)
        {
            foreach (var player in players)
            {
                player.CompositeScores.Clear();

                foreach (var role in RoleWeights.Profiles)
                {
                    double score = Calculate(player, role.Value);
                    player.CompositeScores[role.Key] = Math.Round(score, 1);
                }
            }
        }

        private double Calculate(Player player, Dictionary<string, double> weights)
        {
            // Μετατρέπουμε τα attributes σε Dictionary για εύκολη αναζήτηση
            var attrs = GetAttributeMap(player.Attributes);

            double totalScore = 0;
            double totalWeight = 0;

            foreach (var weight in weights)
            {
                if (attrs.TryGetValue(weight.Key, out int attrValue))
                {
                    totalScore += attrValue * weight.Value;
                    totalWeight += weight.Value;
                }
            }

            // Αν δεν βρέθηκαν attributes, επέστρεψε 0
            if (totalWeight == 0) return 0;

            // Κανονικοποίηση σε κλίμακα 0-100
            return (totalScore / totalWeight) / 20.0 * 100;
        }

        private Dictionary<string, int> GetAttributeMap(PlayerAttributes a)
        {
            return new Dictionary<string, int>
            {
                // Technical
                ["Corners"] = a.Corners,
                ["Crossing"] = a.Crossing,
                ["Dribbling"] = a.Dribbling,
                ["Finishing"] = a.Finishing,
                ["FirstTouch"] = a.FirstTouch,
                ["Freekicks"] = a.Freekicks,
                ["Heading"] = a.Heading,
                ["LongShots"] = a.LongShots,
                ["LongThrows"] = a.LongThrows,
                ["Marking"] = a.Marking,
                ["Passing"] = a.Passing,
                ["PenaltyTaking"] = a.PenaltyTaking,
                ["Tackling"] = a.Tackling,
                ["Technique"] = a.Technique,
                // Mental
                ["Aggression"] = a.Aggression,
                ["Anticipation"] = a.Anticipation,
                ["Bravery"] = a.Bravery,
                ["Composure"] = a.Composure,
                ["Concentration"] = a.Concentration,
                ["Decisions"] = a.Decisions,
                ["Determination"] = a.Determination,
                ["Flair"] = a.Flair,
                ["Leadership"] = a.Leadership,
                ["OffTheBall"] = a.OffTheBall,
                ["Positioning"] = a.Positioning,
                ["Teamwork"] = a.Teamwork,
                ["Vision"] = a.Vision,
                ["WorkRate"] = a.WorkRate,
                // Physical
                ["Acceleration"] = a.Acceleration,
                ["Agility"] = a.Agility,
                ["Balance"] = a.Balance,
                ["JumpingReach"] = a.JumpingReach,
                ["NaturalFitness"] = a.NaturalFitness,
                ["Pace"] = a.Pace,
                ["Stamina"] = a.Stamina,
                ["Strength"] = a.Strength,
            };
        }
    }
}
