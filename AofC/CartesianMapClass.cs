namespace CartesianMapClass
//Positive in quadrant IV from origin
{
    public class Trek
    {
        public char direction = '^';
        public int abscissa;
        public int ordinate;
        public int step = 1;
        public char obstacle = ' ';
        public bool motion = false;
    }

    public class CartesianMap
    {
        // MapPlan Navigation is same as Array index

        public int[] mapSize;
        public int trekLength = 0;
        public char track = 'X';
        public Trek startPoint;
        public Trek position;
        public char[][] navPlan;
        public char[][] myRoute;

        public CartesianMap(string mapFileName)
        {
            Console.WriteLine("Navigation Class initialized!");
            // Get the size, work with index!
            mapSize = GetmapSize(mapFileName);
            // Create the int[][] map from file
            navPlan = CreateMapPlan(mapFileName);

            // track navigation marked with 'X'
            myRoute = CreateRoute();
            // Find where the char '^' is
            startPoint = FindStartingPoint();
            // myRoute[startPoint.abscissa][startPoint.ordinate] = track;
            Patrolling(startPoint);
            PrintMapPlan(myRoute);
            TrekRouteLength(myRoute);
        }

        public int[] GetmapSize(string mapFileName)
        {
            var width = Math.Abs(File.ReadLines(mapFileName).First().Length);
            var depth = File.ReadAllLines(mapFileName).Length;
            int[] mapSize = [depth, width];
            Console.WriteLine("The maze size is {0} x {1}", mapSize[0], mapSize[1]);
            return mapSize;
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
            return initializePlan(mapSize);
        }

        public void PrintMapPlan(char[][] jaggedArray)
        {
            // outer for loop
            for (int j = 0; j < jaggedArray.Length; j++)
            {
                // inner for loop
                for (int i = 0; i < jaggedArray[j].Length; i++)
                {
                    if (jaggedArray[i][j] == 'X')
                    {
                        Console.Write("[{0}]", jaggedArray[i][j]);
                    }
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }

        public bool inBounds(int abscissa, int ordinate)
        {
            // inside the map
            return (0 <= abscissa && abscissa < mapSize[1])
                & (0 <= ordinate && ordinate < mapSize[0]);
        }

        public char ReadMap(int ordinate, int abscissa)
        {
            if (inBounds(ordinate, abscissa))
            {
                return navPlan[ordinate][abscissa];
            }
            return 'Œ';
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

        public Trek FindStartingPoint(char startChar = '^')
        {
            // outer for loop
            Trek startPoint = new Trek();
            startPoint.direction = startChar;
            // int[] startPoint = [0, 0];
            for (int i = 0; i < navPlan.Length; i++)
            {
                // inner for loop
                for (int j = 0; j < navPlan[i].Length; j++)
                {
                    if (navPlan[i][j] == startChar)
                    {
                        startPoint.abscissa = i;
                        startPoint.ordinate = j;
                        Console.WriteLine(
                            "Starting Point dir:{0}, Postion X,Y: {1},{2}",
                            startPoint.direction,
                            startPoint.abscissa,
                            startPoint.ordinate
                        );
                        return startPoint;
                    }
                }
            }

            return startPoint;
        }

        public void Patrolling(Trek position)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("inbound: {0}", inBounds(position.abscissa, position.ordinate));
                myRoute[position.abscissa][position.ordinate] = 'X';
                Console.WriteLine("idx:{0} x: {1}", i, position.abscissa);

                checkNextLocation(navPlan, position);
            }
            // find next location
            // check for obstacle
            // return the next location.
            // iterate until leaving the plan
        }

        public void checkNextLocation(char[][] navPlan, Trek position)
        {
            var direction = position.direction;
            char obstacle;
            Console.WriteLine("direction:{0}", direction);
            if (direction == '^')
            {
                obstacle = navPlan[position.abscissa][position.ordinate - 1];
                Console.WriteLine(
                    "next position [{0},{1}]:{2}",
                    position.abscissa,
                    position.ordinate - 1,
                    obstacle
                );
                position.ordinate--;
            }
        }
    }
}


/* terms
location
track
waypoint
goal
obstacle
initialize
*/
