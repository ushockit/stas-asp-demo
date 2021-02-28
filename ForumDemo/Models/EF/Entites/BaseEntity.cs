using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ForumDemo.Models.EF.Entites
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
    }
}