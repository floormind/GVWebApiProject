using System.Collections.Generic;
using Newtonsoft.Json;

namespace GrandVisualFileReader.DataModel
{
    public class Developer
    {
        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [JsonProperty(PropertyName = "skills")]
        public IList<Skill> Skills { get; set; }
    }
}