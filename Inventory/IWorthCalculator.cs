using StoreFront.Inventory.Model;

namespace StoreFront.Inventory
{
    public interface IWorthCalculator
    {
        Item UpdateWorth(Item item);
    }
}
