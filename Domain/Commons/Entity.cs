using System.ComponentModel.DataAnnotations;

namespace Domain.Commons
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateRegistration { get; set; }
        public DateTime? DateChange { get; set; }
        public DateTime? DateRemoval { get; set; }
    }
}
