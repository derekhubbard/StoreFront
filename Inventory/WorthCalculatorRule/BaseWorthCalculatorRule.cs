namespace StoreFront.Inventory.WorthCalculatorRule
{
    public class BaseWorthCalculatorRule
    {
        public const int MaxWorth = 50;
        public const int MinWorth = 0;

        public virtual int Calculate(int shelfLife, int worth)
        {
            int newWorth;
            if (shelfLife >= 0)
            {
                newWorth = --worth;
            }
            else
            {
                newWorth = worth - 2;
            }

            return newWorth <= MinWorth ? MinWorth : newWorth;
        }
    }
}
    