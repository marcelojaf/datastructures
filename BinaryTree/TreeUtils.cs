namespace BinaryTree;

public class TreeUtils
{
    public static TreeNode GenerateBinaryTree(int?[] values)
    {
        if (values == null || values.Length == 0)
        {
            return null;
        }

        TreeNode root = new TreeNode((int)values[0]);
        Queue<TreeNode> nodesQueue = new Queue<TreeNode>();
        nodesQueue.Enqueue(root);

        int currentIndex = 1;
        while (nodesQueue.Count > 0 && currentIndex < values.Length)
        {
            TreeNode currentNode = nodesQueue.Dequeue();

            // Tentar adicionar o filho à esquerda.
            if (currentIndex < values.Length && values[currentIndex] != null)
            {
                currentNode.left = new TreeNode((int)values[currentIndex]);
                nodesQueue.Enqueue(currentNode.left);
            }
            currentIndex++;

            // Tentar adicionar o filho à direita.
            if (currentIndex < values.Length && values[currentIndex] != null)
            {
                currentNode.right = new TreeNode((int)values[currentIndex]);
                nodesQueue.Enqueue(currentNode.right);
            }
            currentIndex++;
        }

        return root;
    }


    // Método para realizar a travessia "inorder" e retornar a lista de valores
    public static IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = [];
        InorderTraversalRec(root, result);
        return result;
    }

    // Método recursivo para auxiliar na travessia "inorder"
    private static void InorderTraversalRec(TreeNode node, List<int> result)
    {
        if (node != null)
        {
            InorderTraversalRec(node.left, result); // Visita a subárvore esquerda
            result.Add(node.val);                 // Visita o nó atual
            InorderTraversalRec(node.right, result); // Visita a subárvore direita
        }
    }

    public static int MaxDepth(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        int depthLevelLeft = MaxDepth(root.left);
        int depthLevelRight = MaxDepth(root.right);

        return 1 + Math.Max(depthLevelRight, depthLevelLeft);
    }
}
