using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Parameters
{
    public class ContactParameters: QueryStringParameters
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
