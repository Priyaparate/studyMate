using System.ComponentModel.DataAnnotations;

namespace StudyMateLibrary.Enities
{
    public class Subject : Entity
    {
        public string Description { get; set; }

        [Required]
        public string SubjectText { get; set; }
    }
}