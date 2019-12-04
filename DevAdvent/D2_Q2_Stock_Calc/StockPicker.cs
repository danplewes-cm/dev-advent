using System;
using System.Collections.Generic;
using System.Text;

namespace D2_Q2_Stock_Calc
{
    class StockPicker
    {
	    public class StockResult
	    {
		    public int Profit => SellPrice - BuyPrice;
		    public int BuyPrice;
		    public int SellPrice;
			
		    public StockResult(int buyPrice, int sellPrice)
		    {
			    BuyPrice = buyPrice;
			    SellPrice = sellPrice;
		    }

		    public override string ToString()
		    {
			    return $"Largest profit is {Profit}, [{BuyPrice},{SellPrice}]";
		    }
	    }

		private readonly List<int> _inputData;

	    public StockPicker(List<int> inputData)
	    {
		    _inputData = inputData;
	    }

	    public StockResult DetermineMaxProfit()
	    {
		    int currSell = -1;
		    int currBuy = _inputData[0];

			StockResult bestResult = null;

		    for (int i = 1; i < _inputData.Count; i++)
		    {
			    var currVal = _inputData[i];
			    if (currSell < 0)
			    {
				    if (currVal < currBuy)
				    {
					    currBuy = currVal;
				    }
				    else
				    {
					    currSell = currVal;				    
				    }
			    }
			    else
			    {
				    if (currVal > currSell)
				    {
					    currSell = currVal;
				    }

				    if (currVal < currBuy)
				    {
					    currBuy = currVal;
					    currSell = -1;
				    }
			    }

			    if (currSell > 0)
			    {
				    if (bestResult == null || currSell - currBuy > bestResult.Profit)
				    {
					    bestResult = new StockResult(currBuy, currSell);
				    }
				    else if (currSell > bestResult.SellPrice)
				    {
					    bestResult.SellPrice = currSell;
				    }
				}			    
		    }

		    return bestResult;
	    }
	}
}
