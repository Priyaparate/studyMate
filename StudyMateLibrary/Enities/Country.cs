using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Domains;

namespace StudyMateLibrary.Enities
{
    public class Country :Entity
    {
     
        public string CountryName { get; set; }
    }
}