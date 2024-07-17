using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RailwayScheduler.Models
{
    public class Train
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Source must have under 25 characters.")]
        public string Source {  get; set; }
        [Required]
        [StringLength(25, ErrorMessage = "Destination must have under 25 characters.")]
        public string Destination { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Time must be positive.")]
        public int TimeSource { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Time must be positive.")]
        public int TimeDestination { get; set; }
    }
}
