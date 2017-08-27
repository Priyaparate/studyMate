using StudyMateLibrary.Attributes;

namespace StudyMateLibrary.Enities
{
    public class Options : Entity
    {
        public bool IsMultiple { get; set; }
        public string OptionText { get; set; }

        [ForeignKey(typeof(Question))]
        public string QuetionId { get; set; }
    }
}