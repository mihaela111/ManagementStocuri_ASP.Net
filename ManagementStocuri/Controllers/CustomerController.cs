using ManagementStocuri.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    public class CustomerController : Controller
    {
        private Repository.CustomerRepository _customerRepository;

        public CustomerController (ApplicationDbContext dbContext)
        {
            _customerRepository = new Repository.CustomerRepository (dbContext);
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            //CreateCustomer=nume view
            return View("CreateCustomer");
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.CustomerModel model = new Models.CustomerModel();

                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _customerRepository.InsertCustomer(model);
                }

                return View("CreateCustomer");
                
            }
            catch
            {
                return View("CreateCustomer");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
