using Business.Abstract;
using Business.Constants;
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
        ICustomerDal _cutomerDal;
        public CustomerManager(ICustomerDal cutomerDal)
        {
            _cutomerDal = cutomerDal;
        }

        public IResult Add(Customer customer)
        {
            _cutomerDal.Add(customer);
            return new SuccessResult(Messages.AddSucces);
        }

        public IResult Delete(Customer customer)
        {
            _cutomerDal.Delete(customer);
            return new SuccessResult(Messages.DeleteSucces);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cutomerDal.GetAll(), Messages.ListSucces);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_cutomerDal.Get(p => p.CustomerId == customerId), Messages.ListSucces);
        }

        public IResult Update(Customer customer)
        {
            _cutomerDal.Update(customer);
            return new SuccessResult(Messages.UpdateSucces);
        }
    }
}
