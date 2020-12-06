using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameraCapture.Models.Entites.Models
{

    public class Device
    {
        public Device()
        {
        }

        public Device(string name, string ip, string username, string password, short port)
        {
            Name = name;
            IP = ip;
            Username = username;
            Password = password;
            Port = port;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(15)]
        public string IP { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(30)]
        public string Password { get; set; }

        [Required]
        public short Port { get; set; } = 8000;

        [Required, MaxLength(20)]
        public string Username { get; set; }
    }
}
