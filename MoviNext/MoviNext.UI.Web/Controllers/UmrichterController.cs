using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviNext.Model;
using MoviNext.Model.Contracts;

namespace MoviNext.UI.Web.Controllers
{
    public class UmrichterController : Controller
    {
        IRepository repo;

        public UmrichterController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: UmrichterController
        public ActionResult Index()
        {
            return View(repo.Query<Umrichter>());
        }

        // GET: UmrichterController/Details/5
        public ActionResult Details(int id)
        {
            return View(repo.GetById<Umrichter>(id));
        }

        // GET: UmrichterController/Create
        public ActionResult Create()
        {
            return View(new Umrichter() { Frequenz = 100, Leistung = 4, LeistungsEinheit = LeistungsEinheit.MW });
        }

        // POST: UmrichterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Umrichter um)
        {
            try
            {
                um.Steuerung = new Steuerung();
                repo.Add(um);
                repo.SaveChanges();

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
            return View(repo.GetById<Umrichter>(id));

        }

        // POST: UmrichterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Umrichter umrichter)
        {
            try
            {
                repo.Update(umrichter);
                repo.SaveChanges();

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
            return View(repo.GetById<Umrichter>(id));

        }

        // POST: UmrichterController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Umrichter umrichter)
        {
            try
            {
                //var toKill = repo.GetById<Umrichter>(id);
                repo.Delete(umrichter);
                repo.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
