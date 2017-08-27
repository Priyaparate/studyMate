using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudyMateLibrary.Enities
{
    public class Question : Entity
    {
        [Required]
        [BsonRequired]
        public string QuestionText { get; set; }

        [Required]
        [BsonRequired]
        public List<Options> Options { get; set; }

        [Required]
        [ForeignKey(typeof(Test))]
        public int TestId { get; set; }
    }
}