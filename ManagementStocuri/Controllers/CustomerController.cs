using ManagementStocuri.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    [Authorize(Roles="User, Admin")]
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
            var customer=_customerRepository.GetAllCustomers();
            return View("Index", customer);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(Guid id)
        {
            var model = _customerRepository.GetCustomerByID(id);
            return View("CustomerDetails", model);
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
        public ActionResult Edit(Guid id)
        {
            var model = _customerRepository.GetCustomerByID(id);
            return View("EditCustomer",model);
            
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model =new Models.CustomerModel();

                var task= TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _customerRepository.UpdateCustomer(model);
                    return RedirectToAction("Index");

                }
                else
                {
                    return RedirectToAction("Index", id);
                }

                
            }
            catch
            {
                return RedirectToAction("Index", id);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model = _customerRepository.GetCustomerByID(id);
            return View("DeleteCustomer", model);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _customerRepository.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("DeleteCustomer", id);
            }
        }
    }
}
