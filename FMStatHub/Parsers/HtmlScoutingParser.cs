using HtmlAgilityPack;
using FMStatHub.Models;
using FMStatHub.Exceptions;
using FMStatHub.Utilities;
using System;
using System.Collections.Generic;
using System.IO;



namespace FMStatHub.Parsers
{
    internal class HtmlScoutingParser
    {
        public List<Player> Parse(string filePath)
        {
            if (!File.Exists(filePath))
                throw new AppException($"Το αρχείο δεν βρέθηκε: {filePath}");

            var players = new List<Player>();

            try
            {
                var doc = new HtmlDocument();
                doc.Load(filePath, System.Text.Encoding.UTF8);

                var table = doc.DocumentNode.SelectSingleNode("//table[@id='players']");
                if (table == null)
                    throw new AppException("Δεν βρέθηκε πίνακας με id='players'. Έλεγξε τη δομή του HTML.");

                var rows = table.SelectNodes(".//tbody/tr");
                if (rows == null)
                {
                    Logger.Warning("Δεν βρέθηκαν γραμμές παικτών στον πίνακα.");
                    return players;
                }

                int skipped = 0;

                foreach (var row in rows)
                {
                    try
                    {
                        var cells = row.SelectNodes("td");
                        if (cells == null || cells.Count < 43)
                        {
                            skipped++;
                            continue;
                        }

                        var player = new Player
                        {
                            Name        = GetString(cells, 0),
                            Age         = GetInt(cells, 1),
                            Club        = GetString(cells, 2),
                            Nationality = GetString(cells, 3),
                            Position    = GetString(cells, 4),
                            Value       = GetDecimal(cells, 5),
                            Wage        = GetDecimal(cells, 6),

                            Attributes = new PlayerAttributes
                            {
                                Corners         = GetInt(cells, 7),
                                Crossing        = GetInt(cells, 8),
                                Dribbling       = GetInt(cells, 9),
                                Finishing       = GetInt(cells, 10),
                                FirstTouch      = GetInt(cells, 11),
                                Freekicks       = GetInt(cells, 12),
                                Heading         = GetInt(cells, 13),
                                LongShots       = GetInt(cells, 14),
                                LongThrows      = GetInt(cells, 15),
                                Marking         = GetInt(cells, 16),
                                Passing         = GetInt(cells, 17),
                                PenaltyTaking   = GetInt(cells, 18),
                                Tackling        = GetInt(cells, 19),
                                Technique       = GetInt(cells, 20),
                                Aggression      = GetInt(cells, 21),
                                Anticipation    = GetInt(cells, 22),
                                Bravery         = GetInt(cells, 23),
                                Composure       = GetInt(cells, 24),
                                Concentration   = GetInt(cells, 25),
                                Decisions       = GetInt(cells, 26),
                                Determination   = GetInt(cells, 27),
                                Flair           = GetInt(cells, 28),
                                Leadership      = GetInt(cells, 29),
                                OffTheBall      = GetInt(cells, 30),
                                Positioning     = GetInt(cells, 31),
                                Teamwork        = GetInt(cells, 32),
                                Vision          = GetInt(cells, 33),
                                WorkRate        = GetInt(cells, 34),
                                Acceleration    = GetInt(cells, 35),
                                Agility         = GetInt(cells, 36),
                                Balance         = GetInt(cells, 37),
                                JumpingReach    = GetInt(cells, 38),
                                NaturalFitness  = GetInt(cells, 39),
                                Pace            = GetInt(cells, 40),
                                Stamina         = GetInt(cells, 41),
                                Strength        = GetInt(cells, 42),
                            }
                        };

                        players.Add(player);
                    }
                    catch (Exception ex)
                    {
                        skipped++;
                        Logger.Warning($"Παράλειψη γραμμής λόγω σφάλματος: {ex.Message}");
                    }
                }

                if (skipped > 0)
                    Logger.Warning($"Παραλείφθηκαν {skipped} γραμμές με ελλιπή δεδομένα.");

                return players;
            }
            catch (AppException)
            {
                throw; // Τα δικά μας exceptions τα αφήνουμε να ανέβουν
            }
            catch (Exception ex)
            {
                throw new AppException("Σφάλμα κατά την ανάλυση του αρχείου.", ex);
            }
        }

        private string GetString(HtmlNodeCollection cells, int index)
            => cells[index].InnerText.Trim();

        private int GetInt(HtmlNodeCollection cells, int index)
        {
            var text = cells[index].InnerText.Trim();
            return int.TryParse(text, out int result) ? result : 0;
        }

        private decimal GetDecimal(HtmlNodeCollection cells, int index)
        {
            var text = cells[index].InnerText.Trim();
            return decimal.TryParse(text, out decimal result) ? result : 0m;
        }
    }
}