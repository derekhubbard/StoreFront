namespace StoreFront.Inventory.WorthCalculatorRule
{
    public class CadmiumWorthCalculatorRule : BaseWorthCalculatorRule
    {
        public override int Calculate(int shelfLife, int worth)
        {
            return worth;
        }
    }
}
