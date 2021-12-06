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

        public void DeleteBid(Bid bid)
        {
            try
            {
                if(context.Bids.Contains(bid))
                {
                    context.Bids.Remove(bid);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("bid not found");
                }
            }
            catch
            {
                throw;
            }
        }

        public void SaveBid(Bid newbid)
        {
            try
            {
                if (context.Bids.Any(bid => bid.Id.Equals(newbid.Id)))
                {
                    var bid = context.Bids.FirstOrDefault(bid => bid.Id.Equals(newbid.Id));
                    bid.Detail = newbid.Detail;
                    bid.DateCreate = newbid.DateCreate;
                }
                else
                {
                    context.Bids.Add(newbid);
                }
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
           
           
        }
    }
}
