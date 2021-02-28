using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.DTO
{
    public class ThemeMessageDto
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ApplicationUser Publisher { get; set; }
        public string PublisherId { get; set; }
        public ForumThemeDto Theme { get; set; }
        public int? ThemeId { get; set; }
    }
}