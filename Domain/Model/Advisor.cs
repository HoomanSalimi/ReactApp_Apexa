using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Advisor
    {
        [Key]
        public int AdvisorId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 8)]
        public string SIN { get; set; }

        [MaxLength(255)]
        public string? Address { get; set; }

        [StringLength(8, MinimumLength = 7)]
        public string? Phone { get; set; }

        
        public string? HealthStatus { get; set; }


    }
}
