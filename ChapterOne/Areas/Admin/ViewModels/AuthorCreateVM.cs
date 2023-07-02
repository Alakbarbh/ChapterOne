﻿using System.ComponentModel.DataAnnotations;

namespace ChapterOne.Areas.Admin.ViewModels
{
    public class AuthorCreateVM
    {
        [Required(ErrorMessage = "Don't be empty")]
        public string Name { get; set; }
    }
}