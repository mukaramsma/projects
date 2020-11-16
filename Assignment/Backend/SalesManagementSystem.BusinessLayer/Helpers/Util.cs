using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using SalesManagementSystem.BusinessLayer.Models;

namespace SalesManagementSystem.BusinessLayer.Helpers
{
    public static class Util
    {
        private static readonly string LocationsFilePath = AppDomain.CurrentDomain.BaseDirectory + "LocationsData.txt";
        private static readonly string SalesFilePath = AppDomain.CurrentDomain.BaseDirectory + "SalesData.txt";

        private static void SaveData(string filePath, string data)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            File.WriteAllText(filePath, data);
        }

        private static IEnumerable<T> GetData<T>(string filePath)
        {
            if (!File.Exists(filePath))
                return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filePath));
        }

        public static void SaveSalesData(IEnumerable<SaleInfo> salesData) => SaveData(SalesFilePath, JsonSerializer.Serialize(salesData));
        public static void SaveLocationData(IEnumerable<Location> locationData) => SaveData(LocationsFilePath, JsonSerializer.Serialize(locationData));

        public static IEnumerable<SaleInfo> GetSalesInfo() => GetData<SaleInfo>(SalesFilePath);
        public static IEnumerable<Location> GetLocationInfo() => GetData<Location>(LocationsFilePath);
    }
}
