using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
