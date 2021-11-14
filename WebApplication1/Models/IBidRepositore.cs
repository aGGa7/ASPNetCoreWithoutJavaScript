using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IBidRepositore
    {
        IQueryable<Bid> Bids { get; }
        //IQueryable<BidDetail> Details {get; }
        //BidDetail GetDetailByBid(int id);
    }
}
