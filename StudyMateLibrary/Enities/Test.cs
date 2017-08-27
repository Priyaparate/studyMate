using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Attributes;
using StudyMateLibrary.Domains;
using StudyMateLibrary.Enities;
using System.ComponentModel.DataAnnotations;

namespace StudyMateLibrary.Enities
{
    public class Test : Entity
    {
        //[BsonId]
        //public int TestId { get; set; }

        [Required]
        public string TestName { get; set; }

        [Required]
        [ForeignKey(typeof(TestCategory))]
        public string TestCategory { get; set; }

        [Required]
        [ForeignKey(typeof(Subject))]
        public string SubjectId { get; set; }

        [Required]

        [ForeignKey(typeof(TestType))]
        public string TestType { get; set; }
    }
}