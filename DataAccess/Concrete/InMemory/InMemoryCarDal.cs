using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal

    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=1,ColorId=1, DailyPrice="250", Description="", ModelYear="2001"},
                new Car{Id=2,BrandId=1,ColorId=1, DailyPrice="150", Description="", ModelYear="1998"},
                new Car{Id=3,BrandId=1,ColorId=1, DailyPrice="450", Description="", ModelYear="2012"},
                new Car{Id=4,BrandId=1,ColorId=1, DailyPrice="220", Description="", ModelYear="2003"}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carDelete;
            carDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.Id = car.Id;
            updateCar.ColorId = car.ColorId;
            updateCar.Description = car.Description;
            updateCar.DailyPrice = car.DailyPrice;

        }
    }
}
