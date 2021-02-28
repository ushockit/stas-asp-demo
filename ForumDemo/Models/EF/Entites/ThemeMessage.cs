using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.EF.Entites
{
    public class ThemeMessage : BaseEntity<int>
    {
        [StringLength(255)]
        public string Text { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public ApplicationUser Publisher { get; set; }
        public string PublisherId { get; set; }
        public ForumTheme Theme { get; set; }
        public int ThemeId { get; set; }
    }
}