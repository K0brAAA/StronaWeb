using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;




public interface IDataService
{
    Task<List<Product>> GetProductsAsync();
}

public class DataService : IDataService
{
    public async Task<List<Product>> GetProductsAsync()
    {
        string jsonFilePath = "D:\\StronaWeb\\StronaWeb1\\StronaWeb1\\wwwroot\\Produkts.json";

        string json = await File.ReadAllTextAsync(jsonFilePath);

        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);

        return products ?? new List<Product>(); // Возвращаем список или пустой список, если данные не загрузились
    }
}

public class Product
{
    public required string nazwanie { get; set; }
    public decimal price { get; set; }
    public string? processor { get; set; }
    public string? graphics_card { get; set; }
    public string? ram { get; set; }
    public string? storage { get; set; }
    public string? image_url { get; set; }
}
