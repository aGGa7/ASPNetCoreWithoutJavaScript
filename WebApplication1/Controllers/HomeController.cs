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
            return View(repository.GetDetailByBid(id));
        }

        private void SaveResult (BidDetail bidDetail)
        {
            repository.SaveDetail(bidDetail);
        }

    }
}
