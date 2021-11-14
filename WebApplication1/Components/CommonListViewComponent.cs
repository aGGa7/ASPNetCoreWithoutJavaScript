using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Components
{
    public class CommonListViewComponent: ViewComponent
    {
        private IBidRepositore repository;
        public CommonListViewComponent(IBidRepositore repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.Bids);
        }
    }
}
