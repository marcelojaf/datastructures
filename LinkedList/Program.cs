// See https://aka.ms/new-console-template for more information
using LinkedList;

Console.WriteLine("Hello, World!");

//var listWithCycle = ListNodeUtils.CreateLinkedList([1, 2, 3, 4, 5, 6, 7, 8]);
var listWithCycle = ListNodeUtils.CreateLinkedList([1, 2, 3, 4, 5]);
//var listWithCycle = ListNodeUtils.CreateLinkedList([2, 1, 3, 5, 6, 4, 7]);

var listNodeWhereCycleBegins = ListNodeUtils.OddEvenList(listWithCycle);

Console.WriteLine(ListNodeUtils.PrintLinkedList(listNodeWhereCycleBegins));