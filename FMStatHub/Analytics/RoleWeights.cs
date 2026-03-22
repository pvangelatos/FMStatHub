using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Analytics
{
    internal class RoleWeights
    {
        // Κάθε ρόλος έχει ένα Dictionary με attribute → βάρος (weight)
        // Τα weights πρέπει να αθροίζουν 1.0 (100%)
        public static readonly Dictionary<string, Dictionary<string, double>> Profiles = new()
        {
            ["AdvancedPlaymaker"] = new()
            {
                ["Passing"] = 0.20,
                ["Vision"] = 0.20,
                ["Decisions"] = 0.15,
                ["Technique"] = 0.15,
                ["FirstTouch"] = 0.10,
                ["Composure"] = 0.10,
                ["OffTheBall"] = 0.10,
            },

            ["BallWinningMid"] = new()
            {
                ["Tackling"] = 0.25,
                ["Marking"] = 0.15,
                ["Aggression"] = 0.15,
                ["Stamina"] = 0.15,
                ["Strength"] = 0.10,
                ["Anticipation"] = 0.10,
                ["WorkRate"] = 0.10,
            },

            ["Striker"] = new()
            {
                ["Finishing"] = 0.25,
                ["OffTheBall"] = 0.20,
                ["Composure"] = 0.15,
                ["Pace"] = 0.15,
                ["Heading"] = 0.10,
                ["Decisions"] = 0.10,
                ["Strength"] = 0.05,
            },

            ["CentreBack"] = new()
            {
                ["Marking"] = 0.20,
                ["Tackling"] = 0.20,
                ["Positioning"] = 0.15,
                ["Heading"] = 0.15,
                ["Strength"] = 0.10,
                ["Concentration"] = 0.10,
                ["Bravery"] = 0.10,
            },

            ["Winger"] = new()
            {
                ["Pace"] = 0.20,
                ["Dribbling"] = 0.20,
                ["Crossing"] = 0.15,
                ["Acceleration"] = 0.15,
                ["Agility"] = 0.10,
                ["OffTheBall"] = 0.10,
                ["Technique"] = 0.10,
            },
        };
    }
}
