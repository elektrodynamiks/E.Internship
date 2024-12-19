using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using AofC.Models;

namespace AofC
{

    public class Day11Program
    {
        private List<long> pebbles;
        //private Dictionary<int, List<long>> blinks;

        public Day11Program()
        {
            Console.WriteLine($"Day11 Started!");
            string fileExample = "Day11Example.txt";
            string filePuzzle = "Day11Input.txt";
            //var fileName = fileExample;
            var fileName = filePuzzle;
            
            pebbles = new List<long>();
            //blinks = new Dictionary<int, List<long>>();
            
            CreatePebblesList(fileName);
            Day11Part1();

        }

        private void CreatePebblesList(string fileName)
        {
            string lines = File.ReadAllText(fileName);
            string RegPattern = @"(\d)+";
            Console.WriteLine(lines);
            foreach (Match match in Regex.Matches(lines, RegPattern))
            {
                pebbles.Add(Int32.Parse(match.Value)); 
              
            }
            //blinks.Add(0,pebbles);

        }
    
        

        private void Day11Part1()
        {
            for (int blink=0; blink < 75; blink++){
                //var pebbles = blinks[blink];
                var arrangement = new List<long>();
                //List<object> arrangement = new List<object>();
                foreach (var stone in pebbles)
                {
                    
                    //Console.Write(engrave);
                    if (stone == 0)
                    {
                        arrangement.Add(1);
                        //Console.WriteLine($" 0 to 1");
                    }
                    else if (((stone).ToString().Length % 2) == 0)
                    {
                        //Console.WriteLine($" odd digits");
                        string digits = stone.ToString();
                        int length = digits.Length;
                        int half = length / 2;
                        string digitLeft = digits.Substring(0, half);
                        string digitright =digits.Substring(length - half); 
                        // Console.WriteLine($"left {digitLeft} right{digitright}");
                        arrangement.Add(long.Parse(digitLeft)); 
                        arrangement.Add(long.Parse(digitright));

                    }
                    else
                    {   
                        arrangement.Add(stone * 2024);
                        //Console.WriteLine($"  multiplied by 2024");
                    }
                    
                }
                Console.WriteLine($"After {blink+1} blinks");
                //DisplayListInt(arrangement);
                //blinks.Add(1+blink, arrangement);
                pebbles = arrangement;
                Console.WriteLine($"stones: {arrangement.Count}");
                
            } 
           
          
        }
        private void Day11Part2(){}
        private void DisplayListInt(List<long> aList)
        {
            foreach (var el in aList)
            {
                Console.Write($"|{el}| ");
            }

            Console.WriteLine();

        }
    }
}

/* iterate a list
       foreach (var element in list)
           Console.Write(element);
   or like an array
       for (int index = 0; index < list.Count; index += 1)
           Console.Write(list[index]);
    iterate a dictionary
foreach(KeyValuePair<string, string> ele2 in My_dict2)
  {
    Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
    }
*/