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

        List<char> fileSystemList;
         List<int> compactedFile;
         List<int> checksumValue;

        // part 2 

        public day09Program()
        {
            string fileExample = "Day09Example.txt";

            string filePuzzle = "Day09Input.txt";

            //var fileName = fileExample;
             var fileName = filePuzzle;

            // part 1
            Day09Part1(fileName);

        }




        private void Day09Part1(string fileName)
        {
            diskMap = new List<int>();
            diskBlockFile = new List<int>();
            diskBlockFreeSpace = new List<int>();
            fileSystemList= new List<char>();
            compactedFile = new List<int>(); 
            checksumValue = new List<int>(); 

            CreateDiskMap(fileName);
            CreateFileSystem();
            FileCompacting();
            Checksum();
        }

        private void DisplayListChar(List<char> aList)
        {
            foreach (var el in aList)
            {
                Console.Write($"{el} ");
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
                    
                    // 
                    foreach (var digit in id)
                    {
                        fileSystemList.Add(digit);
                        Console.Write(digit);
                    }
                   
                }
                
                if (index < diskBlockFreeSpace.Count)
                {
                    for (var blockLength = 0; blockLength < diskBlockFreeSpace[index]; blockLength++)
                    {
                        fileSystemList.Add('.');
                        Console.Write('.');
                    }
                }

                
            }

            //DisplayListChar(fileSystemList);
            Console.WriteLine();
        }
        private void CreateFileSystem_()
        {
           
            for (int index = 0; index < diskBlockFile.Count; index++)
            {
                var id = Convert.ToChar(index % 10 + '0');
                for (var fileLength = 0; fileLength < diskBlockFile[index]; fileLength++)
                {
                    
                    fileSystemList.Add(id);
                  
                    // Console.Write(id);
                }
                
                if (index < diskBlockFreeSpace.Count)
                {
                    for (var blockLength = 0; blockLength < diskBlockFreeSpace[index]; blockLength++)
                    {
                        fileSystemList.Add('.');
                        //Console.Write('.');
                    }
                }
            }

            DisplayListChar(fileSystemList);
        }

        private void FileCompacting()
        {
          
            var leftIndex = 0;
            var rightIndex = fileSystemList.Count - 1;
             while (leftIndex <= rightIndex)
             {
                 var disk = fileSystemList[leftIndex];
                 if (disk != '.')
                 {
                     var block = (char)disk - '0';
                     compactedFile.Add(block);
                     leftIndex++;
                 }
                 else
                 {
                     var compacting = fileSystemList[rightIndex];
                     if (compacting != '.')
                     {
                         var block = (char)compacting - '0';
                         compactedFile.Add(block);
                         rightIndex--;
                         leftIndex++;
                     }
                     else
                     {rightIndex--;
                     }
                 }

              
             }
             DisplayListInt(compactedFile);
        }

        private void Checksum()
        {
            //checksum
            long sum = 0;
            
            for (int index = 0; index < compactedFile.Count; index += 1)
            {
                var value = compactedFile[index] * index;

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