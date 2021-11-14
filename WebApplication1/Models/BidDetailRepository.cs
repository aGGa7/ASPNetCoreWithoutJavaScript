﻿using System;
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
                return Details.FirstOrDefault(d => d.Bid.Id == id);
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
                context.Details.Add(detail);
                context.SaveChanges();
            }
            catch
            {
                throw;
            } 
          
        }
    }
}
