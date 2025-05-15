using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApi.Domain.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; } // 1-5 ya da 1-10
        public DateTime ReviewDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
