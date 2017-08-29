using StudyMateLibrary.Attributes;

namespace StudyMateLibrary.Enities
{
    public class State : Entity
    {
        [ForeignKey(typeof(Country))]
        public string CountryId { get; set; }

        public string StateName { get; set; }
    }
}