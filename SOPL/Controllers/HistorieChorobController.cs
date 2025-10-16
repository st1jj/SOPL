using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SOPL.Controllers
{
    public class HistorieChorobController : Controller
    {
        // GET: HistorieChorobController
        public ActionResult Index()
        {
            return View();
        }

        // GET: HistorieChorobController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorieChorobController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorieChorobController/Create
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

        // GET: HistorieChorobController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorieChorobController/Edit/5
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

        // GET: HistorieChorobController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorieChorobController/Delete/5
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
