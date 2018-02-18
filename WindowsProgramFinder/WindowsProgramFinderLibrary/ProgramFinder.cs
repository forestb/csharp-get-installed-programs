using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WindowsProgramFinderLibrary.Models;
using Microsoft.Win32;

namespace WindowsProgramFinderLibrary
{
    public class ProgramFinder
    {
        public static List<RegistryEntry> ListAll()
        {
            const string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            var registryEntries = new List<RegistryEntry>();

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                    {
                        if (subkey != null)
                        {
                            var displayName = (string)subkey.GetValue("DisplayName");
                            var displayVersion = (string)subkey.GetValue("DisplayVersion");

                            if (displayName != null)
                            {
                                registryEntries.Add(new RegistryEntry()
                                {
                                    DisplayName = displayName,
                                    DisplayNameLowered = displayName.ToLower(CultureInfo.InvariantCulture),
                                    DisplayVersion = displayVersion
                                });
                            }
                        }
                    }
                }
            }

            return registryEntries;
        }

        public static RegistryEntry FilterByDisplayName(string displayName)
        {
            return ListAll().FirstOrDefault(x =>
                string.Equals(displayName, x.DisplayName, StringComparison.InvariantCultureIgnoreCase));
        }

        public static List<RegistryEntry> FilterByDisplayNameContains(string filter)
        {
            return ListAll()
                .Where(x => x.DisplayName.Contains(filter)).ToList();
        }

        public static List<RegistryEntry> FilterByDisplayNameContainsIgnoreCase(string filter)
        {
            return ListAll()
                .Where(x => x.DisplayNameLowered.Contains(filter.ToLower(CultureInfo.InvariantCulture))).ToList();
        }
    }
}
