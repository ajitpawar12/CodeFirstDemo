using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstDemo.Models
{
    public class Editor
    {
        [Required]
        [AllowHtml]
        [UIHint("tinymce_full")]
        [Display(Name = "Page Content")]
        public string PageContent { get; set; }
    }
}