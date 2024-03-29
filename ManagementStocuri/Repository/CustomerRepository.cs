﻿using ManagementStocuri.Data;
using ManagementStocuri.Models;
using ManagementStocuri.Models.DBObjects;


namespace ManagementStocuri.Repository
{
    public class CustomerRepository
    {
        private ApplicationDbContext dbContext;
        
        public CustomerRepository()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public CustomerRepository (ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //select all

        public List<CustomerModel>GetAllCustomers()
        {
            List<CustomerModel> customerList= new List<CustomerModel>();
            foreach(Customer dbCustomer in this.dbContext.Customers)
            {
                customerList.Add(MapDbObjectToModel(dbCustomer));
            }
            return customerList;
        }

        //select by id
        public CustomerModel GetCustomerByID(Guid ID)
        {
            return MapDbObjectToModel(dbContext.Customers.FirstOrDefault(x => x.Idcustomer == ID));
        }

        //add
        public void InsertCustomer(CustomerModel customerModel)
        {
            customerModel.IDCustomer=Guid.NewGuid();
            dbContext.Customers.Add(MapModelToDbObject(customerModel));
            dbContext.SaveChanges();
        }

        //update
        public void UpdateCustomer(CustomerModel customerModel)
        {
            Customer customer=dbContext.Customers.FirstOrDefault(x=>x.Idcustomer==customerModel.IDCustomer);
            if(customer!=null)
            {
                customer.Idcustomer=customerModel.IDCustomer;
                customer.Name=customerModel.Name;
                customer.Title=customerModel.Title;
                customer.Phone=customerModel.Phone;
                customer.Email=customerModel.Email;
                customer.Adress=customerModel.Adress;
            }
            dbContext.SaveChanges();
        }

        //delete
        public void DeleteCustomer(Guid id)
        {
            Customer customer= dbContext.Customers.FirstOrDefault(x=>x.Idcustomer==id);
            if(customer !=null)
            {
                dbContext.Customers.Remove(customer);
            }
            dbContext.SaveChanges();
        }

        //mappers
        private CustomerModel MapDbObjectToModel(Customer dbCustomer)
        {
            CustomerModel customerModel= new CustomerModel();
            if(dbCustomer !=null)
            {
                customerModel.IDCustomer = dbCustomer.Idcustomer;
                customerModel.Name = dbCustomer.Name;
                customerModel.Title = dbCustomer.Title;
                customerModel.Phone = dbCustomer.Phone;
                customerModel.Email = dbCustomer.Email;
                customerModel.Adress = dbCustomer.Adress;
            }
            return customerModel;
        }

        private Customer MapModelToDbObject(CustomerModel customerModel)
        {
            Customer customer= new Customer();
            if(customerModel != null)
            {
                customer.Idcustomer = customerModel.IDCustomer;
                customer.Name = customerModel.Name;
                customer.Title = customerModel.Title;
                customer.Phone = customerModel.Phone;
                customer.Email = customerModel.Email;
                customer.Adress = customerModel.Adress;
            }
            return customer;
        }
    }
}
