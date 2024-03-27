// See https://aka.ms/new-console-template for more information
using StringManipulation;

Console.WriteLine("Hello, World!");

Console.WriteLine(StringUtils.timeConversion("12:05:45AM"));
Console.WriteLine(StringUtils.timeConversion("07:05:45PM"));
Console.WriteLine(StringUtils.timeConversion("11:59:59PM"));
Console.WriteLine(StringUtils.timeConversion("01:10:59AM"));
Console.WriteLine(StringUtils.timeConversion("12:00:00AM"));
Console.WriteLine(StringUtils.timeConversion("12:00:00PM"));