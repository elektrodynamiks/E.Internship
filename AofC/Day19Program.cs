using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using AofC.Models;


namespace AofC
{

    public class Day19Program
    {
        List<string> patterns;
        List<string> designs;
        //List<string>matchingPattern;
        private int possibleDesign = 0;
        
        public Day19Program()
        {
            Console.WriteLine($"Day19 Started!");
            string fileExample = "Day19Example.txt";
            string filePuzzle = "Day19Input.txt";
            string validDesign = "Day19ValidDesign.txt";
            //var fileName = fileExample;
            var fileName = filePuzzle;
            
            patterns = new List<string>();
            designs = new List<string>();
         
            //Lists of patterns,designs    
            CreatePatternsDesigns(fileName);
            
             Day19Part1();
             

        }

        private void Day19Part1()
        {
           // check which pattern is included in design.
           // => List<string> matchingPattern
           var i = 0;
           foreach (var design in designs)
           {
               //var matchPattern = GetThePatternIncluded(design);
               // Console.WriteLine(design);
               // var regexPattern = CreateRegexPattern(matchPattern);
               // Console.WriteLine(regexPattern);
               // CheckForPatternDesignMatch(design, regexPattern);
             CheckForPatternDesignMatchRandom(design);
              
               //if (i >= 10) {break;}

               i++;
           }

           Console.WriteLine(possibleDesign);

        }

        private void CheckForPatternDesignMatchRandom(string design)
        {
            var i = 0;
            var match = false;
            var order = "none";
            //Console.WriteLine($"creating: {design}");
            do
            {
                if (i >= 1)
                {
                    order = "random"; }

                
                var matchPattern = GetThePatternIncluded(design, order);
                var regexPattern = CreateRegexPattern(matchPattern);
                //Console.WriteLine(regexPattern);
                match = CheckForPatternDesignMatch(design, regexPattern);
                //Console.WriteLine($"try {i} :{match}");
                i++;
                
            } while (i <= 150 && !match);

        }

        private bool CheckForPatternDesignMatch(string design, string regexPattern)
        {
            var copy = design;
            string pattern = @regexPattern ;
            
            foreach (Match match in Regex.Matches(design, pattern, RegexOptions.Compiled))
            {
                //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                design = design.Replace(match.Value,"");
            }

            if (design.Length == 0)
            { 
                // Console.WriteLine($"Pattern is matching!");
                Console.WriteLine($"{copy}");
                possibleDesign++;
                return true;
            }
            //Console.WriteLine(design);
            return false;
        }
        

        private List<string> GetThePatternIncluded(string design, string order = "none")
        {
            var matchingPattern = new List<string>();   
            foreach (var pattern in patterns)
            {
                var include = design.Contains(pattern);
                if (include)
                {
                    matchingPattern.Add(pattern);
                }
                   
            }
            // order the list 
            if (order == "none")
            { 
                matchingPattern.Sort((x, y) => y.Length.CompareTo(x.Length));
            }
            else if (order == "increasing")
            { 
                matchingPattern.Sort((x, y) => x.Length.CompareTo(y.Length));
            }
            else if (order == "decreasing")
            { 
                matchingPattern.Sort((x, y) => y.Length.CompareTo(x.Length));
            }
            else if (order == "random")
            {
                Random rnd = new Random(DateTime.Now.Millisecond);
                matchingPattern = matchingPattern.Select(item => new { item, order = rnd.Next()})
                    .OrderBy(x => x.order).Select(x => x.item)
                    .ToList();
            }

            return matchingPattern;
        }
        
        private string CreateRegexPattern(List<string> matchingPattern)
        {
            string regex = "(";
            foreach (var strPattern in matchingPattern )
            {
                regex += ($"({strPattern})|");
            }

            regex = regex.TrimEnd('|');
            regex += ")+";
            return regex;
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
                        patterns.Add(match.Value);
                        // Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                    }
                }
                else 
                {
                    if (line != "")
                    {
                        foreach (Match match in Regex.Matches(line, Pattern))
                        {
                            designs.Add(match.Value);
                            //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                        }
                    }
                }
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