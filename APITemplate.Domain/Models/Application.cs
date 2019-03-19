using System;
using System.Collections.Generic;
using System.Text;

namespace APITemplate.Domain.Models
{
   public class Application
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
        public IList<ApplicationContact> Contacts { get; set; } = new List<ApplicationContact>();
    }
}
