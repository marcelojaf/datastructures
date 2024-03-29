using System.ComponentModel.Design.Serialization;

namespace BinaryTree;

public class TreeUtils
{
    public static TreeNode GenerateBinaryTree(int?[] values)
    {

        // [root, left, right, left.left, left.right, right.left, right.right]
        if (values == null || values.Length == 0)
        {
            return null;
        }

        TreeNode root = new TreeNode((int)values[0]);
        TreeNode currentNode = root;

        for (int i = 1; i < values.Length; i++)
        {
            if (i % 2 > 0) // Impar. Esquerda
            {
                AddNodeToATree(currentNode.left, (int)values[i]);
            }
            else
            {
                AddNodeToATree(currentNode.right, (int)values[i]);
            }
        }

        return root;
    }

    public static void AddNodeToATree(TreeNode root, int val)
    {
        root.left = new TreeNode(val);
    }
}
