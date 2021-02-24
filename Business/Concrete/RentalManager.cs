using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Unitilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var check = CheckReturnDate(rental.CarId);
            if (!check.Success)
            {
                return new ErrorResult(Messages.RentalError); }

            else
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalSucces);
            }


        }


        public IResult CheckReturnDate(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id && r.ReturnDate == null);
            if (result.Count == 0)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();
            }
        }


        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteSucces);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.ListSucces);
        }

        public IDataResult<Rental> GetByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.CarId == carId),Messages.ListSucces);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UpdateSucces);
        }
    }
}
