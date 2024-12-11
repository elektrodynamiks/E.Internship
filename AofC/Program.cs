using System;
using CartesianMapClass;

namespace AdventofCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileExample = "day06_example.txt";
            // string filePuzzle = "day06_input.txt";
            // Part I
            var fileName = fileExample;
            CartesianMap myMap = new CartesianMap(fileName);
        }
    }
}
