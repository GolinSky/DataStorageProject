using Newtonsoft.Json;
using UnityEngine;

namespace DataStorage.ExportPackage.Runtime.Scripts.Service
{
    public static class DataStorageService
    {
        public static void Save<T>(T data) where T:IDataStorage
        {
            var jsonData = JsonConvert.SerializeObject(data);
            PlayerPrefs.SetString(data.RegistryKey, jsonData);
        }
        
        public static T Get<T>(string key) where T:IDataStorage
        {
            if (PlayerPrefs.HasKey(key))
            {
                var jsonData =  PlayerPrefs.GetString(key);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }

            return default;
        }
    }
}
