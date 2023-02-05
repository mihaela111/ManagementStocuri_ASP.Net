using ManagementStocuri.Data;
using ManagementStocuri.Models;
using ManagementStocuri.Models.DBObjects;

namespace ManagementStocuri.Repository
{
    public class OfferRepository
    {
        private ApplicationDbContext dbContext;

        public OfferRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public OfferRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //select all
        public List<OfferModel>GetAllOffers()
        {
            List<OfferModel> offerList = new List<OfferModel>();
            
            foreach(Offer dbOffer in this.dbContext.Offers)
            {
                offerList.Add(MapDbObjectToModel(dbOffer));

            }
            return offerList;
        }

        //select by id
        public OfferModel GetOfferByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Offers.FirstOrDefault(x => x.Idoffer == ID));
        }



        //add
     public void InsertOffer(OfferModel offerModel)
        {
            offerModel.IDOffer=Guid.NewGuid();
            dbContext.Offers.Add(MapModelToDbObject(offerModel));
            dbContext.SaveChanges();
            

        }

        //update

        public void UpdateOffer(OfferModel offerModel)
        {
            Offer offer = dbContext.Offers.FirstOrDefault(x => x.Idoffer == offerModel.IDOffer);
            if(offer!=null)
            {
                offer.Idoffer = offerModel.IDOffer;
                offer.ValidFrom = offerModel.ValidFrom;
                offer.ValidTo = offerModel.ValidTo;
                offer.Name = offerModel.Name;
                offer.Description = offerModel.Description;
                offer.Discount = offerModel.Discount;

            }
            dbContext.SaveChanges();
        }

   

        //delete

        public void DeleteOffer(Guid id)
        {
            Offer offer=dbContext.Offers.FirstOrDefault(x => x.Idoffer == id);
            if (offer != null)
            {
                dbContext.Offers.Remove(offer);

            }
            dbContext.SaveChanges();
        }
        
        //mappers
        private OfferModel MapDbObjectToModel(Offer dbOffer)
        {
            OfferModel offerModel = new OfferModel();
            if(dbOffer != null)
            {
                offerModel.IDOffer = dbOffer.Idoffer;
                offerModel.ValidFrom= dbOffer.ValidFrom;
                offerModel.ValidTo= dbOffer.ValidTo;
                offerModel.Name = dbOffer.Name;
                offerModel.Description = dbOffer.Description;
                offerModel.Discount = dbOffer.Discount;              
            }

            return offerModel;
        }

        private Offer MapModelToDbObject(OfferModel offerModel)
        {
            Offer offer = new Offer();

            if(offerModel != null)
            {
                offer.Idoffer = offerModel.IDOffer;
                offer.ValidFrom= offerModel.ValidFrom;
                offer.ValidTo= offerModel.ValidTo;
                offer.Name = offerModel.Name;
                offer.Description = offerModel.Description;
                offer.Discount = offerModel.Discount;             

            }

            return offer;

        }



    }
}
