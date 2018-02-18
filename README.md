# Windows Program Finder
A simple library/app for querying installed programs on a Windows system.

# Installation
TODO: Will be turning this into a NuGet package soon.

# Usage
Get a list of the names/versions of all programs installed on Windows:

```csharp
var result =
    WindowsProgramFinderLibrary.ProgramFinder.ListAll();
```

Get a list of all programs installed that contain the word "Microsoft" (*note: case does not matter*):

```csharp
var result = 
    WindowsProgramFinderLibrary.ProgramFinder.FilterByDisplayNameContainsIgnoreCase("microsoft");
```