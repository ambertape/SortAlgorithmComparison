namespace SortAlgorithmComparison.Model;

/// <summary>
/// Simplified tree node.
/// </summary>
public class TreeNode
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TreeNode"/> class.
    /// </summary>
    /// <param name="data">Data.</param>
    public TreeNode(int data)
    {
        Data = data;
    }

    /// <summary>
    /// Gets or sets data.
    /// </summary>
    public int Data { get; set; }

    /// <summary>
    /// Gets or sets left branch.
    /// </summary>
    public TreeNode Left { get; set; }

    /// <summary>
    /// Gets or sets right branch.
    /// </summary>
    public TreeNode Right { get; set; }

    /// <summary>
    /// Inserts node to tree.
    /// </summary>
    /// <param name="node">Node.</param>
    public void Insert(TreeNode node)
    {
        if (node.Data < Data)
        {
            if (Left == null)
            {
                Left = node;
            }
            else
            {
                Left.Insert(node);
            }
        }
        else
        {
            if (Right == null)
            {
                Right = node;
            }
            else
            {
                Right.Insert(node);
            }
        }
    }

    /// <summary>
    /// Transforms tree to sorted array.
    /// </summary>
    /// <param name="elements">Elements.</param>
    /// <returns>Returns array.</returns>
    public int[] Transform(List<int>? elements = null)
    {
        elements ??= new List<int>();

        if (Left != null)
        {
            Left.Transform(elements);
        }

        elements.Add(Data);

        if (Right != null)
        {
            Right.Transform(elements);
        }

        return elements.ToArray();
    }
}
