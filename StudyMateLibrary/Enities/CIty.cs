using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Domains;

namespace StudyMateLibrary.Enities
{
    public class City:Entity
    {
        public int StateId { get; set; }

        public string CityName { get; set; }
    }
}