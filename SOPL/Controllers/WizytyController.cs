using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SOPL.Controllers
{
    public class WizytyController : Controller
    {
        // GET: WizytyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WizytyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WizytyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WizytyController/Create
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

        // GET: WizytyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WizytyController/Edit/5
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

        // GET: WizytyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WizytyController/Delete/5
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
