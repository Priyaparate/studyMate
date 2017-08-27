using MongoDB.Bson.Serialization.Attributes;
using StudyMateLibrary.Domains;
using StudyMateLibrary.Interfaces;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace StudyMateLibrary.Enities
{
    public class Subject : Entity
    {
        public string Description { get; set; }

        [Required]
        public string SubjectText { get; set; }
        
    }
}