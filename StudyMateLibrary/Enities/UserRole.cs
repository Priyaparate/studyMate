using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Domains;

namespace StudyMateLibrary.Enities
{
    public class UserRole :Entity
    {
        
        public string Role { get; set; }

        public string RoleDescription { get; set; }
    }
}