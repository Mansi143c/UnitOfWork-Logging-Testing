public class OrderService : IOrderService
{
    public readonly UnitOfWork _unitOfWork;
    public OrderService(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public void placeOrder(Products product, Orders order)
    {
        _unitOfWork._orders.add(order);

        _unitOfWork._products.add(product);

        _unitOfWork._products.ReduceStock(product);

        _unitOfWork.SaveChanges();
    }
}