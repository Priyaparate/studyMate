using StudyMateLibrary.Attributes;

namespace StudyMateLibrary.Enities
{
    public class City : Entity
    {
        [ForeignKey(typeof(Country))]
        public string CountryId { get; set; }
        [ForeignKey(typeof(State))]
        public int StateId { get; set; }

        public string CityName { get; set; }
    }
}