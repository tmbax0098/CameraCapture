using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraCapture.Models.Entites.Models
{
    public class User : Person
    {
        [Required , MaxLength(15)]
        public string Username { get; set; }

        [Required , MaxLength(100)]
        public string Password { get; set; }
    }
}
