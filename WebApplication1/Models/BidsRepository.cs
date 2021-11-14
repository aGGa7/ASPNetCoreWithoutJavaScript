using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BidsRepository : IBidRepositore
    {
        private ApplicationDBContext context;
        public BidsRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Bid> Bids => context.Bids;

        //public IQueryable<BidDetail> Details => context.Details;

        //public BidDetail GetDetailByBid(int id) => Details.FirstOrDefault(d => d.Bid.Id == id); 
        
    }
}
