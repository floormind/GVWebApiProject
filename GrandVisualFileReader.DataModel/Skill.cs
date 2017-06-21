using Newtonsoft.Json;

namespace GrandVisualFileReader.DataModel
{
    public class Skill
    {
        [JsonProperty (PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty (PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }
    }
}
