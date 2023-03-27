using AssetLogWeb.Data;
using AssetLogWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AssetLogWeb.Controllers
{
    public class AssetsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AssetsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //IEnumerable<Asset> objAssetList = _db.Assets;
            //return View(objAssetList);
            return View();
        }

        [HttpGet]
        public IActionResult GetAllAssets()
        {
            var assets = _db.Assets.ToList();
            return Json(assets);
        }
        [HttpGet]
        public IActionResult Edit(int? id) 
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var assetFromDb = _db.Assets.Find(id);
            var assetFromDbFirst = _db.Assets.FirstOrDefault(u=> u.Id == id);
            var assetFromDbSingle = _db.Assets.SingleOrDefault(u=> u.Id == id);

            if (assetFromDb == null)
            {
                return NotFound();
            }

            return View(assetFromDb); //might need to change what this returns if it's happening in modal
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Asset asset)
        {
            if (ModelState.IsValid)
            {
                _db.Assets.Add(asset);
                _db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
