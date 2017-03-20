using ShishaTime.Models;
using ShishaTime.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using AutoMapper;

namespace ShishaTime.Web.Models
{
    public class AddBarViewModel : IMapFrom<ShishaBar>, IHaveCustomMappings
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The name should be between 3 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "The name should be between 5 and 50 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Region is required")]
        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public HttpPostedFileBase Image { get; set; }

        public void CreateMappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<AddBarViewModel, ShishaBar>()
                .ForMember(d => d.ImagePathBig, src => src.MapFrom(s => ("~/Images/" + s.Image.FileName))); 
        }
    }
}