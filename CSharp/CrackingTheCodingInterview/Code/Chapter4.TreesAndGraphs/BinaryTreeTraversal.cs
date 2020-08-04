using System;

namespace Chapter4.TreesAndGraphs {
    public class Node {
        public string Name;
        public Node[] Children;
    }

    public class Tree {
        public Node Root;
    }

    public class TreeNode {
        public TreeNode Left;
        public TreeNode Right;
    }

    public static partial class MyExtensions {

        public static void dot_Visit(TreeNode node) {
            Console.WriteLine($"{node}");
        }

        // performs search in ascending order
        public static void dot_InOrderTraversal(this TreeNode node) 
        {
            if(node !=null) {
                dot_InOrderTraversal(node.Left);
                dot_Visit(node);
                dot_InOrderTraversal(node.Right);
            }
        }

        /// root is always the first node visited
        public static void dot_PreOrderTraversal(this TreeNode node) 
        {
            if(node !=null) {
                dot_Visit(node);
                dot_PreOrderTraversal(node.Left);
                dot_PreOrderTraversal(node.Right);
            }
        }

        /// root is always the last node visited
        public static void dot_PostOrderTraversal(this TreeNode node) {
            if(node != null) {
                dot_PostOrderTraversal(node.Left);
                dot_PostOrderTraversal(node.Right);
                dot_Visit(node);
            }
        }
    }
}