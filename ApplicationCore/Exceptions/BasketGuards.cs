
namespace Ardalis.GuardClauses
{
    using ApplicationCore.Entities.BasketAggregate;
    using ApplicationCore.Exceptions;

    public static class BasketGuards
    {
        public static void NullBasket(this IGuardClause guardClause, int basketId, Basket basket)
        {
            if (basket == null)
                throw new BasketNotFoundException(basketId);
        }
    }
}
