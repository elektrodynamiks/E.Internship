namespace AntennaMapClass
//Positive in quadrant IV from origin
{
    public class AntennaMap
    {
        public int[] mapSize;
        public char[][] antennaMap;
        public char[][] antinnodeMap;

        public AntennaMap(string mapFileName)
        {
            Console.WriteLine("AntennaMap Class initialized!");
            // Get the size, work with index!
            mapSize = GetmapSize(mapFileName);
            // Create the int[][] map from file
            antennaMap = CreateAntennaMap(mapFileName);
            PrintMapPlan(antennaMap);
        }

        public int[] GetmapSize(string mapFileName)
        {
            var width = Math.Abs(File.ReadLines(mapFileName).First().Length);
            var depth = File.ReadAllLines(mapFileName).Length;
            int[] mapSize = [depth, width];
            Console.WriteLine("The maze size is {0} x {1}", mapSize[0], mapSize[1]);
            return mapSize;
        }

        public char[][] CreateAntennaMap(string mapFileName)
        {
            // initialize the mapPlan
            var result = initializeMap(mapSize);
            // read the map and assign the content
            IEnumerable<string> lines = File.ReadLines(mapFileName);
            var row = 0;
            foreach (var line in lines)
            {
                // Console.WriteLine(line);
                char[] ordinates = line.ToArray();
                var col = 0;
                foreach (var ordinate in ordinates)
                {
                    result[col][row] = ordinate;
                    Console.Write("[{0},{1}] {2} ", col, row, result[col][row]);
                    col += 1;
                }
                row += 1;
                Console.WriteLine();
            }
            // PrintMapPlan(result);
            return result;
        }

        public char[][] CreateAntinodeMap()
        {
            return initializeMap(mapSize);
        }

        public char[][] initializeMap(int[] mapSize)
        {
            var ordinate = mapSize[0];
            var abscissa = mapSize[1];
            char[][] jaggedArray = new char[ordinate][];
            for (int j = 0; j < ordinate; j++)
            {
                jaggedArray[j] = new char[abscissa];
            }
            return jaggedArray;
        }

        public void PrintMapPlan(char[][] jaggedArray)
        {
            // outer for loop
            for (int j = 0; j < jaggedArray.Length; j++)
            {
                // inner for loop
                for (int i = 0; i < jaggedArray[j].Length; i++)
                {
                    Console.Write("[{0}]", jaggedArray[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
