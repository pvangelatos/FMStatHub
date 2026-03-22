using System;
using System.Collections.Generic;
using System.Text;

namespace FMStatHub.Models
{
    internal class PlayerAttributes
    {
        // --- Technical ---
        public int Corners { get; set; }
        public int Crossing { get; set; }
        public int Dribbling { get; set; }
        public int Finishing { get; set; }
        public int FirstTouch { get; set; }
        public int Freekicks { get; set; }
        public int Heading { get; set; }
        public int LongShots { get; set; }
        public int LongThrows { get; set; }
        public int Marking { get; set; }
        public int Passing { get; set; }
        public int PenaltyTaking { get; set; }
        public int Tackling { get; set; }
        public int Technique { get; set; }

        // --- Mental ---
        public int Aggression { get; set; }
        public int Anticipation { get; set; }
        public int Bravery { get; set; }
        public int Composure { get; set; }
        public int Concentration { get; set; }
        public int Decisions { get; set; }
        public int Determination { get; set; }
        public int Flair { get; set; }
        public int Leadership { get; set; }
        public int OffTheBall { get; set; }
        public int Positioning { get; set; }
        public int Teamwork { get; set; }
        public int Vision { get; set; }
        public int WorkRate { get; set; }

        // --- Physical ---
        public int Acceleration { get; set; }
        public int Agility { get; set; }
        public int Balance { get; set; }
        public int JumpingReach { get; set; }
        public int NaturalFitness { get; set; }
        public int Pace { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
    }
}
