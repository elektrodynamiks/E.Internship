namespace CartesianMapClass
//Positive in quadrant IV from origin
{
    public class CartesianMap
    {
        // MapPlan Navigation is same as Array index
        private char[][] plan; //field in class

        // only be accessed within the same class
        public char[][] Plan // property
        {
            get { return plan; }
            // set { plan = value; }
        }
        private int[] mapSize;
        private int[] MapSize
        {
            get { return mapSize; }
            // set { mapSize = value; }
        }
        public int trekLength = 0;
        public char track = 'X';

        public CartesianMap(string mapFileName)
        {
            mapSize = GetMapSize(mapFileName);
            plan = CreateMapPlan(mapFileName);
            // PrintMapPlan(Plan);
        }

        public int[] GetMapSize(string mapFileName)
        {
            var width = Math.Abs(File.ReadLines(mapFileName).First().Length);
            var depth = File.ReadAllLines(mapFileName).Length;
            int[] mapSize = [depth, width];
            Console.WriteLine("The maze size is {0} x {1}", mapSize[0], mapSize[1]);
            return mapSize;
        }

        public char[][] initializePlan(int[] mapSize)
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

        public char[][] CreateRoute()
        {
            return initializePlan(MapSize);
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

        public void PrintMapPlan(char[][] jaggedArray)
        {
            // outer for loop
            for (int j = 0; j < jaggedArray.Length; j++)
            {
                // inner for loop
                for (int i = 0; i < jaggedArray[j].Length; i++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        public bool inBounds(int ordinate, int abscissa)
        {
            // inside the map
            return (0 <= abscissa && abscissa < mapSize[1])
                & (0 <= ordinate && ordinate < mapSize[0]);
        }

        public char ReadMap(int ordinate, int abscissa)
        {
            if (inBounds(ordinate, abscissa))
            {
                return plan[ordinate][abscissa];
            }
            return 'Œ';
        }

        public class Navigation
        {
            public char dir { get; set; }
            public int abscissa { get; set; }
            public int ordinate { get; set; }
            public int step { get; set; }
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
            return null;
        }

        public void TrekRouteLength(char[][] myRoute, char track = 'X')
        {
            for (int i = 0; i < myRoute.Length; i++)
            {
                // inner for loop
                for (int j = 0; j < myRoute[i].Length; j++)
                {
                    if (myRoute[i][j] == track)
                    {
                        trekLength++;
                    }
                }
            }
            Console.WriteLine("The trake measure: {0}", trekLength);
        }
    }
}
