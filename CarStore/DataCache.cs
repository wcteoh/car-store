using System.Collections.Generic;

namespace CarStore
{
    public interface IDataCache
    {
        T GetCache<T>(string key) where T : class;
        void AddCache(string key, object dataSet);
        bool RemoveCache(string key);
        void UpdateCache(string key, object dataSet);
    }

    public class DataCache : IDataCache
    {
        private readonly Dictionary<string, object> _cachedData = new Dictionary<string, object>();

        public T GetCache<T>(string key) where T : class
        {
            if (_cachedData.TryGetValue(key, out object value))
            {
                return (T)value;
            }

            return default(T);
        }

        public void AddCache(string key, object dataSet)
        {
            _cachedData.Add(key, dataSet);
        }

        public bool RemoveCache(string key)
        {
            return _cachedData.Remove(key);
        }

        public void UpdateCache(string key, object dataSet)
        {
            _cachedData[key] = dataSet;
        }
    }

}
