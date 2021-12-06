using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BidDetailRepository : IBidDetails
    {
        private ApplicationDBContext context;

        public BidDetailRepository(ApplicationDBContext ctx)
        {
            context = ctx;
        }

        public IQueryable<BidDetail> Details => context.Details;
        public BidDetail GetDetailByBid(int id)
        {
            try
            {
                return Details.FirstOrDefault(d => d.BidId == id);
            }
            catch
            {
                throw;
            }
           
        }

        public void SaveDetail(BidDetail detail)
        {
            try
            {
                
                if (context.Details.Any(det => det.BidId == detail.BidId))
                {
                    var item = context.Details.FirstOrDefault(det => det.BidId == detail.BidId);
                    item.Email = detail.Email;
                    item.FullNameUser = detail.FullNameUser;
                    item.NameOrganization = detail.NameOrganization;
                    item.PostUser = detail.PostUser;
                }
                else
                {
                    context.Details.Add(detail);
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
