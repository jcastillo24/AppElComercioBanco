using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppElComercio
{
    public class MoneyParts
    {
        private readonly List<decimal> Denominations = new List<decimal>{200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m};
        private List<List<decimal>> Result { get; set; }
        public List<List<decimal>> Build(decimal amount)
        {
            Result = new List<List<decimal>>();
            GetCombinations(amount);
            return Result;
        }
        private void GetCombinations(decimal amount, decimal denominationCurrent = 0m, List<decimal> groupResult = null)
        {
            denominationCurrent = denominationCurrent == 0m ? Denominations.First() : denominationCurrent;
            groupResult = groupResult == null ? new List<decimal>() : groupResult;
            var indexNextDenomination = Denominations.IndexOf(denominationCurrent) + 1;
            //Buscamos el numero de montos incluidos en la demonicacion actual
            var multiple = (int)Math.Floor((amount / denominationCurrent));
            do
            {
                var resultAux = new List<decimal>(groupResult);
                for (int y = 0; y < multiple; y++)
                    resultAux.Add(denominationCurrent);
                if (amount - (denominationCurrent * multiple) < Denominations.Last() && amount != 0)
                    Result.Add(resultAux);
                if (denominationCurrent == Denominations.Last())
                    break;
                GetCombinations(amount - (denominationCurrent * multiple), Denominations[indexNextDenomination], resultAux);
                multiple--;
            } while (multiple >= 0);
        }
    }
}
