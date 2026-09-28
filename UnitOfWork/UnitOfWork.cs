public class UnitOfWork
{
	public IOrderRepo _orders { get; }
	public IProductRepo _products { get; }

	public UnitOfWork(IOrderRepo orderRepo, IProductRepo products)
	{
		_orders = orderRepo;
		_products = products;
	}
	public void SaveChanges()
	{
		Console.WriteLine("All changes saved!");
	}
}