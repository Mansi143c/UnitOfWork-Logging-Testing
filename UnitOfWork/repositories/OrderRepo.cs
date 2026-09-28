using Microsoft.Extensions.Logging;
public class OrderRepo : IOrderRepo
{
	private readonly ILogger<OrderRepo> _logger; 
	private List<Orders> _orders = new List<Orders>();
	public OrderRepo(ILogger<OrderRepo> logger)
	{
		_logger = logger;
	}
	public void add(Orders o)
	{
		_orders.Add(o);
		_logger.LogInformation("Order {OrderId} added", o.Id);
	}
}