using CarStore.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarStore.Services
{
    public class CarService : ICarService
    {
        private const string carCacheKey = "carsdb";
        private readonly IDataCache _cachedData;
        public CarService(IDataCache cachedData)
        {
            _cachedData = cachedData;
        }

        public IList<Car> GetCar()
        {
            return _cachedData.GetCache<IList<Car>>(carCacheKey);
        }

        public void AddCar(Car carObj)
        {
            var carCache = GetCar();
            if (carCache == null)
            {
                carCache = new List<Car>();
                carCache.Add(carObj);
                _cachedData.AddCache(carCacheKey, carCache);
            }
            else
            {
                if (!carCache.Exists(carObj))
                {
                    carCache.Add(carObj);
                    _cachedData.UpdateCache(carCacheKey, carCache);
                }
            }
        }
    }

    public static class CarListExt
    {
        public static bool Exists(this IList<Car> source, Car carInput)
        {
            if(!source.Any(w=> w.Model == carInput.Model && w.Name == carInput.Name && w.Year == carInput.Year))
            {
                return false;
            }
            return true;
        }
    }
}
