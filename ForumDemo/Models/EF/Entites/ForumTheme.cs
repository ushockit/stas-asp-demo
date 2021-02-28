using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.EF.Entites
{
    public class ForumTheme : BaseEntity<int>
    {
        [StringLength(70)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; } = true;
        public DateTime PublishDate { get; set; }
        public ApplicationUser Owner { get; set; }
        public string OwnerId { get; set; }

        public ICollection<ThemeMessage> Messages { get; set; }
    }
}