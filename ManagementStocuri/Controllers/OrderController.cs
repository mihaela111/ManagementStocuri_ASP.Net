using ManagementStocuri.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    public class OrderController : Controller
    {

        private Repository.OrderRepository _orderRepository;

        public OrderController(ApplicationDbContext dbContext)
        {
            _orderRepository = new Repository.OrderRepository(dbContext);
        }

        // GET: OrderController
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            //nume view
            return View("CreateOrder");
            
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.OrderModel model = new Models.OrderModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _orderRepository.InsertOrder(model);

                }
                return View("CreateOrder");
            }
            catch
            {
                return View("CreateOrder");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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
