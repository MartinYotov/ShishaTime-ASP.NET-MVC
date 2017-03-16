using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShishaTime.Models
{
    public class Region
    {
        private ICollection<ShishaBar> bars;

        public Region()
        {
            this.bars = new HashSet<ShishaBar>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(15)]
        public string Name { get; set; }

        public virtual ICollection<ShishaBar> Bars
        {
            get
            {
                return this.bars;
            }

            set
            {
                this.bars = value;
            }
        }
    }
}
