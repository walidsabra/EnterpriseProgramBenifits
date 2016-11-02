using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Program_Benefits.Models
{
    public class software
    {
        public int SoftwareId { get; set; }
        [Display(Name = "Software Name")]
        public string SoftwareName { get; set; }
        public string Description { get; set; }
        [Display(Name = "Product Type")]
        public string TokenRate { get; set; }
        [Display(Name = "Tools Channel")]
        public string LearnIt { get; set; }
        [Display(Name = "Product Family")]
        public string ProductFamily { get; set; }
        public string Platform { get; set; }
        [Display(Name = "License Type")]
        public string LicenseType { get; set; }

    }
}