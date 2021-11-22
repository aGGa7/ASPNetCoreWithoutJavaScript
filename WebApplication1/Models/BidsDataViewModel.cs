using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BidsDataViewModel
    {
        public IEnumerable<Bid> Bids { get; set; }
        BidDetail Detail { get; set; }

    }
}
