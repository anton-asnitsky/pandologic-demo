using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphData.API.Communication.Request
{
    public class GetGraphDataRequest
    {
        [BindProperty(Name = "from_date")]
        public DateTime FromDate { get; set; }

        [BindProperty(Name = "to_date")]
        public DateTime ToDate { get; set; }

        [BindProperty(Name = "page_number")]
        public int PageNumber { get; set; } = 1;

        [BindProperty(Name = "page_size")]
        public int PageSize { get; set; } = Commons.Consts.DBPageSize.DefaultSize;
    }
}
