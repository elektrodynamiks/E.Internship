﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string input =
            "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))&&&xmul(2,4)";

        //Create a FileInfo instance representing an existing text file.
        FileInfo MyFile = new FileInfo(@"day03_input.txt");
        //Instantiate a StreamReader to read from the text file.
        StreamReader reader = MyFile.OpenText();
        // Read the stream as a string.
        string puzzle_input = reader.ReadToEnd();

        static string PurgeCorruptedMem(string input)
        {
            string replacement = "";
            string pattern = @"don\'t.*?do\(\)";
            // Instantiate the regular expression object.
            Regex r = new Regex(pattern, RegexOptions.Singleline);
            // Match the regular expression pattern against a text string.
            bool isMatch = Regex.IsMatch(input, pattern);
            Console.WriteLine(isMatch);
            while (isMatch)
            {
                input = Regex.Replace(input, pattern, replacement, RegexOptions.Singleline);
                isMatch = Regex.IsMatch(input, pattern);
                // Console.WriteLine(input);
            }
            return input;
        }

        input = puzzle_input;
        //Console.WriteLine(input);
        string memory_data = PurgeCorruptedMem(input);
        Console.WriteLine(input);
        string path = @"day03_part2.txt";

        // This text is added only once to the file.
        if (!File.Exists(path))
        {
            // Create a file to write to.
            File.WriteAllText(path, memory_data);
        }
        // loop purge until file is clean.



        // Write the puzzle_input to the console.
        //Console.WriteLine(puzzle_input);

        // string pattern = @"((\w+)[\s.])?+";
        // string pattern = @"((mul\((\d+)\,(\d+)\)))";
        // look for group don't ... do()
        //input = puzzle_input;

        string pattern = @"don\'t.*?do\(\)";
        foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Singleline))
        {
            Console.WriteLine("Match: {0}", match.Value);
            /*
            for (int groupCtr = 0; groupCtr < match.Groups.Count; groupCtr++)
            {
                Group group = match.Groups[groupCtr];
                Console.WriteLine("   Group {0}: {1}", groupCtr, group.Value);
                for (int captureCtr = 0; captureCtr < group.Captures.Count; captureCtr++)
                    Console.WriteLine(
                        "      Capture {0}: {1}",
                        captureCtr,
                        group.Captures[captureCtr].Value
                    );
            }
            */
        }
        /*
                string replacement = "";
                string sPattern = @"(don\'t(.*)do\(\))";
                // Console.WriteLine("Input string: " + input);
                bool isMatch = Regex.IsMatch(
                    puzzle_input,
                    sPattern,
                    RegexOptions.Singleline,
                    TimeSpan.FromMilliseconds(500)
                );
                Console.WriteLine($"{isMatch}.");
        
                Console.WriteLine(
                    "Returned string: "
                        + Regex.Replace(input, sPattern, replacement, RegexOptions.Singleline)
                );
        */
        // input = Regex.Replace(puzzle_input, sPattern, replacement, RegexOptions.Singleline);
        // Console.WriteLine(puzzle_input);

        /*
                // Instantiate the regular expression object.
                Regex r = new Regex(sPattern, RegexOptions.Singleline);
        
                // Match the regular expression pattern against a text string.
                input = puzzle_input;
                Match m = r.Match(input);
                Console.WriteLine(m);
                input = Regex.Replace(input, sPattern, replacement, RegexOptions.Singleline);
                Console.WriteLine(input);
        
                */
    }
}