using Business.Abstract;
using Core.Unitilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICutomerDal _cutomerDal;
        public CustomerManager(ICutomerDal cutomerDal)
        {
            _cutomerDal = cutomerDal;
        }

        public IResult Add(Customer customer)
        {
            _cutomerDal.Add(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _cutomerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cutomerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_cutomerDal.Get(p => p.CustomerId == customerId));
        }

        public IResult Update(Customer customer)
        {
            _cutomerDal.Update(customer);
            return new SuccessResult();
        }
    }
}
