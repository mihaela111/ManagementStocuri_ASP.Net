using ManagementStocuri.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class OrderController : Controller
    {

        private Repository.OrderRepository _orderRepository;
        private Repository.ProductRepository _productRepository;

        public OrderController(ApplicationDbContext dbContext)
        {
            _orderRepository = new Repository.OrderRepository(dbContext);
           _productRepository = new Repository.ProductRepository(dbContext);
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var order=_orderRepository.GetAllOrders();
            return View("Index", order);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(Guid id)
        {
            var model= _orderRepository.GetOrderByID(id);
            return View("OrderDetails", model);
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

                    var productModel = _productRepository.GetProductByID(model.IDProduct);
                    _productRepository.UpdateProduct(productModel, model.Quantity);
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
        public ActionResult Edit(Guid id)
        {
            var model = _orderRepository.GetOrderByID(id);
            return View("EditOrder",model);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new Models.OrderModel();
                var task= TryUpdateModelAsync(model);
                task.Wait();
                if (task.Result)
                {
                    _orderRepository.UpdateOrder(model);
                }
                return View("CreateOrder");
                
            }
            catch
            {
                return View("CreateOrder");
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model= _orderRepository.GetOrderByID(id);
            return View("DeleteOrder", model);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _orderRepository.DeleteOrder(id);
                return View("DeleteOrder");
            }
            catch
            {
                return View("DeleteOrder");
            }
        }
    }
}
