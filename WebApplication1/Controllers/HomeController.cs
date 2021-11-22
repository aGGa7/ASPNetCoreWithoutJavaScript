using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private IBidDetails bidDetailRepositore;
        private IBidRepositore bidRepositore;
        public HomeController(IBidDetails det, IBidRepositore bids)
        {
            bidDetailRepositore = det;
            bidRepositore = bids;
        }

        public ViewResult DetailInfo(int id)
        {
            ViewData["SelectBidId"] = id;
            return View(bidDetailRepositore.GetDetailByBid(id));
        }

        [HttpPost]
        public RedirectToActionResult DetailInfo(BidDetail bidDetail)
        {
            bidDetailRepositore.SaveDetail(bidDetail);
            return RedirectToAction( "DetailInfo", new {id = ViewData["SelectBidId"]});
        }

    }
}
