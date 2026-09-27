# Readify

C# practice work for a Readify competency screen. ConsoleTest classifies triangles, pulls the nth item from the tail of a list, and reverses words while keeping spaces. App is an empty WinForms shell with a typed Access Issues dataset. The folder also keeps the interview Word docs (behavioural questions, code puzzles including SharePoint, skills matrix).

**Source last updated:** 2013-05-16  
**Language:** C#  
**Target:** .NET 3.5 (ConsoleTest) / .NET 4.5 (App)  
**Output:** console exe + WinForms stub, plus interview documents

## Solution structure

| Project | Language | Type | Purpose |
|---------|----------|------|---------|
| `Test/ConsoleTest` | C# | console exe (.NET 3.5) | Triangle type, nth-from-tail, reverse-words puzzles |
| `Test/App` | C# | WinForms exe (.NET 4.5) | Empty form bound to an Access Issues dataset |
| Word docs (folder root) | - | documents | Readify interview / skills materials |

## How to open

Open `Test/Test.sln` in Visual Studio 2012 or later. Run ConsoleTest for the puzzles. Copy `App.config.example` and `Settings.settings.example` to drop the `.example` suffix and point the Access path at a local `Issues.accdb` before building App.

## Requirements

- Visual Studio 2012, .NET Framework 3.5, .NET Framework 4.5

## Attribution and provenance

Working copy from my Historical Dev folder.

From Dave Robinson's Historical Dev archive (OneDrive folder `Readify`). Assembly copyright 2013. Interview documents originated with Readify; they are kept here as Dave's working copy. Connection strings that pointed at a personal Documents path were replaced with `*.example` files.

## License

MIT License. Copyright (c) 2026 VaderConsulting. Interview documents remain third-party; see `THIRD_PARTY_NOTICES.md`.
