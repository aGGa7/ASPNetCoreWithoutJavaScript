using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDBContext context = app.ApplicationServices.GetRequiredService<ApplicationDBContext>();
            context.Database.Migrate();
            if(!context.Bids.Any())
            {
                List<Bid> bids = new List<Bid>();
                List<BidDetail> details = new List<BidDetail>();
                for (int i = 1; i <3; i++)
                {
                    Bid bid = new Bid { Id = i, DateCreate = new System.DateTime(1989, i, 30 - i, 12+i, 12-i, 12), };
                    BidDetail detail = new BidDetail { BidId = i, Id = i, Email = "test1@gmail.com", FullNameUser = "Test"+i+" TestOne", NameOrganization = "UfaOrg", PostUser = "sotrudnik"+i };
                    bids.Add(bid);
                    details.Add(detail);
                }

                context.Bids.AddRange(bids);
                context.Details.AddRange(details);
                context.SaveChanges();
            }
        }
    }
}
