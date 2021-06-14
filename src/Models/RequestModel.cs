using System.ComponentModel.DataAnnotations;

namespace Bowling.Models
{
    public class RequestModel
    {
        [Required]
        public int[] PinsDowned { get; set; }
    }
}