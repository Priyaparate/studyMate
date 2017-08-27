using System.ComponentModel.DataAnnotations;

namespace StudyMateLibrary.Enities
{
    public class TestType : Entity
    {
        [Required]
        public string TestTypeText { get; set; }

        public string Description { get; set; }
    }
}