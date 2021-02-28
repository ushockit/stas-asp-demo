using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.DTO
{
    public class ForumThemeDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsPublished { get; set; } = true;
        public DateTime PublishDate { get; set; } = DateTime.Now;
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }

        public ICollection<ThemeMessageDto> Messages { get; set; }
    }
}