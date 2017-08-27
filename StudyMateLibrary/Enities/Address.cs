using StudyMateLibrary.Attributes;

namespace StudyMateLibrary.Enities
{
    public class Address
    {
        public string currentAddress { get; set; }

        public int PinCode { get; set; }

        [ForeignKey(typeof(City))]
        public int CityId { get; set; }

        [ForeignKey(typeof(Country))]
        public int ContryId { get; set; }

        [ForeignKey(typeof(State))]
        public int StateId { get; set; }
    }
}