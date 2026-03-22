# ⚽ FM StatHub

A Football Manager scouting report analyzer built with C# (.NET 8).  
Parses HTML exports from Football Manager, calculates composite role scores,  
and exports results to CSV for further analysis.

---

## 🚀 Features

- Parses official Football Manager HTML scouting exports
- Calculates composite scores for 5 tactical roles
- Rankings per role using weighted attribute profiles
- CSV export compatible with Excel
- Color-coded console output with file logging

---

## 🛠️ Tech Stack

- C# / .NET 8
- HtmlAgilityPack (HTML parsing)
- LINQ (data querying & sorting)
- File I/O (CSV export, logging)

---

## 📁 Project Structure
```
FMStatHub/
├── Analytics/        # Composite score calculation & role weight profiles
├── Exceptions/       # Custom exception handling
├── Export/           # CSV export logic
├── Models/           # Player & PlayerAttributes data models
├── Parsers/          # HTML scouting report parser
├── Utilities/        # Logger
└── Program.cs        # Entry point & CLI interface
```

---

## ▶️ How to Use

**1. Export your scouting report from Football Manager**
```
In-game: Scouting → Select players → Export as HTML
```

**2. Run the application**
```
dotnet run
```

**3. Enter the path to your HTML file**
```
Δώσε το path του scouting report: C:\FMData\scouting_report.html
```

**4. View rankings and optionally export to CSV**

---

## 📊 Role Profiles

| Role | Key Attributes |
|---|---|
| Advanced Playmaker | Passing, Vision, Decisions, Technique |
| Ball Winning Mid | Tackling, Marking, Stamina, Aggression |
| Striker | Finishing, Off The Ball, Composure, Pace |
| Centre Back | Marking, Tackling, Heading, Positioning |
| Winger | Pace, Dribbling, Crossing, Acceleration |

---

## 💡 Sample Output
```
🏆 Top players for role: AdvancedPlaymaker
--------------------------------------------------
  Pedri                MC    89.2
  Rodri                DM    82.5
  Lamine Yamal         AML   80.1
  Erling Haaland       ST    71.3
  Virgil van Dijk      DC    65.4
```

---

## 🗺️ Roadmap

- [ ] Add more tactical roles (Full Back, Enganche, Libero...)
- [ ] WinForms or Web UI
- [ ] SQLite persistence for historical comparisons
- [ ] Support for real FM save file parsing (.fmf)

---

## 👤 Author

Panagiotis — Career changer from Military Logistics to Software Development.  
Built as part of a C# learning portfolio.

