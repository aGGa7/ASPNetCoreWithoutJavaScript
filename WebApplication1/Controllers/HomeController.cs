using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApplication1.Models;
using Microsoft.AspNetCore.Authorization;

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

        public ViewResult Home ()
        {
            return View(new BidsDataViewModel { ListBids = bidRepositore.Bids, Detail = null }) ;
        }

        public ViewResult DetailInfo(int id)
        {
            ViewData["SelectBidId"] = id;
            return View("Home",new BidsDataViewModel { ListBids = bidRepositore.Bids, Detail = bidDetailRepositore.GetDetailByBid(id) });
        }
        [Authorize]
        [HttpPost]
        public RedirectToActionResult DetailInfo(BidDetail bidDetail)
        {
            bidDetailRepositore.SaveDetail(bidDetail);
            return RedirectToAction( "DetailInfo", new { id = bidDetail.BidId });
        }
        [Authorize]
        public RedirectToActionResult AddBid()
        {
            Bid newBid = new Bid{DateCreate = DateTime.UtcNow, Detail = null };
            bidRepositore.SaveBid(newBid);
            BidDetail detail = new BidDetail { BidId = newBid.Id, NameOrganization = "", Email = "", FullNameUser = "", PostUser = "" };
            bidDetailRepositore.SaveDetail(detail);
            //перенести осхранение в ручной режим
            return RedirectToAction("DetailInfo", new { id = newBid.Id });
        }
        [Authorize]
        public RedirectToActionResult DeleteBid(int bidId)
        {
            Bid bidDelete = bidRepositore.Bids.FirstOrDefault(bid => bid.Id.Equals(bidId));
            bidRepositore.DeleteBid(bidDelete);
            return RedirectToAction("Home");
        }

    }
}
