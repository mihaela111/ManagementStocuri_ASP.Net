using ManagementStocuri.Data;
using ManagementStocuri.Models;
using ManagementStocuri.Models.DBObjects;

namespace ManagementStocuri.Repository
{
    public class ProductRepository
    {
        private ApplicationDbContext dbContext;

        public ProductRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ProductRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //select all
        public List<ProductModel>GetAllProducts()
        {
            List<ProductModel> productList = new List<ProductModel>();
            foreach(Product dbProduct in this.dbContext.Products)
            {
                productList.Add(MapDbObjectToModel(dbProduct));
            }
            return productList;
        }

        //select by id

        public ProductModel GetProductByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Products.FirstOrDefault(x => x.Idproduct == ID));
        }


        //add
        public void InsertProduct(ProductModel productModel)
        {
            productModel.IDProduct=Guid.NewGuid();
            dbContext.Products.Add(MapModelToDbObject(productModel));
            dbContext.SaveChanges();
        }

        //update
        public void UpdateProduct(ProductModel productModel)
        {
            Product product=dbContext.Products.FirstOrDefault(x => x.Idproduct == productModel.IDProduct);
            if(product!=null)
            {
                product.Idproduct=productModel.IDProduct;
                product.Idsupplier=productModel.IDSupplier;
                product.Name=productModel.Name;
                product.Category=productModel.Category;
                product.Description=productModel.Description;
                product.Quantity=productModel.Quantity;
                product.PriceBuy=productModel.PriceBuy;
                product.PriceSell=productModel.PriceSell;
            }
            dbContext.SaveChanges();
        }

        public void UpdateProduct(ProductModel productModel, int quantity)
        {
            Product product = dbContext.Products.FirstOrDefault(x => x.Idproduct == productModel.IDProduct);
            if (product != null)
            {
                int finalQuantity=product.Quantity;
                finalQuantity = finalQuantity - quantity;

                product.Quantity = finalQuantity;

            }
            dbContext.SaveChanges();

        }


        //delete
        public void DeleteProduct(Guid id)
        {
            Product product = dbContext.Products.FirstOrDefault(x => x.Idproduct == id);
            if (product != null)
            {
                dbContext.Products.Remove(product);

            }
            dbContext.SaveChanges();
        }


        //mappers
        private ProductModel MapDbObjectToModel(Product dbProduct)
        {
            ProductModel productModel = new ProductModel();
            if(dbProduct != null)
            {
                productModel.IDProduct = dbProduct.Idproduct;
                productModel.IDSupplier = dbProduct.Idsupplier;
                productModel.Name = dbProduct.Name;
                productModel.Category= dbProduct.Category;
                productModel.Description = dbProduct.Description;
                productModel.Quantity = dbProduct.Quantity;
                productModel.PriceBuy = dbProduct.PriceBuy;
                productModel.PriceSell = dbProduct.PriceSell;

            }

            return productModel;
        }

        private Product MapModelToDbObject(ProductModel productModel)
        {
            Product dbProduct = new Product();
            if(productModel != null)
            {
                dbProduct.Idproduct = productModel.IDProduct;
                dbProduct.Idsupplier = productModel.IDSupplier;
                dbProduct.Name = productModel.Name;
                dbProduct.Category = productModel.Category;
                dbProduct.Description = productModel.Description;
                dbProduct.Quantity = productModel.Quantity;
                dbProduct.PriceBuy = productModel.PriceBuy;
                dbProduct.PriceSell = productModel.PriceSell;
            }
            return dbProduct;
        }

    }
}
