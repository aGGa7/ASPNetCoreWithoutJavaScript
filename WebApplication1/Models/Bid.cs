using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public BidDetail Detail { get; set; }
  
    }
}
