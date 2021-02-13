using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();


            if (result.Success==true)
            {
                foreach (var deger in result.Data)
                {
                    System.Console.WriteLine(deger.ColorName);
                    System.Console.WriteLine(deger.BrandName);
                    System.Console.WriteLine(deger.DailyPrice);
                    System.Console.WriteLine(deger.Id);
                }
            }

            System.Console.WriteLine(result.Message);
            System.Console.WriteLine("Dilberoğlu");
        }
    }
}
