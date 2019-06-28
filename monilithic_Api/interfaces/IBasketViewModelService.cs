

namespace monilithic_Api.interfaces
{
    using monilithic_Api.ViewModels.basketViewModel;
    using System.Threading.Tasks;

    public interface IBasketViewModelService
    {
        Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    }
}
