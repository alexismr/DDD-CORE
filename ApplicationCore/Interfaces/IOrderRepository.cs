

namespace ApplicationCore.Interfaces
{
    using ApplicationCore.Entities.OrderAggregate;
    using System.Threading.Tasks;

    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<Order> GetByIdWithItemsAsync(int id);
    }
}
