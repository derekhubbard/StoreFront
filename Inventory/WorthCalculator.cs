using System.Collections.Generic;
using System.Linq;
using StoreFront.Inventory.Model;
using StoreFront.Inventory.WorthCalculatorRule;

namespace StoreFront.Inventory
{
    public class WorthCalculator : IWorthCalculator
    {
        readonly BaseWorthCalculatorRule _defaultWorthCalculator = new BaseWorthCalculatorRule();
        readonly Dictionary<string, BaseWorthCalculatorRule> _worthCalculators;

        public WorthCalculator()
        {
            // rules tend to be one-one with items. 
            // if that isn't the case in the future, rules can be renamed to be more generic, 
            // with the intent that they are applicable to multiple items.
            _worthCalculators = new Dictionary<string, BaseWorthCalculatorRule>
                {
                    {"Alchemy", new AlchemyWorthCalculatorRule()},
                    {"Gold", new GoldWorthCalculatorRule()},
                    {"Cadmium", new CadmiumWorthCalculatorRule()},
                    {"Helium", new HeliumWorthCalculatorRule()}
                };
        }

        public WorthCalculator(Dictionary<string, BaseWorthCalculatorRule> worthCalculators)
        {
            _worthCalculators = worthCalculators;
        }

        public Item UpdateWorth(Item t)
        {
            t.ShelfLife--;

            var rule = GetWorthCalculatorRule(t.Name);

            t.Worth = rule.Calculate(t.ShelfLife, t.Worth);

            return t;
        }

        public BaseWorthCalculatorRule GetWorthCalculatorRule(string name)
        {
            var rule = _worthCalculators.FirstOrDefault(x => x.Key == name);
            if (rule.Value != null)
            {
                return rule.Value;
            }

            return _defaultWorthCalculator;
        }
    }
}
