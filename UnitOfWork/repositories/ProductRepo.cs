using Microsoft.Extensions.Logging;
public class ProductRepo : IProductRepo
{
    public readonly ILogger<ProductRepo> _logger;
    private List<Products> _products = new List<Products>();
    public ProductRepo(ILogger<ProductRepo> logger)
    {
        _logger = logger;
    }
    public void add(Products p)
    {
        if (p.Name == null)
        {
            throw new ArgumentNullException(nameof(p.Name),"Product name cannot be null or empty.");
        }
        _products.Add(p);
        Console.WriteLine("Products added");
        _logger.LogInformation("Product {Id} added", p.Id);

    }
    public void ReduceStock(Products product)
    {
        if (product.Stock <= 0) 
        {
            throw new InvalidOperationException("Product is out of Stock.");
        }
        product.Stock = product.Stock - 1;
        Console.WriteLine("Stock reduced to " + product.Stock);
        _logger.LogInformation("Remaining items " +  product.Stock);
    }
}