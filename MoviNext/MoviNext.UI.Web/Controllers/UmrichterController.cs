using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviNext.Model;
using MoviNext.Model.Contracts;

namespace MoviNext.UI.Web.Controllers
{
    public class UmrichterController : Controller
    {
        IRepository repo;

        // GET: UmrichterController
        public ActionResult Index()
        {
            return View(repo.Query<Umrichter>());
        }

        // GET: UmrichterController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UmrichterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UmrichterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UmrichterController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UmrichterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UmrichterController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UmrichterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
