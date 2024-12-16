using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using AofC.Models;

namespace AofC
{

    public class AofCDay05
    {
        List<int[]> rules;
        List<int[]> prints;
        private List<int> validPrints;

        public AofCDay05()
        {
            string fileExample = "day05Example.txt";

            string filePuzzle = "day05Input.txt";

            var fileName = fileExample;
            //var fileName = filePuzzle;



            Day05Part1(fileName);
        }

        private void Day05Part1(string fileName)
        {
            // separates rules and prints
            CreateRulesPrints(fileName);
            // check prints - agains rules
            CheckPrints();
        }

        private void CreateRulesPrints(string fileName)
        {
            rules = new List<int[]>();
            prints = new List<int[]>();
            // regex separate with |
            string patternRule = @"(\d)+";
            // regex separate with '
            string patternPrint = @"(\d)+";
            //
            IEnumerable<string> lines = File.ReadLines(fileName);
            foreach (var line in lines)
            {
                if (line.Contains("|"))
                {
                    var Rule = new List<int>();
                    foreach (Match match in Regex.Matches(line, patternRule))
                    {
                        Rule.Add(Int32.Parse(match.Value));
                        // Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                    }

                    rules.Add(Rule.ToArray());


                }
                else // (line.Contains(","));
                {
                    if (line != "")
                    {
                        var Print = new List<int>();
                        foreach (Match match in Regex.Matches(line, patternPrint))
                        {
                            Print.Add(Int32.Parse(match.Value));
                            //Console.WriteLine("Found '{0}' at position {1}", match.Value, match.Index);
                        }

                        prints.Add(Print.ToArray());
                    }
                }
            }

            Console.WriteLine($"Rules has {rules.Count} rules");
            Console.WriteLine($"Prints has {prints.Count} prints");
        }

        private void CheckPrints()
        {
            foreach (var print in prints)
            {
              
                for (int index = 0; index <= print.Count(); index += 1)
                {
                    for (int target = index + 1; target <= print.Count(); target += 1)
                    {
                        Console.WriteLine($"Compare for print: page[{index}] with page[{target}]");
                    }
                }
            }
        }
    }
}
/* iterate a list
       foreach (var element in list)
           Console.Write(element);
   or like an array
       for (int index = 0; index < list.Count; index += 1)
           Console.Write(list[index]);
*/