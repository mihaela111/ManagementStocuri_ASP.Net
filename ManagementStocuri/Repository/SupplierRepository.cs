using ManagementStocuri.Data;
using ManagementStocuri.Models;
using ManagementStocuri.Models.DBObjects;


namespace ManagementStocuri.Repository
{
    public class SupplierRepository
    {
        private ApplicationDbContext dbContext;

        public SupplierRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public SupplierRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //select all

        public List<SupplierModel> GetAllSuppliers()
        {
            List<SupplierModel> supplierList = new List<SupplierModel>();
            foreach(Supplier dbSupplier in this.dbContext.Suppliers)
            {
                supplierList.Add(MapDbObjectToModel(dbSupplier));
            }
            return supplierList;
        
        
        }

        //select by id
        public SupplierModel GetSupplierByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Suppliers.FirstOrDefault(x=>x.Idsupplier==ID));
        }
        

        //add
        public void InsertSupplier(SupplierModel supplierModel)
        {
            supplierModel.IDSupplier=Guid.NewGuid();
            dbContext.Suppliers.Add(MapModelToDbObject(supplierModel));
            dbContext.SaveChanges();

        }


        //update


        //delete


        //mappers
        private SupplierModel MapDbObjectToModel(Supplier dbSupplier)
        {
            SupplierModel supplierModel = new SupplierModel();  
            if(dbSupplier != null)
            {
                supplierModel.IDSupplier = dbSupplier.Idsupplier;
                supplierModel.Name = dbSupplier.Name;
                supplierModel.Phone = dbSupplier.Phone;
                supplierModel.Email = dbSupplier.Email;
                supplierModel.Adress= dbSupplier.Adress;
            }
            return supplierModel;
        }

        private Supplier MapModelToDbObject(SupplierModel supplierModel)
        {
            Supplier dbSupplier=new Supplier();
            if(supplierModel != null)
            {
                dbSupplier.Idsupplier = supplierModel.IDSupplier;
                dbSupplier.Name = supplierModel.Name;
                dbSupplier.Phone = supplierModel.Phone;
                dbSupplier.Email = supplierModel.Email;
                dbSupplier.Adress= supplierModel.Adress;
            }
            return dbSupplier;
        }



    }
}
