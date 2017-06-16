namespace StoreFront.Inventory.WorthCalculatorRule
{
    public class HeliumWorthCalculatorRule : BaseWorthCalculatorRule
    {
        public override int Calculate(int shelfLife, int worth)
        {
            int newWorth;
            if (shelfLife > 10)
            {
                newWorth = ++worth;
            }
            else if (shelfLife <= 10 && shelfLife > 5)
            {
                newWorth = worth + 2;
            }
            else if (shelfLife <= 5 && shelfLife >= 0)
            {
                newWorth = worth + 3;
            }
            else
            {
                newWorth = 0;
            }

            return newWorth >= MaxWorth ? MaxWorth : newWorth;
        }
    }
}
