

namespace ApplicationCore.Interfaces.services
{
    using ApplicationCore.Entities.OrderAggregate;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        Task CreateOrderAsync(int basketId, Address shippingAddress);
    }
}
