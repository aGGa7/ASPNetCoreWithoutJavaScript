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
        private IBidDetails repository;
        public HomeController(IBidDetails repo)
        {
            repository = repo;
        }

        public ViewResult DetailInfo(int id)
        {
            ViewData["SelectBidId"] = id;
            return View(repository.GetDetailByBid(id));
        }

        [HttpPost]
        public RedirectToActionResult DetailInfo(BidDetail bidDetail)
        {
            repository.SaveDetail(bidDetail);
            return RedirectToAction( "DetailInfo", new {id = ViewData["SelectBidId"]});
        }

    }
}
