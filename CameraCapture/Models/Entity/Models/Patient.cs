using CameraCapture.Models.Types;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraCapture.Models.Entites.Models
{
    public class Patient : Person
    {
        [MaxLength(100)]
        public string PatientId { get; set; }

        public GenderType Gender { get; set; } = GenderType.None;

        public bool Pregnant { get; set; } = false;

        [MaxLength(100)]
        public string StudyDescription { get; set; }

        public string Note { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime? StudyDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [MaxLength(100)]
        public string AccessionNumber { get; set; }

        [MaxLength(100)]
        public string RequestingPhysician { get; set; }

        public bool NA { get; set; } = false;


    }
}
