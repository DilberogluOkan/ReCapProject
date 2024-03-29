﻿using Core.Unitilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IResult CheckReturnDate(int id);
        IDataResult<List<Rental>>GetAll();
        IDataResult<Rental> GetByCarId(int carId);

    }
}
