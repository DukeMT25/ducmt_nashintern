﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Entities.Business
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 8, MinimumLength = 2)]
        public string Code { get; set; } = string.Empty;
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required, Range(0.01, float.MaxValue)]
        public float Price { get; set; }
        [StringLength(maximumLength: 350)]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsNewRelease { get; set; }
        [Url]
        public string? PictureUrl { get; set; }

        // Property to hold the categories associated with the product
        public List<SelectListItem>? Categories { get; set; }
        public List<int>? SelectedCategoryIds { get; set; }
    }
}