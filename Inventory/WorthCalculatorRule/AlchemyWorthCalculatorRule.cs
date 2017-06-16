namespace StoreFront.Inventory.WorthCalculatorRule
{
    public class AlchemyWorthCalculatorRule : BaseWorthCalculatorRule
    {
        public override int Calculate(int shelfLife, int worth)
        {
            int newWorth;
            if (shelfLife >= 0)
            {
                newWorth = worth - 2;
            }
            else
            {
                newWorth = worth - 4;
            }

            return worth <= MinWorth ? MinWorth : newWorth;
        }
    }
}
