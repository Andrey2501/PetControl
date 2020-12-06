using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Parameters
{
    public class StatisticParameters: QueryStringParameters
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
