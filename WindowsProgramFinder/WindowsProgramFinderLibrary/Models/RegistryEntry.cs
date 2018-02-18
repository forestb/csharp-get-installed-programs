using Newtonsoft.Json;

namespace WindowsProgramFinderLibrary.Models
{
    public class RegistryEntry
    {
        public string DisplayName { get; set; }

        public string DisplayNameLowered { get; set; }

        public string DisplayVersion { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
