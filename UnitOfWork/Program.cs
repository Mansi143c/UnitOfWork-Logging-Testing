using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

//Logging in file
LoggingConfig.Configure();
var services = new ServiceCollection();
services.AddLogging(config =>
{
    config.AddSerilog(Log.Logger);
});
//////////////////////////For logging in console/////////////////////////
///
/*
services.AddLogging(config =>
{
    config.AddConsole();
});
*/
services.AddTransient<IOrderRepo,OrderRepo>();
services.AddTransient<IProductRepo, ProductRepo>();
services.AddTransient<UnitOfWork>();
services.AddTransient<IOrderService, OrderService>();

var serviceProvider = services.BuildServiceProvider();
var orderService = serviceProvider.GetRequiredService<IOrderService>();
var loggerService = serviceProvider.GetRequiredService<ILogger<Program>>();


Products product = new Products
{
    Id = 1,
    Name = null,
    Stock = 0
};
Orders orders = new Orders
{
    Id = 1,
    ProductName = product.Name,
};


//////////////////////////EXCEPTION HANDLING////////////////////////////
try
{
    orderService.placeOrder(product, orders);
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
    loggerService.LogError(ex, "Invalid product data");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    loggerService.LogError(ex, "Failed to place order");
}








