using System;
using System.Collections.Generic;
using System.Text;

namespace APITemplate.Domain.Resources.Responses
{
   public class ApplicationResource
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public string Description { get; set; }
    }
}
