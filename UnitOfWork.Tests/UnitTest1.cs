using Moq;
using Microsoft.Extensions.Logging;
public class UnitTest1
{
    [Fact]
    public void ReduceStock_ProductWithStock_ReducesStock()
    {
        // Arrange
        var product = new Products
        {
            Id = 1,
            Name = "Test",
            Stock = 10
        };

        // Without Mock:
        // If ProductRepo had no constructor dependency, we could simply create it directly.
        //var repo = new ProductRepo();

        //Mock Testing - Because the constructor needs a dependency(Logger) - we create a Mock object
        var mockLogger = new Mock<ILogger<ProductRepo>>();
        var repo = new ProductRepo(mockLogger.Object);

        // Act
        repo.ReduceStock(product);

        // Assert
        Assert.Equal(9, product.Stock);

    }

    [Fact]
    public void ReduceStock_WhenStockIsZero_ThrowsException()
    {
        // Arrange
        var product = new Products
        {
            Id = 1,
            Name = "Test",
            Stock = 0
        };

        // Without Mock:
        // If ProductRepo had no constructor dependency, we could simply create it directly.
        //var repo = new ProductRepo();

        //Mock Testing - Because the constructor needs a dependency(Logger) - we create a Mock object
        var mockLogger = new Mock<ILogger<ProductRepo>>();
        var repo = new ProductRepo(mockLogger.Object);

        // Act - here we don't call the method throwing exception explicitly, because once the method
        //throws exception,our assert.exception never gets the chance to execute
        //repo.ReduceStock(product);

        // Assert
        Assert.Throws<InvalidOperationException>(() => repo.ReduceStock(product));

    }

    [Fact]
    public void ProductAdd_WhenProductNameIsNull_ThrowsException()
    {
        // Arrange
        var product = new Products
        {
            Id = 1,
            Name = null,
            Stock = 10
        };

        // Without Mock:
        // If ProductRepo had no constructor dependency, we could simply create it directly.
        //var repo = new ProductRepo();

        //Mock Testing - Because the constructor needs a dependency(Logger) - we create a Mock object
        var mockLogger = new Mock<ILogger<ProductRepo>>();
        var repo = new ProductRepo(mockLogger.Object);

        // Act - here we don't call the method throwing exception explicitly, because once the method
        //throws exception,our assert.exception never gets the chance to execute
        //repo.ReduceStock(product);

        // Assert
        Assert.Throws<ArgumentNullException>(() => repo.add(product));

    }
}