using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Attributes;
using StudyMateLibrary.Domains;

namespace StudyMateLibrary.Enities
{
    public class State:Entity
    {
        [ForeignKey(typeof(Country))]
        public string CountryId { get; set; }

        public string StateName { get; set; }
    }
}