using System;
using System.Collections.Generic;
using System.Text;

namespace GraphData.Data.Models
{
    public class Position
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
