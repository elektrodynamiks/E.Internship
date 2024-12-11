using System;
using MapPlanClass;
using NavigationClass;

namespace AdventofCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileExample = "day06_example.txt";
            string filePuzzle = "day06_input.txt";
            // Part I
            var fileName = fileExample;
            MapPlan myPlan = new MapPlan(fileName);
            Navigation myNav = new Navigation(myPlan);
        }
    }
}
