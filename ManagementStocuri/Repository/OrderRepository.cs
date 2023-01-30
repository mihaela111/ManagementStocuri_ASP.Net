using ManagementStocuri.Data;
using ManagementStocuri.Models;
using ManagementStocuri.Models.DBObjects;

namespace ManagementStocuri.Repository
{
    public class OrderRepository
    {
        private ApplicationDbContext dbContext;

        public OrderRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public OrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //select all
        public List<OrderModel>GetAllOrders()
        {
            List<OrderModel> orderList = new List<OrderModel>();
            foreach(Order dbOrder in this.dbContext.Orders)
            {
                orderList.Add(MapDbObjectToModel(dbOrder));
            }
            return orderList;
        }

        //select by id

        public OrderModel GetOrderByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Orders.FirstOrDefault(x => x.Idorder == ID));
        }

        //add

        public void InsertOrder(OrderModel orderModel)
        {
            orderModel.IDOrder=Guid.NewGuid();
            dbContext.Orders.Add(MapModelToDbObject(orderModel));
        }

        //update

        //delete


        //mappers
        private OrderModel MapDbObjectToModel(Order dbOrder)
        {
            OrderModel orderModel = new OrderModel();
            if (dbOrder != null)
            {
                orderModel.IDOrder = dbOrder.Idorder;
                orderModel.IDCustomer = dbOrder.Idcustomer;
                orderModel.IDProduct = dbOrder.Idproduct;
                orderModel.Quantity = dbOrder.Quantity;
                orderModel.IsShipped = dbOrder.IsShipped;
            }
            return orderModel;
        }

        private Order MapModelToDbObject (OrderModel orderModel)
        {
            Order order = new Order();
            if(orderModel != null)
            {
                order.Idorder = orderModel.IDOrder;
                order.Idcustomer=orderModel.IDCustomer;
                order.Idproduct=orderModel.IDProduct;
                order.OrderDate = orderModel.OrderDate;
                order.Quantity = orderModel.Quantity;
                order.IsShipped = orderModel.IsShipped;
            }

            return order;
        }
    }
}
