using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BidsDataViewModel
    {
        public IEnumerable<Bid> ListBids { get; set; }
        public BidDetail Detail { get; set; }

    }
}
