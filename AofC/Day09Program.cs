using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using AofC.Models;

namespace AofC
{

    public class day09Program
    {
        List<int> diskMap;
        List<int> diskBlockFile;
        List<int> diskBlockFreeSpace;

        List<string> fileSystemList;
        List<string> compactedFile;
         List<int> checksumValue;

        // part 2 

        public day09Program()
        {
            string fileExample = "Day09Example.txt";

            string filePuzzle = "Day09Input.txt";

            // var fileName = fileExample;
            var fileName = filePuzzle;

            // part 1
            Day09Part1(fileName);

        }




        private void Day09Part1(string fileName)
        {
            diskMap = new List<int>();
            diskBlockFile = new List<int>();
            diskBlockFreeSpace = new List<int>();
            fileSystemList= new List<string>();
            compactedFile = new List<string>(); 
            checksumValue = new List<int>(); 

            CreateDiskMap(fileName);
            CreateFileSystem();
            FileCompacting();
            Checksum();
        }

        private void DisplayListStr(List<string> aList)
        {
            foreach (var el in aList)
            {
                Console.Write($"|{el}| ");
            }

            Console.WriteLine();

        }
        private void DisplayListInt(List<int> aList)
        {
            foreach (var el in aList)
            {
                Console.Write($"{el} ");
            }

            Console.WriteLine();

        }

        private void CreateDiskMap(string fileName)
        {
            var reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                var element = (char)reader.Read() - '0';
                diskMap.Add(element);

            }

            
            for (int index = 0; index < diskMap.Count; index++)
            {
                if (int.IsEvenInteger(index))
                {
                    diskBlockFile.Add(diskMap[index]);
                }
                else
                {
                    diskBlockFreeSpace.Add(diskMap[index]);
                }
            }

            Console.WriteLine($"diskMap : {diskMap.Count}");
            Console.WriteLine($"diskBlockFile #: {diskBlockFile.Count} ");
            Console.WriteLine($"diskBlockFreeSpace #: {diskBlockFreeSpace.Count} ");
            DisplayListInt(diskMap);
            DisplayListInt(diskBlockFile);
            DisplayListInt(diskBlockFreeSpace);
        }

        private void CreateFileSystem()
        {
           
            for (int index = 0; index < diskBlockFile.Count; index++)
            {
                var id = Convert.ToString(index);
                
                for (var fileLength = 0; fileLength < diskBlockFile[index]; fileLength++)
                {
                   
                        fileSystemList.Add(id);
                        // Console.Write(id);
                    
                   
                }
                
                if (index < diskBlockFreeSpace.Count)
                {
                    for (var blockLength = 0; blockLength < diskBlockFreeSpace[index]; blockLength++)
                    {
                        fileSystemList.Add(".");
                        // Console.Write(".");
                    }
                }

                
            }

            DisplayListStr(fileSystemList);
            Console.WriteLine();
        } 
        
        private void FileCompacting()
        {

            var leftIndex = 0;
            var rightIndex = fileSystemList.Count - 1;
            while (leftIndex <= rightIndex)
            {
                var disk = fileSystemList[leftIndex];
                if (disk != ".")
                {
                   
                    //Console.Write(disk);
                     compactedFile.Add(disk);
                    leftIndex++;
                }
                else
                {
                    var compacting = fileSystemList[rightIndex];
                    if (compacting != ".")
                    {
                        
                        //Console.Write(compacting);
                        compactedFile.Add(compacting);
                        rightIndex--;
                        leftIndex++;
                    }
                    else
                    {rightIndex--;
                    }
                }


            }
            DisplayListStr(compactedFile);
        }
        
     
      

        private void Checksum()
        {
            //checksum
            long sum = 0;

            for (int index = 0; index < compactedFile.Count; index += 1)
            {
                var fileId =   Int32.Parse(compactedFile[index]);
                var value = fileId* index;

                if (value != 0)
                { sum = sum + value;
                    checksumValue.Add(value);
                    //Console.Write($"index: {index}|{compactedFile[index]}, value: {value} ||");
                }

            }
            DisplayListInt(checksumValue);
            Console.WriteLine();
            Console.WriteLine($"The file checksum is: {sum}");

        }
        
    }
}