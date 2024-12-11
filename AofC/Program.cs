using System;
using CartesianMapClass;
using NavigationClass;

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
            Navigation myNav = new Navigation(myMap);
        }
    }
}
