using System;
using System.Collections.Generic;
using System.Text;

namespace GraphData.Data.Models
{
    public class QueryFilter
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
