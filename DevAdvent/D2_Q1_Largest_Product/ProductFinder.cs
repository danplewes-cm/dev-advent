using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D2_Q1_Largest_Product
{
    class ProductFinder
    {
	    public class ProductResult
	    {
		    public int Product;
		    public List<int> Values;

		    public ProductResult(List<int> values)
		    {
			    Values = values;
			    if (values.Count == 3)
			    {
				    Product = values[0] * values[1] * values[2];
			    }
			    else
			    {
				    Product = 0;
			    }
		    }

		    public override string ToString()
		    {				
			    return $"Largest product is {Product}, [{string.Join(",", Values)}]";
		    }
	    }

	    private readonly List<int> _inputData;

	    public ProductFinder(List<int> inputData)
	    {
		    _inputData = inputData;
	    }

	    public ProductResult GetLargestProduct()
	    {
		    List<int> largestPos = new List<int>();
		    List<int> largestNeg = new List<int>();

			List<int> smallestPos = new List<int>();
			List<int> smallestNeg = new List<int>();

			// Get the three largest positive and negative numbers
		    for (int i = 0; i < _inputData.Count; i++)
		    {
			    var val = _inputData[i];
			    if (val >= 0)
			    {
				    if (largestPos.Count < 3)
				    {
						largestPos.Add(val);
				    }
				    else
				    {
					    var minIndex = 0;
					    var minValue = largestPos[0];
					    for (int j = 1; j < largestPos.Count; j++)
					    {
						    if (largestPos[j] < minValue)
						    {
							    minValue = largestPos[j];
							    minIndex = j;
						    }
					    }

					    if (val > minValue)
					    {
						    largestPos[minIndex] = val;
					    }
				    }

				    if (smallestPos.Count < 3)
				    {
					    smallestPos.Add(val);
				    }
				    else
				    {
						var maxIndex = 0;
					    var maxValue = smallestPos[0];
					    for (int j = 1; j < smallestPos.Count; j++)
					    {
						    if (smallestPos[j] > maxValue)
						    {
							    maxValue = smallestPos[j];
							    maxIndex = j;
						    }
					    }

					    if (val < maxValue)
					    {
						    smallestPos[maxIndex] = val;
					    }
					}
				}
			    else
			    {
					if (largestNeg.Count < 3)
					{
						largestNeg.Add(val);
					}
					else
					{
						var maxIndex = 0;
						var maxValue = largestNeg[0];
						for (int j = 1; j < largestNeg.Count; j++)
						{
							if (largestNeg[j] > maxValue)
							{
								maxValue = largestNeg[j];
								maxIndex = j;
							}
						}

						if (val < maxValue)
						{
							largestNeg[maxIndex] = val;
						}
					}

				    if (smallestNeg.Count < 3)
				    {
					    smallestNeg.Add(val);
				    }
				    else
				    {
					    var minIndex = 0;
					    var minValue = smallestNeg[0];
					    for (int j = 1; j < smallestNeg.Count; j++)
					    {
						    if (smallestNeg[j] < minValue)
						    {
							    minValue = smallestNeg[j];
							    minIndex = j;
						    }
					    }

					    if (val > minValue)
					    {
						    smallestNeg[minIndex] = val;
					    }
				    }
				}				
		    }

		    largestNeg.Sort();
			largestPos.Sort();

			smallestNeg.Sort();
		    smallestPos.Sort();

			// Case 1, 1 or less Negative
		    if (largestNeg.Count <= 1)
		    {
			    return new ProductResult(largestPos);
		    }

			// Case 2, All Negative
		    if (largestPos.Count == 0)
		    {
				return new ProductResult(smallestNeg);
		    }			

			// Case 3, Maximize
		    var largestPosProduct = new ProductResult(largestPos);

			List<int> mixed = new List<int> {largestPos.Last(), largestNeg[0], largestNeg[1]};
			var largestMixedProduct = new ProductResult(mixed);

		    if (largestPosProduct.Product > largestMixedProduct.Product)
		    {
			    return largestPosProduct;
		    }

		    return largestMixedProduct;
	    }
    }
}
