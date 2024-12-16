using System;
using System.Collections.Generic;
using AofC.Models;

namespace AofC
{
    
    public class AofCDay08
    {
        private Map myMap;
        private char[][] map;
        
        List<int[]> positions;
        private Dictionary<char, List<int[]>> antennas;

        public AofCDay08()
        {
            string fileExample = "day08_example.txt";
            string filePuzzle = "day08_input.txt";
            var fileName = fileExample;
            // var fileName = filePuzzle;
           
            myMap = new Map(fileName);
            map = myMap.map;
            Day08Part1();
        }

        private void Day08Part1()
        {
            
            // read the map and store positions for each antenna
            // antennas are stored in dictionary with key as char named: 'antenna'.
            // each antennas has positions [x,y] int[] of size 2 stored in a list
            
            char antenna = map[6][5];
            Console.WriteLine(antenna);
            positions = new List<int[]>();
            positions.Add([10, 10]);
            antennas= new Dictionary<char, List<int[]>>();
            antennas.Add( 'A', positions );
            int[] values = { 10, 20, 30, 40, 50 };

            Console.WriteLine(values);
        
        }

        private void ListAntennaPositions()
        {
            // outer for loop abscissa
            for (int j = 0; j < map.Length; j++)
            {
                // inner for loop ordinate
                for (int i = 0; i < map[j].Length; i++)
                {
                    Console.Write("[{0}]", jaggedArray[i][j]);
                }

        }

        private void AddToAntennas(char antenna,int[] position )
        {
            // add or create position for antenna 'char' 
            antennas.ContainsKey(antenna);
         
        }

    }
}


/* iterate by key for dictionay
    foreach (var key in dictionary.Keys)
        Console.WriteLine(${key}={dictionary[key]}}
or by pair
    foreach (var pair in dictionary)
        Console.WriteLine($"{pair.key} = {pair.value}")};
*/
/* iterate a list
    foreach (element in list)
        Console.Write(element);
or like an array
    for (int index = 0; index < list.Count; index += 1)
        Console.Write(list[index]);
*/