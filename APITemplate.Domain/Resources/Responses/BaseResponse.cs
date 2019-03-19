using System;
using System.Collections.Generic;
using System.Text;

namespace APITemplate.Domain.Resources.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
