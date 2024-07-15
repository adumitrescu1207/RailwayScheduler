using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RailwayScheduler.Models
{
    public class Train
    {
        [Required]
        public int Id { get; set; }
        public string Source {  get; set; }
        public string Destination { get; set; }
        public int TimeSource { get; set; }
        public int TimeDestination { get; set; }
    }
}
