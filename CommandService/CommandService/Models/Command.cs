using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommandService.Models
{
    public class Command
    {
        //Id,HowTo,CommandLine,PlatformId
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
        public int PlatformId { get; set; }
        public Platform Platform { get; set; }
    }
}
