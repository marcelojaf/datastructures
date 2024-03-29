// See https://aka.ms/new-console-template for more information
using System.Xml.Schema;
using BinaryTree;

Console.WriteLine("Hello, World!");

//var node = TreeUtils.GenerateBinaryTree([1, null, 2]);
//var node = TreeUtils.GenerateBinaryTree([4, 2, 6, 1, 3, 5, 7]);

var node1 = TreeUtils.GenerateBinaryTree([3, null, 20, 15, 7]);
Console.WriteLine(TreeUtils.MaxDepth(node1));

var node2 = TreeUtils.GenerateBinaryTree([3, 9, 20, null, null, 15, 7]);
Console.WriteLine(TreeUtils.MaxDepth(node2));


var node3 = TreeUtils.GenerateBinaryTree([3, null, 20, null, 7, null, 8]);
Console.WriteLine(TreeUtils.MaxDepth(node3));