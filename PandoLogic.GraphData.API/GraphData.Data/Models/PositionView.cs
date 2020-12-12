using System;
using System.Collections.Generic;
using System.Text;

namespace GraphData.Data.Models
{
    public class PositionView
    {
        public Guid Id { get; set; }
        public Guid PositinId { get; set; }
        public DateTime VisitDateTime { get; set; }
        public string SourceIpAddress { get; set; }
    }
}
