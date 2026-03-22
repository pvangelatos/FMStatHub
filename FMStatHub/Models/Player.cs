using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Models
{
    internal class Player
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Club { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public decimal Wage { get; set; }
        public PlayerAttributes Attributes { get; set; } = new PlayerAttributes();
        public Dictionary<string, double> CompositeScores { get; set; } = new();

    }
}
