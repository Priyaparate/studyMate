using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudyMateLibrary.Enities
{
    public class User : Entity
    {
        public Guid GuidId { get; set; }

        [BsonRequired]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Address Address { get; set; }

        [Required]
        [StringLength(maximumLength: 15, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string MobileNo { get; set; }

        public string ProfilePhoto { get; set; }

        [Required]
        [BsonIgnoreIfDefault]
        public int RoleId { get; set; }
    }
}