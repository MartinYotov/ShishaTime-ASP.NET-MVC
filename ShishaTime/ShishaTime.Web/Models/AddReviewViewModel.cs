using ShishaTime.Models;
using ShishaTime.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShishaTime.Web.Models
{
    public class AddReviewViewModel : IMapFrom<Review>
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "The name should be between 5 and 20 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Text is required")]
        [StringLength(500, MinimumLength = 20, ErrorMessage = "The name should be between 20 and 500 characters")]
        public string Text { get; set; }

        public int BarId { get; set; }

        public string UserId { get; set; }
    }
}