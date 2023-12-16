using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Possible_coin_combinations
{
    internal class Coin_Combinator
    {
        private static readonly double[] Coins = { 0.01, 0.02, 0.05, 0.10, 0.20, 0.50, 1.00, 2.00 };
        private List<List<double>> combinations = new List<List<double>>();

        private void FindCombinations(List<double> current, double amount, int index)
        {
            if (amount == 0 && current.Count <= 10)
            {
                combinations.Add(new List<double>(current));
                return;
            }

            if (amount < 0 || current.Count > 10 || index >= Coins.Length)
            {
                return;
            }

            for (int i = index; i < Coins.Length; i++)
            {
                current.Add(Coins[i]);
                FindCombinations(current, amount - Coins[i], i);
              
                current.RemoveAt(current.Count - 1);
            }
        }

        public List<List<double>> GetAllCombinations(double amount)
        {
            if (amount <= 0 || amount > 5.00)
            {
                return new List<List<double>>();
            }

            combinations.Clear();
            FindCombinations(new List<double>(), amount, 0);
            return combinations;
        }

        public List<double> GetMinimumCoinCombination(double amount)
        {
            return GetAllCombinations(amount).OrderBy(c => c.Count).FirstOrDefault();
        }
    }
}
