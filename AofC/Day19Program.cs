using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using AofC.Models;

namespace AofC
{

    public class Day19Program
    {
        Dictionary<string, string> Patterns;
        List<string> Designs;
        //List<string>matchingPattern;
        private int possibleDesign = 0;
        
        public Day19Program()
        {
            Console.WriteLine($"Day19 Started!");
            string fileExample = "Day19Example.txt";
            string filePuzzle = "Day19Input.txt";
            //var fileName = fileExample;
            var fileName = filePuzzle;
            
            Patterns = new Dictionary<string, string>();
            Designs = new List<string>();
         
            CreatePatternsDesigns(fileName);
            Day19Part1();
            
        }

        private void Day19Part1()
        {
           // check which pattern is included in design.
           // => List<string> matchingPattern
           foreach (var el in Designs)
           {
               var matchingPattern = new List<string>();   
               foreach (KeyValuePair<string, string> ele2 in Patterns)
               {
                   var include = el.Contains((ele2.Value));
                   //Console.WriteLine($"{el} has {ele2.Value}: {include}");
                   if (include)
                   {
                       matchingPattern.Add(ele2.Value);
                       //Console.WriteLine(ele2.Value);
                   }
                   
               }
               // order the list 
               matchingPattern.Sort((x, y) => y.Length.CompareTo(x.Length));
           
               
               // check for pattern composition
               var str = el;
               Console.Write($"{el} :");
               DisplayListStr(matchingPattern);
               
               foreach (var pattern in matchingPattern)
               {
                   do
                   {
                       str = str.Replace(pattern, " ");
                      // Console.WriteLine($"{str}");
                   } while (str.Contains(pattern));
                   
               }
               if (str.Trim() == "")
               {
                   
                   possibleDesign++;
               }
               Console.Write($" [{str.Trim()}]");
               Console.WriteLine(possibleDesign);

           }
           Console.WriteLine($"Possible Designs: {possibleDesign}");
        }
        private void CreatePatternsDesigns(string fileName)
        {
            string Pattern= @"(\w)+";
            
            IEnumerable<string> lines = File.ReadLines(fileName);
            foreach (var line in lines)
            {
                if (line.Contains(","))
                {
                    foreach (Match match in Regex.Matches(line, Pattern))
                    {
                        Patterns.Add(match.Value, match.Value);
                        // Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                    }
                }
                else 
                {
                    if (line != "")
                    {
                        foreach (Match match in Regex.Matches(line, Pattern))
                        {
                            Designs.Add(match.Value);
                            //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                        }
                    }
                }
            }

            //DisplayDictionary(Patterns);
            //DisplayListStr(Designs);
        }
        private void DisplayDictionary(Dictionary<string, string> myDictionary)
        {
            foreach (KeyValuePair<string, string> ele2 in myDictionary)
            {
                Console.WriteLine("key:{0} & {1}", ele2.Key, ele2.Value);
            }
        }
        private void DisplayListStr(List<string> aList)
        {
            foreach (var el in aList)
            { Console.Write($"{el} "); }
            //Console.WriteLine();

        }
    }
}


/* iterate a list
       foreach (var element in list)
           Console.Write(element);
   or like an array
       for (int index = 0; index < list.Count; index += 1)
           Console.Write(list[index]);

foreach(KeyValuePair<string, string> ele2 in My_dict2)
  {
                Console.WriteLine("{0} and {1}", ele2.Key, ele2.Value);
    }
*/