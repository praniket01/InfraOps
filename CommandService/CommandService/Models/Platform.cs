using System.ComponentModel.DataAnnotations;

namespace CommandService.Models
{
    public class Platform
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public int ExternalID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Command> Commands = new List<Command>();
    }
}
