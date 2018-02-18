using System;

namespace WindowsProgramFinderApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WindowsProgramFinderLibrary.ProgramFinder.GetRegistryEntries();

            WindowsProgramFinderLibrary.ProgramFinder.GetByDisplayName("Microsoft");

            WindowsProgramFinderLibrary.ProgramFinder
                .FilterByDisplayNameContainsIgnoreCase("microsoft").ForEach(Console.WriteLine);
        }
    }
}
