using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTOs
{
    public class EmailDTO
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
