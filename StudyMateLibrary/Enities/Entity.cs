using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using StudyMateLibrary.Attributes;

namespace StudyMateLibrary.Enities
{
    public abstract class Entity
    {
        [PrimaryKey]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
    }
}