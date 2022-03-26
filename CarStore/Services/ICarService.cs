using CarStore.Models;
using System.Collections.Generic;

namespace CarStore.Services
{
    public interface ICarService
    {
        IList<Car> GetCar();
        void AddCar(Car carObj);
    }
}
