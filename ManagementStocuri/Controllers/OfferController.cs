using ManagementStocuri.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementStocuri.Controllers
{
    public class OfferController : Controller
    {

        //referinta catre repository
        private Repository.OfferRepository _repository;
        public OfferController(ApplicationDbContext dbContext)
        {
            _repository = new Repository.OfferRepository(dbContext);
        }

        // GET: OfferController
        public ActionResult Index()
        {
            var offers = _repository.GetAllOffers();

            return View("Index", offers);
        }

        // GET: OfferController/Details/5
        public ActionResult Details(Guid id)
        {
            var model= _repository.GetOfferByID(id);
            return View("OfferDetails", model );
        }

        // GET: OfferController/Create
        [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            var model= new Models.OfferModel();
            if(User.Identity.IsAuthenticated)
            {
                model.Description = User.Identity.Name;
            }
            return View("CreateOffer", model);
        }

        // POST: OfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Models.OfferModel model = new Models.OfferModel();
                var task = TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.InsertOffer(model);
                }
                return View("CreateOffer");
            }
            catch
            {
                return View("CreateOffer");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: OfferController/Edit/5
        public ActionResult Edit(Guid id)
        {
           var model = _repository.GetOfferByID(id);
            return View("EditOffer", model);
        }

        // POST: OfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            try
            {
                var model = new Models.OfferModel();
                var task=TryUpdateModelAsync(model);
                task.Wait();
                if(task.Result)
                {
                    _repository.UpdateOffer(model);
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

            return RedirectToAction(nameof(Index));
        }

        // GET: OfferController/Delete/5
        public ActionResult Delete(Guid id)
        {
            var model=_repository.GetOfferByID(id);
            return View("DeleteOffer", model);
        }

        // POST: OfferController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                _repository.DeleteOffer(id);
                return View("DeleteOffer");
              //  return RedirectToAction("Index");
            }
            catch
            {
                return View("DeleteOffer");
            }
        }
    }
}
