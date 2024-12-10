// See https://aka.ms/new-console-template for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Microsoft.VisualBasic;

namespace AdventOfCode
{
    public class MapPlan
    {
        // MapPlan Navigation is from col/row 1 to last cols/row
        private char[][] plan; //field in class

        // only be accessed within the same class
        public char[][] Plan // property
        {
            get { return plan; }
            // set { plan = value; }
        }
        private uint[] mapSize;
        private uint[] MapSize
        {
            get { return mapSize; }
            // set { mapSize = value; }
        }

        public MapPlan(string mapFileName)
        {
            this.mapSize = GetMapSize(mapFileName);
            this.plan = CreateMapPlan(mapFileName);
            // PrintMapPlan(this.Plan);
        }

        public uint[] GetMapSize(string mapFileName)
        {
            var columns = (uint)Math.Abs(File.ReadLines(mapFileName).First().Length);
            var rows = (uint)File.ReadAllLines(mapFileName).Length;
            uint[] mapSize = [rows, columns];
            Console.WriteLine("The maze size is {0} x {1}", mapSize[0], mapSize[1]);
            return mapSize;
        }

        public char[][] initializePlan(uint[] mapSize)
        {
            var row = mapSize[0];
            var col = mapSize[1];
            char[][] jaggedArray = new char[row][];
            for (int i = 0; i < row; i++)
            {
                Console.WriteLine("row {0}:", i);
                jaggedArray[i] = new char[col];
            }
            return jaggedArray;
        }

        public char[][] CreateMapPlan(string mapFileName)
        {
            // initialize the mapPlan
            var result = initializePlan(mapSize);
            // read the map and assign the content
            IEnumerable<string> lines = File.ReadLines(mapFileName);
            var row = 0;
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                char[] xCordinates = line.ToArray();
                var col = 0;
                foreach (var xCord in xCordinates)
                {
                    result[row][col] = xCord;
                    Console.Write("[{0},{1}] {2} ", row, col, result[row][col]);
                    col += 1;
                }
                row += 1;
            }
            PrintMapPlan(result);
            return result;
        }

        public void PrintMapPlan(char[][] jaggedArray)
        {
            // outer for loop
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write("Element " + i + ": ");
                // inner for loop
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool inBounds(int xCord, int yCord)
        {
            // inside the map
            return (1 <= xCord && xCord <= mapSize[0]) & (1 <= yCord && yCord <= mapSize[1]);
        }

        public char ReadMap(int xCord, int yCord)
        {
            if (inBounds(xCord, yCord))
            {
                return this.plan[xCord - 1][yCord - 1];
            }
            return 'Œ';
        }

        public class Navigation
        {

            public char dir { get; set; }
            public uint xCord { get; set; }
            public uint yCord { get; set; }
            public uint step { get; set; }
            public bool block { get; set; }
        }

        public Navigation Navigate(Navigation nav)
        {
            
            switch (nav.dir)
            {
                case '>':
                    //
                    break;
                case 'v':
                    //
                    break;
                case '<':
                    //
                    break;
                case '^':
                    //
                    break;
                default:
                    //
                    break;
            }
            return 
        }

        class Program
        {
            static void Main(string[] args)
            {
                string fileName = "day08_example.txt";
                MapPlan myPlan = new MapPlan(fileName);
                var xyContent = myPlan.ReadMap(17, 5);
                Console.WriteLine(xyContent);
            }
        }
    }
}
