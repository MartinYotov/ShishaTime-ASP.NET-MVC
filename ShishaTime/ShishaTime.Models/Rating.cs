using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Models
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        [Range(0, 1000)]
        public double Vote { get; set; }

        [ForeignKey("Bar")]
        public int BarId { get; set; }

        public virtual ShishaBar Bar { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
