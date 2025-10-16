using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SOPL.Controllers
{
    public class PacjenciController : Controller
    {
        // GET: PacjenciController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PacjenciController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PacjenciController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PacjenciController/Create
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

        // GET: PacjenciController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PacjenciController/Edit/5
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

        // GET: PacjenciController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PacjenciController/Delete/5
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
