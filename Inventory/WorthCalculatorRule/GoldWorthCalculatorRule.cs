namespace StoreFront.Inventory.WorthCalculatorRule
{
    public class GoldWorthCalculatorRule : BaseWorthCalculatorRule
    {
        public override int Calculate(int shelfLife, int worth)
        {
            int newWorth = ++worth;

            return newWorth >= MaxWorth ? MaxWorth : newWorth;
        }
    }
}
