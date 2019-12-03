using System;

namespace Q2_Medians
{
	/// <summary>
	/// Self balancing tree.
	///  - Will maintain an even number of left and right children
	///  - If tree has an even number of nodes the median will be the root value
	///  - If the tree has an odd number, average the root with the Max/Min of the Left/Right child
	/// </summary>
    class SelfBalancingTree
    {
	    private TreeNode _root;	    

	    public SelfBalancingTree()
	    {
		    _root = null;
	    }

	    public double GetMedian()
	    {
		    if (_root == null)
			    return Double.NaN;

		    if (_root.GetCount() % 2 == 1)
			    return _root.Value;

		    if (_root.LeftTreeCount > _root.RightTreeCount)
		    {
			    return ((double)_root.Value + _root.LeftTree.MaxValue) / 2;
		    }
			
			return ((double)_root.Value + _root.RightTree.MinValue) / 2;
		}

	    public void AddValue(int value)
	    {
		    if (_root == null)
		    {
				_root = new TreeNode(value);
		    }
		    else
		    {
				_root = Insert(_root, new TreeNode(value));
		    }				
	    }

	    private TreeNode Insert(TreeNode currNode, TreeNode newNode)
	    {
		    if (currNode == null)
		    {
			    currNode = newNode;
			    return currNode;
		    }

		    if (newNode.Value <= currNode.Value)
		    {
			    currNode.LeftTree = Insert(currNode.LeftTree, newNode);
			    return BalanceTree(currNode);
		    }

		    currNode.RightTree = Insert(currNode.RightTree, newNode);
		    return BalanceTree(currNode);			
		}

	    private TreeNode BalanceTree(TreeNode currNode)
	    {
		    if (currNode == null)
			    return null;

		    int pivotAmount = currNode.LeftTreeCount - currNode.RightTreeCount;

		    if (pivotAmount > 1)
		    {
			    if (currNode.LeftTree.LeftTreeCount - currNode.LeftTree.RightTreeCount > 0)
			    {
				    currNode = RotateLL(currNode);
			    }
			    else
			    {
				    currNode = RotateLR(currNode);
			    }
		    }
		    else if (pivotAmount < -1)
		    {
				if (currNode.RightTree.LeftTreeCount - currNode.RightTree.RightTreeCount > 0)
				{
					currNode = RotateRL(currNode);
				}
				else
				{
					currNode = RotateRR(currNode);
				}
			}

		    return currNode;
	    }

	    private TreeNode RotateRR(TreeNode parent)
	    {
		    TreeNode pivot = parent.RightTree;
		    parent.RightTree = pivot.LeftTree;
		    pivot.LeftTree = parent;
		    return pivot;
	    }

	    private TreeNode RotateLL(TreeNode parent)
	    {
		    TreeNode pivot = parent.LeftTree;
			parent.LeftTree = pivot.RightTree;
		    pivot.RightTree = parent;
		    return pivot;
	    }

	    private TreeNode RotateLR(TreeNode parent)
	    {
		    TreeNode pivot = parent.LeftTree;
		    parent.LeftTree = RotateRR(pivot);

			return RotateLL(parent);
	    }

	    private TreeNode RotateRL(TreeNode parent)
	    {
		    TreeNode pivot = parent.RightTree;
		    parent.RightTree = RotateLL(pivot);

		    return RotateRR(parent);
	    }
	}

	class TreeNode
	{
		public int Value { get; }

		public int MinValue
		{
			get
			{
				if (LeftTree != null)
					return LeftTree.MinValue;

				return Value;
			}
		}

		public int MaxValue
		{
			get
			{
				if (RightTree != null)
					return RightTree.MaxValue;

				return Value;
			}
		}

		public TreeNode LeftTree { get; set; }
		public int LeftTreeCount => LeftTree?.GetCount() ?? 0;

		public TreeNode RightTree { get; set; }
		public int RightTreeCount => RightTree?.GetCount() ?? 0;

		public TreeNode(int value)
		{
			Value = value;
			LeftTree = null;
			RightTree = null;
		}		

		public int GetCount()
		{
			return 1 + (LeftTree?.GetCount() ?? 0) + (RightTree?.GetCount() ?? 0);
		}
	}
}
