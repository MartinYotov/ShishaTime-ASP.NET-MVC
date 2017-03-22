using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Text { get; set; }

        [ForeignKey("Bar")]
        public int BarId { get; set; }

        public virtual ShishaBar Bar { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
