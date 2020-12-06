using CameraCapture.Models.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraCapture.Models.Entites.Models
{
    public class Person
    {
        [Key , DatabaseGenerated(DatabaseGeneratedOption.Identity) , Column(Order = 0)]
        public int Id { get; set; }

        [MaxLength(100), Column(Order = 1)]
        public string Title { get; set; }

        [MaxLength(100), Column(Order = 2)]
        public string FirstName { get; set; }

        [MaxLength(100), Column(Order = 3)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime" , Order = 4)]
        public DateTime? Birthday { get; set; }

        [Column(Order = 5)]
        public int Age { get; set; }

        [Column(Order = 6)]
        public AgeType AgeType { get; set; }
    }
}
