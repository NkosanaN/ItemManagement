using ItemManagementControl.Model;
using ItemManagementControl.Service.Repositoty.IRepository;
using ItemManagementControl.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ItemManagementControl.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IItemRepositoty _itemRepo;

        public HomeController(ILogger<HomeController> logger , IItemRepositoty itemRepo)
        {
            _logger = logger;
            _itemRepo = itemRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            var list = _itemRepo.GetItemList();

            return View(list);
        }

        public ActionResult Edit(int? id)
        {

            if (id is null)
            {
                return NotFound();
            }

            var item = _itemRepo.GetItemById(id.Value);

            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(Item model)
        {
            if (model is null)
            {
                return View(new Item());
            }


            return RedirectToAction("Dashboard");
        }
        public ActionResult Create(int? id)
        {
            if (id is null)
            {
                return View(new Item());
            }
            else
            {
                var item = _itemRepo.GetItemById(id.Value);

                if(item is null)
                {
                    return NotFound();
                }
                return View(item);
            }
        }
        [HttpPost]
        public ActionResult Create(int id,Item model)
        {

            Item item = _itemRepo.GetItemById(id);

            if(item is null)
            {
                _itemRepo.InsertItem(model);
                _itemRepo.Save();
            }
            else
            {
                _itemRepo.UpdateItem(item);
                _itemRepo.Save();
            }
            return RedirectToAction("Dashboard");
        }

        public ActionResult Delete(int? id)
        {

            if(id is null)
            {
                return NotFound();
            }

            var item  = _itemRepo.GetItemById(id.Value);

            return View(item);
        }
        [HttpPost]
        public ActionResult Delete(int id,Item model)
        {
      
            var item = _itemRepo.GetItemById(id);
            _itemRepo.DeleteItem(item);
            _itemRepo.Save();

            return RedirectToAction("Dashboard");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}